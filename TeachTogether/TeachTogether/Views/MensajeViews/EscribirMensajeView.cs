using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
    public partial class EscribirMensajeView : Form
    {
        private UsuarioController usuarioController=new UsuarioController();
        private PerfilesController perfilesController=new PerfilesController();
        private MensajesController mensajesController=new MensajesController();
        public EscribirMensajeView()
        {
            InitializeComponent();
            getUsuarios();
            this.MaximizeBox = false;

        }

        private async void getUsuarios()
        {
            List<UsuarioModel>listaUsuarios= await usuarioController.GetUsuarios();

            foreach (UsuarioModel usuario in listaUsuarios)
            {
                PerfilModel perfilModel = new PerfilModel();
                perfilModel = await perfilesController.getPerfilById(usuario.idUsuario);
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvUsuarios);
                row.Cells[0].Value = usuario.usuario;
                row.Cells[1].Value = perfilModel.nombre;
                row.Cells[2].Value = perfilModel.apellidos;
                row.Cells[3].Value = usuario.idUsuario;
                dgvUsuarios.Rows.Add(row);
                LlenarComboBoxConDatosDeDataGridView();
                BtnEnviar.Enabled = false;
            }
        }
        private void LlenarComboBoxConDatosDeDataGridView()
        {
            List<string> datos = new List<string>();
            foreach (DataGridViewRow row in dgvUsuarios.Rows)
            {
                if (!row.IsNewRow)  
                {
                    object valor = row.Cells[0].Value;  
                    if (valor != null)
                        datos.Add(valor.ToString());
                }
            }

            comboBox1.DataSource = datos;  
        }
        private async void BtnEnviar_Click(object sender, EventArgs e)
        {
            if(txtMensaje.Text != "")
            {
                MensajePOST mensajePOST = new MensajePOST();
                mensajePOST.fecha_creaccion = DateTime.Now;
                List<UsuarioPerfilModel> usuarioPerfilModel= await this.usuarioController.getPerfilByUsuario(comboBox1.Text);
                int idReceptor = usuarioPerfilModel[0].idUsuario.idUsuario;
                mensajePOST.id_receptor = idReceptor;
                mensajePOST.id_creador=AuthenticationManager.GetUserId();
                mensajePOST.texto = txtMensaje.Text;
                // Serializar el usuario a JSON
                string json = JsonConvert.SerializeObject(mensajePOST);
                HttpContent contentRegistro = new StringContent(json, Encoding.UTF8, "application/json");
                await this.mensajesController.enviarMensaje(contentRegistro);
                this.Close();
            }
            else
            {
                MessageBox.Show("Debes escribir un mensaje", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsuarios.Rows[e.RowIndex];             
                string usuario = row.Cells[0].Value.ToString();
                string nombre = row.Cells[1].Value.ToString();
                string apellidos = row.Cells[2].Value.ToString();
                
                if (!comboBox1.Items.Contains(usuario))
                {
                    comboBox1.Items.Add(usuario);
                }             
                comboBox1.SelectedItem = usuario;
                txtNombre.Text = nombre;
                txtApellidos.Text = apellidos;
                BtnEnviar.Enabled = true;
            }
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                List<UsuarioPerfilModel> usuarioPerfilModel =await usuarioController.getPerfilByUsuario(comboBox1.Text);
                txtNombre.Text = usuarioPerfilModel[0].nombre;
                txtApellidos.Text = usuarioPerfilModel[0].apellidos;
                BtnEnviar.Enabled = true;
            }
            else
            {
                BtnEnviar.Enabled = false;
            }
        }

        private async void comboBox1_TextChanged(object sender, EventArgs e)
        {
            
            if (comboBox1.Items.Contains(comboBox1.Text))
            {
                List<UsuarioPerfilModel> usuarioPerfilModel = await usuarioController.getPerfilByUsuario(comboBox1.Text);
                txtNombre.Text = usuarioPerfilModel[0].nombre;
                txtApellidos.Text = usuarioPerfilModel[0].apellidos;
                BtnEnviar.Enabled = true;
            }
            else
            {
               
                txtNombre.Text = "";
                txtApellidos.Text = "";
                BtnEnviar.Enabled = false;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
