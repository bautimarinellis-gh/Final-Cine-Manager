namespace Vista.Módulo_de_Seguridad
{
    partial class FormAgregarUsuario
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
            TreeNode treeNode1 = new TreeNode("Gestionar Inventario");
            TreeNode treeNode2 = new TreeNode("Gestionar Inventario", new TreeNode[] { treeNode1 });
            tabUsuario = new TabControl();
            tabDatos = new TabPage();
            btnCancelar = new Button();
            groupBox1 = new GroupBox();
            txtApellido = new TextBox();
            cmbEstado = new ComboBox();
            txtEmail = new TextBox();
            txtNombre = new TextBox();
            txtUsuario = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tabGrupos = new TabPage();
            button1 = new Button();
            groupBox2 = new GroupBox();
            clbGrupos = new CheckedListBox();
            tabAcciones = new TabPage();
            button3 = new Button();
            btnGuardar = new Button();
            groupBox3 = new GroupBox();
            treeAcciones = new TreeView();
            tabUsuario.SuspendLayout();
            tabDatos.SuspendLayout();
            groupBox1.SuspendLayout();
            tabGrupos.SuspendLayout();
            groupBox2.SuspendLayout();
            tabAcciones.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // tabUsuario
            // 
            tabUsuario.Controls.Add(tabDatos);
            tabUsuario.Controls.Add(tabGrupos);
            tabUsuario.Controls.Add(tabAcciones);
            tabUsuario.Location = new Point(14, 16);
            tabUsuario.Margin = new Padding(3, 4, 3, 4);
            tabUsuario.Name = "tabUsuario";
            tabUsuario.SelectedIndex = 0;
            tabUsuario.Size = new Size(627, 440);
            tabUsuario.TabIndex = 0;
            // 
            // tabDatos
            // 
            tabDatos.Controls.Add(btnCancelar);
            tabDatos.Controls.Add(groupBox1);
            tabDatos.Location = new Point(4, 29);
            tabDatos.Margin = new Padding(3, 4, 3, 4);
            tabDatos.Name = "tabDatos";
            tabDatos.Padding = new Padding(3, 4, 3, 4);
            tabDatos.Size = new Size(619, 407);
            tabDatos.TabIndex = 0;
            tabDatos.Text = "Datos";
            tabDatos.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(489, 332);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(86, 31);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtApellido);
            groupBox1.Controls.Add(cmbEstado);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(txtUsuario);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(17, 8);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(558, 305);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(377, 107);
            txtApellido.Margin = new Padding(3, 4, 3, 4);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(157, 27);
            txtApellido.TabIndex = 3;
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(179, 241);
            cmbEstado.Margin = new Padding(3, 4, 3, 4);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(157, 28);
            cmbEstado.TabIndex = 5;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(179, 181);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(157, 27);
            txtEmail.TabIndex = 4;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(179, 111);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(157, 27);
            txtNombre.TabIndex = 2;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(179, 44);
            txtUsuario.Margin = new Padding(3, 4, 3, 4);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(157, 27);
            txtUsuario.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(35, 241);
            label4.Name = "label4";
            label4.Size = new Size(54, 20);
            label4.TabIndex = 3;
            label4.Text = "Estado";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(37, 111);
            label3.Name = "label3";
            label3.Size = new Size(136, 20);
            label3.TabIndex = 2;
            label3.Text = "Nombre y Apellido";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 181);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 1;
            label2.Text = "E-mail";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 44);
            label1.Name = "label1";
            label1.Size = new Size(59, 20);
            label1.TabIndex = 0;
            label1.Text = "Usuario";
            // 
            // tabGrupos
            // 
            tabGrupos.Controls.Add(button1);
            tabGrupos.Controls.Add(groupBox2);
            tabGrupos.Location = new Point(4, 29);
            tabGrupos.Margin = new Padding(3, 4, 3, 4);
            tabGrupos.Name = "tabGrupos";
            tabGrupos.Padding = new Padding(3, 4, 3, 4);
            tabGrupos.Size = new Size(619, 407);
            tabGrupos.TabIndex = 1;
            tabGrupos.Text = "Grupos";
            tabGrupos.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(502, 348);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(86, 31);
            button1.TabIndex = 8;
            button1.Text = "Cancelar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(clbGrupos);
            groupBox2.Location = new Point(30, 24);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(558, 305);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            // 
            // clbGrupos
            // 
            clbGrupos.CheckOnClick = true;
            clbGrupos.FormattingEnabled = true;
            clbGrupos.Location = new Point(18, 29);
            clbGrupos.Margin = new Padding(3, 4, 3, 4);
            clbGrupos.Name = "clbGrupos";
            clbGrupos.Size = new Size(519, 224);
            clbGrupos.TabIndex = 5;
            // 
            // tabAcciones
            // 
            tabAcciones.Controls.Add(button3);
            tabAcciones.Controls.Add(btnGuardar);
            tabAcciones.Controls.Add(groupBox3);
            tabAcciones.Location = new Point(4, 29);
            tabAcciones.Margin = new Padding(3, 4, 3, 4);
            tabAcciones.Name = "tabAcciones";
            tabAcciones.Padding = new Padding(3, 4, 3, 4);
            tabAcciones.Size = new Size(619, 407);
            tabAcciones.TabIndex = 2;
            tabAcciones.Text = "Acciones";
            tabAcciones.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(502, 348);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(86, 31);
            button3.TabIndex = 8;
            button3.Text = "Cancelar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(375, 348);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(86, 31);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click_1;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(treeAcciones);
            groupBox3.Location = new Point(30, 24);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(558, 305);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            // 
            // treeAcciones
            // 
            treeAcciones.CheckBoxes = true;
            treeAcciones.Location = new Point(22, 31);
            treeAcciones.Margin = new Padding(3, 4, 3, 4);
            treeAcciones.Name = "treeAcciones";
            treeNode1.Name = "nInventario";
            treeNode1.Tag = "Gestionar Inventario";
            treeNode1.Text = "Gestionar Inventario";
            treeNode2.Name = "nInventario";
            treeNode2.Tag = "Gestionar Inventario";
            treeNode2.Text = "Gestionar Inventario";
            treeAcciones.Nodes.AddRange(new TreeNode[] { treeNode2 });
            treeAcciones.Size = new Size(514, 241);
            treeAcciones.TabIndex = 1;
            treeAcciones.AfterCheck += treeAcciones_AfterCheck;
            // 
            // FormAgregarUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(750, 472);
            Controls.Add(tabUsuario);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormAgregarUsuario";
            Text = "Usuario";
            tabUsuario.ResumeLayout(false);
            tabDatos.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabGrupos.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            tabAcciones.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabUsuario;
        private TabPage tabDatos;
        private TabPage tabGrupos;
        private TabPage tabAcciones;
        private Button btnCancelar;
        private GroupBox groupBox1;
        private ComboBox cmbEstado;
        private TextBox txtEmail;
        private TextBox txtNombre;
        private TextBox txtUsuario;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button button1;
        private GroupBox groupBox2;
        private Button button3;
        private Button btnGuardar;
        private GroupBox groupBox3;
        private TreeView treeAcciones;
        private TextBox txtApellido;
        private CheckedListBox clbGrupos;
    }
}