namespace Vista.Módulo_de_Seguridad
{
    partial class FormGestionarGrupos
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
            textBox1 = new TextBox();
            label3 = new Label();
            label1 = new Label();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnAgregar = new Button();
            dgvGrupos = new DataGridView();
            codigoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            NombreGrupo = new DataGridViewTextBoxColumn();
            EstadoGrupo = new DataGridViewTextBoxColumn();
            grupoBindingSource = new BindingSource(components);
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGrupos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grupoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnSalir);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(btnModificar);
            groupBox1.Controls.Add(btnEliminar);
            groupBox1.Controls.Add(btnAgregar);
            groupBox1.Controls.Add(dgvGrupos);
            groupBox1.Location = new Point(12, 26);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 398);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(684, 360);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 6;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnBuscar);
            groupBox2.Controls.Add(cmbEstado);
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(label3);
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
            btnBuscar.Location = new Point(589, 24);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(93, 23);
            btnBuscar.TabIndex = 16;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // cmbEstado
            // 
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Items.AddRange(new object[] { "Activo", "Inactivo" });
            cmbEstado.Location = new Point(374, 24);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(121, 23);
            cmbEstado.TabIndex = 5;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(103, 30);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(123, 23);
            textBox1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(303, 30);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 2;
            label3.Text = "Estado";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 32);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
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
            // dgvGrupos
            // 
            dgvGrupos.AutoGenerateColumns = false;
            dgvGrupos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGrupos.Columns.AddRange(new DataGridViewColumn[] { codigoDataGridViewTextBoxColumn, NombreGrupo, EstadoGrupo });
            dgvGrupos.DataSource = grupoBindingSource;
            dgvGrupos.Location = new Point(20, 92);
            dgvGrupos.Name = "dgvGrupos";
            dgvGrupos.RowTemplate.Height = 25;
            dgvGrupos.Size = new Size(739, 232);
            dgvGrupos.TabIndex = 0;
            // 
            // codigoDataGridViewTextBoxColumn
            // 
            codigoDataGridViewTextBoxColumn.DataPropertyName = "Codigo";
            codigoDataGridViewTextBoxColumn.HeaderText = "Codigo";
            codigoDataGridViewTextBoxColumn.Name = "codigoDataGridViewTextBoxColumn";
            // 
            // NombreGrupo
            // 
            NombreGrupo.DataPropertyName = "NombreGrupo";
            NombreGrupo.HeaderText = "Nombre";
            NombreGrupo.Name = "NombreGrupo";
            // 
            // EstadoGrupo
            // 
            EstadoGrupo.DataPropertyName = "EstadoGrupo";
            EstadoGrupo.HeaderText = "Estado";
            EstadoGrupo.Name = "EstadoGrupo";
            // 
            // grupoBindingSource
            // 
            grupoBindingSource.DataSource = typeof(Modelo.Módulo_de_Seguridad.Grupo);
            // 
            // FormGestionarGrupos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Name = "FormGestionarGrupos";
            Text = "FormGestionarGrupos";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGrupos).EndInit();
            ((System.ComponentModel.ISupportInitialize)grupoBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ComboBox cmbEstado;
        private TextBox textBox1;
        private Label label3;
        private Label label1;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnAgregar;
        private DataGridView dgvGrupos;
        private Button btnSalir;
        private Button btnBuscar;
        private BindingSource grupoBindingSource;
        private DataGridViewTextBoxColumn nombreGrupoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn estadoGrupoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn NombreGrupo;
        private DataGridViewTextBoxColumn EstadoGrupo;
    }
}