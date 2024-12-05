namespace Vista.Módulo_de_Administración
{
    partial class FormGestorPedidos
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
            cmbMetodoPago = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            btnVolver = new Button();
            btnPagar = new Button();
            btnInformacion = new Button();
            dgvPedidos = new DataGridView();
            codigoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            totalDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            clienteDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fechaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            estadoDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            recargoDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            pedidoBindingSource1 = new BindingSource(components);
            pedidoBindingSource = new BindingSource(components);
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pedidoBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pedidoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmbMetodoPago);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnBuscar);
            groupBox1.Controls.Add(txtBuscar);
            groupBox1.Controls.Add(btnVolver);
            groupBox1.Controls.Add(btnPagar);
            groupBox1.Controls.Add(btnInformacion);
            groupBox1.Controls.Add(dgvPedidos);
            groupBox1.Location = new Point(14, 16);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(752, 565);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // cmbMetodoPago
            // 
            cmbMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodoPago.FormattingEnabled = true;
            cmbMetodoPago.Location = new Point(14, 528);
            cmbMetodoPago.Margin = new Padding(3, 4, 3, 4);
            cmbMetodoPago.Name = "cmbMetodoPago";
            cmbMetodoPago.Size = new Size(155, 28);
            cmbMetodoPago.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 492);
            label2.Name = "label2";
            label2.Size = new Size(120, 20);
            label2.TabIndex = 19;
            label2.Text = "Metodo de Pago";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(329, 92);
            label1.Name = "label1";
            label1.Size = new Size(121, 20);
            label1.TabIndex = 18;
            label1.Text = "Grilla de Pedidos";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(203, 28);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(106, 31);
            btnBuscar.TabIndex = 17;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(19, 29);
            txtBuscar.Margin = new Padding(3, 4, 3, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Ingrese DNI del cliente";
            txtBuscar.Size = new Size(146, 27);
            txtBuscar.TabIndex = 16;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(641, 527);
            btnVolver.Margin = new Padding(3, 4, 3, 4);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(86, 31);
            btnVolver.TabIndex = 3;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnPagar
            // 
            btnPagar.Location = new Point(203, 527);
            btnPagar.Margin = new Padding(3, 4, 3, 4);
            btnPagar.Name = "btnPagar";
            btnPagar.Size = new Size(106, 31);
            btnPagar.TabIndex = 2;
            btnPagar.Text = "Pagar Pedido";
            btnPagar.UseVisualStyleBackColor = true;
            btnPagar.Click += btnPagar_Click;
            // 
            // btnInformacion
            // 
            btnInformacion.Location = new Point(350, 527);
            btnInformacion.Margin = new Padding(3, 4, 3, 4);
            btnInformacion.Name = "btnInformacion";
            btnInformacion.Size = new Size(131, 31);
            btnInformacion.TabIndex = 1;
            btnInformacion.Text = "Ver Información";
            btnInformacion.UseVisualStyleBackColor = true;
            btnInformacion.Click += btnInformacion_Click;
            // 
            // dgvPedidos
            // 
            dgvPedidos.AutoGenerateColumns = false;
            dgvPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPedidos.Columns.AddRange(new DataGridViewColumn[] { codigoDataGridViewTextBoxColumn, totalDataGridViewTextBoxColumn, clienteDataGridViewTextBoxColumn, fechaDataGridViewTextBoxColumn, estadoDataGridViewCheckBoxColumn, recargoDataGridViewCheckBoxColumn });
            dgvPedidos.DataSource = pedidoBindingSource1;
            dgvPedidos.Location = new Point(19, 136);
            dgvPedidos.Margin = new Padding(3, 4, 3, 4);
            dgvPedidos.Name = "dgvPedidos";
            dgvPedidos.ReadOnly = true;
            dgvPedidos.RowHeadersWidth = 51;
            dgvPedidos.RowTemplate.Height = 25;
            dgvPedidos.Size = new Size(707, 327);
            dgvPedidos.TabIndex = 0;
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
            // totalDataGridViewTextBoxColumn
            // 
            totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            totalDataGridViewTextBoxColumn.HeaderText = "Total";
            totalDataGridViewTextBoxColumn.MinimumWidth = 6;
            totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            totalDataGridViewTextBoxColumn.ReadOnly = true;
            totalDataGridViewTextBoxColumn.Width = 125;
            // 
            // clienteDataGridViewTextBoxColumn
            // 
            clienteDataGridViewTextBoxColumn.DataPropertyName = "Cliente";
            clienteDataGridViewTextBoxColumn.HeaderText = "DNI Cliente";
            clienteDataGridViewTextBoxColumn.MinimumWidth = 6;
            clienteDataGridViewTextBoxColumn.Name = "clienteDataGridViewTextBoxColumn";
            clienteDataGridViewTextBoxColumn.ReadOnly = true;
            clienteDataGridViewTextBoxColumn.Width = 125;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            fechaDataGridViewTextBoxColumn.MinimumWidth = 6;
            fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            fechaDataGridViewTextBoxColumn.ReadOnly = true;
            fechaDataGridViewTextBoxColumn.Width = 125;
            // 
            // estadoDataGridViewCheckBoxColumn
            // 
            estadoDataGridViewCheckBoxColumn.DataPropertyName = "Estado";
            estadoDataGridViewCheckBoxColumn.HeaderText = "Estado";
            estadoDataGridViewCheckBoxColumn.MinimumWidth = 6;
            estadoDataGridViewCheckBoxColumn.Name = "estadoDataGridViewCheckBoxColumn";
            estadoDataGridViewCheckBoxColumn.ReadOnly = true;
            estadoDataGridViewCheckBoxColumn.Width = 125;
            // 
            // recargoDataGridViewCheckBoxColumn
            // 
            recargoDataGridViewCheckBoxColumn.DataPropertyName = "Recargo";
            recargoDataGridViewCheckBoxColumn.HeaderText = "Recargo";
            recargoDataGridViewCheckBoxColumn.MinimumWidth = 6;
            recargoDataGridViewCheckBoxColumn.Name = "recargoDataGridViewCheckBoxColumn";
            recargoDataGridViewCheckBoxColumn.ReadOnly = true;
            recargoDataGridViewCheckBoxColumn.Width = 125;
            // 
            // pedidoBindingSource1
            // 
            pedidoBindingSource1.DataSource = typeof(Modelo.Entidades.Pedido);
            // 
            // pedidoBindingSource
            // 
            pedidoBindingSource.DataSource = typeof(Modelo.Entidades.Pedido);
            // 
            // FormGestorPedidos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(779, 597);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormGestorPedidos";
            Text = "FormGestorPedidos";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).EndInit();
            ((System.ComponentModel.ISupportInitialize)pedidoBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pedidoBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnVolver;
        private Button btnPagar;
        private Button btnInformacion;
        private DataGridView dgvPedidos;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private BindingSource pedidoBindingSource;
        private DataGridViewTextBoxColumn codigoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn clienteDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn estadoDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn recargoDataGridViewCheckBoxColumn;
        private BindingSource pedidoBindingSource1;
        private Button btnBuscar;
        private TextBox txtBuscar;
        private Label label1;
        private ComboBox cmbMetodoPago;
        private Label label2;
    }
}