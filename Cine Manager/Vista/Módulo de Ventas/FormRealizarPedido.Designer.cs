namespace Vista.Módulo_de_Transacciones
{
    partial class FormRealizarPedido
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
            label5 = new Label();
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            btnAlquiler = new Button();
            btnVenta = new Button();
            dgvPeliculasDisponibles = new DataGridView();
            codigoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nombreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cantidadDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            precioDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            directorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            generoCinematograficoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            peliculaBindingSource = new BindingSource(components);
            txtCantidadPeliculas = new TextBox();
            cmbDNI = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            label4 = new Label();
            btnQuitar = new Button();
            label3 = new Label();
            txtTotal = new TextBox();
            dgvDetallesPedido = new DataGridView();
            peliculaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cantidadDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            subtotalDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            detallePedidoBindingSource1 = new BindingSource(components);
            detallePedidoBindingSource = new BindingSource(components);
            btnFinalizarPedido = new Button();
            btnVolver = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPeliculasDisponibles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)peliculaBindingSource).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetallesPedido).BeginInit();
            ((System.ComponentModel.ISupportInitialize)detallePedidoBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)detallePedidoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(btnBuscar);
            groupBox1.Controls.Add(txtBuscar);
            groupBox1.Controls.Add(btnAlquiler);
            groupBox1.Controls.Add(btnVenta);
            groupBox1.Controls.Add(dgvPeliculasDisponibles);
            groupBox1.Controls.Add(txtCantidadPeliculas);
            groupBox1.Controls.Add(cmbDNI);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(14, 16);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(458, 680);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(154, 201);
            label5.Name = "label5";
            label5.Size = new Size(127, 20);
            label5.TabIndex = 16;
            label5.Text = "Grilla de peliculas";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(262, 127);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(120, 31);
            btnBuscar.TabIndex = 8;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(19, 127);
            txtBuscar.Margin = new Padding(3, 4, 3, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Ingrese el nombre de la pelicula";
            txtBuscar.Size = new Size(215, 27);
            txtBuscar.TabIndex = 7;
            // 
            // btnAlquiler
            // 
            btnAlquiler.Location = new Point(238, 628);
            btnAlquiler.Margin = new Padding(3, 4, 3, 4);
            btnAlquiler.Name = "btnAlquiler";
            btnAlquiler.Size = new Size(152, 31);
            btnAlquiler.TabIndex = 6;
            btnAlquiler.Text = "Agregar Alquiler";
            btnAlquiler.UseVisualStyleBackColor = true;
            btnAlquiler.Click += btnAlquiler_Click;
            // 
            // btnVenta
            // 
            btnVenta.Location = new Point(47, 628);
            btnVenta.Margin = new Padding(3, 4, 3, 4);
            btnVenta.Name = "btnVenta";
            btnVenta.Size = new Size(119, 31);
            btnVenta.TabIndex = 5;
            btnVenta.Text = "Agregar Venta";
            btnVenta.UseVisualStyleBackColor = true;
            btnVenta.Click += btnVenta_Click;
            // 
            // dgvPeliculasDisponibles
            // 
            dgvPeliculasDisponibles.AutoGenerateColumns = false;
            dgvPeliculasDisponibles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPeliculasDisponibles.Columns.AddRange(new DataGridViewColumn[] { codigoDataGridViewTextBoxColumn, nombreDataGridViewTextBoxColumn, cantidadDataGridViewTextBoxColumn, precioDataGridViewTextBoxColumn, directorDataGridViewTextBoxColumn, generoCinematograficoDataGridViewTextBoxColumn });
            dgvPeliculasDisponibles.DataSource = peliculaBindingSource;
            dgvPeliculasDisponibles.Location = new Point(19, 247);
            dgvPeliculasDisponibles.Margin = new Padding(3, 4, 3, 4);
            dgvPeliculasDisponibles.Name = "dgvPeliculasDisponibles";
            dgvPeliculasDisponibles.ReadOnly = true;
            dgvPeliculasDisponibles.RowHeadersWidth = 51;
            dgvPeliculasDisponibles.RowTemplate.Height = 25;
            dgvPeliculasDisponibles.Size = new Size(395, 321);
            dgvPeliculasDisponibles.TabIndex = 4;
            // 
            // codigoDataGridViewTextBoxColumn
            // 
            codigoDataGridViewTextBoxColumn.DataPropertyName = "Codigo";
            codigoDataGridViewTextBoxColumn.HeaderText = "Codigo";
            codigoDataGridViewTextBoxColumn.MinimumWidth = 6;
            codigoDataGridViewTextBoxColumn.Name = "codigoDataGridViewTextBoxColumn";
            codigoDataGridViewTextBoxColumn.ReadOnly = true;
            codigoDataGridViewTextBoxColumn.Width = 125;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            nombreDataGridViewTextBoxColumn.MinimumWidth = 6;
            nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            nombreDataGridViewTextBoxColumn.ReadOnly = true;
            nombreDataGridViewTextBoxColumn.Width = 125;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            cantidadDataGridViewTextBoxColumn.MinimumWidth = 6;
            cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            cantidadDataGridViewTextBoxColumn.Width = 125;
            // 
            // precioDataGridViewTextBoxColumn
            // 
            precioDataGridViewTextBoxColumn.DataPropertyName = "Precio";
            precioDataGridViewTextBoxColumn.HeaderText = "Precio";
            precioDataGridViewTextBoxColumn.MinimumWidth = 6;
            precioDataGridViewTextBoxColumn.Name = "precioDataGridViewTextBoxColumn";
            precioDataGridViewTextBoxColumn.ReadOnly = true;
            precioDataGridViewTextBoxColumn.Width = 125;
            // 
            // directorDataGridViewTextBoxColumn
            // 
            directorDataGridViewTextBoxColumn.DataPropertyName = "Director";
            directorDataGridViewTextBoxColumn.HeaderText = "Director";
            directorDataGridViewTextBoxColumn.MinimumWidth = 6;
            directorDataGridViewTextBoxColumn.Name = "directorDataGridViewTextBoxColumn";
            directorDataGridViewTextBoxColumn.ReadOnly = true;
            directorDataGridViewTextBoxColumn.Width = 125;
            // 
            // generoCinematograficoDataGridViewTextBoxColumn
            // 
            generoCinematograficoDataGridViewTextBoxColumn.DataPropertyName = "GeneroCinematografico";
            generoCinematograficoDataGridViewTextBoxColumn.HeaderText = "GeneroCinematografico";
            generoCinematograficoDataGridViewTextBoxColumn.MinimumWidth = 6;
            generoCinematograficoDataGridViewTextBoxColumn.Name = "generoCinematograficoDataGridViewTextBoxColumn";
            generoCinematograficoDataGridViewTextBoxColumn.ReadOnly = true;
            generoCinematograficoDataGridViewTextBoxColumn.Width = 125;
            // 
            // peliculaBindingSource
            // 
            peliculaBindingSource.DataSource = typeof(Modelo.Entidades.Pelicula);
            // 
            // txtCantidadPeliculas
            // 
            txtCantidadPeliculas.Location = new Point(242, 67);
            txtCantidadPeliculas.Margin = new Padding(3, 4, 3, 4);
            txtCantidadPeliculas.Name = "txtCantidadPeliculas";
            txtCantidadPeliculas.Size = new Size(172, 27);
            txtCantidadPeliculas.TabIndex = 3;
            // 
            // cmbDNI
            // 
            cmbDNI.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDNI.FormattingEnabled = true;
            cmbDNI.Location = new Point(19, 67);
            cmbDNI.Margin = new Padding(3, 4, 3, 4);
            cmbDNI.Name = "cmbDNI";
            cmbDNI.Size = new Size(155, 28);
            cmbDNI.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(238, 25);
            label2.Name = "label2";
            label2.Size = new Size(129, 20);
            label2.TabIndex = 1;
            label2.Text = "Cantidad Películas";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 25);
            label1.Name = "label1";
            label1.Size = new Size(85, 20);
            label1.TabIndex = 0;
            label1.Text = "DNI Cliente";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(btnQuitar);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(txtTotal);
            groupBox2.Controls.Add(dgvDetallesPedido);
            groupBox2.Location = new Point(491, 16);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(473, 568);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(146, 40);
            label4.Name = "label4";
            label4.Size = new Size(198, 20);
            label4.TabIndex = 17;
            label4.Text = "Grilla de detalles del pedido";
            // 
            // btnQuitar
            // 
            btnQuitar.Location = new Point(249, 484);
            btnQuitar.Margin = new Padding(3, 4, 3, 4);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(148, 31);
            btnQuitar.TabIndex = 7;
            btnQuitar.Text = "Quitar del carrito";
            btnQuitar.UseVisualStyleBackColor = true;
            btnQuitar.Click += btnQuitar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(45, 441);
            label3.Name = "label3";
            label3.Size = new Size(97, 20);
            label3.TabIndex = 7;
            label3.Text = "Total a pagar";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(45, 485);
            txtTotal.Margin = new Padding(3, 4, 3, 4);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(172, 27);
            txtTotal.TabIndex = 6;
            // 
            // dgvDetallesPedido
            // 
            dgvDetallesPedido.AutoGenerateColumns = false;
            dgvDetallesPedido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetallesPedido.Columns.AddRange(new DataGridViewColumn[] { peliculaDataGridViewTextBoxColumn, cantidadDataGridViewTextBoxColumn1, subtotalDataGridViewTextBoxColumn });
            dgvDetallesPedido.DataSource = detallePedidoBindingSource1;
            dgvDetallesPedido.Location = new Point(31, 85);
            dgvDetallesPedido.Margin = new Padding(3, 4, 3, 4);
            dgvDetallesPedido.Name = "dgvDetallesPedido";
            dgvDetallesPedido.ReadOnly = true;
            dgvDetallesPedido.RowHeadersWidth = 51;
            dgvDetallesPedido.RowTemplate.Height = 25;
            dgvDetallesPedido.Size = new Size(395, 321);
            dgvDetallesPedido.TabIndex = 5;
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
            // cantidadDataGridViewTextBoxColumn1
            // 
            cantidadDataGridViewTextBoxColumn1.DataPropertyName = "Cantidad";
            cantidadDataGridViewTextBoxColumn1.HeaderText = "Cantidad";
            cantidadDataGridViewTextBoxColumn1.MinimumWidth = 6;
            cantidadDataGridViewTextBoxColumn1.Name = "cantidadDataGridViewTextBoxColumn1";
            cantidadDataGridViewTextBoxColumn1.ReadOnly = true;
            cantidadDataGridViewTextBoxColumn1.Width = 125;
            // 
            // subtotalDataGridViewTextBoxColumn
            // 
            subtotalDataGridViewTextBoxColumn.DataPropertyName = "Subtotal";
            subtotalDataGridViewTextBoxColumn.HeaderText = "Subtotal";
            subtotalDataGridViewTextBoxColumn.MinimumWidth = 6;
            subtotalDataGridViewTextBoxColumn.Name = "subtotalDataGridViewTextBoxColumn";
            subtotalDataGridViewTextBoxColumn.ReadOnly = true;
            subtotalDataGridViewTextBoxColumn.Width = 125;
            // 
            // detallePedidoBindingSource1
            // 
            detallePedidoBindingSource1.DataSource = typeof(Modelo.Entidades.DetallePedido);
            // 
            // detallePedidoBindingSource
            // 
            detallePedidoBindingSource.DataSource = typeof(Modelo.Entidades.DetallePedido);
            // 
            // btnFinalizarPedido
            // 
            btnFinalizarPedido.Location = new Point(737, 619);
            btnFinalizarPedido.Margin = new Padding(3, 4, 3, 4);
            btnFinalizarPedido.Name = "btnFinalizarPedido";
            btnFinalizarPedido.Size = new Size(136, 31);
            btnFinalizarPedido.TabIndex = 8;
            btnFinalizarPedido.Text = "Finalizar Pedido";
            btnFinalizarPedido.UseVisualStyleBackColor = true;
            btnFinalizarPedido.Click += btnFinalizarPedido_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(879, 619);
            btnVolver.Margin = new Padding(3, 4, 3, 4);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(86, 31);
            btnVolver.TabIndex = 9;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // FormRealizarPedido
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(989, 712);
            Controls.Add(btnVolver);
            Controls.Add(btnFinalizarPedido);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormRealizarPedido";
            Text = "FormRealizarPedido";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPeliculasDisponibles).EndInit();
            ((System.ComponentModel.ISupportInitialize)peliculaBindingSource).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetallesPedido).EndInit();
            ((System.ComponentModel.ISupportInitialize)detallePedidoBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)detallePedidoBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnAlquiler;
        private Button btnVenta;
        private DataGridView dgvPeliculasDisponibles;
        private TextBox txtCantidadPeliculas;
        private ComboBox cmbDNI;
        private Label label2;
        private Label label1;
        private GroupBox groupBox2;
        private Button btnFinalizarPedido;
        private Button btnQuitar;
        private Label label3;
        private TextBox txtTotal;
        private DataGridView dgvDetallesPedido;
        private DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn precioDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn directorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn generoCinematograficoDataGridViewTextBoxColumn;
        private BindingSource peliculaBindingSource;
        private BindingSource detallePedidoBindingSource;
        private DataGridViewTextBoxColumn peliculaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn subtotalDataGridViewTextBoxColumn;
        private Button btnVolver;
        private Button btnBuscar;
        private TextBox txtBuscar;
        private BindingSource detallePedidoBindingSource1;
        private Label label5;
        private Label label4;
    }
}