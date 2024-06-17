using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeachTogether.Controllers;
using TeachTogether.Models;
using System.IO;
namespace TeachTogether.Views
{
    public partial class MensajesView : Form
    {
        private MensajesController mensajesController = new MensajesController();
        private List<MensajeModel> listaMensajes = new List<MensajeModel>();
        private PerfilesController perfilController = new PerfilesController();
        private UsuarioController usarioController = new UsuarioController();
        private string origen = "enviando";
        private Timer timer;
        public MensajesView()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(updateStatusStrip);
            timer.Start();
            getMensajesRecibidos();
            getMensajesEnviados();
            this.MaximizeBox = false;
           
        }
     
        private void updateStatusStrip(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = $"  Hora: {DateTime.Now.ToString("HH:mm:ss")}";
            toolStripStatusLabel2.Text = $"  Fecha: {DateTime.Now.ToString("dd/MM/yyyy")}";
            toolStripStatusLabel3.Text = $"  Mensajes recibidos: {dataGridViewMensajesRecibidos.Rows.Count}";
            toolStripStatusLabel4.Text = $"  Mensajes enviados: {dataGridViewMensajesEnviados.Rows.Count}";
        }
        private async void getMensajesRecibidos()
        {

            this.listaMensajes = await mensajesController.getMensajesRecibidos(); 
            var mensajesOrdenados = listaMensajes.OrderByDescending(m => m.fechaCreaccion).ToList();

            foreach (MensajeModel mensaje in mensajesOrdenados)
            {
                PerfilModel perfil = await perfilController.getPerfilById(mensaje.idCreador.idUsuario);
                string nombreCreador = perfil.nombre;
                string apellidosCreador = perfil.apellidos;

                UsuarioModel usuarioEmisor = await this.usarioController.getUsuarioById(mensaje.idCreador.idUsuario);
                string usuario = usuarioEmisor.usuario;

                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridViewMensajesRecibidos);
                row.Cells[0].Value = usuario;
                row.Cells[1].Value = nombreCreador;
                row.Cells[2].Value = apellidosCreador;
                row.Cells[3].Value = mensaje.texto;
                row.Cells[4].Value = mensaje.fechaCreaccion;
                row.Cells[5].Value = mensaje.idMensaje;
                row.Tag = mensaje.idCreador.idUsuario;
                dataGridViewMensajesRecibidos.Rows.Add(row);
            }
        }



        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dataGridViewMensajesRecibidos.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewMensajesRecibidos.SelectedRows[0];
                if (selectedRow.Cells[0].Value != null)
                {
                    try
                    {
                        string usuario = (string)selectedRow.Cells[0].Value;
                        string nombre = (string)selectedRow.Cells[1].Value;
                        string apellidos = (string)selectedRow.Cells[2].Value;
                        string mensaje = (string)selectedRow.Cells[3].Value;
                        DateTime fecha = (DateTime)selectedRow.Cells[4].Value;
                        int idMensaje = (int)selectedRow.Cells[5].Value;
                        int idCreador = (int)selectedRow.Tag;
                        this.origen = "recibiendo";
                        DetalleMensajeView detalleMensajeView = new DetalleMensajeView(usuario, nombre, apellidos, mensaje, fecha, idCreador, idMensaje,origen);
                        
                        detalleMensajeView.MensajeEliminado += (idMsgEliminado) =>
                        {
                            
                            foreach (DataGridViewRow r in dataGridViewMensajesRecibidos.Rows)
                            {
                                if (Convert.ToInt32(r.Cells["idMensaje"].Value) == idMsgEliminado)
                                {
                                    dataGridViewMensajesRecibidos.Rows.Remove(r);
                                    break;
                                }
                            }
                        };
                        detalleMensajeView.ShowDialog();
                        dataGridViewMensajesEnviados.Rows.Clear();
                        getMensajesEnviados();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al procesar los datos de la fila seleccionada: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una fila que contenga datos.");
                }
            }
            else
            {
                MessageBox.Show("No hay ninguna fila seleccionada.");
            }
        }

        private void dataGridViewMensajesRecibidos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewMensajesRecibidos.Rows[e.RowIndex];


                if (row.Cells[0].Value != null)
                {
                    string usuario = (string)row.Cells[0].Value;
                    string nombre = (string)row.Cells[1].Value;
                    string apellidos = (string)row.Cells[2].Value;
                    string mensaje = (string)row.Cells[3].Value;
                    DateTime fecha = (DateTime)row.Cells[4].Value;
                    int idMensaje = (int)row.Cells[5].Value;
                    int idCreador = (int)row.Tag;
                    this.origen = "recibiendo";
                    DetalleMensajeView detalleMensajeView = new DetalleMensajeView(usuario, nombre, apellidos, mensaje, fecha, idCreador, idMensaje,origen);
                    
                    detalleMensajeView.MensajeEliminado += (idMsgEliminado) =>
                    {
                       
                        foreach (DataGridViewRow r in dataGridViewMensajesRecibidos.Rows)
                        {
                            if (Convert.ToInt32(r.Cells["idMensaje"].Value) == idMsgEliminado)
                            {
                                dataGridViewMensajesRecibidos.Rows.Remove(r);
                                break;
                            }
                        }
                    };
                    detalleMensajeView.ShowDialog();

                }
            }

        }

        private async void btnBorrarMensaje_Click(object sender, EventArgs e)
        {
            if (dataGridViewMensajesRecibidos.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewMensajesRecibidos.SelectedRows[0];
                if (selectedRow.Cells[0].Value != null)
                {
                    int idMensajeEliminar = (int)selectedRow.Cells[5].Value;
                    await mensajesController.eliminarMensaje(idMensajeEliminar);
                    foreach (DataGridViewRow row  in dataGridViewMensajesRecibidos.Rows)
                    {
                        if ((int)row.Cells[5].Value == idMensajeEliminar)
                        {
                            dataGridViewMensajesRecibidos.Rows.Remove(row);
                            break;
                        }
                    }
                }
            }
        }

        private async void getMensajesEnviados()
        {
            this.listaMensajes = await mensajesController.getMensajesEnviados();

            // Ordenar los mensajes por fecha de creación descendente
            var mensajesOrdenados = listaMensajes.OrderByDescending(m => m.fechaCreaccion).ToList();

            foreach (MensajeModel mensaje in mensajesOrdenados)
            {
                string texto = mensaje.texto;
                int idReceptor = mensaje.idReceptor.idUsuario;
                int idMensaje = mensaje.idMensaje;
                DateTime fecha = mensaje.fechaCreaccion;
                UsuarioModel usuarioModel = await usarioController.getUsuarioById(mensaje.idReceptor.idUsuario);
                string usuarioReceptor = usuarioModel.usuario;
                PerfilModel perfilModel = await perfilController.getPerfilById(usuarioModel.idUsuario);
                string nombreReceptor = perfilModel.nombre;
                string apellidosReceptor = perfilModel.apellidos;
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridViewMensajesEnviados);
                row.Cells[0].Value = usuarioReceptor;
                row.Cells[1].Value = nombreReceptor;
                row.Cells[2].Value = apellidosReceptor;
                row.Cells[3].Value = texto;
                row.Cells[4].Value = fecha;
                row.Cells[5].Value = idReceptor;
                row.Cells[6].Value = idMensaje;
                dataGridViewMensajesEnviados.Rows.Add(row);
            }
        }
        private void btnSeleccionarMensajeEnviado_Click(object sender, EventArgs e)
        {
            if(dataGridViewMensajesEnviados.SelectedRows.Count>0) 
            {
                var selectedRow = dataGridViewMensajesEnviados.SelectedRows[0];

                if (selectedRow.Cells[0]!=null)
                {
                    try
                    {
                        string usuario = (string)selectedRow.Cells[0].Value;
                        string nombre = (string)selectedRow.Cells[1].Value;
                        string apellidos = (string)selectedRow.Cells[2].Value;
                        string mensaje = (string)selectedRow.Cells[3].Value;
                        DateTime fecha = (DateTime)selectedRow.Cells[4].Value;
                        int idReceptor = (int)selectedRow.Cells[5].Value;
                        int idMensaje = (int)selectedRow.Cells[6].Value;
                        this.origen = "enviando";
                        DetalleMensajeView detalleMensajeView = new DetalleMensajeView(usuario, nombre, apellidos, mensaje, fecha, idReceptor, idMensaje, origen);
                       
                        
                        detalleMensajeView.MensajeEliminado += (idMsgEliminado) =>
                        {
                            
                            foreach (DataGridViewRow r in dataGridViewMensajesEnviados.Rows)
                            {
                                if (Convert.ToInt32(r.Cells["MensajeId"].Value) == idMsgEliminado)
                                {
                                    dataGridViewMensajesEnviados.Rows.Remove(r);
                                    break;
                                }
                            }
                        };
                        detalleMensajeView.ShowDialog();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al procesar los datos de la fila seleccionada: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una fila que contenga datos.");
                }
            }
            else
            {
                MessageBox.Show("No hay ninguna fila seleccionada.");
            }
        
            }

        private async void btnBorraMensajeEnviado_Click(object sender, EventArgs e)
        {
            if (dataGridViewMensajesEnviados.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewMensajesEnviados.SelectedRows[0];
                if (selectedRow.Cells[0].Value != null)
                {
                    int idMensajeEliminar = (int)selectedRow.Cells[6].Value;
                    await mensajesController.eliminarMensaje(idMensajeEliminar);
                    foreach (DataGridViewRow row in dataGridViewMensajesEnviados.Rows)
                    {
                        if ((int)row.Cells[6].Value == idMensajeEliminar)
                        {
                            dataGridViewMensajesEnviados.Rows.Remove(row);
                            break;
                        }
                    }
                }
            }
        }

        private void btnCrearMensaje_Click(object sender, EventArgs e)
        {
            EscribirMensajeView escribirMensajeView=new EscribirMensajeView();
            escribirMensajeView.ShowDialog();
            dataGridViewMensajesEnviados.Rows.Clear();
            getMensajesEnviados();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFiltroRecibidos_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltroRecibidos.Text.ToLower();
            foreach (DataGridViewRow row in dataGridViewMensajesRecibidos.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[1].Value != null && row.Cells[2].Value != null && row.Cells[3].Value != null)
                {
                    row.Visible = row.Cells[0].Value.ToString().ToLower().Contains(filtro) ||
                                  row.Cells[1].Value.ToString().ToLower().Contains(filtro) ||
                                  row.Cells[2].Value.ToString().ToLower().Contains(filtro) ||
                                  row.Cells[3].Value.ToString().ToLower().Contains(filtro);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltroEnviados.Text.ToLower();
            foreach (DataGridViewRow row in dataGridViewMensajesEnviados.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[1].Value != null && row.Cells[2].Value != null && row.Cells[3].Value != null)
                {
                    row.Visible = row.Cells[0].Value.ToString().ToLower().Contains(filtro) ||
                                  row.Cells[1].Value.ToString().ToLower().Contains(filtro) ||
                                  row.Cells[2].Value.ToString().ToLower().Contains(filtro) ||
                                  row.Cells[3].Value.ToString().ToLower().Contains(filtro);
                }
            }
        }

        private void dataGridViewMensajesEnviados_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewMensajesEnviados.Rows[e.RowIndex];

                if (row.Cells[0].Value != null)
                {
                    string usuario = (string)row.Cells[0].Value;
                    string nombre = (string)row.Cells[1].Value;
                    string apellidos = (string)row.Cells[2].Value;
                    string mensaje = (string)row.Cells[3].Value;
                    DateTime fecha = (DateTime)row.Cells[4].Value;
                    int idReceptor = (int)row.Cells[5].Value;
                    int idMensaje = (int)row.Cells[6].Value;
                    this.origen = "enviando";

                    DetalleMensajeView detalleMensajeView = new DetalleMensajeView(usuario, nombre, apellidos, mensaje, fecha, idReceptor, idMensaje, origen);

                   
                    detalleMensajeView.MensajeEliminado += (idMsgEliminado) =>
                    {
                       
                        foreach (DataGridViewRow r in dataGridViewMensajesEnviados.Rows)
                        {
                            if (Convert.ToInt32(r.Cells["idMensaje"].Value) == idMsgEliminado)
                            {
                                dataGridViewMensajesEnviados.Rows.Remove(r);
                                break;
                            }
                        }
                    };

                    detalleMensajeView.ShowDialog();
                }
            }
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            string pdfPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Manual de Usuario App Escritorio.pdf");


            if (File.Exists(pdfPath))
            {
                try
                {
                    Process.Start(new ProcessStartInfo(pdfPath) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo abrir el archivo de ayuda PDF", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("El archivo de ayuda no se encuentra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEnviarCodigo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad en desarrollo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

