namespace Vista.Módulo_de_Compras
{
    partial class FormDetallesOrdenesCompra
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
            btnVolver = new Button();
            groupBox2 = new GroupBox();
            lblCodigoProveedor = new Label();
            lblOrdenCompraCodigo = new Label();
            label1 = new Label();
            txtCantidadPeliculas = new TextBox();
            btnGuardar = new Button();
            dgvDetallesOrdenCompra = new DataGridView();
            peliculaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cantidadOrdenadaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cantidadEntregadaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            estadoDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            detalleOrdenCompraBindingSource1 = new BindingSource(components);
            detalleOrdenCompraBindingSource = new BindingSource(components);
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetallesOrdenCompra).BeginInit();
            ((System.ComponentModel.ISupportInitialize)detalleOrdenCompraBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)detalleOrdenCompraBindingSource).BeginInit();
            SuspendLayout();
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(447, 474);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 4;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblCodigoProveedor);
            groupBox2.Controls.Add(lblOrdenCompraCodigo);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(txtCantidadPeliculas);
            groupBox2.Controls.Add(btnGuardar);
            groupBox2.Controls.Add(dgvDetallesOrdenCompra);
            groupBox2.Location = new Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(510, 456);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            // 
            // lblCodigoProveedor
            // 
            lblCodigoProveedor.AutoSize = true;
            lblCodigoProveedor.Location = new Point(16, 65);
            lblCodigoProveedor.Name = "lblCodigoProveedor";
            lblCodigoProveedor.Size = new Size(0, 15);
            lblCodigoProveedor.TabIndex = 7;
            // 
            // lblOrdenCompraCodigo
            // 
            lblOrdenCompraCodigo.AutoSize = true;
            lblOrdenCompraCodigo.Location = new Point(16, 27);
            lblOrdenCompraCodigo.Name = "lblOrdenCompraCodigo";
            lblOrdenCompraCodigo.Size = new Size(0, 15);
            lblOrdenCompraCodigo.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(144, 100);
            label1.Name = "label1";
            label1.Size = new Size(214, 15);
            label1.TabIndex = 5;
            label1.Text = "Grilla de detalles de ordenes de compra";
            // 
            // txtCantidadPeliculas
            // 
            txtCantidadPeliculas.Location = new Point(20, 415);
            txtCantidadPeliculas.Name = "txtCantidadPeliculas";
            txtCantidadPeliculas.PlaceholderText = "Ingrese la cantidad a entregar";
            txtCantidadPeliculas.Size = new Size(172, 23);
            txtCantidadPeliculas.TabIndex = 4;
            txtCantidadPeliculas.KeyPress += txtCantidadPeliculas_KeyPress;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(216, 415);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(111, 24);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Entregar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // dgvDetallesOrdenCompra
            // 
            dgvDetallesOrdenCompra.AutoGenerateColumns = false;
            dgvDetallesOrdenCompra.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetallesOrdenCompra.Columns.AddRange(new DataGridViewColumn[] { peliculaDataGridViewTextBoxColumn, cantidadOrdenadaDataGridViewTextBoxColumn, cantidadEntregadaDataGridViewTextBoxColumn, estadoDataGridViewCheckBoxColumn });
            dgvDetallesOrdenCompra.DataSource = detalleOrdenCompraBindingSource1;
            dgvDetallesOrdenCompra.Location = new Point(16, 128);
            dgvDetallesOrdenCompra.Name = "dgvDetallesOrdenCompra";
            dgvDetallesOrdenCompra.ReadOnly = true;
            dgvDetallesOrdenCompra.RowTemplate.Height = 25;
            dgvDetallesOrdenCompra.Size = new Size(477, 270);
            dgvDetallesOrdenCompra.TabIndex = 0;
            // 
            // peliculaDataGridViewTextBoxColumn
            // 
            peliculaDataGridViewTextBoxColumn.DataPropertyName = "Pelicula";
            peliculaDataGridViewTextBoxColumn.HeaderText = "Pelicula";
            peliculaDataGridViewTextBoxColumn.Name = "peliculaDataGridViewTextBoxColumn";
            peliculaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantidadOrdenadaDataGridViewTextBoxColumn
            // 
            cantidadOrdenadaDataGridViewTextBoxColumn.DataPropertyName = "CantidadOrdenada";
            cantidadOrdenadaDataGridViewTextBoxColumn.HeaderText = "CantidadOrdenada";
            cantidadOrdenadaDataGridViewTextBoxColumn.Name = "cantidadOrdenadaDataGridViewTextBoxColumn";
            cantidadOrdenadaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantidadEntregadaDataGridViewTextBoxColumn
            // 
            cantidadEntregadaDataGridViewTextBoxColumn.DataPropertyName = "CantidadEntregada";
            cantidadEntregadaDataGridViewTextBoxColumn.HeaderText = "CantidadEntregada";
            cantidadEntregadaDataGridViewTextBoxColumn.Name = "cantidadEntregadaDataGridViewTextBoxColumn";
            cantidadEntregadaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estadoDataGridViewCheckBoxColumn
            // 
            estadoDataGridViewCheckBoxColumn.DataPropertyName = "Estado";
            estadoDataGridViewCheckBoxColumn.HeaderText = "Estado";
            estadoDataGridViewCheckBoxColumn.Name = "estadoDataGridViewCheckBoxColumn";
            estadoDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // detalleOrdenCompraBindingSource1
            // 
            detalleOrdenCompraBindingSource1.DataSource = typeof(Modelo.Entidades.DetalleOrdenCompra);
            // 
            // detalleOrdenCompraBindingSource
            // 
            detalleOrdenCompraBindingSource.DataSource = typeof(Modelo.Entidades.DetalleOrdenCompra);
            // 
            // FormDetallesOrdenesCompra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(534, 509);
            Controls.Add(btnVolver);
            Controls.Add(groupBox2);
            Name = "FormDetallesOrdenesCompra";
            Text = "FormDetallesOrdenesCompra";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetallesOrdenCompra).EndInit();
            ((System.ComponentModel.ISupportInitialize)detalleOrdenCompraBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)detalleOrdenCompraBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnVolver;
        private GroupBox groupBox2;
        private Button btnGuardar;
        private DataGridView dgvDetallesOrdenCompra;
        private DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private BindingSource detalleOrdenCompraBindingSource;
        private DataGridViewTextBoxColumn peliculaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cantidadOrdenadaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cantidadEntregadaDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn estadoDataGridViewCheckBoxColumn;
        private BindingSource detalleOrdenCompraBindingSource1;
        private TextBox txtCantidadPeliculas;
        private Label label1;
        private Label lblCodigoProveedor;
        private Label lblOrdenCompraID;
        private Label lblOrdenCompraCodigo;
    }
}