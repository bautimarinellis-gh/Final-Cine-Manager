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
            btnBuscarCliente = new Button();
            txtDNICliente = new TextBox();
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
            label2 = new Label();
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
            groupBox1.Controls.Add(btnBuscarCliente);
            groupBox1.Controls.Add(txtDNICliente);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(btnBuscar);
            groupBox1.Controls.Add(txtBuscar);
            groupBox1.Controls.Add(btnAlquiler);
            groupBox1.Controls.Add(btnVenta);
            groupBox1.Controls.Add(dgvPeliculasDisponibles);
            groupBox1.Controls.Add(txtCantidadPeliculas);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(401, 510);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // btnBuscarCliente
            // 
            btnBuscarCliente.Location = new Point(159, 49);
            btnBuscarCliente.Name = "btnBuscarCliente";
            btnBuscarCliente.Size = new Size(94, 23);
            btnBuscarCliente.TabIndex = 18;
            btnBuscarCliente.Text = "Buscar cliente";
            btnBuscarCliente.UseVisualStyleBackColor = true;
            btnBuscarCliente.Click += btnBuscarCliente_Click;
            // 
            // txtDNICliente
            // 
            txtDNICliente.Location = new Point(17, 49);
            txtDNICliente.Name = "txtDNICliente";
            txtDNICliente.PlaceholderText = "DNI del Cliente";
            txtDNICliente.ReadOnly = true;
            txtDNICliente.Size = new Size(128, 23);
            txtDNICliente.TabIndex = 17;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(135, 151);
            label5.Name = "label5";
            label5.Size = new Size(99, 15);
            label5.TabIndex = 16;
            label5.Text = "Grilla de peliculas";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(229, 95);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(105, 23);
            btnBuscar.TabIndex = 8;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(17, 95);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Ingrese el nombre de la pelicula";
            txtBuscar.Size = new Size(189, 23);
            txtBuscar.TabIndex = 7;
            // 
            // btnAlquiler
            // 
            btnAlquiler.Location = new Point(208, 471);
            btnAlquiler.Name = "btnAlquiler";
            btnAlquiler.Size = new Size(133, 23);
            btnAlquiler.TabIndex = 6;
            btnAlquiler.Text = "Agregar Alquiler";
            btnAlquiler.UseVisualStyleBackColor = true;
            btnAlquiler.Click += btnAlquiler_Click;
            // 
            // btnVenta
            // 
            btnVenta.Location = new Point(41, 471);
            btnVenta.Name = "btnVenta";
            btnVenta.Size = new Size(104, 23);
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
            dgvPeliculasDisponibles.Location = new Point(17, 185);
            dgvPeliculasDisponibles.Name = "dgvPeliculasDisponibles";
            dgvPeliculasDisponibles.ReadOnly = true;
            dgvPeliculasDisponibles.RowHeadersWidth = 51;
            dgvPeliculasDisponibles.RowTemplate.Height = 25;
            dgvPeliculasDisponibles.Size = new Size(346, 241);
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
            txtCantidadPeliculas.Location = new Point(271, 49);
            txtCantidadPeliculas.Name = "txtCantidadPeliculas";
            txtCantidadPeliculas.Size = new Size(104, 23);
            txtCantidadPeliculas.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(271, 19);
            label2.Name = "label2";
            label2.Size = new Size(104, 15);
            label2.TabIndex = 1;
            label2.Text = "Cantidad Películas";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(btnQuitar);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(txtTotal);
            groupBox2.Controls.Add(dgvDetallesPedido);
            groupBox2.Location = new Point(430, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(414, 426);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(128, 30);
            label4.Name = "label4";
            label4.Size = new Size(152, 15);
            label4.TabIndex = 17;
            label4.Text = "Grilla de detalles del pedido";
            // 
            // btnQuitar
            // 
            btnQuitar.Location = new Point(218, 363);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(130, 23);
            btnQuitar.TabIndex = 7;
            btnQuitar.Text = "Quitar del carrito";
            btnQuitar.UseVisualStyleBackColor = true;
            btnQuitar.Click += btnQuitar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 331);
            label3.Name = "label3";
            label3.Size = new Size(74, 15);
            label3.TabIndex = 7;
            label3.Text = "Total a pagar";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(39, 364);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(151, 23);
            txtTotal.TabIndex = 6;
            // 
            // dgvDetallesPedido
            // 
            dgvDetallesPedido.AutoGenerateColumns = false;
            dgvDetallesPedido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetallesPedido.Columns.AddRange(new DataGridViewColumn[] { peliculaDataGridViewTextBoxColumn, cantidadDataGridViewTextBoxColumn1, subtotalDataGridViewTextBoxColumn });
            dgvDetallesPedido.DataSource = detallePedidoBindingSource1;
            dgvDetallesPedido.Location = new Point(27, 64);
            dgvDetallesPedido.Name = "dgvDetallesPedido";
            dgvDetallesPedido.ReadOnly = true;
            dgvDetallesPedido.RowHeadersWidth = 51;
            dgvDetallesPedido.RowTemplate.Height = 25;
            dgvDetallesPedido.Size = new Size(346, 241);
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
            btnFinalizarPedido.Location = new Point(645, 464);
            btnFinalizarPedido.Name = "btnFinalizarPedido";
            btnFinalizarPedido.Size = new Size(119, 23);
            btnFinalizarPedido.TabIndex = 8;
            btnFinalizarPedido.Text = "Finalizar Pedido";
            btnFinalizarPedido.UseVisualStyleBackColor = true;
            btnFinalizarPedido.Click += btnFinalizarPedido_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(769, 464);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 9;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // FormRealizarPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(865, 534);
            Controls.Add(btnVolver);
            Controls.Add(btnFinalizarPedido);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
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
        private Label label2;
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
        private Button btnBuscarCliente;
        private TextBox txtDNICliente;
    }
}