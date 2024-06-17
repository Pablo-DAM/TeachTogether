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
    public partial class PerfilView : Form
    {
        private PerfilesController perfilController=new PerfilesController();
        private int idPerfil = 0;
        private bool isDataLoading = true;
        public PerfilView()
        {
            
            InitializeComponent();
            cargarDatos();
            btnGuardar.Enabled = false;
            this.MaximizeBox = false;
        }

      
        private async void cargarDatos()
        {
            isDataLoading = true;
            PerfilModel perfilModel =await perfilController.getPerfil();
            txtNombre.Text = perfilModel.nombre;
            txtApellidos.Text = perfilModel.apellidos;
            if (perfilModel.fechaNacimiento != null)
            {
                dtpFechaNacimiento.Value = Convert.ToDateTime(perfilModel.fechaNacimiento);
            }
           
            idPerfil=perfilModel.idPerfil;
            isDataLoading = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(!isDataLoading)
            btnGuardar.Enabled = true;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
           
            
            PerfilPUT perfil=new PerfilPUT();
            perfil.nombre= txtNombre.Text;
            perfil.apellidos= txtApellidos.Text;
            perfil.fecha_nacimiento = dtpFechaNacimiento.Value.ToString("yyyy-MM-dd");
            perfil.id_perfil=idPerfil;
            perfil.id_usuario=AuthenticationManager.GetUserId();
           
            // Serializar el objeto perfil a JSON
            string json = JsonConvert.SerializeObject(perfil);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            await perfilController.updatePerfil(content);        
            btnGuardar.Enabled = false;
            cargarDatos();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if(!isDataLoading)
            btnGuardar.Enabled = true;
        }

        private void dtpFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {
            if(!isDataLoading)
            btnGuardar.Enabled = true;
        }

        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            ChangePasswordView changePasswordView = new ChangePasswordView();
            changePasswordView.FormClosed += (s, args) => this.Show(); 
            this.Hide(); 
            changePasswordView.ShowDialog();

        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
