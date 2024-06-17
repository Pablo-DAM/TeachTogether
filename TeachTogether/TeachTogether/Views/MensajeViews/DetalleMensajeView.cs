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

namespace TeachTogether.Views
{
    public partial class DetalleMensajeView : Form
    {
        private string usuario {  get; set; }
        private string nombre {  get; set; }
        private string apellidos {  get; set; }
        private string text {  get; set; }
        private DateTime fecha {  get; set; }
        private int idCreador {  get; set; }
        private int idMensaje { get; set; }

        private string origen;
        public DetalleMensajeView()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }
        public DetalleMensajeView(string usuario, string nombre, string apellidos,string texto, DateTime fecha,int idCreador, int idMensaje, string origen)
        {
            this.usuario = usuario;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.text = texto;
            this.fecha = fecha;
            this.idCreador = idCreador;
            this.idMensaje = idMensaje;
            this.origen = origen;
            InitializeComponent();
            cargarDatos();
            if (this.origen == "enviando")
            {
                btnResponder.Visible = false;
            }
        }

        private void cargarDatos()
        {
          
            txtApellidos.Text = apellidos;
            txtNombre.Text = nombre;
            txtFecha.Text =Convert.ToString(fecha);
            txtMensaje.Text = text;
            txtUsuario.Text = usuario;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnResponder_Click(object sender, EventArgs e)
        {
            ResponderMensajeView enviarMensajeView = new ResponderMensajeView(usuario,nombre,apellidos,idCreador);
            enviarMensajeView.ShowDialog();
        }

        private async void btnEliminarMensaje_Click(object sender, EventArgs e)
        {
            
            MensajesController mensajesController = new MensajesController();
            await  mensajesController.eliminarMensaje(idMensaje);
            txtApellidos.Text = "";
            txtFecha.Text = "";
            txtMensaje.Text = "";
            txtNombre.Text = "";
            txtUsuario.Text = "";
            MensajeEliminado?.Invoke(idMensaje);
            this.Close();
        }

        //Evento para pasar el ID eliminado al formulario padre
        public delegate void MensajeEliminadoHandler(int idMensajeEliminado);
        public event MensajeEliminadoHandler MensajeEliminado;
    }
}
