namespace Vista.Módulo_de_Ventas
{
    partial class FormMetodosPago
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
            txtCodigo = new TextBox();
            label3 = new Label();
            label1 = new Label();
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            btnModificar = new Button();
            label4 = new Label();
            btnVolver = new Button();
            btnEliminar = new Button();
            btnAgregar = new Button();
            txtNombre = new TextBox();
            label2 = new Label();
            dgvMetodosPago = new DataGridView();
            codigoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nombreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            metodoPagoBindingSource = new BindingSource(components);
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMetodosPago).BeginInit();
            ((System.ComponentModel.ISupportInitialize)metodoPagoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtCodigo);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnBuscar);
            groupBox1.Controls.Add(txtBuscar);
            groupBox1.Controls.Add(btnModificar);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(btnVolver);
            groupBox1.Controls.Add(btnEliminar);
            groupBox1.Controls.Add(btnAgregar);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(dgvMetodosPago);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 316);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(107, 116);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(129, 23);
            txtCodigo.TabIndex = 20;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 124);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 21;
            label3.Text = "Codigo:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(493, 32);
            label1.Name = "label1";
            label1.Size = new Size(130, 15);
            label1.TabIndex = 19;
            label1.Text = "Grilla Métodos de pago";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(216, 72);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(93, 23);
            btnBuscar.TabIndex = 15;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(23, 72);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Ingrese el nombre del metodo";
            txtBuscar.Size = new Size(171, 23);
            txtBuscar.TabIndex = 14;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(134, 273);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.TabIndex = 3;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(68, 32);
            label4.Name = "label4";
            label4.Size = new Size(190, 15);
            label4.TabIndex = 11;
            label4.Text = "Gestión Géneros Cinematograficos";
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(663, 273);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 6;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(254, 273);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(23, 273);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(107, 160);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(129, 23);
            txtNombre.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 168);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 2;
            label2.Text = "Nombre:";
            // 
            // dgvMetodosPago
            // 
            dgvMetodosPago.AutoGenerateColumns = false;
            dgvMetodosPago.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMetodosPago.Columns.AddRange(new DataGridViewColumn[] { codigoDataGridViewTextBoxColumn, nombreDataGridViewTextBoxColumn });
            dgvMetodosPago.DataSource = metodoPagoBindingSource;
            dgvMetodosPago.Location = new Point(388, 58);
            dgvMetodosPago.Name = "dgvMetodosPago";
            dgvMetodosPago.ReadOnly = true;
            dgvMetodosPago.RowTemplate.Height = 25;
            dgvMetodosPago.Size = new Size(373, 209);
            dgvMetodosPago.TabIndex = 5;
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
            // metodoPagoBindingSource
            // 
            metodoPagoBindingSource.DataSource = typeof(Modelo.Entidades.MetodoPago);
            // 
            // FormMetodosPago
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 347);
            Controls.Add(groupBox1);
            Name = "FormMetodosPago";
            Text = "FormMetodosPago";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMetodosPago).EndInit();
            ((System.ComponentModel.ISupportInitialize)metodoPagoBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private Button btnBuscar;
        private TextBox txtBuscar;
        private Button btnModificar;
        private Label label4;
        private Button btnVolver;
        private Button btnEliminar;
        private Button btnAgregar;
        private TextBox txtNombre;
        private Label label2;
        private DataGridView dgvMetodosPago;
        private TextBox txtCodigo;
        private Label label3;
        private DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private BindingSource metodoPagoBindingSource;
    }
}