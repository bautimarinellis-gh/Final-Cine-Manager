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
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pedidoBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pedidoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnBuscar);
            groupBox1.Controls.Add(txtBuscar);
            groupBox1.Controls.Add(btnVolver);
            groupBox1.Controls.Add(btnPagar);
            groupBox1.Controls.Add(btnInformacion);
            groupBox1.Controls.Add(dgvPedidos);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(658, 411);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(561, 373);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 3;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnPagar
            // 
            btnPagar.Location = new Point(148, 373);
            btnPagar.Name = "btnPagar";
            btnPagar.Size = new Size(93, 23);
            btnPagar.TabIndex = 2;
            btnPagar.Text = "Pagar Pedido";
            btnPagar.UseVisualStyleBackColor = true;
            btnPagar.Click += btnPagar_Click;
            // 
            // btnInformacion
            // 
            btnInformacion.Location = new Point(17, 373);
            btnInformacion.Name = "btnInformacion";
            btnInformacion.Size = new Size(103, 23);
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
            dgvPedidos.Location = new Point(17, 58);
            dgvPedidos.Name = "dgvPedidos";
            dgvPedidos.ReadOnly = true;
            dgvPedidos.RowTemplate.Height = 25;
            dgvPedidos.Size = new Size(619, 287);
            dgvPedidos.TabIndex = 0;
            // 
            // codigoDataGridViewTextBoxColumn
            // 
            codigoDataGridViewTextBoxColumn.DataPropertyName = "Codigo";
            codigoDataGridViewTextBoxColumn.HeaderText = "Codigo";
            codigoDataGridViewTextBoxColumn.Name = "codigoDataGridViewTextBoxColumn";
            codigoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            totalDataGridViewTextBoxColumn.HeaderText = "Total";
            totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            totalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // clienteDataGridViewTextBoxColumn
            // 
            clienteDataGridViewTextBoxColumn.DataPropertyName = "Cliente";
            clienteDataGridViewTextBoxColumn.HeaderText = "DNI Cliente";
            clienteDataGridViewTextBoxColumn.Name = "clienteDataGridViewTextBoxColumn";
            clienteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            fechaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estadoDataGridViewCheckBoxColumn
            // 
            estadoDataGridViewCheckBoxColumn.DataPropertyName = "Estado";
            estadoDataGridViewCheckBoxColumn.HeaderText = "Estado";
            estadoDataGridViewCheckBoxColumn.Name = "estadoDataGridViewCheckBoxColumn";
            estadoDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // recargoDataGridViewCheckBoxColumn
            // 
            recargoDataGridViewCheckBoxColumn.DataPropertyName = "Recargo";
            recargoDataGridViewCheckBoxColumn.HeaderText = "Recargo";
            recargoDataGridViewCheckBoxColumn.Name = "recargoDataGridViewCheckBoxColumn";
            recargoDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // pedidoBindingSource1
            // 
            pedidoBindingSource1.DataSource = typeof(Modelo.Entidades.Pedido);
            // 
            // pedidoBindingSource
            // 
            pedidoBindingSource.DataSource = typeof(Modelo.Entidades.Pedido);
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(178, 21);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(93, 23);
            btnBuscar.TabIndex = 17;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(17, 22);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Ingrese DNI del cliente";
            txtBuscar.Size = new Size(128, 23);
            txtBuscar.TabIndex = 16;
            // 
            // FormGestorPedidos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 435);
            Controls.Add(groupBox1);
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
    }
}