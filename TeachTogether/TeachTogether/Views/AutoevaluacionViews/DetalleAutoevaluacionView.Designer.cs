namespace TeachTogether.Views.AutoevaluacionViews
{
    partial class DetalleAutoevaluacionView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetalleAutoevaluacionView));
            this.dataGridAutoevaluaciones = new System.Windows.Forms.DataGridView();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Enviada = new System.Windows.Forms.DataGridViewImageColumn();
            this.Respondida = new System.Windows.Forms.DataGridViewImageColumn();
            this.idAutoevaluacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridAlumnos = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblAlumnos = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVerRespuestas = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.txtFiltroAuto = new System.Windows.Forms.TextBox();
            this.txtFiltroAlumnos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAyuda = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAutoevaluaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAlumnos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridAutoevaluaciones
            // 
            this.dataGridAutoevaluaciones.AllowUserToAddRows = false;
            this.dataGridAutoevaluaciones.AllowUserToDeleteRows = false;
            this.dataGridAutoevaluaciones.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridAutoevaluaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridAutoevaluaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAutoevaluaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numero,
            this.Titulo,
            this.Enviada,
            this.Respondida,
            this.idAutoevaluacion,
            this.modulo});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridAutoevaluaciones.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridAutoevaluaciones.Location = new System.Drawing.Point(12, 150);
            this.dataGridAutoevaluaciones.MultiSelect = false;
            this.dataGridAutoevaluaciones.Name = "dataGridAutoevaluaciones";
            this.dataGridAutoevaluaciones.ReadOnly = true;
            this.dataGridAutoevaluaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridAutoevaluaciones.Size = new System.Drawing.Size(521, 319);
            this.dataGridAutoevaluaciones.TabIndex = 18;
            this.dataGridAutoevaluaciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridAutoevaluaciones_CellClick);
            // 
            // Numero
            // 
            this.Numero.FillWeight = 56.02694F;
            this.Numero.HeaderText = "Número";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            // 
            // Titulo
            // 
            this.Titulo.FillWeight = 176.8481F;
            this.Titulo.HeaderText = "Título";
            this.Titulo.MinimumWidth = 60;
            this.Titulo.Name = "Titulo";
            this.Titulo.ReadOnly = true;
            // 
            // Enviada
            // 
            this.Enviada.FillWeight = 85.90667F;
            this.Enviada.HeaderText = "Enviada";
            this.Enviada.Name = "Enviada";
            this.Enviada.ReadOnly = true;
            // 
            // Respondida
            // 
            this.Respondida.FillWeight = 81.21828F;
            this.Respondida.HeaderText = "Respondida";
            this.Respondida.Name = "Respondida";
            this.Respondida.ReadOnly = true;
            // 
            // idAutoevaluacion
            // 
            this.idAutoevaluacion.HeaderText = "idAutoevaluacion";
            this.idAutoevaluacion.Name = "idAutoevaluacion";
            this.idAutoevaluacion.ReadOnly = true;
            this.idAutoevaluacion.Visible = false;
            // 
            // modulo
            // 
            this.modulo.HeaderText = "Módulo";
            this.modulo.Name = "modulo";
            this.modulo.ReadOnly = true;
            // 
            // dataGridAlumnos
            // 
            this.dataGridAlumnos.AllowUserToAddRows = false;
            this.dataGridAlumnos.AllowUserToDeleteRows = false;
            this.dataGridAlumnos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridAlumnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAlumnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Usuario,
            this.Nombre,
            this.Apellidos,
            this.dataGridViewImageColumn2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridAlumnos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridAlumnos.Location = new System.Drawing.Point(640, 150);
            this.dataGridAlumnos.MultiSelect = false;
            this.dataGridAlumnos.Name = "dataGridAlumnos";
            this.dataGridAlumnos.ReadOnly = true;
            this.dataGridAlumnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridAlumnos.Size = new System.Drawing.Size(598, 319);
            this.dataGridAlumnos.TabIndex = 19;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 56.02694F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Número";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Usuario
            // 
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Apellidos
            // 
            this.Apellidos.HeaderText = "Apellidos";
            this.Apellidos.Name = "Apellidos";
            this.Apellidos.ReadOnly = true;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.FillWeight = 81.21828F;
            this.dataGridViewImageColumn2.HeaderText = "Respondida";
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            // 
            // lblAlumnos
            // 
            this.lblAlumnos.AutoSize = true;
            this.lblAlumnos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlumnos.Location = new System.Drawing.Point(776, 67);
            this.lblAlumnos.Name = "lblAlumnos";
            this.lblAlumnos.Size = new System.Drawing.Size(371, 40);
            this.lblAlumnos.TabIndex = 20;
            this.lblAlumnos.Text = "Alumnos que han recibido la autoevaluación: \r\nNo hay ninguna seleccionada";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(125, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Autoevaluaciones registradas";
            // 
            // btnVerRespuestas
            // 
            this.btnVerRespuestas.BackColor = System.Drawing.Color.LightBlue;
            this.btnVerRespuestas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerRespuestas.Location = new System.Drawing.Point(539, 171);
            this.btnVerRespuestas.Name = "btnVerRespuestas";
            this.btnVerRespuestas.Size = new System.Drawing.Size(95, 39);
            this.btnVerRespuestas.TabIndex = 22;
            this.btnVerRespuestas.Text = "Ver respuestas";
            this.btnVerRespuestas.UseVisualStyleBackColor = false;
            this.btnVerRespuestas.Click += new System.EventHandler(this.btnVerRespuestas_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.LightSalmon;
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(1128, 475);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(105, 31);
            this.btnVolver.TabIndex = 23;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // txtFiltroAuto
            // 
            this.txtFiltroAuto.Location = new System.Drawing.Point(185, 124);
            this.txtFiltroAuto.Name = "txtFiltroAuto";
            this.txtFiltroAuto.Size = new System.Drawing.Size(348, 20);
            this.txtFiltroAuto.TabIndex = 24;
            this.txtFiltroAuto.TextChanged += new System.EventHandler(this.txtFiltroAuto_TextChanged);
            // 
            // txtFiltroAlumnos
            // 
            this.txtFiltroAlumnos.Location = new System.Drawing.Point(877, 124);
            this.txtFiltroAlumnos.Name = "txtFiltroAlumnos";
            this.txtFiltroAlumnos.Size = new System.Drawing.Size(361, 20);
            this.txtFiltroAlumnos.TabIndex = 25;
            this.txtFiltroAlumnos.TextChanged += new System.EventHandler(this.txtFiltroAlumnos_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Buscar autoevaluación:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(777, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Buscar alumno:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnAyuda
            // 
            this.btnAyuda.BackColor = System.Drawing.Color.LightBlue;
            this.btnAyuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAyuda.Location = new System.Drawing.Point(1098, 12);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(140, 45);
            this.btnAyuda.TabIndex = 28;
            this.btnAyuda.Text = "Ayuda";
            this.btnAyuda.UseVisualStyleBackColor = false;
            this.btnAyuda.Click += new System.EventHandler(this.btnAyuda_Click);
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "H:\\CLASE\\PROYECTO FINAL\\TeachTogether\\TeachTogether\\Help\\Manual de Usuario App Es" +
    "critorio.pdf";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(494, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(175, 104);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // DetalleAutoevaluacionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1250, 514);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAyuda);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFiltroAlumnos);
            this.Controls.Add(this.txtFiltroAuto);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnVerRespuestas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAlumnos);
            this.Controls.Add(this.dataGridAlumnos);
            this.Controls.Add(this.dataGridAutoevaluaciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DetalleAutoevaluacionView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalles de las autoevaluaciones";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAutoevaluaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAlumnos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridAutoevaluaciones;
        private System.Windows.Forms.DataGridView dataGridAlumnos;
        private System.Windows.Forms.Label lblAlumnos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellidos;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.Button btnVerRespuestas;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Titulo;
        private System.Windows.Forms.DataGridViewImageColumn Enviada;
        private System.Windows.Forms.DataGridViewImageColumn Respondida;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAutoevaluacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn modulo;
        private System.Windows.Forms.TextBox txtFiltroAuto;
        private System.Windows.Forms.TextBox txtFiltroAlumnos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAyuda;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}