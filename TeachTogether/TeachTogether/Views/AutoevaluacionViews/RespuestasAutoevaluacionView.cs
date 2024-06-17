using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeachTogether.Controllers;
using TeachTogether.Models;
using TeachTogether.Models.AutoevaluacionModels;

namespace TeachTogether.Views.AutoevaluacionViews
{
    public partial class RespuestasAutoevaluacionView : Form
    {
        private int idAutoev;
        private AutoevaluacionPreguntasController autoevaluacionPreguntasController = new AutoevaluacionPreguntasController();
        private AutoevaluacionPreguntaRespuestaController AutoevaluacionPreguntaRespuestaController = new AutoevaluacionPreguntaRespuestaController();
        private AutoevaluacionUsuariosController AutoevaluacionUsuariosController = new AutoevaluacionUsuariosController();
        private UsuarioController usuarioController = new UsuarioController();
        private String titulo;
        public RespuestasAutoevaluacionView(int idAutoev,String titulo)
        {
            InitializeComponent();
            this.btnDetalleRespuesta.Enabled = false;
            this.idAutoev = idAutoev;
            this.titulo = titulo;
            lblPreguntas.Text = "Preguntas de la Autoevaluación:\n"+titulo;
            getPreguntas();
            this.MaximizeBox = false;

        }




        public async void getPreguntas()
        {
            List<AutoevaluacionPreguntasModel> listaPreguntas = await this.autoevaluacionPreguntasController.getAutoevaluaciones();
            int contadorFilas = 1;
            foreach (AutoevaluacionPreguntasModel item in listaPreguntas)
            {
                if (item.idAutoevaluacion.idAutoevaluacion == this.idAutoev)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dataGridPreguntas);
                    row.Cells[0].Value = contadorFilas;
                    row.Cells[1].Value = item.enunciadoPregunta;
                    row.Cells[2].Value = this.idAutoev;
                    row.Cells[3].Value = item.idPregunta;
                    contadorFilas++;
                    dataGridPreguntas.Rows.Add(row);
                    
                }

            }
            dataGridPreguntas.ClearSelection();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void dataGridPreguntas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridRespuestas.Rows.Clear();
            if (dataGridPreguntas.SelectedRows.Count > 0)
            {
                DataGridViewRow drow= dataGridPreguntas.SelectedRows[0];

                if (drow.Cells[0].Value!=null)
                {
                    lblRespuestas.Text = "Respuestas de la Pregunta:\n"+ drow.Cells[1].Value.ToString();
                    int idPregunta =(int) drow.Cells[3].Value;
                    int contadorFilas = 1;
                    List<AutoevaluacionPreguntaRespuestaModel> todasLasRespuestas = await this.AutoevaluacionPreguntaRespuestaController.getAllRespuestas();
                                  
                    foreach (AutoevaluacionPreguntaRespuestaModel item in todasLasRespuestas)
                    {
                        if (item.idPregunta.idPregunta == idPregunta && item.idPregunta.idAutoevaluacion.idAutoevaluacion == this.idAutoev)
                        {

                            List<UsuarioPerfilModel> perfil = await this.usuarioController.getPerfilByUsuario(item.idAlumno.usuario);
                            DataGridViewRow row = new DataGridViewRow();
                            row.CreateCells(dataGridRespuestas);
                            row.Cells[0].Value = contadorFilas;
                            row.Cells[1].Value = item.idAlumno.usuario;
                            row.Cells[2].Value = perfil[0].nombre;
                            row.Cells[3].Value = perfil[0].apellidos;
                            row.Cells[4].Value = item.textoRespuesta;
                            row.Cells[5].Value = (int)item.idRespuesta;

                            dataGridRespuestas.Rows.Add(row);

                            contadorFilas++;
                            btnDetalleRespuesta.Enabled = true;
                        }
                    }
                   
                }

            }
               
        }

        private void btnDetalleRespuesta_Click(object sender, EventArgs e)
        {
           if(dataGridRespuestas.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridRespuestas.SelectedRows[0];
                if (row.Cells[0].Value!=null)
                {
                    string usuario = row.Cells[1].Value.ToString();
                    string nombre = row.Cells[2].Value.ToString();
                    string apellidos = row.Cells[3].Value.ToString();
                    string respuesta = row.Cells[4].Value.ToString();
                    DetalleRespuestaView detalleRespuestaView = new DetalleRespuestaView(usuario,nombre,apellidos,respuesta);
                    detalleRespuestaView.ShowDialog();

                }
            }  
        }

        private void dataGridPreguntas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filtro = textBox1.Text.ToLower();
            foreach (DataGridViewRow row in dataGridPreguntas.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    row.Visible = row.Cells[1].Value.ToString().ToLower().Contains(filtro);
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string filtro = textBox2.Text.ToLower();
            foreach (DataGridViewRow row in dataGridRespuestas.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[2].Value != null && row.Cells[3].Value != null && row.Cells[4].Value != null)
                {
                    row.Visible = row.Cells[1].Value.ToString().ToLower().Contains(filtro) ||
                                  row.Cells[2].Value.ToString().ToLower().Contains(filtro) ||
                                  row.Cells[3].Value.ToString().ToLower().Contains(filtro) ||
                                  row.Cells[4].Value.ToString().ToLower().Contains(filtro);
                }
            }
        }
    }
}
