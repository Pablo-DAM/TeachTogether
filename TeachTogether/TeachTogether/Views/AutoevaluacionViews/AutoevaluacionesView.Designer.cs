namespace TeachTogether.Views
{
    partial class AutoevaluacionesView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoevaluacionesView));
            this.btnAñadirPregunta = new System.Windows.Forms.Button();
            this.dataGridPreguntas = new System.Windows.Forms.DataGridView();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Enunciado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPregunta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idAutoev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminarPregunta = new System.Windows.Forms.Button();
            this.btnEditarAuto = new System.Windows.Forms.Button();
            this.dataGridAutoevaluaciones = new System.Windows.Forms.DataGridView();
            this.NumeroFila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Título = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idAutoevaluacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idModulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminarAuto = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCrearAuto = new System.Windows.Forms.Button();
            this.btnDetalles = new System.Windows.Forms.Button();
            this.btnEditarPregunta = new System.Windows.Forms.Button();
            this.enviarTodos = new System.Windows.Forms.Button();
            this.btnEnviarUno = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelPregunta = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnAyuda = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPreguntas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAutoevaluaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAñadirPregunta
            // 
            this.btnAñadirPregunta.BackColor = System.Drawing.Color.LightGreen;
            this.btnAñadirPregunta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAñadirPregunta.Location = new System.Drawing.Point(1122, 203);
            this.btnAñadirPregunta.Name = "btnAñadirPregunta";
            this.btnAñadirPregunta.Size = new System.Drawing.Size(107, 45);
            this.btnAñadirPregunta.TabIndex = 7;
            this.btnAñadirPregunta.Text = "Añadir pregunta ";
            this.toolTip1.SetToolTip(this.btnAñadirPregunta, "Añade una pregunta a la autoevaluación seleccionada");
            this.btnAñadirPregunta.UseVisualStyleBackColor = false;
            this.btnAñadirPregunta.Click += new System.EventHandler(this.btnAñadirPregunta_Click);
            // 
            // dataGridPreguntas
            // 
            this.dataGridPreguntas.AllowUserToAddRows = false;
            this.dataGridPreguntas.AllowUserToDeleteRows = false;
            this.dataGridPreguntas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridPreguntas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridPreguntas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridPreguntas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPreguntas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numero,
            this.Enunciado,
            this.idPregunta,
            this.idAutoev});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridPreguntas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridPreguntas.Location = new System.Drawing.Point(637, 159);
            this.dataGridPreguntas.MultiSelect = false;
            this.dataGridPreguntas.Name = "dataGridPreguntas";
            this.dataGridPreguntas.ReadOnly = true;
            this.dataGridPreguntas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridPreguntas.Size = new System.Drawing.Size(479, 391);
            this.dataGridPreguntas.TabIndex = 17;
            this.dataGridPreguntas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridPreguntas_CellClick);
            // 
            // Numero
            // 
            this.Numero.FillWeight = 30.45685F;
            this.Numero.HeaderText = "Número";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            // 
            // Enunciado
            // 
            this.Enunciado.FillWeight = 169.5432F;
            this.Enunciado.HeaderText = "Enunciado";
            this.Enunciado.Name = "Enunciado";
            this.Enunciado.ReadOnly = true;
            // 
            // idPregunta
            // 
            this.idPregunta.HeaderText = "idPregunta";
            this.idPregunta.Name = "idPregunta";
            this.idPregunta.ReadOnly = true;
            this.idPregunta.Visible = false;
            // 
            // idAutoev
            // 
            this.idAutoev.HeaderText = "idAutoev";
            this.idAutoev.Name = "idAutoev";
            this.idAutoev.ReadOnly = true;
            this.idAutoev.Visible = false;
            // 
            // btnEliminarPregunta
            // 
            this.btnEliminarPregunta.BackColor = System.Drawing.Color.LightCoral;
            this.btnEliminarPregunta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarPregunta.Location = new System.Drawing.Point(1122, 407);
            this.btnEliminarPregunta.Name = "btnEliminarPregunta";
            this.btnEliminarPregunta.Size = new System.Drawing.Size(107, 45);
            this.btnEliminarPregunta.TabIndex = 10;
            this.btnEliminarPregunta.Text = "Eliminar pregunta";
            this.toolTip1.SetToolTip(this.btnEliminarPregunta, "Elimina la autoevaluación seleccionada");
            this.btnEliminarPregunta.UseVisualStyleBackColor = false;
            this.btnEliminarPregunta.Click += new System.EventHandler(this.btnEliminarPregunta_Click);
            // 
            // btnEditarAuto
            // 
            this.btnEditarAuto.BackColor = System.Drawing.Color.LightSalmon;
            this.btnEditarAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarAuto.Location = new System.Drawing.Point(524, 305);
            this.btnEditarAuto.Name = "btnEditarAuto";
            this.btnEditarAuto.Size = new System.Drawing.Size(107, 45);
            this.btnEditarAuto.TabIndex = 3;
            this.btnEditarAuto.Text = "Modificar título";
            this.toolTip1.SetToolTip(this.btnEditarAuto, "Modifica el título de la autoevaluación seleccionada");
            this.btnEditarAuto.UseVisualStyleBackColor = false;
            this.btnEditarAuto.Click += new System.EventHandler(this.btnEditarAuto_Click);
            // 
            // dataGridAutoevaluaciones
            // 
            this.dataGridAutoevaluaciones.AllowUserToAddRows = false;
            this.dataGridAutoevaluaciones.AllowUserToDeleteRows = false;
            this.dataGridAutoevaluaciones.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridAutoevaluaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridAutoevaluaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridAutoevaluaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAutoevaluaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumeroFila,
            this.Título,
            this.idAutoevaluacion,
            this.idModulo,
            this.modulo});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridAutoevaluaciones.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridAutoevaluaciones.Location = new System.Drawing.Point(23, 159);
            this.dataGridAutoevaluaciones.MultiSelect = false;
            this.dataGridAutoevaluaciones.Name = "dataGridAutoevaluaciones";
            this.dataGridAutoevaluaciones.ReadOnly = true;
            this.dataGridAutoevaluaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridAutoevaluaciones.Size = new System.Drawing.Size(495, 391);
            this.dataGridAutoevaluaciones.TabIndex = 16;
            this.dataGridAutoevaluaciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridAutoevaluaciones_CellClick);
            // 
            // NumeroFila
            // 
            this.NumeroFila.FillWeight = 25.30341F;
            this.NumeroFila.HeaderText = "Número";
            this.NumeroFila.Name = "NumeroFila";
            this.NumeroFila.ReadOnly = true;
            // 
            // Título
            // 
            this.Título.FillWeight = 223.9352F;
            this.Título.HeaderText = "Título";
            this.Título.Name = "Título";
            this.Título.ReadOnly = true;
            // 
            // idAutoevaluacion
            // 
            this.idAutoevaluacion.FillWeight = 50.76142F;
            this.idAutoevaluacion.HeaderText = "idAutoevaluacion";
            this.idAutoevaluacion.Name = "idAutoevaluacion";
            this.idAutoevaluacion.ReadOnly = true;
            this.idAutoevaluacion.Visible = false;
            // 
            // idModulo
            // 
            this.idModulo.HeaderText = "idModulo";
            this.idModulo.Name = "idModulo";
            this.idModulo.ReadOnly = true;
            this.idModulo.Visible = false;
            // 
            // modulo
            // 
            this.modulo.HeaderText = "Módulo";
            this.modulo.Name = "modulo";
            this.modulo.ReadOnly = true;
            // 
            // btnEliminarAuto
            // 
            this.btnEliminarAuto.BackColor = System.Drawing.Color.LightCoral;
            this.btnEliminarAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarAuto.Location = new System.Drawing.Point(524, 458);
            this.btnEliminarAuto.Name = "btnEliminarAuto";
            this.btnEliminarAuto.Size = new System.Drawing.Size(107, 45);
            this.btnEliminarAuto.TabIndex = 6;
            this.btnEliminarAuto.Text = "Eliminar autoevaluación";
            this.toolTip1.SetToolTip(this.btnEliminarAuto, "Elimina la autoevaluación seleccionada");
            this.btnEliminarAuto.UseVisualStyleBackColor = false;
            this.btnEliminarAuto.Click += new System.EventHandler(this.btnEliminarAuto_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.LightSalmon;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(1122, 515);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(107, 37);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "Volver";
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(488, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(175, 104);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // btnCrearAuto
            // 
            this.btnCrearAuto.BackColor = System.Drawing.Color.LightGreen;
            this.btnCrearAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearAuto.Location = new System.Drawing.Point(524, 203);
            this.btnCrearAuto.Name = "btnCrearAuto";
            this.btnCrearAuto.Size = new System.Drawing.Size(107, 45);
            this.btnCrearAuto.TabIndex = 1;
            this.btnCrearAuto.Text = "Nueva autoevaluación";
            this.toolTip1.SetToolTip(this.btnCrearAuto, "Crea una nueva autoevaluación");
            this.btnCrearAuto.UseVisualStyleBackColor = false;
            this.btnCrearAuto.Click += new System.EventHandler(this.btnCrearAuto_Click);
            // 
            // btnDetalles
            // 
            this.btnDetalles.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnDetalles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalles.Location = new System.Drawing.Point(524, 254);
            this.btnDetalles.Name = "btnDetalles";
            this.btnDetalles.Size = new System.Drawing.Size(107, 45);
            this.btnDetalles.TabIndex = 2;
            this.btnDetalles.Text = "Ver detalles";
            this.toolTip1.SetToolTip(this.btnDetalles, "Muestra y gestiona todas las autievaluaciones en profundidad");
            this.btnDetalles.UseVisualStyleBackColor = false;
            this.btnDetalles.Click += new System.EventHandler(this.btnVerRespuestas_Click);
            // 
            // btnEditarPregunta
            // 
            this.btnEditarPregunta.BackColor = System.Drawing.Color.LightSalmon;
            this.btnEditarPregunta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarPregunta.Location = new System.Drawing.Point(1122, 305);
            this.btnEditarPregunta.Name = "btnEditarPregunta";
            this.btnEditarPregunta.Size = new System.Drawing.Size(107, 45);
            this.btnEditarPregunta.TabIndex = 8;
            this.btnEditarPregunta.Text = "Ver/Editar";
            this.toolTip1.SetToolTip(this.btnEditarPregunta, "Muestra o edita la pregunta seleccionada");
            this.btnEditarPregunta.UseVisualStyleBackColor = false;
            this.btnEditarPregunta.Click += new System.EventHandler(this.btnEditarPregunta_Click);
            // 
            // enviarTodos
            // 
            this.enviarTodos.BackColor = System.Drawing.Color.Thistle;
            this.enviarTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enviarTodos.Location = new System.Drawing.Point(524, 407);
            this.enviarTodos.Name = "enviarTodos";
            this.enviarTodos.Size = new System.Drawing.Size(107, 45);
            this.enviarTodos.TabIndex = 5;
            this.enviarTodos.Text = "Enviar a todos los alumnos";
            this.toolTip1.SetToolTip(this.enviarTodos, "Envía a todos los alumnos del módulo la autoevaluación seleccionada");
            this.enviarTodos.UseVisualStyleBackColor = false;
            this.enviarTodos.Click += new System.EventHandler(this.enviarTodos_Click);
            // 
            // btnEnviarUno
            // 
            this.btnEnviarUno.BackColor = System.Drawing.Color.LightYellow;
            this.btnEnviarUno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviarUno.Location = new System.Drawing.Point(524, 356);
            this.btnEnviarUno.Name = "btnEnviarUno";
            this.btnEnviarUno.Size = new System.Drawing.Size(107, 45);
            this.btnEnviarUno.TabIndex = 4;
            this.btnEnviarUno.Text = "Enviar a...";
            this.toolTip1.SetToolTip(this.btnEnviarUno, "Envía a un alumno del módulo la autoevaluación seleccionada");
            this.btnEnviarUno.UseVisualStyleBackColor = false;
            this.btnEnviarUno.Click += new System.EventHandler(this.btnEnviarUno_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(193, 118);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(326, 20);
            this.textBox1.TabIndex = 30;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Buscar autoevaluación:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(680, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Buscar pregunta:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(790, 114);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(326, 20);
            this.textBox2.TabIndex = 32;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(161, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 24);
            this.label3.TabIndex = 34;
            this.label3.Text = "Mis Autoevaluaciones";
            // 
            // labelPregunta
            // 
            this.labelPregunta.AutoSize = true;
            this.labelPregunta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPregunta.Location = new System.Drawing.Point(708, 46);
            this.labelPregunta.Name = "labelPregunta";
            this.labelPregunta.Size = new System.Drawing.Size(397, 24);
            this.labelPregunta.TabIndex = 35;
            this.labelPregunta.Text = "Preguntas de la Autoevaluación: Ninguna";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 555);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1241, 22);
            this.statusStrip1.TabIndex = 36;
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
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(101, 17);
            this.toolStripStatusLabel3.Text = "Autoevaluaciones";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(60, 17);
            this.toolStripStatusLabel4.Text = "Preguntas";
            // 
            // btnAyuda
            // 
            this.btnAyuda.BackColor = System.Drawing.Color.LightBlue;
            this.btnAyuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAyuda.Location = new System.Drawing.Point(1122, 12);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(107, 45);
            this.btnAyuda.TabIndex = 37;
            this.btnAyuda.Text = "Ayuda";
            this.toolTip1.SetToolTip(this.btnAyuda, "Muestra la ayuda interactiva");
            this.btnAyuda.UseVisualStyleBackColor = false;
            this.btnAyuda.Click += new System.EventHandler(this.btnAyuda_Click);
            // 
            // AutoevaluacionesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1241, 577);
            this.Controls.Add(this.btnAyuda);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.labelPregunta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnEnviarUno);
            this.Controls.Add(this.enviarTodos);
            this.Controls.Add(this.btnEditarPregunta);
            this.Controls.Add(this.btnDetalles);
            this.Controls.Add(this.btnCrearAuto);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAñadirPregunta);
            this.Controls.Add(this.dataGridPreguntas);
            this.Controls.Add(this.btnEliminarPregunta);
            this.Controls.Add(this.btnEditarAuto);
            this.Controls.Add(this.dataGridAutoevaluaciones);
            this.Controls.Add(this.btnEliminarAuto);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AutoevaluacionesView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autoevaluaciones";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPreguntas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAutoevaluaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAñadirPregunta;
        private System.Windows.Forms.DataGridView dataGridPreguntas;
        private System.Windows.Forms.Button btnEliminarPregunta;
        private System.Windows.Forms.Button btnEditarAuto;
        private System.Windows.Forms.DataGridView dataGridAutoevaluaciones;
        private System.Windows.Forms.Button btnEliminarAuto;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCrearAuto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Enunciado;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPregunta;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAutoev;
        private System.Windows.Forms.Button btnDetalles;
        private System.Windows.Forms.Button btnEditarPregunta;
        private System.Windows.Forms.Button enviarTodos;
        private System.Windows.Forms.Button btnEnviarUno;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroFila;
        private System.Windows.Forms.DataGridViewTextBoxColumn Título;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAutoevaluacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn idModulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn modulo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelPregunta;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.Button btnAyuda;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}