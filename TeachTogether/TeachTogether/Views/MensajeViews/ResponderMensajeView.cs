using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Cache;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeachTogether.Controllers;
using TeachTogether.Models;
using TeachTogether.Security;
namespace TeachTogether.Views
{
    public partial class ResponderMensajeView : Form
    {
        private MensajesController mensajeController=new MensajesController();
        private string usuario { get; set; }
        private string nombre { get; set; }
        private string apellidos { get; set; }
        private string text { get; set; }
        private DateTime fecha=DateTime.Now;
        private int idReceptor { get; set; }
        public ResponderMensajeView(string usuario, string nombre,string apellidos,int idReceptor)
        {
            this.usuario = usuario;
            this.nombre = nombre;
            this.apellidos = apellidos;      
            this.idReceptor = idReceptor;
            InitializeComponent();
            cargarDatos();
            this.MaximizeBox = false;
        }

        private void cargarDatos()
        {
            txtNombre.Text = nombre;
            txtApellidos.Text= apellidos;
            txtfecha.Text = Convert.ToString(fecha);
            txtUsuario.Text= usuario;
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            if(txtTextoEnviar.Text.Length > 0)
            {
                MensajePOST mensaje = new MensajePOST();
                mensaje.fecha_creaccion = fecha;
                mensaje.texto = txtTextoEnviar.Text;
                mensaje.id_receptor = idReceptor;
                mensaje.id_creador = AuthenticationManager.GetUserId();
                string json = JsonConvert.SerializeObject(mensaje);
                HttpContent contentRegistro = new StringContent(json, Encoding.UTF8, "application/json");
                await mensajeController.enviarMensaje(contentRegistro);
                this.Close();
                
            }
            else
            {
                MessageBox.Show("Debes introducir un texto en el mensaje.","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
