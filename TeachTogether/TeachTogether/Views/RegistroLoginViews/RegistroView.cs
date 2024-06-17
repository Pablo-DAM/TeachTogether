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
namespace TeachTogether.Views
{
    public partial class RegistroView : Form
    {
        private RegistroController registroController = new RegistroController();
        private RegistroModel registroModel = new RegistroModel();

        private PerfilesController perfilesController = new PerfilesController();
        private PerfilPOST perfilModel = new PerfilPOST();

        private bool cambioFecha = false;
        private int idUsuario = 0;
        public RegistroView()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            btnGuardar.Enabled = false;
            this.MaximizeBox = false;
        }

        
        private bool validarCampos()
        {
            bool todoCorrecto = false;
            if (txtUsuario.Text.Length >= 6 && txtContraseña.Text.Length >= 6 && txtRepetirContraseña.Text.Length >= 6
                && txtNombre.Text != "" && txtApellidos.Text != "")
            {
                todoCorrecto = true;
            }
            return todoCorrecto;
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                btnGuardar.Enabled = true;
            }
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                btnGuardar.Enabled = true;
            }
        }

        private void txtRepetirContraseña_TextChanged(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                btnGuardar.Enabled = true;
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                btnGuardar.Enabled = true;
            }
        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                btnGuardar.Enabled = true;
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            cambioFecha = true;
            if (validarCampos())
            {
                btnGuardar.Enabled = true;
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text != txtRepetirContraseña.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                registroModel.usuario = txtUsuario.Text;
                registroModel.rol = "profesor";
                registroModel.password = txtContraseña.Text;

              
                // Serializar el usuario a JSON
                string json = JsonConvert.SerializeObject(registroModel);
                HttpContent contentRegistro = new StringContent(json, Encoding.UTF8, "application/json");

               UsuarioModel usu= await registroController.registrarse(contentRegistro);
                if(usu == null)
                {
                    return;
                }
                perfilModel.nombre = txtNombre.Text;
                perfilModel.apellidos = txtApellidos.Text;
                perfilModel.id_usuario = usu.idUsuario;
                if (cambioFecha)
                {
                    perfilModel.fecha_nacimiento = dtpFecha.Value.ToString("yyyy-MM-dd");
                }
                else
                {
                    perfilModel.fecha_nacimiento = null;
                }

                string jsonPerfil = JsonConvert.SerializeObject(perfilModel);
                HttpContent contentPerfil = new StringContent(jsonPerfil, Encoding.UTF8, "application/json");
                await perfilesController.registrarPerfil(contentPerfil);
                this.Close();
            }


        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
