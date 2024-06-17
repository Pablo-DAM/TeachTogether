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
    public partial class AñadirAlumnoAModuloView : Form
    {
        private UsuarioController usuarioController=new UsuarioController();
        private PerfilesController perfilesController=new PerfilesController();
        private UsuarioModuloController usuarioModuloController=new UsuarioModuloController();
        private int idMod;
        private string nombreModulo;
        
        public AñadirAlumnoAModuloView(int idModulo, string nombreModulo)
        {
            InitializeComponent();
            getAllUsuarios();
            this.idMod= idModulo;
            this.nombreModulo= nombreModulo;
            this.lblNombre.Text += " " + nombreModulo;
            this.MaximizeBox = false;
        }

        private async void getAllUsuarios()
        {
            List<UsuarioModel> listaUsuarios=await usuarioController.GetUsuarios();
            foreach (UsuarioModel usuario in listaUsuarios)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridUsuarios);
                row.Cells[0].Value = usuario.usuario;
                PerfilModel perfil =await perfilesController.getPerfilById(usuario.idUsuario);
                row.Cells[1].Value = perfil.nombre;
                row.Cells[2].Value = perfil.apellidos;
                row.Cells[3].Value = perfil.fechaNacimiento;
                row.Cells[4].Value = usuario.idUsuario;
                row.Cells[5].Value = perfil.idPerfil;
                dataGridUsuarios.Rows.Add(row);
                LlenarComboBoxDesdeDataGridView();

            }

        }
        private void LlenarComboBoxDesdeDataGridView()
        {
            List<string> datos = new List<string>();
            foreach (DataGridViewRow row in dataGridUsuarios.Rows)
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

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnAñadirAlumno_Click(object sender, EventArgs e)
        {
            int idAlu= await this.usuarioController.getIDbyUsuario(comboBox1.SelectedItem.ToString());
            UsuarioModuloPOST usuarioModuloPOST= new UsuarioModuloPOST();
            usuarioModuloPOST.id_modulo = idMod;
            usuarioModuloPOST.id_alumno = idAlu;
            string json = JsonConvert.SerializeObject(usuarioModuloPOST);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            await this.usuarioModuloController.postAlumno(content);

        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                List<UsuarioPerfilModel> usuarioPerfilModel = await usuarioController.getPerfilByUsuario(comboBox1.Text);
                txtNombre.Text = usuarioPerfilModel[0].nombre;
                txtApellidos.Text = usuarioPerfilModel[0].apellidos;
                txtFecha.Text = usuarioPerfilModel[0].fechaNacimiento;
            }
 
        }

        private async void comboBox1_TextChanged(object sender, EventArgs e)
        { 
            if (comboBox1.Items.Contains(comboBox1.Text))
            {
                List<UsuarioPerfilModel> usuarioPerfilModel = await usuarioController.getPerfilByUsuario(comboBox1.Text);
                txtNombre.Text = usuarioPerfilModel[0].nombre;
                txtApellidos.Text = usuarioPerfilModel[0].apellidos;
                txtFecha.Text = usuarioPerfilModel[0].fechaNacimiento;
            }
          
        }

        private void dataGridUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridUsuarios.Rows[e.RowIndex];
                string usuario = row.Cells[0].Value.ToString();
                string nombre = row.Cells[1].Value.ToString();
                string apellidos = row.Cells[2].Value.ToString();
                string fecha = "";
                if (row.Cells[3].Value != null)
                {
                    fecha = row.Cells[3].Value.ToString();
                }
                if (!comboBox1.Items.Contains(usuario))
                {
                    comboBox1.Items.Add(usuario);
                }
                comboBox1.SelectedItem = usuario;
                txtNombre.Text = nombre;
                txtApellidos.Text = apellidos;
                txtFecha.Text=fecha;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFiltroUsuario_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltroUsuario.Text.ToLower();
            foreach (DataGridViewRow row in dataGridUsuarios.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[1].Value != null && row.Cells[2].Value != null)
                {
                    row.Visible = row.Cells[0].Value.ToString().ToLower().Contains(filtro) ||
                                  row.Cells[1].Value.ToString().ToLower().Contains(filtro) ||
                                  row.Cells[2].Value.ToString().ToLower().Contains(filtro);
                }
            }
        }
    }
}
