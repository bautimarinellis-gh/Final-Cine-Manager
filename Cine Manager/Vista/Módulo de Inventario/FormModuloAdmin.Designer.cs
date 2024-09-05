namespace Vista.Módulo_de_Administración
{
    partial class FormModuloAdmin
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
            btnPedidos = new Button();
            btnVolver = new Button();
            btnPeliculas = new Button();
            btnClientes = new Button();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnPedidos);
            groupBox1.Controls.Add(btnVolver);
            groupBox1.Controls.Add(btnPeliculas);
            groupBox1.Controls.Add(btnClientes);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(374, 374);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // btnPedidos
            // 
            btnPedidos.Location = new Point(116, 266);
            btnPedidos.Name = "btnPedidos";
            btnPedidos.Size = new Size(120, 23);
            btnPedidos.TabIndex = 4;
            btnPedidos.Text = "Gestionar Pedidos";
            btnPedidos.UseVisualStyleBackColor = true;
            btnPedidos.Click += btnPedidos_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(272, 331);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(75, 23);
            btnVolver.TabIndex = 3;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnPeliculas
            // 
            btnPeliculas.Location = new Point(116, 119);
            btnPeliculas.Name = "btnPeliculas";
            btnPeliculas.Size = new Size(120, 23);
            btnPeliculas.TabIndex = 1;
            btnPeliculas.Text = "Gestionar Películas";
            btnPeliculas.UseVisualStyleBackColor = true;
            btnPeliculas.Click += btnPeliculas_Click;
            // 
            // btnClientes
            // 
            btnClientes.Location = new Point(116, 194);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(120, 23);
            btnClientes.TabIndex = 2;
            btnClientes.Text = "Gestionar Clientes";
            btnClientes.UseVisualStyleBackColor = true;
            btnClientes.Click += btnClientes_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(107, 41);
            label1.Name = "label1";
            label1.Size = new Size(149, 15);
            label1.TabIndex = 0;
            label1.Text = "Módulo de Administración";
            // 
            // FormModuloAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 398);
            Controls.Add(groupBox1);
            Name = "FormModuloAdmin";
            Text = "FormModuloAdmin";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnVolver;
        private Button btnPeliculas;
        private Button btnClientes;
        private Label label1;
        private Button btnPedidos;
    }
}