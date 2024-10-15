namespace Vista
{
    partial class FormDirectores
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
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            btnEliminar = new Button();
            label4 = new Label();
            btnVolver = new Button();
            btnModificar = new Button();
            btnAgregar = new Button();
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            txtCodigo = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dgvDirectores = new DataGridView();
            codigoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nombreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            apellidoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            directorBindingSource = new BindingSource(components);
            label5 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDirectores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)directorBindingSource).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(btnBuscar);
            groupBox1.Controls.Add(txtBuscar);
            groupBox1.Controls.Add(btnEliminar);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(btnVolver);
            groupBox1.Controls.Add(btnModificar);
            groupBox1.Controls.Add(btnAgregar);
            groupBox1.Controls.Add(txtApellido);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(txtCodigo);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(dgvDirectores);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 426);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(234, 82);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(93, 23);
            btnBuscar.TabIndex = 15;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(15, 83);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Ingrese nombe, apellido o ambos..";
            txtBuscar.Size = new Size(188, 23);
            txtBuscar.TabIndex = 14;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(233, 383);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(97, 31);
            label4.Name = "label4";
            label4.Size = new Size(103, 15);
            label4.TabIndex = 11;
            label4.Text = "Gestión Directores";
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(684, 383);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 8;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(120, 383);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 5;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(15, 383);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 4;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(97, 267);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(129, 23);
            txtApellido.TabIndex = 3;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(97, 206);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(129, 23);
            txtNombre.TabIndex = 2;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(97, 154);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(129, 23);
            txtCodigo.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 267);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 3;
            label3.Text = "Apellido:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 214);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 2;
            label2.Text = "Nombre:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 157);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 1;
            label1.Text = "Codigo: ";
            // 
            // dgvDirectores
            // 
            dgvDirectores.AutoGenerateColumns = false;
            dgvDirectores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDirectores.Columns.AddRange(new DataGridViewColumn[] { codigoDataGridViewTextBoxColumn, nombreDataGridViewTextBoxColumn, apellidoDataGridViewTextBoxColumn });
            dgvDirectores.DataSource = directorBindingSource;
            dgvDirectores.Location = new Point(397, 69);
            dgvDirectores.Name = "dgvDirectores";
            dgvDirectores.ReadOnly = true;
            dgvDirectores.RowTemplate.Height = 25;
            dgvDirectores.Size = new Size(373, 308);
            dgvDirectores.TabIndex = 7;
            // 
            // codigoDataGridViewTextBoxColumn
            // 
            codigoDataGridViewTextBoxColumn.DataPropertyName = "Codigo";
            codigoDataGridViewTextBoxColumn.HeaderText = "Codigo";
            codigoDataGridViewTextBoxColumn.Name = "codigoDataGridViewTextBoxColumn";
            codigoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // apellidoDataGridViewTextBoxColumn
            // 
            apellidoDataGridViewTextBoxColumn.DataPropertyName = "Apellido";
            apellidoDataGridViewTextBoxColumn.HeaderText = "Apellido";
            apellidoDataGridViewTextBoxColumn.Name = "apellidoDataGridViewTextBoxColumn";
            apellidoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // directorBindingSource
            // 
            directorBindingSource.DataSource = typeof(Modelo.Entidades.Director);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(531, 31);
            label5.Name = "label5";
            label5.Size = new Size(106, 15);
            label5.TabIndex = 19;
            label5.Text = "Grilla de Directores";
            // 
            // FormDirectores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Name = "FormDirectores";
            Text = "FormDirectores";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDirectores).EndInit();
            ((System.ComponentModel.ISupportInitialize)directorBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private DataGridView dgvDirectores;
        private Button btnVolver;
        private Button btnModificar;
        private Button btnAgregar;
        private TextBox txtApellido;
        private TextBox txtNombre;
        private TextBox txtCodigo;
        private Label label3;
        private Label label2;
        private Label label4;
        private Button btnEliminar;
        private DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn apellidoDataGridViewTextBoxColumn;
        private BindingSource directorBindingSource;
        private Button btnBuscar;
        private TextBox txtBuscar;
        private Label label5;
    }
}