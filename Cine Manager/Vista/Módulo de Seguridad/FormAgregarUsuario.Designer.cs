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
            TreeNode treeNode1 = new TreeNode("Gestionar Peliculas");
            TreeNode treeNode2 = new TreeNode("Gestionar Pedidos");
            TreeNode treeNode3 = new TreeNode("Empleados", new TreeNode[] { treeNode1, treeNode2 });
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
            tabUsuario.Location = new Point(12, 12);
            tabUsuario.Name = "tabUsuario";
            tabUsuario.SelectedIndex = 0;
            tabUsuario.Size = new Size(549, 330);
            tabUsuario.TabIndex = 0;
            // 
            // tabDatos
            // 
            tabDatos.Controls.Add(btnCancelar);
            tabDatos.Controls.Add(groupBox1);
            tabDatos.Location = new Point(4, 24);
            tabDatos.Name = "tabDatos";
            tabDatos.Padding = new Padding(3);
            tabDatos.Size = new Size(541, 302);
            tabDatos.TabIndex = 0;
            tabDatos.Text = "Datos";
            tabDatos.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(428, 249);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
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
            groupBox1.Location = new Point(15, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(488, 229);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(316, 80);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(138, 23);
            txtApellido.TabIndex = 3;
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(145, 178);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(138, 23);
            cmbEstado.TabIndex = 5;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(145, 133);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(138, 23);
            txtEmail.TabIndex = 4;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(145, 80);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(138, 23);
            txtNombre.TabIndex = 2;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(145, 30);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(138, 23);
            txtUsuario.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 181);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 3;
            label4.Text = "Estado";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 83);
            label3.Name = "label3";
            label3.Size = new Size(107, 15);
            label3.TabIndex = 2;
            label3.Text = "Nombre y Apellido";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 136);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 1;
            label2.Text = "E-mail";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 33);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 0;
            label1.Text = "Usuario";
            // 
            // tabGrupos
            // 
            tabGrupos.Controls.Add(button1);
            tabGrupos.Controls.Add(groupBox2);
            tabGrupos.Location = new Point(4, 24);
            tabGrupos.Name = "tabGrupos";
            tabGrupos.Padding = new Padding(3);
            tabGrupos.Size = new Size(541, 302);
            tabGrupos.TabIndex = 1;
            tabGrupos.Text = "Grupos";
            tabGrupos.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(439, 261);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 8;
            button1.Text = "Cancelar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(clbGrupos);
            groupBox2.Location = new Point(26, 18);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(488, 229);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            // 
            // clbGrupos
            // 
            clbGrupos.CheckOnClick = true;
            clbGrupos.FormattingEnabled = true;
            clbGrupos.Location = new Point(16, 22);
            clbGrupos.Name = "clbGrupos";
            clbGrupos.Size = new Size(455, 184);
            clbGrupos.TabIndex = 5;
            // 
            // tabAcciones
            // 
            tabAcciones.Controls.Add(button3);
            tabAcciones.Controls.Add(btnGuardar);
            tabAcciones.Controls.Add(groupBox3);
            tabAcciones.Location = new Point(4, 24);
            tabAcciones.Name = "tabAcciones";
            tabAcciones.Padding = new Padding(3);
            tabAcciones.Size = new Size(541, 302);
            tabAcciones.TabIndex = 2;
            tabAcciones.Text = "Acciones";
            tabAcciones.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(439, 261);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 8;
            button3.Text = "Cancelar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(328, 261);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click_1;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(treeAcciones);
            groupBox3.Location = new Point(26, 18);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(488, 229);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            // 
            // treeAcciones
            // 
            treeAcciones.CheckBoxes = true;
            treeAcciones.Location = new Point(19, 23);
            treeAcciones.Name = "treeAcciones";
            treeNode1.Name = "nGestionarPeliculas";
            treeNode1.Tag = "Gestionar Peliculas";
            treeNode1.Text = "Gestionar Peliculas";
            treeNode2.Name = "nGestionarPedidos";
            treeNode2.Tag = "Gestionar Pedidos";
            treeNode2.Text = "Gestionar Pedidos";
            treeNode3.Name = "nEmpleado";
            treeNode3.Tag = "Empleados";
            treeNode3.Text = "Empleados";
            treeAcciones.Nodes.AddRange(new TreeNode[] { treeNode3 });
            treeAcciones.Size = new Size(450, 182);
            treeAcciones.TabIndex = 1;
            // 
            // FormAgregarUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(656, 354);
            Controls.Add(tabUsuario);
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