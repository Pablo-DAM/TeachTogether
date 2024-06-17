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
using TeachTogether.Models;
using TeachTogether.Models.AutoevaluacionModels;

namespace TeachTogether.Views.AutoevaluacionViews
{
    public partial class AgregarPreguntaView : Form
    {
        private AutoevaluacionPreguntasController autoevaluacionPreguntasController= new AutoevaluacionPreguntasController();
        private int idAutoev;
        public AgregarPreguntaView(int idAutoev)
        {
            this.idAutoev = idAutoev;
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnAñadir_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
              AutoevaluacionPreguntasPOST autoevaluacionPreguntasPOST = new AutoevaluacionPreguntasPOST();
                autoevaluacionPreguntasPOST.id_autoevaluacion = this.idAutoev;
                autoevaluacionPreguntasPOST.enunciado_pregunta = textBox1.Text;
                string json = JsonConvert.SerializeObject(autoevaluacionPreguntasPOST);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                await this.autoevaluacionPreguntasController.postPregunta(content);
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Debe escribir un enunciado.","Error",MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }
    }
}
