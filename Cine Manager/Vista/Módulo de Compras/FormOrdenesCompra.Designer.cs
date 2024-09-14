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
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            btnPagar = new Button();
            btnVolver = new Button();
            btnRealizarOrden = new Button();
            dgvOrdenesCompra = new DataGridView();
            codigoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            proveedorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fechaOrdenDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            totalDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            estadoDataGridViewCheckBoxColumn = new DataGridViewTextBoxColumn();
            ordenCompraBindingSource = new BindingSource(components);
            cmbEstado = new ComboBox();
            label2 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrdenesCompra).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ordenCompraBindingSource).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cmbEstado);
            groupBox1.Controls.Add(btnBuscar);
            groupBox1.Controls.Add(txtBuscar);
            groupBox1.Controls.Add(btnPagar);
            groupBox1.Controls.Add(btnVolver);
            groupBox1.Controls.Add(btnRealizarOrden);
            groupBox1.Controls.Add(dgvOrdenesCompra);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(689, 382);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
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
            // btnPagar
            // 
            btnPagar.Location = new Point(210, 347);
            btnPagar.Name = "btnPagar";
            btnPagar.Size = new Size(150, 23);
            btnPagar.TabIndex = 3;
            btnPagar.Text = "Pagar Orden de compra";
            btnPagar.UseVisualStyleBackColor = true;
            btnPagar.Click += btnPagar_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(593, 347);
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
            btnRealizarOrden.Text = "Realizar Orden de Compra";
            btnRealizarOrden.UseVisualStyleBackColor = true;
            btnRealizarOrden.Click += btnRealizarOrden_Click;
            // 
            // dgvOrdenesCompra
            // 
            dgvOrdenesCompra.AutoGenerateColumns = false;
            dgvOrdenesCompra.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrdenesCompra.Columns.AddRange(new DataGridViewColumn[] { codigoDataGridViewTextBoxColumn, proveedorDataGridViewTextBoxColumn, fechaOrdenDataGridViewTextBoxColumn, totalDataGridViewTextBoxColumn, estadoDataGridViewCheckBoxColumn });
            dgvOrdenesCompra.DataSource = ordenCompraBindingSource;
            dgvOrdenesCompra.Location = new Point(18, 63);
            dgvOrdenesCompra.Name = "dgvOrdenesCompra";
            dgvOrdenesCompra.RowTemplate.Height = 25;
            dgvOrdenesCompra.Size = new Size(650, 258);
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
            // totalDataGridViewTextBoxColumn
            // 
            totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            totalDataGridViewTextBoxColumn.HeaderText = "Total";
            totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            // 
            // estadoDataGridViewCheckBoxColumn
            // 
            estadoDataGridViewCheckBoxColumn.DataPropertyName = "EstadoTexto";
            estadoDataGridViewCheckBoxColumn.HeaderText = "Estado";
            estadoDataGridViewCheckBoxColumn.Name = "estadoDataGridViewCheckBoxColumn";
            estadoDataGridViewCheckBoxColumn.ReadOnly = true;
            estadoDataGridViewCheckBoxColumn.Resizable = DataGridViewTriState.True;
            estadoDataGridViewCheckBoxColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ordenCompraBindingSource
            // 
            ordenCompraBindingSource.DataSource = typeof(Modelo.Entidades.OrdenCompra);
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Items.AddRange(new object[] { "Todas", "Pendientes", "Completadas" });
            cmbEstado.Location = new Point(445, 22);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(121, 23);
            cmbEstado.TabIndex = 6;
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
            // FormOrdenesCompra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(719, 406);
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
        private Button btnPagar;
        private Button btnBuscar;
        private TextBox txtBuscar;
        private BindingSource ordenCompraBindingSource;
        private DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn proveedorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechaOrdenDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn estadoDataGridViewCheckBoxColumn;
        private ComboBox cmbEstado;
        private Label label2;
    }
}