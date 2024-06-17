namespace TeachTogether.Views
{
    partial class MensajesView
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
            System.Windows.Forms.Label label2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MensajesView));
            this.dataGridViewMensajesRecibidos = new System.Windows.Forms.DataGridView();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mensaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idMensaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewMensajesEnviados = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idReceptor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MensajeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnBorrarMensaje = new System.Windows.Forms.Button();
            this.btnSeleccionarMensajeEnviado = new System.Windows.Forms.Button();
            this.btnBorraMensajeEnviado = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCrearMensaje = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtFiltroRecibidos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFiltroEnviados = new System.Windows.Forms.TextBox();
            this.btnAyuda = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMensajesRecibidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMensajesEnviados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(838, 85);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(139, 13);
            label2.TabIndex = 8;
            label2.Text = "MENSAJES ENVIADOS";
            // 
            // dataGridViewMensajesRecibidos
            // 
            this.dataGridViewMensajesRecibidos.AllowUserToAddRows = false;
            this.dataGridViewMensajesRecibidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMensajesRecibidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMensajesRecibidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Usuario,
            this.Nombre,
            this.Apellidos,
            this.Mensaje,
            this.Fecha,
            this.idMensaje});
            this.dataGridViewMensajesRecibidos.Location = new System.Drawing.Point(12, 138);
            this.dataGridViewMensajesRecibidos.MultiSelect = false;
            this.dataGridViewMensajesRecibidos.Name = "dataGridViewMensajesRecibidos";
            this.dataGridViewMensajesRecibidos.ReadOnly = true;
            this.dataGridViewMensajesRecibidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMensajesRecibidos.Size = new System.Drawing.Size(530, 408);
            this.dataGridViewMensajesRecibidos.TabIndex = 0;
            this.dataGridViewMensajesRecibidos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMensajesRecibidos_CellContentDoubleClick);
            // 
            // Usuario
            // 
            this.Usuario.FillWeight = 83.44009F;
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.FillWeight = 96.55209F;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Apellidos
            // 
            this.Apellidos.FillWeight = 96.55209F;
            this.Apellidos.HeaderText = "Apellidos";
            this.Apellidos.Name = "Apellidos";
            this.Apellidos.ReadOnly = true;
            // 
            // Mensaje
            // 
            this.Mensaje.FillWeight = 96.55209F;
            this.Mensaje.HeaderText = "Mensaje";
            this.Mensaje.Name = "Mensaje";
            this.Mensaje.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.FillWeight = 126.9035F;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // idMensaje
            // 
            this.idMensaje.HeaderText = "idMensaje";
            this.idMensaje.Name = "idMensaje";
            this.idMensaje.ReadOnly = true;
            this.idMensaje.Visible = false;
            // 
            // dataGridViewMensajesEnviados
            // 
            this.dataGridViewMensajesEnviados.AllowUserToAddRows = false;
            this.dataGridViewMensajesEnviados.AllowUserToDeleteRows = false;
            this.dataGridViewMensajesEnviados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMensajesEnviados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMensajesEnviados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.idReceptor,
            this.MensajeId});
            this.dataGridViewMensajesEnviados.Location = new System.Drawing.Point(637, 138);
            this.dataGridViewMensajesEnviados.MultiSelect = false;
            this.dataGridViewMensajesEnviados.Name = "dataGridViewMensajesEnviados";
            this.dataGridViewMensajesEnviados.ReadOnly = true;
            this.dataGridViewMensajesEnviados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMensajesEnviados.Size = new System.Drawing.Size(533, 408);
            this.dataGridViewMensajesEnviados.TabIndex = 1;
            this.dataGridViewMensajesEnviados.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMensajesEnviados_CellContentDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 93.27411F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Usuario";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 93.27411F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.FillWeight = 93.27411F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Apellidos";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.FillWeight = 93.27411F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Mensaje";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.FillWeight = 126.9036F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Fecha";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // idReceptor
            // 
            this.idReceptor.HeaderText = "idReceptor";
            this.idReceptor.Name = "idReceptor";
            this.idReceptor.ReadOnly = true;
            this.idReceptor.Visible = false;
            // 
            // MensajeId
            // 
            this.MensajeId.HeaderText = "MensajeId";
            this.MensajeId.Name = "MensajeId";
            this.MensajeId.ReadOnly = true;
            this.MensajeId.Visible = false;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.BackColor = System.Drawing.Color.LightBlue;
            this.btnSeleccionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionar.Location = new System.Drawing.Point(548, 255);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(75, 50);
            this.btnSeleccionar.TabIndex = 2;
            this.btnSeleccionar.Text = "Mostrar mensaje";
            this.toolTip1.SetToolTip(this.btnSeleccionar, "Muestra el mensaje recibido seleccionado");
            this.btnSeleccionar.UseVisualStyleBackColor = false;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.LightSalmon;
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(1176, 496);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 50);
            this.btnVolver.TabIndex = 3;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnBorrarMensaje
            // 
            this.btnBorrarMensaje.BackColor = System.Drawing.Color.LightCoral;
            this.btnBorrarMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarMensaje.Location = new System.Drawing.Point(548, 335);
            this.btnBorrarMensaje.Name = "btnBorrarMensaje";
            this.btnBorrarMensaje.Size = new System.Drawing.Size(75, 50);
            this.btnBorrarMensaje.TabIndex = 3;
            this.btnBorrarMensaje.Text = "Borrar mensaje";
            this.toolTip1.SetToolTip(this.btnBorrarMensaje, "Borra el mensaje recibido seleccionado");
            this.btnBorrarMensaje.UseVisualStyleBackColor = false;
            this.btnBorrarMensaje.Click += new System.EventHandler(this.btnBorrarMensaje_Click);
            // 
            // btnSeleccionarMensajeEnviado
            // 
            this.btnSeleccionarMensajeEnviado.BackColor = System.Drawing.Color.LightBlue;
            this.btnSeleccionarMensajeEnviado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarMensajeEnviado.Location = new System.Drawing.Point(1176, 255);
            this.btnSeleccionarMensajeEnviado.Name = "btnSeleccionarMensajeEnviado";
            this.btnSeleccionarMensajeEnviado.Size = new System.Drawing.Size(75, 50);
            this.btnSeleccionarMensajeEnviado.TabIndex = 4;
            this.btnSeleccionarMensajeEnviado.Text = "Mostrar mensaje";
            this.toolTip1.SetToolTip(this.btnSeleccionarMensajeEnviado, "Muestra el mensaje enviado seleccionado");
            this.btnSeleccionarMensajeEnviado.UseVisualStyleBackColor = false;
            this.btnSeleccionarMensajeEnviado.Click += new System.EventHandler(this.btnSeleccionarMensajeEnviado_Click);
            // 
            // btnBorraMensajeEnviado
            // 
            this.btnBorraMensajeEnviado.BackColor = System.Drawing.Color.LightCoral;
            this.btnBorraMensajeEnviado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorraMensajeEnviado.Location = new System.Drawing.Point(1176, 335);
            this.btnBorraMensajeEnviado.Name = "btnBorraMensajeEnviado";
            this.btnBorraMensajeEnviado.Size = new System.Drawing.Size(75, 50);
            this.btnBorraMensajeEnviado.TabIndex = 5;
            this.btnBorraMensajeEnviado.Text = "Borrar mensaje";
            this.toolTip1.SetToolTip(this.btnBorraMensajeEnviado, "Borra el mensaje enviado seleccionado");
            this.btnBorraMensajeEnviado.UseVisualStyleBackColor = false;
            this.btnBorraMensajeEnviado.Click += new System.EventHandler(this.btnBorraMensajeEnviado_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(207, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "MENSAJES RECIBIDOS";
            // 
            // btnCrearMensaje
            // 
            this.btnCrearMensaje.BackColor = System.Drawing.Color.LightGreen;
            this.btnCrearMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearMensaje.Location = new System.Drawing.Point(548, 181);
            this.btnCrearMensaje.Name = "btnCrearMensaje";
            this.btnCrearMensaje.Size = new System.Drawing.Size(75, 48);
            this.btnCrearMensaje.TabIndex = 1;
            this.btnCrearMensaje.Text = "Escribir mensaje";
            this.toolTip1.SetToolTip(this.btnCrearMensaje, "Escribe un nuevo mensaje");
            this.btnCrearMensaje.UseVisualStyleBackColor = false;
            this.btnCrearMensaje.Click += new System.EventHandler(this.btnCrearMensaje_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(501, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(175, 104);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // txtFiltroRecibidos
            // 
            this.txtFiltroRecibidos.Location = new System.Drawing.Point(210, 112);
            this.txtFiltroRecibidos.Name = "txtFiltroRecibidos";
            this.txtFiltroRecibidos.Size = new System.Drawing.Size(332, 20);
            this.txtFiltroRecibidos.TabIndex = 10;
            this.txtFiltroRecibidos.TextChanged += new System.EventHandler(this.txtFiltroRecibidos_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(55, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Buscar mensaje recibido:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(683, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Buscar mensaje enviado:";
            // 
            // txtFiltroEnviados
            // 
            this.txtFiltroEnviados.Location = new System.Drawing.Point(838, 115);
            this.txtFiltroEnviados.Name = "txtFiltroEnviados";
            this.txtFiltroEnviados.Size = new System.Drawing.Size(332, 20);
            this.txtFiltroEnviados.TabIndex = 12;
            this.txtFiltroEnviados.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnAyuda
            // 
            this.btnAyuda.BackColor = System.Drawing.Color.LightBlue;
            this.btnAyuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAyuda.Location = new System.Drawing.Point(1111, 12);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(140, 45);
            this.btnAyuda.TabIndex = 14;
            this.btnAyuda.Text = "Ayuda";
            this.toolTip1.SetToolTip(this.btnAyuda, "Muestra la ayuda interactiva");
            this.btnAyuda.UseVisualStyleBackColor = false;
            this.btnAyuda.Click += new System.EventHandler(this.btnAyuda_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 549);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1263, 22);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(33, 17);
            this.toolStripStatusLabel1.Text = "Hora";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(38, 17);
            this.toolStripStatusLabel2.Text = "Fecha";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(107, 17);
            this.toolStripStatusLabel3.Text = "Mensajes recibidos";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(106, 17);
            this.toolStripStatusLabel4.Text = "Mensajes enviados";
            // 
            // MensajesView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1263, 571);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnAyuda);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFiltroEnviados);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFiltroRecibidos);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCrearMensaje);
            this.Controls.Add(label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBorraMensajeEnviado);
            this.Controls.Add(this.btnSeleccionarMensajeEnviado);
            this.Controls.Add(this.btnBorrarMensaje);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.dataGridViewMensajesEnviados);
            this.Controls.Add(this.dataGridViewMensajesRecibidos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MensajesView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mensajes";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMensajesRecibidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMensajesEnviados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMensajesRecibidos;
        private System.Windows.Forms.DataGridView dataGridViewMensajesEnviados;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnBorrarMensaje;
        private System.Windows.Forms.Button btnSeleccionarMensajeEnviado;
        private System.Windows.Forms.Button btnBorraMensajeEnviado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCrearMensaje;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtFiltroRecibidos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFiltroEnviados;
        private System.Windows.Forms.Button btnAyuda;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mensaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMensaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn idReceptor;
        private System.Windows.Forms.DataGridViewTextBoxColumn MensajeId;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}