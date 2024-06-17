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
using TeachTogether.Models.AutoevaluacionModels;
using TeachTogether.Security;
using System.IO;
namespace TeachTogether.Views.AutoevaluacionViews
{
    public partial class DetalleAutoevaluacionView : Form
    {
        private AutoevaluacionPreguntaRespuestaController autoevaluacionPreguntaRespuestaController = new AutoevaluacionPreguntaRespuestaController();
        private AutoevaluacionUsuariosController autoevaluacionUsuariosController = new AutoevaluacionUsuariosController();
        private AutoevaluacionesController autoevaluacionesController = new AutoevaluacionesController();
        private UsuarioController usuarioController = new UsuarioController();
        public DetalleAutoevaluacionView()
        {
            InitializeComponent();
            getAllAutoevaluacionesSent();
            btnVerRespuestas.Enabled = false;
            this.MaximizeBox = false;
        }

        public async void getAllAutoevaluacionesSent()
        {
            List<AutoevaluacionesModel> listaAutos =
                await this.autoevaluacionesController.getAutoevaluacionesByIdProf(AuthenticationManager.GetUserId());
            HashSet<AutoevaluacionUsuariosModel> listaAutoevaluacionesEnviadas = await this.autoevaluacionUsuariosController.getAllAutoevalucionUsuarios();
            int contadorFilas = 1;
            foreach (AutoevaluacionesModel item in listaAutos)
            {
                bool enviado = false;
                bool respondido = false;
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridAutoevaluaciones);
                row.Cells[0].Value = contadorFilas.ToString();
                row.Cells[1].Value = item.titulo;
                row.Cells[4].Value =(int) item.idAutoevaluacion;
                row.Cells[5].Value = item.id_modulo.nombre;
                //ver si la autoevaluación ha sido enviada a algn alumno
                foreach (AutoevaluacionUsuariosModel elemento in listaAutoevaluacionesEnviadas)
                {
                    if (elemento.idAutoevaluacion == item.idAutoevaluacion)
                    {
                        enviado = true;
                        if (elemento.fecha_realizacion != null)
                        {
                            respondido = true;

                        }

                    }
                }
                if (enviado)
                {
                    string iconEnviadoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "icons", "correcto.ico");
                    Image iconEnv = Image.FromFile(iconEnviadoPath);
                    Image iconRedimensionado = iconEnv.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                    row.Cells[2].Value = iconRedimensionado;
                }
                else
                {
                    string iconEnviadoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "icons", "error.ico");
                    Image iconEnv = Image.FromFile(iconEnviadoPath);
                    Image iconRedimensionado = iconEnv.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                    row.Cells[2].Value = iconRedimensionado;
                }
                if (respondido)
                {
                    string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "icons", "correcto.ico");
                    Image icon = Image.FromFile(iconPath);
                    Image iconRedimensionado = icon.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                    row.Cells[3].Value = iconRedimensionado;
                }
                else
                {
                    string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "icons", "error.ico");
                    Image icon = Image.FromFile(iconPath);
                    Image iconRedimensionado = icon.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                    row.Cells[3].Value = iconRedimensionado;
                }
                contadorFilas++;
                dataGridAutoevaluaciones.Rows.Add(row);
            }
        }

        private async void dataGridAutoevaluaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnVerRespuestas.Enabled = true;   
            dataGridAlumnos.Rows.Clear();
            if (dataGridAutoevaluaciones.SelectedRows.Count > 0)
            {
              
                DataGridViewRow row = dataGridAutoevaluaciones.SelectedRows[0];
                if (row.Cells[0] != null)
                {
                    int idAutoevaluacion = (int)row.Cells[4].Value;
                    HashSet<AutoevaluacionUsuariosModel> listaAlumnos = await this.autoevaluacionUsuariosController.getAllAutoevalucionUsuarios();
                    if(listaAlumnos != null)
                    {
                        int contadorFilas = 1;
                        foreach (AutoevaluacionUsuariosModel item in listaAlumnos)
                        {
                            if (item.idAutoevaluacion == idAutoevaluacion)
                            {
                                DataGridViewRow rowAlumno = new DataGridViewRow();
                                rowAlumno.CreateCells(dataGridAlumnos);
                                List<UsuarioPerfilModel> perfil = await this.usuarioController.getPerfilByUsuario(item.alumno.usuario);
                                rowAlumno.Cells[0].Value = contadorFilas;
                                rowAlumno.Cells[1].Value = item.alumno.usuario;
                                rowAlumno.Cells[2].Value = perfil[0].nombre;
                                rowAlumno.Cells[3].Value = perfil[0].apellidos;
                                if (item.fecha_realizacion != null)
                                {
                                    string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "icons", "correcto.ico");
                                    Image icon = Image.FromFile(iconPath);
                                    Image iconRedimensionado = icon.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                                    rowAlumno.Cells[4].Value = iconRedimensionado;

                                }
                                else
                                {
                                    string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "icons", "error.ico");
                                    Image icon = Image.FromFile(iconPath);
                                    Image iconRedimensionado = icon.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                                    rowAlumno.Cells[4].Value = iconRedimensionado;
                                }
                                dataGridAlumnos.Rows.Add(rowAlumno);
                                string alumnos = dataGridAutoevaluaciones.SelectedRows[0].Cells[1].Value.ToString();
                                string alumnosTruncados = alumnos.Length > 25 ? alumnos.Substring(0, 25) : alumnos;
                                lblAlumnos.Text = "Alumnos que han recibido la autoevaluación: \r\n" + alumnosTruncados;
                            }
                                                
                        }                                             
                    }
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVerRespuestas_Click(object sender, EventArgs e)
        {
            int idAutoev = (int) dataGridAutoevaluaciones.SelectedRows[0].Cells[4].Value;
            String titulo = dataGridAutoevaluaciones.SelectedRows[0].Cells["Titulo"].Value.ToString();
            RespuestasAutoevaluacionView respuestasAutoevaluacionView = new RespuestasAutoevaluacionView(idAutoev,titulo);
            respuestasAutoevaluacionView.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtFiltroAuto_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltroAuto.Text.ToLower();
            foreach (DataGridViewRow row in dataGridAutoevaluaciones.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[5].Value != null)
                {
                    row.Visible = row.Cells[1].Value.ToString().ToLower().Contains(filtro) ||
                                  row.Cells[5].Value.ToString().ToLower().Contains(filtro);
                }
            }
        }

        private void txtFiltroAlumnos_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltroAlumnos.Text.ToLower();
            foreach (DataGridViewRow row in dataGridAlumnos.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[2].Value != null && row.Cells[3].Value != null)
                {
                    row.Visible = row.Cells[1].Value.ToString().ToLower().Contains(filtro) ||
                                  row.Cells[2].Value.ToString().ToLower().Contains(filtro) ||
                                  row.Cells[3].Value.ToString().ToLower().Contains(filtro);
                }
            }
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            string pdfPath = helpProvider1.HelpNamespace;
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
