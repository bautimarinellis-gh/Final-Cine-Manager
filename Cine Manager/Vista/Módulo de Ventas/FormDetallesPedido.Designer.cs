namespace Vista.Módulo_de_Administración
{
    partial class FormDetallesPedido
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
            dgvDetallesVenta = new DataGridView();
            peliculaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cantidadDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            garantiaDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            detalleVentaBindingSource = new BindingSource(components);
            detallePedidoBindingSource = new BindingSource(components);
            groupBox2 = new GroupBox();
            btnDevolver = new Button();
            label2 = new Label();
            dgvDetallesAlquiler = new DataGridView();
            peliculaDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            cantidadDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            fechaDevolucionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            devueltoDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            detalleAlquilerBindingSource = new BindingSource(components);
            btnVolver = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetallesVenta).BeginInit();
            ((System.ComponentModel.ISupportInitialize)detalleVentaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)detallePedidoBindingSource).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetallesAlquiler).BeginInit();
            ((System.ComponentModel.ISupportInitialize)detalleAlquilerBindingSource).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(dgvDetallesVenta);
            groupBox1.Location = new Point(24, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(388, 369);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 19);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 1;
            label1.Text = "Detalles Ventas";
            // 
            // dgvDetallesVenta
            // 
            dgvDetallesVenta.AutoGenerateColumns = false;
            dgvDetallesVenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetallesVenta.Columns.AddRange(new DataGridViewColumn[] { peliculaDataGridViewTextBoxColumn, cantidadDataGridViewTextBoxColumn, garantiaDataGridViewCheckBoxColumn });
            dgvDetallesVenta.DataSource = detalleVentaBindingSource;
            dgvDetallesVenta.Location = new Point(27, 47);
            dgvDetallesVenta.Name = "dgvDetallesVenta";
            dgvDetallesVenta.ReadOnly = true;
            dgvDetallesVenta.RowTemplate.Height = 25;
            dgvDetallesVenta.Size = new Size(345, 270);
            dgvDetallesVenta.TabIndex = 0;
            // 
            // peliculaDataGridViewTextBoxColumn
            // 
            peliculaDataGridViewTextBoxColumn.DataPropertyName = "Pelicula";
            peliculaDataGridViewTextBoxColumn.HeaderText = "Pelicula";
            peliculaDataGridViewTextBoxColumn.Name = "peliculaDataGridViewTextBoxColumn";
            peliculaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // garantiaDataGridViewCheckBoxColumn
            // 
            garantiaDataGridViewCheckBoxColumn.DataPropertyName = "Garantia";
            garantiaDataGridViewCheckBoxColumn.HeaderText = "Garantia";
            garantiaDataGridViewCheckBoxColumn.Name = "garantiaDataGridViewCheckBoxColumn";
            garantiaDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // detalleVentaBindingSource
            // 
            detalleVentaBindingSource.DataSource = typeof(Modelo.Entidades.DetalleVenta);
            // 
            // detallePedidoBindingSource
            // 
            detallePedidoBindingSource.DataSource = typeof(Modelo.Entidades.DetallePedido);
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnDevolver);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(dgvDetallesAlquiler);
            groupBox2.Location = new Point(435, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(465, 369);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            // 
            // btnDevolver
            // 
            btnDevolver.Location = new Point(16, 339);
            btnDevolver.Name = "btnDevolver";
            btnDevolver.Size = new Size(111, 24);
            btnDevolver.TabIndex = 3;
            btnDevolver.Text = "Devolver Alquiler";
            btnDevolver.UseVisualStyleBackColor = true;
            btnDevolver.Click += btnDevolver_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 19);
            label2.Name = "label2";
            label2.Size = new Size(103, 15);
            label2.TabIndex = 2;
            label2.Text = "Detalles Alquileres";
            // 
            // dgvDetallesAlquiler
            // 
            dgvDetallesAlquiler.AutoGenerateColumns = false;
            dgvDetallesAlquiler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetallesAlquiler.Columns.AddRange(new DataGridViewColumn[] { peliculaDataGridViewTextBoxColumn1, cantidadDataGridViewTextBoxColumn1, fechaDevolucionDataGridViewTextBoxColumn, devueltoDataGridViewCheckBoxColumn });
            dgvDetallesAlquiler.DataSource = detalleAlquilerBindingSource;
            dgvDetallesAlquiler.Location = new Point(16, 47);
            dgvDetallesAlquiler.Name = "dgvDetallesAlquiler";
            dgvDetallesAlquiler.ReadOnly = true;
            dgvDetallesAlquiler.RowTemplate.Height = 25;
            dgvDetallesAlquiler.Size = new Size(443, 270);
            dgvDetallesAlquiler.TabIndex = 0;
            // 
            // peliculaDataGridViewTextBoxColumn1
            // 
            peliculaDataGridViewTextBoxColumn1.DataPropertyName = "Pelicula";
            peliculaDataGridViewTextBoxColumn1.HeaderText = "Pelicula";
            peliculaDataGridViewTextBoxColumn1.Name = "peliculaDataGridViewTextBoxColumn1";
            peliculaDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // cantidadDataGridViewTextBoxColumn1
            // 
            cantidadDataGridViewTextBoxColumn1.DataPropertyName = "Cantidad";
            cantidadDataGridViewTextBoxColumn1.HeaderText = "Cantidad";
            cantidadDataGridViewTextBoxColumn1.Name = "cantidadDataGridViewTextBoxColumn1";
            cantidadDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // fechaDevolucionDataGridViewTextBoxColumn
            // 
            fechaDevolucionDataGridViewTextBoxColumn.DataPropertyName = "FechaDevolucion";
            fechaDevolucionDataGridViewTextBoxColumn.HeaderText = "FechaDevolucion";
            fechaDevolucionDataGridViewTextBoxColumn.Name = "fechaDevolucionDataGridViewTextBoxColumn";
            fechaDevolucionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // devueltoDataGridViewCheckBoxColumn
            // 
            devueltoDataGridViewCheckBoxColumn.DataPropertyName = "Devuelto";
            devueltoDataGridViewCheckBoxColumn.HeaderText = "Devuelto";
            devueltoDataGridViewCheckBoxColumn.Name = "devueltoDataGridViewCheckBoxColumn";
            devueltoDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // detalleAlquilerBindingSource
            // 
            detalleAlquilerBindingSource.DataSource = typeof(Modelo.Entidades.DetalleAlquiler);
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(825, 377);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // FormDetallesPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(912, 403);
            Controls.Add(btnVolver);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FormDetallesPedido";
            Text = "FormDetallesPedido";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetallesVenta).EndInit();
            ((System.ComponentModel.ISupportInitialize)detalleVentaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)detallePedidoBindingSource).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetallesAlquiler).EndInit();
            ((System.ComponentModel.ISupportInitialize)detalleAlquilerBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dgvDetallesVenta;
        private BindingSource detalleVentaBindingSource;
        private BindingSource detallePedidoBindingSource;
        private GroupBox groupBox2;
        private DataGridView dgvDetallesAlquiler;
        private DataGridViewTextBoxColumn peliculaDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn fechaDevolucionDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn devueltoDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn estadoDataGridViewCheckBoxColumn1;
        private BindingSource detalleAlquilerBindingSource;
        private DataGridViewTextBoxColumn peliculaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn garantiaDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn estadoDataGridViewCheckBoxColumn;
        private Button btnVolver;
        private Label label1;
        private Label label2;
        private Button btnDevolver;
    }
}