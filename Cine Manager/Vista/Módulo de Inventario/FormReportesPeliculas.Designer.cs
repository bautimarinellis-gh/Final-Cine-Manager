namespace Vista.Módulo_de_Inventario
{
    partial class FormReportesPeliculas
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
            label1 = new Label();
            dgvVentasPeliculas = new DataGridView();
            btnExportar = new Button();
            btnVolver = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVentasPeliculas).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(dgvVentasPeliculas);
            groupBox1.Controls.Add(btnExportar);
            groupBox1.Controls.Add(btnVolver);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(667, 422);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 19);
            label1.Name = "label1";
            label1.Size = new Size(225, 15);
            label1.TabIndex = 3;
            label1.Text = "Grilla Reporte con películas más vendidas";
            // 
            // dgvVentasPeliculas
            // 
            dgvVentasPeliculas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentasPeliculas.Location = new Point(25, 50);
            dgvVentasPeliculas.Name = "dgvVentasPeliculas";
            dgvVentasPeliculas.RowTemplate.Height = 25;
            dgvVentasPeliculas.Size = new Size(626, 308);
            dgvVentasPeliculas.TabIndex = 2;
            // 
            // btnExportar
            // 
            btnExportar.Location = new Point(25, 386);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(101, 23);
            btnExportar.TabIndex = 1;
            btnExportar.Text = "Exportar a PDF";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(576, 386);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 0;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // FormReportesPeliculas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(703, 446);
            Controls.Add(groupBox1);
            Name = "FormReportesPeliculas";
            Text = "FormReportesPeliculas";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVentasPeliculas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dgvVentasPeliculas;
        private Button btnExportar;
        private Button btnVolver;
        private Label label1;
    }
}