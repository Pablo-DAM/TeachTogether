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
    public partial class ModificarModuloView : Form
    {
        private int id;
        private ModulosController modulosController=new ModulosController();
        public ModificarModuloView(ModulosModel moduloRecibido, int id)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.id= id;
            txtCodigo.Text = moduloRecibido.codigo;
            txtHorario.Text=moduloRecibido.horario;
            txtHoras.Text = moduloRecibido.horas.ToString();
            txtNombre.Text=moduloRecibido.nombre;
            if (moduloRecibido.dias.Contains("Lunes"))
            {
                checkBoxLunes.Checked = true;
            }
            if (moduloRecibido.dias.Contains("Martes"))
            {
                checkBoxMartes.Checked = true;
            }
            if (moduloRecibido.dias.Contains("Miércoles"))
            {
                checkBoxMiercoles.Checked = true;
            }
            if (moduloRecibido.dias.Contains("Jueves"))
            {
                checkBoxJueves.Checked = true;
            }
            if (moduloRecibido.dias.Contains("Viernes"))
            {
                checkBoxViernes.Checked = true;
            }
            if (moduloRecibido.dias.Contains("Sábado"))
            {
                checkBoxSabado.Checked = true;
            }
            if (moduloRecibido.dias.Contains("Domingo"))
            {
                checkBoxDomigo.Checked = true;
            }
                
        }

        private async void buttonModificarModulo_Click(object sender, EventArgs e)
        {
            if(txtCodigo.Text!="" && txtNombre.Text != "")
            {
                ModuloPUT moduloPUT = new ModuloPUT();
                moduloPUT.id_modulo = id;
                moduloPUT.id_profesor = AuthenticationManager.GetUserId();
                moduloPUT.nombre=txtNombre.Text;
                moduloPUT.horario=txtHorario.Text;
                if (txtHoras.Text != "")
                {
                    moduloPUT.horas = Convert.ToInt32(txtHoras.Text);
                }
                moduloPUT.codigo = txtCodigo.Text;
                moduloPUT.dias = ObtenerDiasSeleccionados();

                string json = JsonConvert.SerializeObject(moduloPUT);
                HttpContent contentRegistro = new StringContent(json, Encoding.UTF8, "application/json");
                
                await modulosController.editarModulo(contentRegistro);
            }
            else
            {
                MessageBox.Show("Campos requeridos: Nombre dél módulo y Código del módulo","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
