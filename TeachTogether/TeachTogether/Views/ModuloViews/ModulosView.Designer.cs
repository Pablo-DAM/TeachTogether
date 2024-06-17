namespace TeachTogether
{
    partial class ModulosView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModulosView));
            this.btnEditarModulo = new System.Windows.Forms.Button();
            this.btnEliminarMod = new System.Windows.Forms.Button();
            this.btnAgregarModulo = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dataGridUsuariosModulo = new System.Windows.Forms.DataGridView();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreAlumno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaNacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idAlumno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModuloId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridModulos = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Horario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Horas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Código = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idModulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAyuda = new System.Windows.Forms.Button();
            this.btnEliminarUsuarioDelModulo = new System.Windows.Forms.Button();
            this.btnAñadirAlumno = new System.Windows.Forms.Button();
            this.btnMostrarTodos = new System.Windows.Forms.Button();
            this.lblModuloSeleccionado = new System.Windows.Forms.Label();
            this.btnEnviarCodigo = new System.Windows.Forms.Button();
            this.lblMisModulos = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFiltroModulos = new System.Windows.Forms.TextBox();
            this.txtFiltroUsuarios = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsuariosModulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridModulos)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEditarModulo
            // 
            this.btnEditarModulo.BackColor = System.Drawing.Color.LightSalmon;
            this.btnEditarModulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarModulo.Location = new System.Drawing.Point(526, 275);
            this.btnEditarModulo.Name = "btnEditarModulo";
            this.btnEditarModulo.Size = new System.Drawing.Size(94, 45);
            this.btnEditarModulo.TabIndex = 5;
            this.btnEditarModulo.Text = "Editar módulo";
            this.toolTip1.SetToolTip(this.btnEditarModulo, "Edita el módulo seleccionado");
            this.btnEditarModulo.UseVisualStyleBackColor = false;
            this.btnEditarModulo.Click += new System.EventHandler(this.btnSeleccionarModulo_Click);
            // 
            // btnEliminarMod
            // 
            this.btnEliminarMod.BackColor = System.Drawing.Color.LightCoral;
            this.btnEliminarMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarMod.Location = new System.Drawing.Point(526, 366);
            this.btnEliminarMod.Name = "btnEliminarMod";
            this.btnEliminarMod.Size = new System.Drawing.Size(94, 45);
            this.btnEliminarMod.TabIndex = 12;
            this.btnEliminarMod.Text = "Eliminar Módulo";
            this.toolTip1.SetToolTip(this.btnEliminarMod, "Elimina el módulo seleccionado");
            this.btnEliminarMod.UseVisualStyleBackColor = false;
            this.btnEliminarMod.Click += new System.EventHandler(this.btnEliminarMod_Click);
            // 
            // btnAgregarModulo
            // 
            this.btnAgregarModulo.BackColor = System.Drawing.Color.LightGreen;
            this.btnAgregarModulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarModulo.Location = new System.Drawing.Point(526, 184);
            this.btnAgregarModulo.Name = "btnAgregarModulo";
            this.btnAgregarModulo.Size = new System.Drawing.Size(94, 45);
            this.btnAgregarModulo.TabIndex = 13;
            this.btnAgregarModulo.Text = "Nuevo Módulo";
            this.toolTip1.SetToolTip(this.btnAgregarModulo, "Crea un nuevo módulo");
            this.btnAgregarModulo.UseVisualStyleBackColor = false;
            this.btnAgregarModulo.Click += new System.EventHandler(this.btnAgregarModulo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.LightSalmon;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(1116, 461);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(71, 30);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Volver";
            this.toolTip1.SetToolTip(this.btnSalir, "Volver");
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dataGridUsuariosModulo
            // 
            this.dataGridUsuariosModulo.AllowUserToAddRows = false;
            this.dataGridUsuariosModulo.AllowUserToDeleteRows = false;
            this.dataGridUsuariosModulo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridUsuariosModulo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridUsuariosModulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridUsuariosModulo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Usuario,
            this.NombreAlumno,
            this.Apellidos,
            this.FechaNacimiento,
            this.idAlumno,
            this.ModuloId,
            this.modulo});
            this.dataGridUsuariosModulo.Location = new System.Drawing.Point(631, 170);
            this.dataGridUsuariosModulo.MultiSelect = false;
            this.dataGridUsuariosModulo.Name = "dataGridUsuariosModulo";
            this.dataGridUsuariosModulo.ReadOnly = true;
            this.dataGridUsuariosModulo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridUsuariosModulo.Size = new System.Drawing.Size(479, 348);
            this.dataGridUsuariosModulo.TabIndex = 2;
            // 
            // Usuario
            // 
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            // 
            // NombreAlumno
            // 
            this.NombreAlumno.HeaderText = "Nombre";
            this.NombreAlumno.Name = "NombreAlumno";
            this.NombreAlumno.ReadOnly = true;
            // 
            // Apellidos
            // 
            this.Apellidos.HeaderText = "Apellidos";
            this.Apellidos.Name = "Apellidos";
            this.Apellidos.ReadOnly = true;
            // 
            // FechaNacimiento
            // 
            this.FechaNacimiento.HeaderText = "Fecha de Nacimiento";
            this.FechaNacimiento.Name = "FechaNacimiento";
            this.FechaNacimiento.ReadOnly = true;
            // 
            // idAlumno
            // 
            this.idAlumno.HeaderText = "idAlumno";
            this.idAlumno.Name = "idAlumno";
            this.idAlumno.ReadOnly = true;
            this.idAlumno.Visible = false;
            // 
            // ModuloId
            // 
            this.ModuloId.HeaderText = "ModuloId";
            this.ModuloId.Name = "ModuloId";
            this.ModuloId.ReadOnly = true;
            this.ModuloId.Visible = false;
            // 
            // modulo
            // 
            this.modulo.HeaderText = "Módulo";
            this.modulo.Name = "modulo";
            this.modulo.ReadOnly = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(487, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(175, 104);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridModulos
            // 
            this.dataGridModulos.AllowUserToAddRows = false;
            this.dataGridModulos.AllowUserToDeleteRows = false;
            this.dataGridModulos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridModulos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridModulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridModulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.dias,
            this.Horario,
            this.Horas,
            this.Código,
            this.idModulo});
            this.dataGridModulos.Location = new System.Drawing.Point(12, 170);
            this.dataGridModulos.Name = "dataGridModulos";
            this.dataGridModulos.ReadOnly = true;
            this.dataGridModulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridModulos.Size = new System.Drawing.Size(508, 348);
            this.dataGridModulos.TabIndex = 1;
            this.dataGridModulos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridModulos_CellClick);
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // dias
            // 
            this.dias.HeaderText = "Días";
            this.dias.Name = "dias";
            this.dias.ReadOnly = true;
            // 
            // Horario
            // 
            this.Horario.HeaderText = "Horario";
            this.Horario.Name = "Horario";
            this.Horario.ReadOnly = true;
            // 
            // Horas
            // 
            this.Horas.HeaderText = "Horas";
            this.Horas.Name = "Horas";
            this.Horas.ReadOnly = true;
            // 
            // Código
            // 
            this.Código.HeaderText = "Código";
            this.Código.Name = "Código";
            this.Código.ReadOnly = true;
            // 
            // idModulo
            // 
            this.idModulo.HeaderText = "idmodulo";
            this.idModulo.Name = "idModulo";
            this.idModulo.ReadOnly = true;
            this.idModulo.Visible = false;
            // 
            // btnAyuda
            // 
            this.btnAyuda.BackColor = System.Drawing.Color.LightBlue;
            this.btnAyuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAyuda.Location = new System.Drawing.Point(1047, 12);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(140, 45);
            this.btnAyuda.TabIndex = 6;
            this.btnAyuda.Text = "Ayuda";
            this.toolTip1.SetToolTip(this.btnAyuda, "muestra la Ayuda interactiva");
            this.btnAyuda.UseVisualStyleBackColor = false;
            this.btnAyuda.Click += new System.EventHandler(this.btnAyuda_Click);
            // 
            // btnEliminarUsuarioDelModulo
            // 
            this.btnEliminarUsuarioDelModulo.BackColor = System.Drawing.Color.LightCoral;
            this.btnEliminarUsuarioDelModulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarUsuarioDelModulo.Location = new System.Drawing.Point(1116, 358);
            this.btnEliminarUsuarioDelModulo.Name = "btnEliminarUsuarioDelModulo";
            this.btnEliminarUsuarioDelModulo.Size = new System.Drawing.Size(71, 69);
            this.btnEliminarUsuarioDelModulo.TabIndex = 11;
            this.btnEliminarUsuarioDelModulo.Text = "Eliminar alumno del módulo";
            this.toolTip1.SetToolTip(this.btnEliminarUsuarioDelModulo, "Elimina el alumno del modulo seleccionado");
            this.btnEliminarUsuarioDelModulo.UseVisualStyleBackColor = false;
            this.btnEliminarUsuarioDelModulo.Click += new System.EventHandler(this.btnEliminarUsuarioDelModulo_Click);
            // 
            // btnAñadirAlumno
            // 
            this.btnAñadirAlumno.BackColor = System.Drawing.Color.LightGreen;
            this.btnAñadirAlumno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAñadirAlumno.Location = new System.Drawing.Point(1116, 172);
            this.btnAñadirAlumno.Name = "btnAñadirAlumno";
            this.btnAñadirAlumno.Size = new System.Drawing.Size(71, 69);
            this.btnAñadirAlumno.TabIndex = 14;
            this.btnAñadirAlumno.Text = "Añadir alumno al módulo";
            this.toolTip1.SetToolTip(this.btnAñadirAlumno, "Añade un usuario al módulo seleccionado");
            this.btnAñadirAlumno.UseVisualStyleBackColor = false;
            this.btnAñadirAlumno.Click += new System.EventHandler(this.btnAñadirAlumno_Click);
            // 
            // btnMostrarTodos
            // 
            this.btnMostrarTodos.BackColor = System.Drawing.Color.LightSalmon;
            this.btnMostrarTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarTodos.Location = new System.Drawing.Point(1116, 263);
            this.btnMostrarTodos.Name = "btnMostrarTodos";
            this.btnMostrarTodos.Size = new System.Drawing.Size(71, 69);
            this.btnMostrarTodos.TabIndex = 15;
            this.btnMostrarTodos.Text = "Mostrar todos mis alumnos";
            this.toolTip1.SetToolTip(this.btnMostrarTodos, "Muestra todos los alumnos de tus módulos");
            this.btnMostrarTodos.UseVisualStyleBackColor = false;
            this.btnMostrarTodos.Click += new System.EventHandler(this.btnMostrarTodos_Click);
            // 
            // lblModuloSeleccionado
            // 
            this.lblModuloSeleccionado.AutoSize = true;
            this.lblModuloSeleccionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModuloSeleccionado.Location = new System.Drawing.Point(750, 108);
            this.lblModuloSeleccionado.Name = "lblModuloSeleccionado";
            this.lblModuloSeleccionado.Size = new System.Drawing.Size(241, 18);
            this.lblModuloSeleccionado.TabIndex = 16;
            this.lblModuloSeleccionado.Text = "Módulo seleccionado: Ninguno";
            // 
            // btnEnviarCodigo
            // 
            this.btnEnviarCodigo.BackColor = System.Drawing.Color.Gold;
            this.btnEnviarCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviarCodigo.Location = new System.Drawing.Point(526, 434);
            this.btnEnviarCodigo.Name = "btnEnviarCodigo";
            this.btnEnviarCodigo.Size = new System.Drawing.Size(94, 34);
            this.btnEnviarCodigo.TabIndex = 17;
            this.btnEnviarCodigo.Text = "Enviar Código";
            this.toolTip1.SetToolTip(this.btnEnviarCodigo, "Envía el código del módulo a cualquier usuario para que pueda registrarse si lo d" +
        "esea");
            this.btnEnviarCodigo.UseVisualStyleBackColor = false;
            this.btnEnviarCodigo.Click += new System.EventHandler(this.btnEnviarCodigo_Click);
            // 
            // lblMisModulos
            // 
            this.lblMisModulos.AutoSize = true;
            this.lblMisModulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMisModulos.Location = new System.Drawing.Point(189, 108);
            this.lblMisModulos.Name = "lblMisModulos";
            this.lblMisModulos.Size = new System.Drawing.Size(105, 18);
            this.lblMisModulos.TabIndex = 18;
            this.lblMisModulos.Text = "Mis módulos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Buscar módulo:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtFiltroModulos
            // 
            this.txtFiltroModulos.Location = new System.Drawing.Point(152, 144);
            this.txtFiltroModulos.Name = "txtFiltroModulos";
            this.txtFiltroModulos.Size = new System.Drawing.Size(368, 20);
            this.txtFiltroModulos.TabIndex = 20;
            this.txtFiltroModulos.TextChanged += new System.EventHandler(this.txtFiltroModulos_TextChanged);
            // 
            // txtFiltroUsuarios
            // 
            this.txtFiltroUsuarios.Location = new System.Drawing.Point(742, 144);
            this.txtFiltroUsuarios.Name = "txtFiltroUsuarios";
            this.txtFiltroUsuarios.Size = new System.Drawing.Size(368, 20);
            this.txtFiltroUsuarios.TabIndex = 22;
            this.txtFiltroUsuarios.TextChanged += new System.EventHandler(this.txtFiltroUsuarios_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(642, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Buscar alumno:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 508);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1192, 22);
            this.statusStrip1.TabIndex = 23;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(33, 17);
            this.toolStripStatusLabel1.Text = "Hora";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
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
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(54, 17);
            this.toolStripStatusLabel3.Text = "Módulos";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(55, 17);
            this.toolStripStatusLabel4.Text = "Alumnos";
            // 
            // ModulosView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1192, 530);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtFiltroUsuarios);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFiltroModulos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMisModulos);
            this.Controls.Add(this.btnEnviarCodigo);
            this.Controls.Add(this.lblModuloSeleccionado);
            this.Controls.Add(this.btnMostrarTodos);
            this.Controls.Add(this.btnAñadirAlumno);
            this.Controls.Add(this.dataGridUsuariosModulo);
            this.Controls.Add(this.btnEliminarUsuarioDelModulo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAyuda);
            this.Controls.Add(this.btnEditarModulo);
            this.Controls.Add(this.dataGridModulos);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAgregarModulo);
            this.Controls.Add(this.btnEliminarMod);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModulosView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Módulos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsuariosModulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridModulos)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnEditarModulo;
        private System.Windows.Forms.Button btnEliminarMod;
        private System.Windows.Forms.Button btnAgregarModulo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dataGridUsuariosModulo;
        private System.Windows.Forms.Button btnEliminarUsuarioDelModulo;
        private System.Windows.Forms.Button btnAyuda;
        private System.Windows.Forms.DataGridView dataGridModulos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn dias;
        private System.Windows.Forms.DataGridViewTextBoxColumn Horario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Horas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Código;
        private System.Windows.Forms.DataGridViewTextBoxColumn idModulo;
        private System.Windows.Forms.Button btnAñadirAlumno;
        private System.Windows.Forms.Button btnMostrarTodos;
        private System.Windows.Forms.Label lblModuloSeleccionado;
        private System.Windows.Forms.Button btnEnviarCodigo;
        private System.Windows.Forms.Label lblMisModulos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFiltroModulos;
        private System.Windows.Forms.TextBox txtFiltroUsuarios;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreAlumno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaNacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAlumno;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModuloId;
        private System.Windows.Forms.DataGridViewTextBoxColumn modulo;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}