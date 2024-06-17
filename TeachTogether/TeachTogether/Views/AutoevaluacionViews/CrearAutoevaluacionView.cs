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
using Newtonsoft.Json;
using TeachTogether.Security;
using TeachTogether.Models;
namespace TeachTogether.Views
{

    public partial class CrearAutoevaluacionView : Form
    {
        private AutoevaluacionesController autoevaluacionesController = new AutoevaluacionesController();
        private ModulosController modulosController = new ModulosController();
        public CrearAutoevaluacionView()
        {
            InitializeComponent();
            btnGuardar.Enabled = false;
            loadModulosIntoComboBox();
            this.MaximizeBox = false;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            
            AutoevaluacionPOST autoevaluacionPOST = new AutoevaluacionPOST();
            autoevaluacionPOST.titulo = textBox1.Text;
            if (comboBox1.SelectedItem is ComboBoxItem selectedItem)
            {
                autoevaluacionPOST.id_modulo = selectedItem.IdModulo;
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un módulo.");
                return;
            }
            autoevaluacionPOST.id_profesor = AuthenticationManager.GetUserId();
            string json = JsonConvert.SerializeObject(autoevaluacionPOST);
            HttpContent contentRegistro = new StringContent(json, Encoding.UTF8, "application/json");
            await this.autoevaluacionesController.postAutoevaluacion(contentRegistro);
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                btnGuardar.Enabled = true;
            }
            else
            {
                btnGuardar.Enabled = false;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async Task<List<ModulosModel>> getModulosAsync()
        {

            List<ModulosModel> modulos = await modulosController.getModulos();
            return modulos;
        }
        private async Task loadModulosIntoComboBox()
        {

            List<ModulosModel> modulos = await getModulosAsync();
            comboBox1.Items.Clear();
            foreach (ModulosModel modulo in modulos)
            {
                if (modulo.idProfesor.idUsuario == AuthenticationManager.GetUserId())
                {
                    var item = new ComboBoxItem
                    {
                        Nombre = modulo.nombre,
                        IdModulo = modulo.idModulo
                    };          
                    comboBox1.Items.Add(item);
                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is ComboBoxItem selectedItem)
            {
                int selectedIdModulo = selectedItem.IdModulo;
                string selectedNombre = selectedItem.Nombre;
               
            }
        }
    }
    public class ComboBoxItem
    {
        public string Nombre { get; set; }
        public int IdModulo { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}