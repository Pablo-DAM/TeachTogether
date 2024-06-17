using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeachTogether.Controllers;
using TeachTogether.Models;
using TeachTogether.Models.AutoevaluacionModels;
using TeachTogether.Models.ModuloModels;
using TeachTogether.Models.UsuarioModels;
using TeachTogether.Security;
using TeachTogether.Views.AutoevaluacionViews;
using System.IO;
namespace TeachTogether.Views
{
    public partial class AutoevaluacionesView : Form
    {
        private AutoevaluacionesController autoevaluacionesController = new AutoevaluacionesController();
        private AutoevaluacionPreguntasController AutoevaluacionPreguntasController = new AutoevaluacionPreguntasController();
        private AutoevaluacionUsuariosController AutoevaluacionUsuariosController = new AutoevaluacionUsuariosController();
        private ModulosController modulosController = new ModulosController();
        private UsuarioModuloController usuarioModuloController = new UsuarioModuloController();
        private Timer timer;
        public AutoevaluacionesView()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(updateStatusStrip);
            timer.Start();
            getAutoevaluaciones();
            btnAñadirPregunta.Enabled = false;
            btnEliminarPregunta.Enabled = false;
            btnEditarPregunta.Enabled = false;
            this.MaximizeBox = false;
        }
        private void updateStatusStrip(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = $"  Hora: {DateTime.Now.ToString("HH:mm:ss")}";
            toolStripStatusLabel2.Text = $"  Fecha: {DateTime.Now.ToString("dd/MM/yyyy")}";
            toolStripStatusLabel3.Text = $"  Autoevaluaciones registradas: {dataGridAutoevaluaciones.Rows.Count}";
            toolStripStatusLabel4.Text = $"  Número de Preguntas de la Autoevaluación seleccionada: {dataGridPreguntas.Rows.Count}";
        }

        private async Task getAutoevaluaciones()
        {
            int idProf = AuthenticationManager.GetUserId();
            List<AutoevaluacionesModel> listaAuto = await this.autoevaluacionesController.getAutoevaluacionesByIdProf(idProf);


            int contadorFilas = 1;
            foreach (AutoevaluacionesModel auto in listaAuto)
            {
                List<ModulosModel> listaModulos = await this.modulosController.getModulosByAutoevaluacionID(auto.idAutoevaluacion);
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridAutoevaluaciones);
                row.Cells[0].Value = contadorFilas;
                row.Cells[1].Value = auto.titulo;
                row.Cells[2].Value = auto.idAutoevaluacion;
                row.Cells[3].Value = auto.id_modulo.idModulo;
                row.Cells[4].Value = auto.id_modulo.nombre;
                dataGridAutoevaluaciones.Rows.Add(row);
                contadorFilas++;
            }

        }

        private async void btnCrearAuto_Click(object sender, EventArgs e)
        {
            CrearAutoevaluacionView crearAutoevaluacionView = new CrearAutoevaluacionView();
            crearAutoevaluacionView.ShowDialog();
            dataGridAutoevaluaciones.Rows.Clear();
            await getAutoevaluaciones();
        }

        private async void btnEditarAuto_Click(object sender, EventArgs e)
        {
            if (dataGridAutoevaluaciones.SelectedRows.Count > 0)
            {
                DataGridViewRow drow = dataGridAutoevaluaciones.SelectedRows[0];
                if (drow.Cells[0].Value != null)
                {
                    int idAutoevaluacion = (int)drow.Cells[2].Value;
                    String titulo = drow.Cells[1].Value.ToString();
                    ModificarAutoevaluacionView mod = new ModificarAutoevaluacionView(idAutoevaluacion,titulo);
                    mod.ShowDialog();
                    dataGridAutoevaluaciones.Rows.Clear();
                    await getAutoevaluaciones();
                }
            }
            else
            {
                MessageBox.Show("Selecciona una fila para modificar el título.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnEliminarAuto_Click(object sender, EventArgs e)
        {
            if (dataGridAutoevaluaciones.SelectedRows.Count > 0)
                if (dataGridAutoevaluaciones.SelectedRows.Count > 0)
                {
                    DataGridViewRow drow = dataGridAutoevaluaciones.SelectedRows[0];
                    if (drow.Cells[0].Value != null)
                    {
                        DialogResult result = MessageBox.Show(
                            "¿Estás seguro de que quieres eliminar esa Autoevaluación? Se eliminarán todas sus preguntas y respuestas.",
                            "Confirmar Eliminación",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            int idAutoevaluacion = (int)drow.Cells[2].Value;
                            await this.autoevaluacionesController.deleteAutoevaluacion(idAutoevaluacion);

                            dataGridAutoevaluaciones.Rows.Clear();
                            await getAutoevaluaciones();
                            labelPregunta.Text = "Preguntas de la Autoevaluación:\nNinguna";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Selecciona una autoevaluación para eliminarla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
        }

        private void dataGridAutoevaluaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            labelPregunta.Text = "Preguntas de la Autoevaluación:\n " + dataGridAutoevaluaciones.SelectedRows[0].Cells[1].Value;
            pasarDatos();
        }



        private void btnAñadirPregunta_Click(object sender, EventArgs e)
        {

            int idAutoev = (int)dataGridAutoevaluaciones.SelectedRows[0].Cells[2].Value;
            AgregarPreguntaView agregarPreguntaView = new AgregarPreguntaView(idAutoev);
            agregarPreguntaView.ShowDialog();
            dataGridPreguntas.Rows.Clear();
            pasarDatos();
        }
        private async void pasarDatos()
        {
            if (dataGridAutoevaluaciones.SelectedRows.Count > 0)
            {
                DataGridViewRow dRow = dataGridAutoevaluaciones.SelectedRows[0];
                if (dRow.Cells[0].Value != null)
                {
                    btnAñadirPregunta.Enabled = true;
                    List<AutoevaluacionPreguntasModel> listaPreguntas = await this.AutoevaluacionPreguntasController.getAutoevaluaciones();
                    int contadorFilas = 1;
                    dataGridPreguntas.Rows.Clear();
                    foreach (AutoevaluacionPreguntasModel pregunta in listaPreguntas)
                    {
                        if (pregunta.idAutoevaluacion.idAutoevaluacion == (int)dRow.Cells[2].Value)
                        {
                            DataGridViewRow r = new DataGridViewRow();
                            r.CreateCells(dataGridPreguntas);
                            r.Cells[0].Value = contadorFilas;
                            r.Cells[1].Value = pregunta.enunciadoPregunta;
                            r.Cells[2].Value = pregunta.idPregunta;
                            r.Cells[3].Value = pregunta.idAutoevaluacion;
                            contadorFilas++;
                            dataGridPreguntas.Rows.Add(r);
                        }
                    }
                }
            }
        }

        private async void btnEliminarPregunta_Click(object sender, EventArgs e)
        {
            if (dataGridPreguntas.SelectedRows.Count > 0)
            {
                DataGridViewRow drow = dataGridPreguntas.SelectedRows[0];
                if (drow.Cells[0].Value != null)
                {
                    int idPregunta = (int)drow.Cells[2].Value;
                    await this.AutoevaluacionPreguntasController.deletePregunta(idPregunta);
                    pasarDatos();
                }
            }
        }

        private void dataGridPreguntas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEliminarPregunta.Enabled = true;
            btnEditarPregunta.Enabled = true;
        }

        private void btnEditarPregunta_Click(object sender, EventArgs e)
        {
            if (dataGridPreguntas.SelectedRows.Count > 0)
            {
                DataGridViewRow drow = dataGridPreguntas.SelectedRows[0];
                if (drow.Cells[0].Value != null)
                {
                    int idPregunta = (int)drow.Cells[2].Value;
                    string enunciado = drow.Cells[1].Value.ToString();
                    if (dataGridAutoevaluaciones.SelectedRows.Count > 0)
                    {
                        DataGridViewRow drow2 = dataGridAutoevaluaciones.SelectedRows[0];
                        if (drow.Cells[0].Value != null)
                        {
                            int idAutoeva = (int)drow2.Cells[2].Value;

                            EditarPreguntaView editarPreguntaView = new EditarPreguntaView(idPregunta, idAutoeva, enunciado);
                            editarPreguntaView.ShowDialog();
                            pasarDatos();
                        }
                    }

                }
            }

        }

        private void btnVerRespuestas_Click(object sender, EventArgs e)
        {
            int idAutoev = (int)dataGridAutoevaluaciones.SelectedRows[0].Cells[2].Value;
            DetalleAutoevaluacionView detalleAutoevaluacionView = new DetalleAutoevaluacionView();
            detalleAutoevaluacionView.ShowDialog();

        }

        private void btnEnviarUno_Click(object sender, EventArgs e)
        {
            if (dataGridAutoevaluaciones.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridAutoevaluaciones.SelectedRows[0];
                if (row.Cells[0].Value != null)
                {
                    var cellValue = row.Cells[3].Value;
                    String titulo = row.Cells[1].Value.ToString();
                    int idAu = (int)row.Cells[2].Value;
                    if (cellValue != null && int.TryParse(cellValue.ToString(), out int idModulo))
                    {
                        EnviarAView enviarAView = new EnviarAView(idModulo,titulo,idAu);
                        enviarAView.ShowDialog();
                    }
                }

            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna fila.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void enviarTodos_Click(object sender, EventArgs e)
        {
            if (dataGridAutoevaluaciones.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridAutoevaluaciones.SelectedRows[0];
                if (row.Cells[0].Value != null)
                {
                    int idAu = (int)row.Cells[2].Value;
                    int idModulo = (int)row.Cells[3].Value;

                    List<IdUsuarioSinModuloModel> listaUsuariosSinAu = await this.autoevaluacionesController.getUsuariosSinAuto(idAu);
                    List<UsuarioModuloModel> listaUsuariosModulos = await this.usuarioModuloController.getAllUsuariosModulo();

                    HashSet<int> filtroUsuarioModulo = new HashSet<int>();
                    foreach (UsuarioModuloModel item in listaUsuariosModulos)
                    {
                        if (item.idModulo == idModulo)
                        {
                            filtroUsuarioModulo.Add(item.id_alumno.idUsuario);
                        }
                    }

                    HashSet<int> usuariosConAutoevaluacion = new HashSet<int>();
                    HashSet<AutoevaluacionUsuariosModel> listaUsuariosAutoevaluacion = await this.AutoevaluacionUsuariosController.getAllAutoevalucionUsuarios();
                    foreach (var item in listaUsuariosAutoevaluacion)
                    {
                        if (item.idAutoevaluacion == idAu)
                        {
                            usuariosConAutoevaluacion.Add(item.idAlumno);
                        }
                    }

                    bool encontrado = false;
                    foreach (int idUsuario in filtroUsuarioModulo)
                    {
                        if (!usuariosConAutoevaluacion.Contains(idUsuario))
                        {
                            AutoevaluacionUsuarioPOST autoevaluacionUsuarioPOST = new AutoevaluacionUsuarioPOST();
                            autoevaluacionUsuarioPOST.id_alumno = idUsuario;
                            autoevaluacionUsuarioPOST.id_autoevaluacion = idAu;
                            string json = JsonConvert.SerializeObject(autoevaluacionUsuarioPOST);
                            HttpContent contentRegistro = new StringContent(json, Encoding.UTF8, "application/json");

                            ResultadoOperacion resultado = await this.AutoevaluacionUsuariosController.postAutoevaluacionUsuario(contentRegistro);

                            if (resultado.Exitoso)
                            {
                                encontrado = true;
                            }
                            else
                            {
                                MessageBox.Show(resultado.MensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                    if (encontrado)
                    {
                        MessageBox.Show("Se ha enviado la autoevaluación a todos los alumnos del módulo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ya se envió esa evaluación a los alumnos previamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona una autoevaluación para enviar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filtro = textBox1.Text.ToLower();
            foreach (DataGridViewRow row in dataGridAutoevaluaciones.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[4].Value != null)
                {
                    row.Visible = row.Cells[1].Value.ToString().ToLower().Contains(filtro) ||
                                  row.Cells[4].Value.ToString().ToLower().Contains(filtro);
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string filtro = textBox2.Text.ToLower();
            foreach (DataGridViewRow row in dataGridPreguntas.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    row.Visible = row.Cells[1].Value.ToString().ToLower().Contains(filtro);
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
    }
}