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
    public partial class ChangePasswordView : Form
    {
        private UsuarioController usuarioController = new UsuarioController();
        public ChangePasswordView()
        {
            InitializeComponent();
            btnConfirmar.Enabled = false;
            this.MaximizeBox = false;
        }

        private async void btnConfirmar_Click(object sender, EventArgs e)
        {

            UsuarioModel usuario = new UsuarioModel();
            usuario = await usuarioController.getUsuario();
           

                if (ContieneMayuscula(txtNueva.Text) && ContieneSigno(txtNueva.Text))
                {
     
                    usuario.password = txtNueva.Text;
                    // Serializar el objeto perfil a JSON
                    string json = JsonConvert.SerializeObject(usuario);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                   await usuarioController.changePassword(content);
                    btnConfirmar.Enabled = false;
                    txtRepetirContraseña.Text = "";
                    txtNueva.Text = "";
                  

                }
                else
                {
                    MessageBox.Show("La contraseña nueva no coincide en los dos campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           

        

        private void txtNueva_TextChanged(object sender, EventArgs e)
        {
            if (txtNueva.Text.Length >= 6 && txtRepetirContraseña.Text.Length >= 6)
            {
                btnConfirmar.Enabled = true;
            }
        }

        private void txtRepetirContraseña_TextChanged(object sender, EventArgs e)
        {
            if (txtNueva.Text.Length >= 6 && txtRepetirContraseña.Text.Length >= 6)
            {
                btnConfirmar.Enabled = true;
            }
        }
        private bool ContieneMayuscula(string texto)
        {
            return texto.Any(char.IsUpper);
        }


        private bool ContieneSigno(string texto)
        {

            return texto.Any(ch => !char.IsLetterOrDigit(ch));
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
