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
using TeachTogether.Security;
namespace TeachTogether.Views
{
    public partial class RegistrarModuloView : Form
    {
        public delegate void ModuloRegistradoHandler();
        public event ModuloRegistradoHandler ModuloRegistrado;
        private ModulosController modulosController=new ModulosController();
        public RegistrarModuloView()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }


        private async void buttonRegistrarModulo_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text!="" && txtCodigo.Text != "")
            {
                ModulosPOST modulosPOST = new ModulosPOST();
                modulosPOST.id_profesor = AuthenticationManager.GetUserId();
                modulosPOST.horario = txtHorario.Text;
                if (txtHoras.Text != "")
                {
                    modulosPOST.horas = Convert.ToInt32(txtHoras.Text);
                }              
                modulosPOST.codigo = txtCodigo.Text;
                modulosPOST.nombre = txtNombre.Text;
                modulosPOST.dias = ObtenerDiasSeleccionados();
                string json = JsonConvert.SerializeObject(modulosPOST);
                HttpContent contentRegistro = new StringContent(json, Encoding.UTF8, "application/json");
                await this.modulosController.postModulo(contentRegistro);
               
            }
            else
            {
                MessageBox.Show("Debes introducir un nombre y un código de módulo","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }


        private string ObtenerDiasSeleccionados()
        {
            List<string> diasSeleccionados = new List<string>();

            if (checkBoxLunes.Checked)
                diasSeleccionados.Add("Lunes");
            if (checkBoxMartes.Checked)
                diasSeleccionados.Add("Martes");
            if (checkBoxMiercoles.Checked)
                diasSeleccionados.Add("Miércoles");
            if (checkBoxJueves.Checked)
                diasSeleccionados.Add("Jueves");
            if (checkBoxViernes.Checked)
                diasSeleccionados.Add("Viernes");
            if (checkBoxSabado.Checked)
                diasSeleccionados.Add("Sábado");
            if (checkBoxDomigo.Checked)
                diasSeleccionados.Add("Domingo");

          
            return String.Join(", ", diasSeleccionados);
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
