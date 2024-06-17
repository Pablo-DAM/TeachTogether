using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeachTogether.Views.AutoevaluacionViews
{
    public partial class DetalleRespuestaView : Form
    {
        private string usuario;
        private string nombre;
        private string apellidos;
        private string respuesta;
        public DetalleRespuestaView(string usuario, string nombre, string apellidos, string respuesta)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.nombre= nombre;
            this.apellidos= apellidos;
            this.respuesta= respuesta;
            txtUsuario.Text = usuario;
            txtNombre.Text = nombre;
            txtApellidos.Text = apellidos;
            txtRespuesta.Text = respuesta;
            this.MaximizeBox = false;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
