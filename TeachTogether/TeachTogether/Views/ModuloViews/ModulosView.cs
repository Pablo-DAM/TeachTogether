using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeachTogether.Controllers;
using TeachTogether.Models;
using TeachTogether.Security;
using TeachTogether.Views;

namespace TeachTogether
{
    public partial class ModulosView : Form
    {
        private ModulosController modulosController=new ModulosController();
        private List<ModulosModel> listaModulos=new List<ModulosModel>();
        private UsuarioModuloController usuarioModuloController =new UsuarioModuloController();
        private PerfilesController perfilesController =new PerfilesController();
        private string nombreModulo = "";
        private Timer timer;
        public ModulosView()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(updateStatusStrip);
            timer.Start();
            GetModulos();
            getAllUsuariosModulos();
            btnAñadirAlumno.Enabled= false;
            btnEliminarUsuarioDelModulo.Enabled= false;
            this.MaximizeBox = false;
        }
        private void updateStatusStrip(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = $"  Hora: {DateTime.Now.ToString("HH:mm:ss")}";
            toolStripStatusLabel2.Text = $"  Fecha: {DateTime.Now.ToString("dd/MM/yyyy")}";
            toolStripStatusLabel3.Text = $"  Módulos registrados: {dataGridModulos.Rows.Count}";
            toolStripStatusLabel4.Text = $"  Alumnos registrados en el módulo seleccionado: {dataGridUsuariosModulo.Rows.Count}";
        }

        private async void btnSeleccionarModulo_Click(object sender, EventArgs e)
        {
            if (dataGridModulos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridModulos.SelectedRows[0];
                if (row.Cells[0].Value != null)
                {
                    ModulosModel modulosModel=new ModulosModel();
                    modulosModel.nombre = row.Cells[0].Value.ToString();
                    modulosModel.dias = row.Cells[1].Value.ToString();
                    modulosModel.horario = row.Cells[2].Value.ToString();
                    if (row.Cells[3].Value != null)
                    {
                        modulosModel.horas = (int)row.Cells[3].Value;
                    }
                    modulosModel.codigo = row.Cells[4].Value.ToString();
                    int idModulo =(int) row.Cells[5].Value;

                    ModificarModuloView modificarModuloView = new ModificarModuloView(modulosModel,idModulo);

                    modificarModuloView.ShowDialog();
                    dataGridModulos.Rows.Clear();
                    await GetModulos();
                }
            }
            else
            {
                MessageBox.Show("Selecciona un módulo antes.","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        private async Task GetModulos()
        {

            List<ModulosModel> listaModulos = await modulosController.getModulos();
            if (listaModulos != null)
            {
                foreach (var modulo in listaModulos)
                {
                    if (modulo.idProfesor.idUsuario == AuthenticationManager.GetUserId())
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dataGridModulos);
                        row.Cells[0].Value = modulo.nombre;
                        row.Cells[1].Value = modulo.dias;
                        row.Cells[2].Value = modulo.horario;
                        row.Cells[3].Value = modulo.horas;
                        row.Cells[4].Value = modulo.codigo;
                        row.Cells[5].Value = modulo.idModulo;
                        dataGridModulos.Rows.Add(row);
                    }
                }
            }

        }

        private async void btnAgregarModulo_Click(object sender, EventArgs e)
        {
            RegistrarModuloView registrarModuloView = new RegistrarModuloView();
         

            registrarModuloView.ShowDialog();
            dataGridModulos.Rows.Clear();
            await GetModulos();
           
        }
    

        private async void btnEliminarMod_Click(object sender, EventArgs e)
        {
            if(dataGridModulos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridModulos.SelectedRows[0];
                if (row.Cells[0].Value!=null)
                {
                    DialogResult result = MessageBox.Show(
                        "¿Estás seguro de que quieres borrar el módulo? (Se borrarán todos sus participantes)",
                        "Aviso",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning);

                    
                    if (result == DialogResult.OK)
                    {
                       
                        await this.modulosController.eliminarModulo(Convert.ToInt32(row.Cells[5].Value));
                        dataGridModulos.Rows.Clear();
                        await GetModulos();
                        dataGridUsuariosModulo.Rows.Clear();
                        getAllUsuariosModulos();
                    }                
                }
            }
            else
            {
                MessageBox.Show("Selecciona un módulo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }
        public async void getAllUsuariosModulos()
        {
            List<UsuarioModuloModel> listaUsuariosModulos = await this.usuarioModuloController.getAllUsuariosModulo();

            foreach (UsuarioModuloModel usuMod in listaUsuariosModulos)
            {
                if (usuMod.id_modulo.idProfesor.idUsuario == AuthenticationManager.GetUserId())
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dataGridUsuariosModulo);
                    row.Cells[0].Value = usuMod.id_alumno.usuario;

                    PerfilModel perfil = await perfilesController.getPerfilById(usuMod.id_alumno.idUsuario);

                    row.Cells[1].Value = perfil.nombre;
                    row.Cells[2].Value = perfil.apellidos;
                    row.Cells[3].Value = perfil.fechaNacimiento;
                    row.Cells[4].Value = usuMod.id_alumno.idUsuario;
                    row.Cells[5].Value = usuMod.id_modulo.idModulo;
                    row.Cells[6].Value = usuMod.id_modulo.nombre;
                    dataGridUsuariosModulo.Rows.Add(row);
                }
            }

        }


        private async void btnAñadirAlumno_Click(object sender, EventArgs e)
        {
            DataGridViewRow filaSeleccionada = dataGridModulos.SelectedRows[0];
            int idModulo = (int)filaSeleccionada.Cells[5].Value;           
            AñadirAlumnoAModuloView añadirAlumnoAModuloView = new AñadirAlumnoAModuloView(idModulo,this.nombreModulo);
            añadirAlumnoAModuloView.ShowDialog();
            dataGridUsuariosModulo.Rows.Clear();
            if (dataGridModulos.SelectedRows.Count > 0)
            {
                DataGridViewRow dRow = dataGridModulos.SelectedRows[0];
                if (dRow.Cells[0].Value != null)
                {
                    lblModuloSeleccionado.Text = "Módulo seleccionado: " + dRow.Cells[0].Value;
                    
                    List<UsuarioModuloModel> listaUsuariosModulos = await this.usuarioModuloController.getAllUsuariosModulo();
                    foreach (UsuarioModuloModel usuMod in listaUsuariosModulos)
                    {
                        if (usuMod.id_modulo.idProfesor.idUsuario == AuthenticationManager.GetUserId())
                        {
                            if ((int)dRow.Cells[5].Value == usuMod.id_modulo.idModulo)
                            {
                                DataGridViewRow row = new DataGridViewRow();
                                row.CreateCells(dataGridUsuariosModulo);
                                row.Cells[0].Value = usuMod.id_alumno.usuario;

                                PerfilModel perfil = await perfilesController.getPerfilById(usuMod.id_alumno.idUsuario);

                                row.Cells[1].Value = perfil.nombre;
                                row.Cells[2].Value = perfil.apellidos;
                                row.Cells[3].Value = perfil.fechaNacimiento;
                                row.Cells[4].Value = usuMod.id_alumno.idUsuario;
                                row.Cells[5].Value = usuMod.id_modulo.idModulo;
                                row.Cells[6].Value = usuMod.id_modulo.nombre;
                                dataGridUsuariosModulo.Rows.Add(row);

                            }
                        }
                    }
                }
            }


        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            dataGridUsuariosModulo.Rows.Clear();
            getAllUsuariosModulos();
            lblModuloSeleccionado.Text = "Módulo seleccionado: Ninguno";
            this.nombreModulo = "";
            btnAñadirAlumno.Enabled = false;
            btnEliminarUsuarioDelModulo.Enabled = false;
        }

       

        private async void dataGridModulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           dataGridUsuariosModulo.Rows.Clear();
           btnAñadirAlumno.Enabled = true;
           btnEliminarUsuarioDelModulo.Enabled = true;
           if(dataGridModulos.SelectedRows.Count>0)
            {
                DataGridViewRow dRow = dataGridModulos.SelectedRows[0];
                if (dRow.Cells[0].Value!=null)
                {
                    lblModuloSeleccionado.Text = "Módulo seleccionado: " + dRow.Cells[0].Value;
                    this.nombreModulo = dRow.Cells[0].Value.ToString();
                    List<UsuarioModuloModel> listaUsuariosModulos = await this.usuarioModuloController.getAllUsuariosModulo();
                    foreach (UsuarioModuloModel usuMod in listaUsuariosModulos)
                    {
                        if (usuMod.id_modulo.idProfesor.idUsuario == AuthenticationManager.GetUserId())
                        {
                            if ((int)dRow.Cells[5].Value == usuMod.id_modulo.idModulo)
                            {
                                DataGridViewRow row = new DataGridViewRow();
                                row.CreateCells(dataGridUsuariosModulo);
                                row.Cells[0].Value = usuMod.id_alumno.usuario;

                                PerfilModel perfil = await perfilesController.getPerfilById(usuMod.id_alumno.idUsuario);

                                row.Cells[1].Value = perfil.nombre;
                                row.Cells[2].Value = perfil.apellidos;
                                row.Cells[3].Value = perfil.fechaNacimiento;
                                row.Cells[4].Value = usuMod.id_alumno.idUsuario;
                                row.Cells[5].Value = dRow.Cells[5].Value;
                                row.Cells[6].Value = dRow.Cells[0].Value;
                                dataGridUsuariosModulo.Rows.Add(row);
                              
                            }                          
                        }
                    }
                }
            }
        }

        private async void btnEliminarUsuarioDelModulo_Click(object sender, EventArgs e)
        {
            if (dataGridUsuariosModulo.SelectedRows.Count > 0)
            {
                DataGridViewRow drow= dataGridUsuariosModulo.SelectedRows[0];
                if (drow.Cells[0].Value.ToString() != null)
                {
                    int idAlumno = (int)drow.Cells[4].Value;
                    int idModulo = (int)drow.Cells[5].Value;
                    await this.usuarioModuloController.deleteAlumno(idAlumno,idModulo);
                    dataGridUsuariosModulo.Rows.RemoveAt(drow.Index);
                }                              
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtFiltroModulos_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltroModulos.Text.ToLower();
            foreach (DataGridViewRow row in dataGridModulos.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    row.Visible = row.Cells[0].Value.ToString().ToLower().Contains(filtro) ||
                                  row.Cells[1].Value.ToString().ToLower().Contains(filtro) ||
                                  row.Cells[2].Value.ToString().ToLower().Contains(filtro) ||
                                  row.Cells[4].Value.ToString().ToLower().Contains(filtro);
                }
            }
        }

        private void txtFiltroUsuarios_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltroUsuarios.Text.ToLower();
            foreach (DataGridViewRow row in dataGridUsuariosModulo.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    row.Visible = row.Cells[0].Value.ToString().ToLower().Contains(filtro) ||
                                  row.Cells[1].Value.ToString().ToLower().Contains(filtro) ||
                                  row.Cells[2].Value.ToString().ToLower().Contains(filtro);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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
            MessageBox.Show("Funcionalidad en desarrollo","Aviso",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}