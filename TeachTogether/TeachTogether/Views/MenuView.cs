using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeachTogether.Models;

namespace TeachTogether.Views
{
    public partial class MenuView : Form
    {
        public MenuView()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            btnPerfil.MouseEnter += new EventHandler(this.Button_MouseEnter);
            btnPerfil.MouseLeave += new EventHandler(this.Button_MouseLeave);

            btnVerMensajes.MouseEnter += new EventHandler(this.Button_MouseEnter);
            btnVerMensajes.MouseLeave += new EventHandler(this.Button_MouseLeave);

            btnVerMensajes.MouseEnter += new EventHandler(this.Button_MouseEnter);
            btnVerMensajes.MouseLeave += new EventHandler(this.Button_MouseLeave);

            btnAutoevaluaciones.MouseEnter += new EventHandler(this.Button_MouseEnter);
            btnAutoevaluaciones.MouseLeave += new EventHandler(this.Button_MouseLeave);

            btnPaginaWeb.MouseEnter += new EventHandler(this.Button_MouseEnter);
            btnPaginaWeb.MouseLeave += new EventHandler(this.Button_MouseLeave);

            btnSalir.MouseEnter += new EventHandler(this.Button_MouseEnter);
            btnSalir.MouseLeave += new EventHandler(this.Button_MouseLeave);

            btnModulos.MouseEnter += new EventHandler(this.Button_MouseEnter);
            btnModulos.MouseLeave += new EventHandler(this.Button_MouseLeave);
        }

       

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            PerfilView perfil = new PerfilView();
            perfil.FormClosed += (s, args) => this.Show();
            this.Hide(); 
            perfil.ShowDialog();
        }

        private void btnMensajes_Click(object sender, EventArgs e)
        {
            ModulosView usuariosView=new ModulosView();
            usuariosView.FormClosed += (s, args) => this.Show();
            this.Hide();
            usuariosView.ShowDialog();
        }

        private void btnVerMensajes_Click(object sender, EventArgs e)
        {
            MensajesView mensajesView=new MensajesView();
            mensajesView.FormClosed += (s, args) => this.Show();
            this.Hide();
            mensajesView.ShowDialog();
        }

        private void btnAutoevaluaciones_Click(object sender, EventArgs e)
        {
            AutoevaluacionesView autoevaluacionesView=new AutoevaluacionesView();
            autoevaluacionesView.FormClosed += (s, args) => this.Show();
            this.Hide();
            autoevaluacionesView.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPaginaWeb_Click(object sender, EventArgs e)
        {
            string url = "https://ipsl19892.wixsite.com/teachtogether";
            try
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir la página web: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                button.BackColor = Color.LightGreen; 
                
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null && button != btnSalir && button != btnPaginaWeb)
            {
                button.BackColor = Color.LightGoldenrodYellow;
                button.ForeColor = Color.Black; 
            }
            if(button == btnSalir)
            {
                button.BackColor = Color.LightCoral;
            }
            if(button == btnPaginaWeb)
            {
                button.BackColor = Color.LightBlue;
            }
        }
    }
}
