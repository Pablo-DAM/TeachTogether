using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeachTogether.Controllers;
using TeachTogether.Models.AutoevaluacionModels;

namespace TeachTogether.Views.AutoevaluacionViews
{
    public partial class EditarPreguntaView : Form
    {
        private string enunciado;
        private int idPregunta;
        private int idAutoevaluacion;
        private AutoevaluacionPreguntasController autoevaluacionesController= new AutoevaluacionPreguntasController();
        public EditarPreguntaView(int idPregunta,int idAutoevaluacion,string enunciado)
        {
            
            InitializeComponent();
            this.idAutoevaluacion = idAutoevaluacion;
            this.idPregunta = idPregunta;
            this.enunciado=enunciado;
            textBox1.Text = this.enunciado;
            btnEditar.Enabled = false;
            this.MaximizeBox = false;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if(textBox1.Text !=enunciado && textBox1.Text != "")
            {
                AutoevaluacionPreguntasPUT autoevaluacionPreguntasPUT = new AutoevaluacionPreguntasPUT();
                autoevaluacionPreguntasPUT.enunciado_pregunta=textBox1.Text;
                autoevaluacionPreguntasPUT.id_pregunta = idPregunta;
                autoevaluacionPreguntasPUT.id_autoevaluacion = idAutoevaluacion;
                string json=JsonConvert.SerializeObject(autoevaluacionPreguntasPUT);
                HttpContent contentRegistro = new StringContent(json, Encoding.UTF8, "application/json");
                await this.autoevaluacionesController.putPregunta(contentRegistro);
                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != enunciado)
            {
                btnEditar.Enabled = true;
            }
        }
    }
}
