namespace Vista
{
    partial class FormProveedores
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
            numCUIT = new TextBox();
            txtBuscar = new TextBox();
            btnEliminar = new Button();
            label4 = new Label();
            btnVolver = new Button();
            btnModificar = new Button();
            btnAgregar = new Button();
            txtRazonSocial = new TextBox();
            txtCodigo = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dgvProveedores = new DataGridView();
            codigoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cuitDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            RazonSocial = new DataGridViewTextBoxColumn();
            proveedorBindingSource1 = new BindingSource(components);
            proveedorBindingSource = new BindingSource(components);
            btnOrdenCompra = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)proveedorBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)proveedorBindingSource).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnOrdenCompra);
            groupBox1.Controls.Add(btnBuscar);
            groupBox1.Controls.Add(numCUIT);
            groupBox1.Controls.Add(txtBuscar);
            groupBox1.Controls.Add(btnEliminar);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(btnVolver);
            groupBox1.Controls.Add(btnModificar);
            groupBox1.Controls.Add(btnAgregar);
            groupBox1.Controls.Add(txtRazonSocial);
            groupBox1.Controls.Add(txtCodigo);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(dgvProveedores);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(805, 426);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(244, 78);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(93, 23);
            btnBuscar.TabIndex = 15;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // numCUIT
            // 
            numCUIT.Location = new Point(107, 203);
            numCUIT.Name = "numCUIT";
            numCUIT.Size = new Size(129, 23);
            numCUIT.TabIndex = 12;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(25, 79);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Ingrese el codigo";
            txtBuscar.Size = new Size(188, 23);
            txtBuscar.TabIndex = 14;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(234, 383);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(71, 23);
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
            label4.Size = new Size(115, 15);
            label4.TabIndex = 11;
            label4.Text = "Gestión Proveedores";
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(713, 383);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 7;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(121, 383);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(71, 23);
            btnModificar.TabIndex = 5;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(16, 383);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(71, 23);
            btnAgregar.TabIndex = 4;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtRazonSocial
            // 
            txtRazonSocial.Location = new Point(107, 256);
            txtRazonSocial.Name = "txtRazonSocial";
            txtRazonSocial.Size = new Size(129, 23);
            txtRazonSocial.TabIndex = 3;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(107, 143);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(129, 23);
            txtCodigo.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 256);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 3;
            label3.Text = "Razón Social:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 203);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 2;
            label2.Text = "CUIT:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 146);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 1;
            label1.Text = "Codigo: ";
            // 
            // dgvProveedores
            // 
            dgvProveedores.AutoGenerateColumns = false;
            dgvProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProveedores.Columns.AddRange(new DataGridViewColumn[] { codigoDataGridViewTextBoxColumn, cuitDataGridViewTextBoxColumn, RazonSocial });
            dgvProveedores.DataSource = proveedorBindingSource1;
            dgvProveedores.Location = new Point(386, 31);
            dgvProveedores.Name = "dgvProveedores";
            dgvProveedores.ReadOnly = true;
            dgvProveedores.RowTemplate.Height = 25;
            dgvProveedores.Size = new Size(402, 308);
            dgvProveedores.TabIndex = 8;
            // 
            // codigoDataGridViewTextBoxColumn
            // 
            codigoDataGridViewTextBoxColumn.DataPropertyName = "Codigo";
            codigoDataGridViewTextBoxColumn.HeaderText = "Codigo";
            codigoDataGridViewTextBoxColumn.Name = "codigoDataGridViewTextBoxColumn";
            codigoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cuitDataGridViewTextBoxColumn
            // 
            cuitDataGridViewTextBoxColumn.DataPropertyName = "Cuit";
            cuitDataGridViewTextBoxColumn.HeaderText = "Cuit";
            cuitDataGridViewTextBoxColumn.Name = "cuitDataGridViewTextBoxColumn";
            cuitDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // RazonSocial
            // 
            RazonSocial.DataPropertyName = "RazonSocial";
            RazonSocial.HeaderText = "RazonSocial";
            RazonSocial.Name = "RazonSocial";
            RazonSocial.ReadOnly = true;
            // 
            // proveedorBindingSource1
            // 
            proveedorBindingSource1.DataSource = typeof(Modelo.Entidades.Proveedor);
            // 
            // proveedorBindingSource
            // 
            proveedorBindingSource.DataSource = typeof(Modelo.Entidades.Proveedor);
            // 
            // btnOrdenCompra
            // 
            btnOrdenCompra.Location = new Point(565, 383);
            btnOrdenCompra.Name = "btnOrdenCompra";
            btnOrdenCompra.Size = new Size(119, 23);
            btnOrdenCompra.TabIndex = 16;
            btnOrdenCompra.Text = "Órdenes de compra";
            btnOrdenCompra.UseVisualStyleBackColor = true;
            // 
            // FormProveedores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(829, 450);
            Controls.Add(groupBox1);
            Name = "FormProveedores";
            Text = "FormProveedores";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).EndInit();
            ((System.ComponentModel.ISupportInitialize)proveedorBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)proveedorBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnEliminar;
        private Label label4;
        private Button btnVolver;
        private Button btnModificar;
        private Button btnAgregar;
        private TextBox txtRazonSocial;
        private TextBox txtCodigo;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridView dgvProveedores;
        private DataGridViewTextBoxColumn razoSocialDataGridViewTextBoxColumn;
        private BindingSource proveedorBindingSource;
        private BindingSource proveedorBindingSource1;
        private DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cuitDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn RazonSocial;
        private TextBox numCUIT;
        private Button btnBuscar;
        private TextBox txtBuscar;
        private Button btnOrdenCompra;
    }
}