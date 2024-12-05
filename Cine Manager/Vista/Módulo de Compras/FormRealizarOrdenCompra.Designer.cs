namespace Vista.Módulo_de_Compras
{
    partial class FormRealizarOrdenCompra
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
            label4 = new Label();
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            txtCantidadPeliculas = new TextBox();
            label2 = new Label();
            btnAgregarDetalle = new Button();
            label1 = new Label();
            cmbProveedores = new ComboBox();
            dgvPeliculas = new DataGridView();
            codigoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nombreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cantidadDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            precioDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            peliculaBindingSource = new BindingSource(components);
            groupBox2 = new GroupBox();
            label5 = new Label();
            label3 = new Label();
            txtTotal = new TextBox();
            btnQuitar = new Button();
            dgvDetalles = new DataGridView();
            peliculaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            detalleOrdenCompraBindingSource1 = new BindingSource(components);
            detalleOrdenCompraBindingSource = new BindingSource(components);
            btnEmitirOrden = new Button();
            btnVolver = new Button();
            ordenCompraBindingSource = new BindingSource(components);
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPeliculas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)peliculaBindingSource).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)detalleOrdenCompraBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)detalleOrdenCompraBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ordenCompraBindingSource).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(btnBuscar);
            groupBox1.Controls.Add(txtBuscar);
            groupBox1.Controls.Add(txtCantidadPeliculas);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btnAgregarDetalle);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cmbProveedores);
            groupBox1.Controls.Add(dgvPeliculas);
            groupBox1.Location = new Point(14, 16);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(466, 588);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(149, 217);
            label4.Name = "label4";
            label4.Size = new Size(131, 20);
            label4.TabIndex = 16;
            label4.Text = "Grilla de peliculas ";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(288, 149);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(120, 31);
            btnBuscar.TabIndex = 9;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(29, 149);
            txtBuscar.Margin = new Padding(3, 4, 3, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Ingrese el nombre de la pelicula";
            txtBuscar.Size = new Size(215, 27);
            txtBuscar.TabIndex = 8;
            // 
            // txtCantidadPeliculas
            // 
            txtCantidadPeliculas.Location = new Point(235, 84);
            txtCantidadPeliculas.Margin = new Padding(3, 4, 3, 4);
            txtCantidadPeliculas.Name = "txtCantidadPeliculas";
            txtCantidadPeliculas.Size = new Size(172, 27);
            txtCantidadPeliculas.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(235, 48);
            label2.Name = "label2";
            label2.Size = new Size(154, 20);
            label2.TabIndex = 4;
            label2.Text = "Cantidad de Películas ";
            // 
            // btnAgregarDetalle
            // 
            btnAgregarDetalle.Location = new Point(279, 549);
            btnAgregarDetalle.Margin = new Padding(3, 4, 3, 4);
            btnAgregarDetalle.Name = "btnAgregarDetalle";
            btnAgregarDetalle.Size = new Size(149, 31);
            btnAgregarDetalle.TabIndex = 3;
            btnAgregarDetalle.Text = "Agregar detalle";
            btnAgregarDetalle.UseVisualStyleBackColor = true;
            btnAgregarDetalle.Click += btnAgregarDetalle_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 48);
            label1.Name = "label1";
            label1.Size = new Size(156, 20);
            label1.TabIndex = 2;
            label1.Text = "Codigo del proveedor";
            // 
            // cmbProveedores
            // 
            cmbProveedores.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProveedores.FormattingEnabled = true;
            cmbProveedores.Location = new Point(30, 84);
            cmbProveedores.Margin = new Padding(3, 4, 3, 4);
            cmbProveedores.Name = "cmbProveedores";
            cmbProveedores.Size = new Size(138, 28);
            cmbProveedores.TabIndex = 1;
            // 
            // dgvPeliculas
            // 
            dgvPeliculas.AutoGenerateColumns = false;
            dgvPeliculas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPeliculas.Columns.AddRange(new DataGridViewColumn[] { codigoDataGridViewTextBoxColumn, nombreDataGridViewTextBoxColumn, cantidadDataGridViewTextBoxColumn, precioDataGridViewTextBoxColumn });
            dgvPeliculas.DataSource = peliculaBindingSource;
            dgvPeliculas.Location = new Point(29, 263);
            dgvPeliculas.Margin = new Padding(3, 4, 3, 4);
            dgvPeliculas.Name = "dgvPeliculas";
            dgvPeliculas.RowHeadersWidth = 51;
            dgvPeliculas.RowTemplate.Height = 25;
            dgvPeliculas.Size = new Size(399, 259);
            dgvPeliculas.TabIndex = 0;
            // 
            // codigoDataGridViewTextBoxColumn
            // 
            codigoDataGridViewTextBoxColumn.DataPropertyName = "Codigo";
            codigoDataGridViewTextBoxColumn.HeaderText = "Codigo";
            codigoDataGridViewTextBoxColumn.MinimumWidth = 6;
            codigoDataGridViewTextBoxColumn.Name = "codigoDataGridViewTextBoxColumn";
            codigoDataGridViewTextBoxColumn.Width = 125;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            nombreDataGridViewTextBoxColumn.MinimumWidth = 6;
            nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            nombreDataGridViewTextBoxColumn.Width = 125;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            cantidadDataGridViewTextBoxColumn.MinimumWidth = 6;
            cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            cantidadDataGridViewTextBoxColumn.Width = 125;
            // 
            // precioDataGridViewTextBoxColumn
            // 
            precioDataGridViewTextBoxColumn.DataPropertyName = "Precio";
            precioDataGridViewTextBoxColumn.HeaderText = "Precio";
            precioDataGridViewTextBoxColumn.MinimumWidth = 6;
            precioDataGridViewTextBoxColumn.Name = "precioDataGridViewTextBoxColumn";
            precioDataGridViewTextBoxColumn.Width = 125;
            // 
            // peliculaBindingSource
            // 
            peliculaBindingSource.DataSource = typeof(Modelo.Entidades.Pelicula);
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(txtTotal);
            groupBox2.Controls.Add(btnQuitar);
            groupBox2.Controls.Add(dgvDetalles);
            groupBox2.Location = new Point(501, 16);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(448, 480);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(104, 48);
            label5.Name = "label5";
            label5.Size = new Size(275, 20);
            label5.TabIndex = 16;
            label5.Text = "Grilla de detalles de ordenes de compra";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 361);
            label3.Name = "label3";
            label3.Size = new Size(42, 20);
            label3.TabIndex = 10;
            label3.Text = "Total";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(25, 404);
            txtTotal.Margin = new Padding(3, 4, 3, 4);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(172, 27);
            txtTotal.TabIndex = 9;
            // 
            // btnQuitar
            // 
            btnQuitar.Location = new Point(229, 404);
            btnQuitar.Margin = new Padding(3, 4, 3, 4);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(150, 31);
            btnQuitar.TabIndex = 8;
            btnQuitar.Text = "Quitar ";
            btnQuitar.UseVisualStyleBackColor = true;
            btnQuitar.Click += btnQuitar_Click;
            // 
            // dgvDetalles
            // 
            dgvDetalles.AutoGenerateColumns = false;
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Columns.AddRange(new DataGridViewColumn[] { peliculaDataGridViewTextBoxColumn });
            dgvDetalles.DataSource = detalleOrdenCompraBindingSource1;
            dgvDetalles.Location = new Point(25, 84);
            dgvDetalles.Margin = new Padding(3, 4, 3, 4);
            dgvDetalles.Name = "dgvDetalles";
            dgvDetalles.ReadOnly = true;
            dgvDetalles.RowHeadersWidth = 51;
            dgvDetalles.RowTemplate.Height = 25;
            dgvDetalles.Size = new Size(399, 259);
            dgvDetalles.TabIndex = 1;
            // 
            // peliculaDataGridViewTextBoxColumn
            // 
            peliculaDataGridViewTextBoxColumn.DataPropertyName = "Pelicula";
            peliculaDataGridViewTextBoxColumn.HeaderText = "Pelicula";
            peliculaDataGridViewTextBoxColumn.MinimumWidth = 6;
            peliculaDataGridViewTextBoxColumn.Name = "peliculaDataGridViewTextBoxColumn";
            peliculaDataGridViewTextBoxColumn.ReadOnly = true;
            peliculaDataGridViewTextBoxColumn.Width = 125;
            // 
            // detalleOrdenCompraBindingSource1
            // 
            detalleOrdenCompraBindingSource1.DataSource = typeof(Modelo.Entidades.DetalleOrdenCompra);
            // 
            // detalleOrdenCompraBindingSource
            // 
            detalleOrdenCompraBindingSource.DataSource = typeof(Modelo.Entidades.DetalleOrdenCompra);
            // 
            // btnEmitirOrden
            // 
            btnEmitirOrden.Location = new Point(617, 553);
            btnEmitirOrden.Margin = new Padding(3, 4, 3, 4);
            btnEmitirOrden.Name = "btnEmitirOrden";
            btnEmitirOrden.Size = new Size(181, 31);
            btnEmitirOrden.TabIndex = 11;
            btnEmitirOrden.Text = "Emitir Orden de Compra";
            btnEmitirOrden.UseVisualStyleBackColor = true;
            btnEmitirOrden.Click += btnEmitirOrden_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(818, 553);
            btnVolver.Margin = new Padding(3, 4, 3, 4);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(120, 31);
            btnVolver.TabIndex = 12;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // ordenCompraBindingSource
            // 
            ordenCompraBindingSource.DataSource = typeof(Modelo.Entidades.OrdenCompra);
            // 
            // FormRealizarOrdenCompra
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(962, 620);
            Controls.Add(btnVolver);
            Controls.Add(btnEmitirOrden);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormRealizarOrdenCompra";
            Text = "FormRealizarOrdenCompra";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPeliculas).EndInit();
            ((System.ComponentModel.ISupportInitialize)peliculaBindingSource).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ((System.ComponentModel.ISupportInitialize)detalleOrdenCompraBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)detalleOrdenCompraBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)ordenCompraBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox cmbProveedores;
        private DataGridView dgvPeliculas;
        private Label label1;
        private Button btnAgregarDetalle;
        private Label label2;
        private TextBox txtCantidadPeliculas;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private GroupBox groupBox2;
        private DataGridView dgvDetalles;
        private Button btnQuitar;
        private TextBox txtTotal;
        private Label label3;
        private Button btnEmitirOrden;
        private Button btnVolver;
        private DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn precioDataGridViewTextBoxColumn;
        private BindingSource peliculaBindingSource;
        private DataGridViewTextBoxColumn peliculaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn1;
        private BindingSource detalleOrdenCompraBindingSource;
        private BindingSource ordenCompraBindingSource;
        private BindingSource detalleOrdenCompraBindingSource1;
        private Label label5;
        private Label label4;
    }
}