namespace Vista
{
    partial class FormInicio
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
            btnCerrar = new Button();
            btnModuloTransacc = new Button();
            btnModuloAdmin = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCerrar);
            groupBox1.Controls.Add(btnModuloTransacc);
            groupBox1.Controls.Add(btnModuloAdmin);
            groupBox1.Location = new Point(12, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(375, 300);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(139, 243);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 23);
            btnCerrar.TabIndex = 2;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnModuloTransacc
            // 
            btnModuloTransacc.Location = new Point(98, 151);
            btnModuloTransacc.Name = "btnModuloTransacc";
            btnModuloTransacc.Size = new Size(172, 27);
            btnModuloTransacc.TabIndex = 1;
            btnModuloTransacc.Text = "Módulo de Transacciones";
            btnModuloTransacc.UseVisualStyleBackColor = true;
            btnModuloTransacc.Click += btnModuloTransacc_Click;
            // 
            // btnModuloAdmin
            // 
            btnModuloAdmin.Location = new Point(98, 61);
            btnModuloAdmin.Name = "btnModuloAdmin";
            btnModuloAdmin.Size = new Size(172, 27);
            btnModuloAdmin.TabIndex = 0;
            btnModuloAdmin.Text = "Módulo de Administración";
            btnModuloAdmin.UseVisualStyleBackColor = true;
            btnModuloAdmin.Click += btnModuloAdmin_Click;
            // 
            // FormInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(402, 319);
            Controls.Add(groupBox1);
            Name = "FormInicio";
            Text = "FormInicio";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnModuloTransacc;
        private Button btnModuloAdmin;
        private Button btnCerrar;
    }
}