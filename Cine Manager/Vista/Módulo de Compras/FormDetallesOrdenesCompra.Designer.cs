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
            btnPagar = new Button();
            dgvDetallesOrdenCompra = new DataGridView();
            peliculaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cantidadDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            estadoDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            detalleOrdenCompraBindingSource = new BindingSource(components);
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetallesOrdenCompra).BeginInit();
            ((System.ComponentModel.ISupportInitialize)detalleOrdenCompraBindingSource).BeginInit();
            SuspendLayout();
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(402, 387);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 4;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnPagar);
            groupBox2.Controls.Add(dgvDetallesOrdenCompra);
            groupBox2.Location = new Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(465, 369);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            // 
            // btnPagar
            // 
            btnPagar.Location = new Point(16, 339);
            btnPagar.Name = "btnPagar";
            btnPagar.Size = new Size(111, 24);
            btnPagar.TabIndex = 3;
            btnPagar.Text = "Pagar Detalle";
            btnPagar.UseVisualStyleBackColor = true;
            btnPagar.Click += btnPagar_Click;
            // 
            // dgvDetallesOrdenCompra
            // 
            dgvDetallesOrdenCompra.AutoGenerateColumns = false;
            dgvDetallesOrdenCompra.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetallesOrdenCompra.Columns.AddRange(new DataGridViewColumn[] { peliculaDataGridViewTextBoxColumn, cantidadDataGridViewTextBoxColumn, estadoDataGridViewCheckBoxColumn });
            dgvDetallesOrdenCompra.DataSource = detalleOrdenCompraBindingSource;
            dgvDetallesOrdenCompra.Location = new Point(16, 47);
            dgvDetallesOrdenCompra.Name = "dgvDetallesOrdenCompra";
            dgvDetallesOrdenCompra.ReadOnly = true;
            dgvDetallesOrdenCompra.RowTemplate.Height = 25;
            dgvDetallesOrdenCompra.Size = new Size(443, 270);
            dgvDetallesOrdenCompra.TabIndex = 0;
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
            // estadoDataGridViewCheckBoxColumn
            // 
            estadoDataGridViewCheckBoxColumn.DataPropertyName = "Estado";
            estadoDataGridViewCheckBoxColumn.HeaderText = "Estado";
            estadoDataGridViewCheckBoxColumn.Name = "estadoDataGridViewCheckBoxColumn";
            estadoDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // detalleOrdenCompraBindingSource
            // 
            detalleOrdenCompraBindingSource.DataSource = typeof(Modelo.Entidades.DetalleOrdenCompra);
            // 
            // FormDetallesOrdenesCompra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(498, 450);
            Controls.Add(btnVolver);
            Controls.Add(groupBox2);
            Name = "FormDetallesOrdenesCompra";
            Text = "FormDetallesOrdenesCompra";
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDetallesOrdenCompra).EndInit();
            ((System.ComponentModel.ISupportInitialize)detalleOrdenCompraBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnVolver;
        private GroupBox groupBox2;
        private Button btnPagar;
        private DataGridView dgvDetallesOrdenCompra;
        private DataGridViewTextBoxColumn peliculaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn estadoDataGridViewCheckBoxColumn;
        private BindingSource detalleOrdenCompraBindingSource;
    }
}