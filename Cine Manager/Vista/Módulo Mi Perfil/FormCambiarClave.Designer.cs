namespace Vista.Módulo_de_Seguridad
{
    partial class FormCambiarClave
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
            txtConfirmar = new TextBox();
            label3 = new Label();
            btnCancelar = new Button();
            btnAceptar = new Button();
            txtClaveNueva = new TextBox();
            txtClaveActual = new TextBox();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtConfirmar);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(btnCancelar);
            groupBox1.Controls.Add(btnAceptar);
            groupBox1.Controls.Add(txtClaveNueva);
            groupBox1.Controls.Add(txtClaveActual);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(475, 260);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // txtConfirmar
            // 
            txtConfirmar.Location = new Point(181, 145);
            txtConfirmar.Name = "txtConfirmar";
            txtConfirmar.Size = new Size(259, 23);
            txtConfirmar.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(54, 99);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 7;
            label3.Text = "Clave Nueva";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(365, 212);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(247, 212);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 4;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // txtClaveNueva
            // 
            txtClaveNueva.Location = new Point(181, 91);
            txtClaveNueva.Name = "txtClaveNueva";
            txtClaveNueva.Size = new Size(259, 23);
            txtClaveNueva.TabIndex = 2;
            // 
            // txtClaveActual
            // 
            txtClaveActual.Location = new Point(181, 40);
            txtClaveActual.Name = "txtClaveActual";
            txtClaveActual.Size = new Size(259, 23);
            txtClaveActual.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(54, 153);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 1;
            label2.Text = "Confirmar";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 40);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 0;
            label1.Text = "Clave Actual";
            // 
            // FormCambiarClave
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(506, 284);
            Controls.Add(groupBox1);
            Name = "FormCambiarClave";
            Text = "FormRecuperarClave";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtConfirmar;
        private Label label3;
        private Button btnCancelar;
        private Button btnAceptar;
        private TextBox txtClaveNueva;
        private TextBox txtClaveActual;
        private Label label2;
        private Label label1;
    }
}