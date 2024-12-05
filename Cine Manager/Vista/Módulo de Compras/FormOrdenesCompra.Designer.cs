namespace Vista.Módulo_de_Compras
{
    partial class FormOrdenesCompra
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
            label1 = new Label();
            btnCerrar = new Button();
            btnInformacion = new Button();
            btnCancelar = new Button();
            label2 = new Label();
            cmbEstado = new ComboBox();
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            btnVolver = new Button();
            btnRealizarOrden = new Button();
            dgvOrdenesCompra = new DataGridView();
            codigoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            proveedorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fechaOrdenDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            EstadoActual = new DataGridViewTextBoxColumn();
            totalDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ordenCompraBindingSource = new BindingSource(components);
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrdenesCompra).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ordenCompraBindingSource).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnCerrar);
            groupBox1.Controls.Add(btnInformacion);
            groupBox1.Controls.Add(btnCancelar);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cmbEstado);
            groupBox1.Controls.Add(btnBuscar);
            groupBox1.Controls.Add(txtBuscar);
            groupBox1.Controls.Add(btnVolver);
            groupBox1.Controls.Add(btnRealizarOrden);
            groupBox1.Controls.Add(dgvOrdenesCompra);
            groupBox1.Location = new Point(14, 16);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(894, 537);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(321, 93);
            label1.Name = "label1";
            label1.Size = new Size(202, 20);
            label1.TabIndex = 11;
            label1.Text = "Grilla de Ordenes de Compra";
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(366, 496);
            btnCerrar.Margin = new Padding(3, 4, 3, 4);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(183, 31);
            btnCerrar.TabIndex = 10;
            btnCerrar.Text = "Cerrar orden de compra";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnInformacion
            // 
            btnInformacion.Location = new Point(222, 496);
            btnInformacion.Margin = new Padding(3, 4, 3, 4);
            btnInformacion.Name = "btnInformacion";
            btnInformacion.Size = new Size(122, 31);
            btnInformacion.TabIndex = 9;
            btnInformacion.Text = "Ver Información";
            btnInformacion.UseVisualStyleBackColor = true;
            btnInformacion.Click += btnInformacion_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(576, 496);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(195, 31);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar orden de compra";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(366, 33);
            label2.Name = "label2";
            label2.Size = new Size(127, 20);
            label2.TabIndex = 7;
            label2.Text = "Filtrar por estado ";
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Items.AddRange(new object[] { "Todas", "Pendientes", "Parcialmente Completadas", "Completadas", "Cerradas Con Faltante", "Canceladas" });
            cmbEstado.Location = new Point(509, 29);
            cmbEstado.Margin = new Padding(3, 4, 3, 4);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(189, 28);
            cmbEstado.TabIndex = 6;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(245, 28);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(86, 31);
            btnBuscar.TabIndex = 5;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(21, 29);
            txtBuscar.Margin = new Padding(3, 4, 3, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Ingrese el codigo de la orden";
            txtBuscar.Size = new Size(208, 27);
            txtBuscar.TabIndex = 4;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(786, 496);
            btnVolver.Margin = new Padding(3, 4, 3, 4);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(86, 31);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnRealizarOrden
            // 
            btnRealizarOrden.Location = new Point(21, 496);
            btnRealizarOrden.Margin = new Padding(3, 4, 3, 4);
            btnRealizarOrden.Name = "btnRealizarOrden";
            btnRealizarOrden.Size = new Size(195, 31);
            btnRealizarOrden.TabIndex = 1;
            btnRealizarOrden.Text = "Realizar orden de compra";
            btnRealizarOrden.UseVisualStyleBackColor = true;
            btnRealizarOrden.Click += btnRealizarOrden_Click;
            // 
            // dgvOrdenesCompra
            // 
            dgvOrdenesCompra.AutoGenerateColumns = false;
            dgvOrdenesCompra.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrdenesCompra.Columns.AddRange(new DataGridViewColumn[] { codigoDataGridViewTextBoxColumn, proveedorDataGridViewTextBoxColumn, fechaOrdenDataGridViewTextBoxColumn, EstadoActual, totalDataGridViewTextBoxColumn });
            dgvOrdenesCompra.DataSource = ordenCompraBindingSource;
            dgvOrdenesCompra.Location = new Point(21, 117);
            dgvOrdenesCompra.Margin = new Padding(3, 4, 3, 4);
            dgvOrdenesCompra.Name = "dgvOrdenesCompra";
            dgvOrdenesCompra.ReadOnly = true;
            dgvOrdenesCompra.RowHeadersWidth = 51;
            dgvOrdenesCompra.RowTemplate.Height = 25;
            dgvOrdenesCompra.Size = new Size(851, 344);
            dgvOrdenesCompra.TabIndex = 0;
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
            // proveedorDataGridViewTextBoxColumn
            // 
            proveedorDataGridViewTextBoxColumn.DataPropertyName = "CodigoProveedor";
            proveedorDataGridViewTextBoxColumn.HeaderText = "Proveedor";
            proveedorDataGridViewTextBoxColumn.MinimumWidth = 6;
            proveedorDataGridViewTextBoxColumn.Name = "proveedorDataGridViewTextBoxColumn";
            proveedorDataGridViewTextBoxColumn.ReadOnly = true;
            proveedorDataGridViewTextBoxColumn.Width = 125;
            // 
            // fechaOrdenDataGridViewTextBoxColumn
            // 
            fechaOrdenDataGridViewTextBoxColumn.DataPropertyName = "FechaOrden";
            fechaOrdenDataGridViewTextBoxColumn.HeaderText = "Fecha ";
            fechaOrdenDataGridViewTextBoxColumn.MinimumWidth = 6;
            fechaOrdenDataGridViewTextBoxColumn.Name = "fechaOrdenDataGridViewTextBoxColumn";
            fechaOrdenDataGridViewTextBoxColumn.ReadOnly = true;
            fechaOrdenDataGridViewTextBoxColumn.Width = 125;
            // 
            // EstadoActual
            // 
            EstadoActual.DataPropertyName = "Estado";
            EstadoActual.HeaderText = "Estado";
            EstadoActual.MinimumWidth = 6;
            EstadoActual.Name = "EstadoActual";
            EstadoActual.ReadOnly = true;
            EstadoActual.Width = 125;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            totalDataGridViewTextBoxColumn.HeaderText = "Total";
            totalDataGridViewTextBoxColumn.MinimumWidth = 6;
            totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            totalDataGridViewTextBoxColumn.ReadOnly = true;
            totalDataGridViewTextBoxColumn.Width = 125;
            // 
            // ordenCompraBindingSource
            // 
            ordenCompraBindingSource.DataSource = typeof(Modelo.Entidades.OrdenCompra);
            // 
            // FormOrdenesCompra
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(921, 569);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormOrdenesCompra";
            Text = "FormOrdenesCompra";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrdenesCompra).EndInit();
            ((System.ComponentModel.ISupportInitialize)ordenCompraBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnVolver;
        private Button btnRealizarOrden;
        private DataGridView dgvOrdenesCompra;
        private Button btnBuscar;
        private TextBox txtBuscar;
        private BindingSource ordenCompraBindingSource;
        private DataGridViewTextBoxColumn estadoDataGridViewCheckBoxColumn;
        private ComboBox cmbEstado;
        private Label label2;
        private Button btnCancelar;
        private DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn proveedorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechaOrdenDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn EstadoActual;
        private DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private Button btnInformacion;
        private Button btnCerrar;
        private Label label1;
    }
}