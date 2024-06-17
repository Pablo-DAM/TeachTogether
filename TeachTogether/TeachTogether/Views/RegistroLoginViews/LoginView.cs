using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeachTogether.Controllers;
using TeachTogether.Models;
using TeachTogether.Views;
using AuthenticationManager = TeachTogether.Security.AuthenticationManager;
namespace TeachTogether
{
    public partial class LoginView : Form
    {
        public LoginView()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            

        }

        private async void btnEntrar_Click(object sender, EventArgs e)
        {
            LoginController loginController = new LoginController();
            UsuarioController usuarioController = new UsuarioController();

            try
            {
                await loginController.Login(txtUsuario.Text, txtContraseña.Text);

              
                var userId = AuthenticationManager.GetUserId();
                var token = AuthenticationManager.GetToken();
              

                if (userId == 0)
                {
                    MessageBox.Show("Error: No se pudo obtener el UserId.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                UsuarioModel usuVerificado = await usuarioController.getUsuarioById(userId);

                if (usuVerificado != null && usuVerificado.rol.Equals("profesor"))
                {
                    MenuView menu = new MenuView();
                    menu.FormClosed += (s, args) => { this.Show(); LimpiarCampos(); };
                    this.Hide();
                    menu.Show();

                }
                else
                {
                    MessageBox.Show("Solo se admiten usuarios con el rol 'profesor'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show("Error de login: " + httpEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistroView registroView = new RegistroView();
            registroView.FormClosed += (s, args) => { this.Show(); LimpiarCampos(); };
            this.Hide();
            registroView.Show();

        }
        private void LimpiarCampos()
        {
            txtUsuario.Text = string.Empty;
            txtContraseña.Text = string.Empty;
        }


    }
}