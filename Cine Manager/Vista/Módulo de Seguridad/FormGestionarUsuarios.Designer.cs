namespace Vista.Módulo_de_Seguridad
{
    partial class FormGestionarUsuarios
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
            components = new System.ComponentModel.Container();
            groupBox1 = new GroupBox();
            btnSalir = new Button();
            groupBox2 = new GroupBox();
            btnBuscar = new Button();
            cmbEstado = new ComboBox();
            cmbGrupo = new ComboBox();
            txtNombre = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnResetear = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnAgregar = new Button();
            dgvUsuarios = new DataGridView();
            nombreUsuarioDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nombreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            apellidoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            estadoUsuarioDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            usuarioBindingSource = new BindingSource(components);
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            ((System.ComponentModel.ISupportInitialize)usuarioBindingSource).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnSalir);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(btnResetear);
            groupBox1.Controls.Add(btnModificar);
            groupBox1.Controls.Add(btnEliminar);
            groupBox1.Controls.Add(btnAgregar);
            groupBox1.Controls.Add(dgvUsuarios);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 398);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(684, 347);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 7;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnBuscar);
            groupBox2.Controls.Add(cmbEstado);
            groupBox2.Controls.Add(cmbGrupo);
            groupBox2.Controls.Add(txtNombre);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(20, 22);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(739, 64);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Filtros";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(638, 31);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 6;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Items.AddRange(new object[] { "Todos", "Activo", "Inactivo" });
            cmbEstado.Location = new Point(483, 30);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(121, 23);
            cmbEstado.TabIndex = 5;
            // 
            // cmbGrupo
            // 
            cmbGrupo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGrupo.FormattingEnabled = true;
            cmbGrupo.Items.AddRange(new object[] { "TODOS" });
            cmbGrupo.Location = new Point(275, 30);
            cmbGrupo.Name = "cmbGrupo";
            cmbGrupo.Size = new Size(121, 23);
            cmbGrupo.TabIndex = 4;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(103, 30);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(90, 23);
            txtNombre.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(420, 33);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 2;
            label3.Text = "Estado";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(214, 33);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 1;
            label2.Text = "Grupo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 35);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // btnResetear
            // 
            btnResetear.Location = new Point(319, 347);
            btnResetear.Name = "btnResetear";
            btnResetear.Size = new Size(86, 23);
            btnResetear.TabIndex = 4;
            btnResetear.Text = "Resetear";
            btnResetear.UseVisualStyleBackColor = true;
            btnResetear.Click += btnResetear_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(223, 347);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 3;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(123, 347);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(20, 347);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AutoGenerateColumns = false;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Columns.AddRange(new DataGridViewColumn[] { nombreUsuarioDataGridViewTextBoxColumn, nombreDataGridViewTextBoxColumn, apellidoDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, estadoUsuarioDataGridViewTextBoxColumn });
            dgvUsuarios.DataSource = usuarioBindingSource;
            dgvUsuarios.Location = new Point(20, 92);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.RowTemplate.Height = 25;
            dgvUsuarios.Size = new Size(739, 232);
            dgvUsuarios.TabIndex = 0;
            // 
            // nombreUsuarioDataGridViewTextBoxColumn
            // 
            nombreUsuarioDataGridViewTextBoxColumn.DataPropertyName = "NombreUsuario";
            nombreUsuarioDataGridViewTextBoxColumn.HeaderText = "Usuario";
            nombreUsuarioDataGridViewTextBoxColumn.Name = "nombreUsuarioDataGridViewTextBoxColumn";
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            // 
            // apellidoDataGridViewTextBoxColumn
            // 
            apellidoDataGridViewTextBoxColumn.DataPropertyName = "Apellido";
            apellidoDataGridViewTextBoxColumn.HeaderText = "Apellido";
            apellidoDataGridViewTextBoxColumn.Name = "apellidoDataGridViewTextBoxColumn";
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "E-mail";
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            // 
            // estadoUsuarioDataGridViewTextBoxColumn
            // 
            estadoUsuarioDataGridViewTextBoxColumn.DataPropertyName = "EstadoUsuario";
            estadoUsuarioDataGridViewTextBoxColumn.HeaderText = "Estado";
            estadoUsuarioDataGridViewTextBoxColumn.Name = "estadoUsuarioDataGridViewTextBoxColumn";
            // 
            // usuarioBindingSource
            // 
            usuarioBindingSource.DataSource = typeof(Modelo.Módulo_de_Seguridad.Usuario);
            // 
            // FormGestionarUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 425);
            Controls.Add(groupBox1);
            Name = "FormGestionarUsuarios";
            Text = "FormGestionarUsuarios";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ((System.ComponentModel.ISupportInitialize)usuarioBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ComboBox cmbEstado;
        private ComboBox cmbGrupo;
        private TextBox txtNombre;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnResetear;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnAgregar;
        private DataGridView dgvUsuarios;
        private Button btnBuscar;
        private Button btnSalir;
        private DataGridViewTextBoxColumn nombreUsuarioDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn apellidoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn estadoUsuarioDataGridViewTextBoxColumn;
        private BindingSource usuarioBindingSource;
    }
}