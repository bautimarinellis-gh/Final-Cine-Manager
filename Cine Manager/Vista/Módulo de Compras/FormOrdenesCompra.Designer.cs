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
            groupBox1.Controls.Add(btnInformacion);
            groupBox1.Controls.Add(btnCancelar);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cmbEstado);
            groupBox1.Controls.Add(btnBuscar);
            groupBox1.Controls.Add(txtBuscar);
            groupBox1.Controls.Add(btnVolver);
            groupBox1.Controls.Add(btnRealizarOrden);
            groupBox1.Controls.Add(dgvOrdenesCompra);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(765, 382);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // btnInformacion
            // 
            btnInformacion.Location = new Point(194, 347);
            btnInformacion.Name = "btnInformacion";
            btnInformacion.Size = new Size(107, 23);
            btnInformacion.TabIndex = 9;
            btnInformacion.Text = "Ver Información";
            btnInformacion.UseVisualStyleBackColor = true;
            btnInformacion.Click += btnInformacion_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(320, 347);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(160, 23);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar orden de compra";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(320, 25);
            label2.Name = "label2";
            label2.Size = new Size(99, 15);
            label2.TabIndex = 7;
            label2.Text = "Filtrar por estado ";
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Items.AddRange(new object[] { "Todas", "Pendientes", "Parcialmente Completadas", "Completadas", "Canceladas" });
            cmbEstado.Location = new Point(445, 22);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(140, 23);
            cmbEstado.TabIndex = 6;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(194, 21);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 5;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(18, 22);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Ingrese el codigo de la orden";
            txtBuscar.Size = new Size(159, 23);
            txtBuscar.TabIndex = 4;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(674, 347);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnRealizarOrden
            // 
            btnRealizarOrden.Location = new Point(18, 347);
            btnRealizarOrden.Name = "btnRealizarOrden";
            btnRealizarOrden.Size = new Size(159, 23);
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
            dgvOrdenesCompra.Location = new Point(18, 63);
            dgvOrdenesCompra.Name = "dgvOrdenesCompra";
            dgvOrdenesCompra.RowTemplate.Height = 25;
            dgvOrdenesCompra.Size = new Size(731, 258);
            dgvOrdenesCompra.TabIndex = 0;
            // 
            // codigoDataGridViewTextBoxColumn
            // 
            codigoDataGridViewTextBoxColumn.DataPropertyName = "Codigo";
            codigoDataGridViewTextBoxColumn.HeaderText = "Codigo";
            codigoDataGridViewTextBoxColumn.Name = "codigoDataGridViewTextBoxColumn";
            // 
            // proveedorDataGridViewTextBoxColumn
            // 
            proveedorDataGridViewTextBoxColumn.DataPropertyName = "CodigoProveedor";
            proveedorDataGridViewTextBoxColumn.HeaderText = "Proveedor";
            proveedorDataGridViewTextBoxColumn.Name = "proveedorDataGridViewTextBoxColumn";
            proveedorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaOrdenDataGridViewTextBoxColumn
            // 
            fechaOrdenDataGridViewTextBoxColumn.DataPropertyName = "FechaOrden";
            fechaOrdenDataGridViewTextBoxColumn.HeaderText = "Fecha ";
            fechaOrdenDataGridViewTextBoxColumn.Name = "fechaOrdenDataGridViewTextBoxColumn";
            // 
            // EstadoActual
            // 
            EstadoActual.DataPropertyName = "Estado";
            EstadoActual.HeaderText = "Estado";
            EstadoActual.Name = "EstadoActual";
            // 
            // totalDataGridViewTextBoxColumn
            // 
            totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            totalDataGridViewTextBoxColumn.HeaderText = "Total";
            totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            // 
            // ordenCompraBindingSource
            // 
            ordenCompraBindingSource.DataSource = typeof(Modelo.Entidades.OrdenCompra);
            // 
            // FormOrdenesCompra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(789, 406);
            Controls.Add(groupBox1);
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
    }
}