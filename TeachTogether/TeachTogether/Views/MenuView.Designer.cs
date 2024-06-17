namespace TeachTogether.Views
{
    partial class MenuView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuView));
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnPerfil = new System.Windows.Forms.Button();
            this.btnModulos = new System.Windows.Forms.Button();
            this.btnVerMensajes = new System.Windows.Forms.Button();
            this.btnAutoevaluaciones = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnPaginaWeb = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenido.Location = new System.Drawing.Point(22, 121);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(212, 13);
            this.lblBienvenido.TabIndex = 0;
            this.lblBienvenido.Text = "Haga clic en un botón para navegar";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(51, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(165, 105);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnPerfil
            // 
            this.btnPerfil.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnPerfil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPerfil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPerfil.Location = new System.Drawing.Point(72, 149);
            this.btnPerfil.Name = "btnPerfil";
            this.btnPerfil.Size = new System.Drawing.Size(120, 40);
            this.btnPerfil.TabIndex = 1;
            this.btnPerfil.Text = "Perfil";
            this.toolTip1.SetToolTip(this.btnPerfil, "Ir a tú Perfil");
            this.btnPerfil.UseVisualStyleBackColor = false;
            this.btnPerfil.Click += new System.EventHandler(this.btnPerfil_Click);
            // 
            // btnModulos
            // 
            this.btnModulos.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnModulos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModulos.Location = new System.Drawing.Point(72, 241);
            this.btnModulos.Name = "btnModulos";
            this.btnModulos.Size = new System.Drawing.Size(120, 40);
            this.btnModulos.TabIndex = 3;
            this.btnModulos.Text = "Módulos";
            this.toolTip1.SetToolTip(this.btnModulos, "Gestionar módulos");
            this.btnModulos.UseVisualStyleBackColor = false;
            this.btnModulos.Click += new System.EventHandler(this.btnMensajes_Click);
            // 
            // btnVerMensajes
            // 
            this.btnVerMensajes.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnVerMensajes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerMensajes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerMensajes.Location = new System.Drawing.Point(72, 195);
            this.btnVerMensajes.Name = "btnVerMensajes";
            this.btnVerMensajes.Size = new System.Drawing.Size(120, 40);
            this.btnVerMensajes.TabIndex = 2;
            this.btnVerMensajes.Text = "Mensajes";
            this.toolTip1.SetToolTip(this.btnVerMensajes, "Mensajes");
            this.btnVerMensajes.UseVisualStyleBackColor = false;
            this.btnVerMensajes.Click += new System.EventHandler(this.btnVerMensajes_Click);
            // 
            // btnAutoevaluaciones
            // 
            this.btnAutoevaluaciones.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnAutoevaluaciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAutoevaluaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoevaluaciones.Location = new System.Drawing.Point(72, 287);
            this.btnAutoevaluaciones.Name = "btnAutoevaluaciones";
            this.btnAutoevaluaciones.Size = new System.Drawing.Size(120, 40);
            this.btnAutoevaluaciones.TabIndex = 4;
            this.btnAutoevaluaciones.Text = "Autoevaluaciones";
            this.toolTip1.SetToolTip(this.btnAutoevaluaciones, "Gestionar Autoevaluaciones");
            this.btnAutoevaluaciones.UseVisualStyleBackColor = false;
            this.btnAutoevaluaciones.Click += new System.EventHandler(this.btnAutoevaluaciones_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.LightCoral;
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(72, 379);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(120, 40);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnPaginaWeb
            // 
            this.btnPaginaWeb.BackColor = System.Drawing.Color.LightBlue;
            this.btnPaginaWeb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPaginaWeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaginaWeb.Location = new System.Drawing.Point(72, 333);
            this.btnPaginaWeb.Name = "btnPaginaWeb";
            this.btnPaginaWeb.Size = new System.Drawing.Size(120, 40);
            this.btnPaginaWeb.TabIndex = 5;
            this.btnPaginaWeb.Text = "Portal Web";
            this.toolTip1.SetToolTip(this.btnPaginaWeb, "Ir al Portal Web");
            this.btnPaginaWeb.UseVisualStyleBackColor = false;
            this.btnPaginaWeb.Click += new System.EventHandler(this.btnPaginaWeb_Click);
            // 
            // MenuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(262, 437);
            this.Controls.Add(this.btnPaginaWeb);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAutoevaluaciones);
            this.Controls.Add(this.btnVerMensajes);
            this.Controls.Add(this.btnModulos);
            this.Controls.Add(this.btnPerfil);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblBienvenido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MenuView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnPerfil;
        private System.Windows.Forms.Button btnModulos;
        private System.Windows.Forms.Button btnVerMensajes;
        private System.Windows.Forms.Button btnAutoevaluaciones;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnPaginaWeb;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}