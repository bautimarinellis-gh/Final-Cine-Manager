namespace Vista.Módulo_de_Compras
{
    partial class FormAsignarProveedor
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
            groupBox1 = new GroupBox();
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            label5 = new Label();
            btnVolver = new Button();
            btnAsginar = new Button();
            dgvProveedores = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnBuscar);
            groupBox1.Controls.Add(txtBuscar);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(btnVolver);
            groupBox1.Controls.Add(btnAsginar);
            groupBox1.Controls.Add(dgvProveedores);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(497, 384);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(214, 49);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(93, 23);
            btnBuscar.TabIndex = 21;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(27, 50);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Ingrese codigo del proveedor";
            txtBuscar.Size = new Size(171, 23);
            txtBuscar.TabIndex = 20;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 19);
            label5.Name = "label5";
            label5.Size = new Size(118, 15);
            label5.TabIndex = 19;
            label5.Text = "Grilla de proveedores";
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(386, 342);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 8;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnAsginar
            // 
            btnAsginar.Location = new Point(27, 342);
            btnAsginar.Name = "btnAsginar";
            btnAsginar.Size = new Size(75, 23);
            btnAsginar.TabIndex = 4;
            btnAsginar.Text = "Asignar";
            btnAsginar.UseVisualStyleBackColor = true;
            btnAsginar.Click += btnAsginar_Click;
            // 
            // dgvProveedores
            // 
            dgvProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProveedores.Location = new Point(27, 90);
            dgvProveedores.Name = "dgvProveedores";
            dgvProveedores.ReadOnly = true;
            dgvProveedores.RowTemplate.Height = 25;
            dgvProveedores.Size = new Size(434, 237);
            dgvProveedores.TabIndex = 7;
            // 
            // FormAsignarProveedor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(529, 411);
            Controls.Add(groupBox1);
            Name = "FormAsignarProveedor";
            Text = "FormAsignarProveedor";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnBuscar;
        private TextBox txtBuscar;
        private Label label5;
        private Button btnVolver;
        private Button btnAsginar;
        private DataGridView dgvProveedores;
    }
}