namespace TeachTogether.Views.AutoevaluacionViews
{
    partial class RespuestasAutoevaluacionView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RespuestasAutoevaluacionView));
            this.dataGridRespuestas = new System.Windows.Forms.DataGridView();
            this.NumeroFila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Respuesta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idRespuesta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridPreguntas = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Enunciado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPregunta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDetalleRespuesta = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblPreguntas = new System.Windows.Forms.Label();
            this.lblRespuestas = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRespuestas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPreguntas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridRespuestas
            // 
            this.dataGridRespuestas.AllowUserToAddRows = false;
            this.dataGridRespuestas.AllowUserToDeleteRows = false;
            this.dataGridRespuestas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridRespuestas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridRespuestas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRespuestas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumeroFila,
            this.Usuario,
            this.Nombre,
            this.Apellidos,
            this.Respuesta,
            this.idRespuesta});
            this.dataGridRespuestas.Location = new System.Drawing.Point(584, 129);
            this.dataGridRespuestas.MultiSelect = false;
            this.dataGridRespuestas.Name = "dataGridRespuestas";
            this.dataGridRespuestas.ReadOnly = true;
            this.dataGridRespuestas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridRespuestas.Size = new System.Drawing.Size(495, 426);
            this.dataGridRespuestas.TabIndex = 17;
            // 
            // NumeroFila
            // 
            this.NumeroFila.FillWeight = 31.87885F;
            this.NumeroFila.HeaderText = "Número";
            this.NumeroFila.Name = "NumeroFila";
            this.NumeroFila.ReadOnly = true;
            // 
            // Usuario
            // 
            this.Usuario.FillWeight = 139.4007F;
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.FillWeight = 125.9864F;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Apellidos
            // 
            this.Apellidos.FillWeight = 125.9864F;
            this.Apellidos.HeaderText = "Apellidos";
            this.Apellidos.Name = "Apellidos";
            this.Apellidos.ReadOnly = true;
            // 
            // Respuesta
            // 
            this.Respuesta.FillWeight = 125.9864F;
            this.Respuesta.HeaderText = "Respuesta";
            this.Respuesta.Name = "Respuesta";
            this.Respuesta.ReadOnly = true;
            // 
            // idRespuesta
            // 
            this.idRespuesta.FillWeight = 50.76142F;
            this.idRespuesta.HeaderText = "idRespuesta";
            this.idRespuesta.Name = "idRespuesta";
            this.idRespuesta.ReadOnly = true;
            this.idRespuesta.Visible = false;
            // 
            // dataGridPreguntas
            // 
            this.dataGridPreguntas.AllowUserToAddRows = false;
            this.dataGridPreguntas.AllowUserToDeleteRows = false;
            this.dataGridPreguntas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridPreguntas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridPreguntas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPreguntas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Enunciado,
            this.dataGridViewTextBoxColumn3,
            this.idPregunta});
            this.dataGridPreguntas.Location = new System.Drawing.Point(12, 129);
            this.dataGridPreguntas.MultiSelect = false;
            this.dataGridPreguntas.Name = "dataGridPreguntas";
            this.dataGridPreguntas.ReadOnly = true;
            this.dataGridPreguntas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridPreguntas.Size = new System.Drawing.Size(495, 426);
            this.dataGridPreguntas.TabIndex = 18;
            this.dataGridPreguntas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridPreguntas_CellClick);
            this.dataGridPreguntas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridPreguntas_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 25.30341F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Número";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Enunciado
            // 
            this.Enunciado.FillWeight = 223.9352F;
            this.Enunciado.HeaderText = "Enunciado";
            this.Enunciado.Name = "Enunciado";
            this.Enunciado.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.FillWeight = 50.76142F;
            this.dataGridViewTextBoxColumn3.HeaderText = "idAutoevaluacion";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // idPregunta
            // 
            this.idPregunta.HeaderText = "idPregunta";
            this.idPregunta.Name = "idPregunta";
            this.idPregunta.ReadOnly = true;
            this.idPregunta.Visible = false;
            // 
            // btnDetalleRespuesta
            // 
            this.btnDetalleRespuesta.BackColor = System.Drawing.Color.LightBlue;
            this.btnDetalleRespuesta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalleRespuesta.Location = new System.Drawing.Point(1094, 152);
            this.btnDetalleRespuesta.Name = "btnDetalleRespuesta";
            this.btnDetalleRespuesta.Size = new System.Drawing.Size(87, 44);
            this.btnDetalleRespuesta.TabIndex = 19;
            this.btnDetalleRespuesta.Text = "Ver detalles";
            this.btnDetalleRespuesta.UseVisualStyleBackColor = false;
            this.btnDetalleRespuesta.Click += new System.EventHandler(this.btnDetalleRespuesta_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.LightSalmon;
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(1094, 517);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(87, 38);
            this.btnVolver.TabIndex = 20;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblPreguntas
            // 
            this.lblPreguntas.AutoSize = true;
            this.lblPreguntas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreguntas.Location = new System.Drawing.Point(71, 38);
            this.lblPreguntas.Name = "lblPreguntas";
            this.lblPreguntas.Size = new System.Drawing.Size(57, 20);
            this.lblPreguntas.TabIndex = 21;
            this.lblPreguntas.Text = "label1";
            // 
            // lblRespuestas
            // 
            this.lblRespuestas.AutoSize = true;
            this.lblRespuestas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRespuestas.Location = new System.Drawing.Point(633, 38);
            this.lblRespuestas.Name = "lblRespuestas";
            this.lblRespuestas.Size = new System.Drawing.Size(232, 40);
            this.lblRespuestas.TabIndex = 22;
            this.lblRespuestas.Text = "Respuestas de la Pregunta:\r\nNinguna seleccionada.";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(182, 103);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(325, 20);
            this.textBox1.TabIndex = 23;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(72, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Buscar pregunta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(644, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Buscar respuesta:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(754, 99);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(325, 20);
            this.textBox2.TabIndex = 25;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(452, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(175, 104);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // RespuestasAutoevaluacionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1193, 567);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblRespuestas);
            this.Controls.Add(this.lblPreguntas);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnDetalleRespuesta);
            this.Controls.Add(this.dataGridPreguntas);
            this.Controls.Add(this.dataGridRespuestas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RespuestasAutoevaluacionView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Respuestas de la autoevaluación";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRespuestas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPreguntas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridRespuestas;
        private System.Windows.Forms.DataGridView dataGridPreguntas;
        private System.Windows.Forms.Button btnDetalleRespuesta;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Enunciado;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPregunta;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroFila;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Respuesta;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRespuesta;
        private System.Windows.Forms.Label lblPreguntas;
        private System.Windows.Forms.Label lblRespuestas;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}