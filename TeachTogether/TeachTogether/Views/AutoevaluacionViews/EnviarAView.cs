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
using TeachTogether.Models.AutoevaluacionModels;
using TeachTogether.Models.UsuarioModels;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TeachTogether.Views.AutoevaluacionViews
{
    public partial class EnviarAView : Form
    {
        private UsuarioController usuarioController = new UsuarioController();
        private AutoevaluacionUsuariosController autoevaluacionUsuarioController= new AutoevaluacionUsuariosController();
        private int idModul;
        private String titulo;
        private int idAu;
        public EnviarAView(int idModulo, string titulo, int idAu)
        {
            InitializeComponent();
            this.idModul = idModulo;
            getUsuarios();
            this.titulo = titulo;
            labelTitulo.Text = "Autoevaluación: " + titulo;
            this.idAu = idAu;
            this.MaximizeBox = false;
        }

        public async void getUsuarios()
        {

            List<UsuarioPerfilByIdModuloModel> listaUsus = await this.usuarioController.GetUsuariosPerfilesByIdModulo(idModul);
            int contadorFilas = 1;
            foreach (UsuarioPerfilByIdModuloModel item in listaUsus)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridUsuarios);
                row.Cells[0].Value = contadorFilas;
                row.Cells[1].Value = item.usuario;
                row.Cells[2].Value = item.nombre;
                row.Cells[3].Value = item.apellidos;
                if (item.fecha_nacimiento != null)
                {
                    row.Cells[4].Value =item.fecha_nacimiento.ToString();
                }
                contadorFilas++;
                dataGridUsuarios.Rows.Add(row);
                LlenarComboBoxDesdeDataGridView();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridUsuarios.Rows[e.RowIndex];
                string usuario = row.Cells[1].Value.ToString();
                string nombre = row.Cells[2].Value.ToString();
                string apellidos = row.Cells[3].Value.ToString();
                string fecha = "";
                if (row.Cells[4].Value != null)
                {
                    fecha = row.Cells[4].Value.ToString();
                }
                if (!comboBox2.Items.Contains(usuario))
                {
                    comboBox2.Items.Add(usuario);
                }
                comboBox2.SelectedItem = usuario;
                txtNombre.Text = nombre;
                txtApellidos.Text = apellidos;
                txtFecha.Text = fecha;
            }
        }

        private async void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.Items.Contains(comboBox2.Text))
            {
                try
                {
                    List<UsuarioPerfilModel> usuarioPerfilModel = await usuarioController.getPerfilByUsuario(comboBox2.Text);
                    if (usuarioPerfilModel.Count > 0)
                    {
                        txtNombre.Text = usuarioPerfilModel[0].nombre;
                        txtApellidos.Text = usuarioPerfilModel[0].apellidos;
                        txtFecha.Text = usuarioPerfilModel[0].fechaNacimiento;
                    }
                    else
                    {
                        txtNombre.Text = "";
                        txtApellidos.Text = "";
                        txtFecha.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show("Error al obtener los datos del perfil: " + ex.Message);
                }
            }
        }

        private async void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1)
            {
                List<UsuarioPerfilModel> usuarioPerfilModel = await usuarioController.getPerfilByUsuario(comboBox2.Text);
                txtNombre.Text = usuarioPerfilModel[0].nombre;
                txtApellidos.Text = usuarioPerfilModel[0].apellidos;
                txtFecha.Text = usuarioPerfilModel[0].fechaNacimiento;
            }
        }
        private void LlenarComboBoxDesdeDataGridView()
        {
            List<string> datos = new List<string>();
            foreach (DataGridViewRow row in dataGridUsuarios.Rows)
            {
                if (!row.IsNewRow)
                {
                    object valor = row.Cells[1].Value;
                    if (valor != null)
                        datos.Add(valor.ToString());
                }
            }

            comboBox2.DataSource = datos;
        }

        private async void btnEnviar_Click(object sender, EventArgs e)
        {

            int idUsuario = await this.usuarioController.getIDbyUsuario(comboBox2.Text.ToString());

            AutoevaluacionUsuarioPOST autoevaluacionUsuarioPOST = new AutoevaluacionUsuarioPOST();
            autoevaluacionUsuarioPOST.id_alumno = idUsuario;
            autoevaluacionUsuarioPOST.id_autoevaluacion = idAu;
            string json = JsonConvert.SerializeObject(autoevaluacionUsuarioPOST);
            HttpContent contentRegistro = new StringContent(json, Encoding.UTF8, "application/json");

            ResultadoOperacion resultado = await this.autoevaluacionUsuarioController.postAutoevaluacionUsuario(contentRegistro);

            if (resultado.Exitoso)
            {
                MessageBox.Show("Autoevaluación enviada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(resultado.MensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscarUsuarios_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarUsuarios.Text.ToLower();
            foreach (DataGridViewRow row in dataGridUsuarios.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[2].Value != null && row.Cells[3].Value != null)
                {
                    row.Visible = row.Cells[1].Value.ToString().ToLower().Contains(filtro) ||
                                  row.Cells[2].Value.ToString().ToLower().Contains(filtro) ||
                                  row.Cells[3].Value.ToString().ToLower().Contains(filtro);
                }
            }
        }
    }
}
