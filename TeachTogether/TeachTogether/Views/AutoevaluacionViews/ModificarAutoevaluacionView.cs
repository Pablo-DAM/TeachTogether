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
using TeachTogether.Security;
using Newtonsoft.Json;
using System.Net.Http;
using TeachTogether.Models;

namespace TeachTogether.Views
{
    public partial class ModificarAutoevaluacionView : Form
    {
        private AutoevaluacionesController autoevaluacionesController = new AutoevaluacionesController();
        private int idAutoevaluacion;
        private String titulo;
        public ModificarAutoevaluacionView(int idAutoevaluacion, string titulo)
        {
            InitializeComponent();
            btnGuardar.Enabled = false;
            this.idAutoevaluacion = idAutoevaluacion;
            this.titulo = titulo;
            textBox1.Text = titulo;
            this.MaximizeBox = false;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox1.Text != titulo)
            {
                btnGuardar.Enabled = true;
            }
            else
            {
                btnGuardar.Enabled = false;
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            int idProfesor=AuthenticationManager.GetUserId();
            AutoevaluacionPUT autoevaluacionPUT = new AutoevaluacionPUT();
            autoevaluacionPUT.titulo = textBox1.Text;
            autoevaluacionPUT.id_profesor = idProfesor;
            autoevaluacionPUT.id_autoevaluacion = this.idAutoevaluacion;
            string json = JsonConvert.SerializeObject(autoevaluacionPUT);
            HttpContent contentRegistro = new StringContent(json, Encoding.UTF8, "application/json");
            await this.autoevaluacionesController.putAutoevaluacion(contentRegistro);
            this.Close();

          
        }
    }
}
