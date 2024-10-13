namespace Vista.Módulo_de_Seguridad
{
    partial class FormDatosUsuario
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
            TreeNode treeNode1 = new TreeNode("Realizar Pedido");
            TreeNode treeNode2 = new TreeNode("Gestionar Clientes");
            TreeNode treeNode3 = new TreeNode("Gestionar Pedidos");
            TreeNode treeNode4 = new TreeNode("Ventas", new TreeNode[] { treeNode1, treeNode2, treeNode3 });
            TreeNode treeNode5 = new TreeNode("Gestionar Proveedores");
            TreeNode treeNode6 = new TreeNode("Gestionar Ordenes de Compra");
            TreeNode treeNode7 = new TreeNode("Compras", new TreeNode[] { treeNode5, treeNode6 });
            TreeNode treeNode8 = new TreeNode("Gestionar Grupos");
            TreeNode treeNode9 = new TreeNode("Gestionar Usuarios");
            TreeNode treeNode10 = new TreeNode("Seguridad", new TreeNode[] { treeNode8, treeNode9 });
            TreeNode treeNode11 = new TreeNode("Gestionar Inventario");
            TreeNode treeNode12 = new TreeNode("Gestionar Inventario", new TreeNode[] { treeNode11 });
            tabUsuario = new TabControl();
            tabDatos = new TabPage();
            btnCancelar = new Button();
            groupBox1 = new GroupBox();
            txtEstadoUsuario = new TextBox();
            txtApellido = new TextBox();
            label5 = new Label();
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
            groupBox3 = new GroupBox();
            treeView1 = new TreeView();
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
            tabUsuario.TabIndex = 2;
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
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Volver";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtEstadoUsuario);
            groupBox1.Controls.Add(txtApellido);
            groupBox1.Controls.Add(label5);
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
            // txtEstadoUsuario
            // 
            txtEstadoUsuario.Enabled = false;
            txtEstadoUsuario.Location = new Point(89, 173);
            txtEstadoUsuario.Name = "txtEstadoUsuario";
            txtEstadoUsuario.Size = new Size(138, 23);
            txtEstadoUsuario.TabIndex = 10;
            // 
            // txtApellido
            // 
            txtApellido.Enabled = false;
            txtApellido.Location = new Point(327, 75);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(138, 23);
            txtApellido.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(259, 83);
            label5.Name = "label5";
            label5.Size = new Size(51, 15);
            label5.TabIndex = 8;
            label5.Text = "Apellido";
            // 
            // txtEmail
            // 
            txtEmail.Enabled = false;
            txtEmail.Location = new Point(89, 128);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(208, 23);
            txtEmail.TabIndex = 6;
            // 
            // txtNombre
            // 
            txtNombre.Enabled = false;
            txtNombre.Location = new Point(89, 75);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(138, 23);
            txtNombre.TabIndex = 5;
            // 
            // txtUsuario
            // 
            txtUsuario.Enabled = false;
            txtUsuario.Location = new Point(89, 25);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(138, 23);
            txtUsuario.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 181);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 3;
            label4.Text = "Estado";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 83);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 2;
            label3.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 136);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 1;
            label2.Text = "E-mail";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 33);
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
            button1.Text = "Volver";
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
            clbGrupos.Enabled = false;
            clbGrupos.FormattingEnabled = true;
            clbGrupos.Location = new Point(6, 22);
            clbGrupos.Name = "clbGrupos";
            clbGrupos.Size = new Size(476, 202);
            clbGrupos.TabIndex = 5;
            // 
            // tabAcciones
            // 
            tabAcciones.Controls.Add(button3);
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
            button3.Text = "Volver";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(treeView1);
            groupBox3.Location = new Point(26, 18);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(488, 229);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            // 
            // treeView1
            // 
            treeView1.CheckBoxes = true;
            treeView1.Location = new Point(18, 22);
            treeView1.Name = "treeView1";
            treeNode1.Name = "nRealizarPedido";
            treeNode1.Tag = "Realizar Pedido";
            treeNode1.Text = "Realizar Pedido";
            treeNode2.Name = "nClientes";
            treeNode2.Tag = "Gestionar Clientes";
            treeNode2.Text = "Gestionar Clientes";
            treeNode3.Name = "nPedidos";
            treeNode3.Tag = "Gestionar Pedidos";
            treeNode3.Text = "Gestionar Pedidos";
            treeNode4.Name = "nVentas";
            treeNode4.Tag = "Gestionar Ventas";
            treeNode4.Text = "Ventas";
            treeNode5.Name = "nProveedores";
            treeNode5.Tag = "Gestionar Proveedores";
            treeNode5.Text = "Gestionar Proveedores";
            treeNode6.Name = "nOrdenesCompra";
            treeNode6.Tag = "Gestionar Ordenes de Compra";
            treeNode6.Text = "Gestionar Ordenes de Compra";
            treeNode7.Name = "nCompras";
            treeNode7.Tag = "Gestionar Compras";
            treeNode7.Text = "Compras";
            treeNode8.Name = "nGrupos";
            treeNode8.Tag = "Gestionar Grupos";
            treeNode8.Text = "Gestionar Grupos";
            treeNode9.Name = "nUsuarios";
            treeNode9.Tag = "Gestionar Usuarios";
            treeNode9.Text = "Gestionar Usuarios";
            treeNode10.Name = "nSeguridad";
            treeNode10.Tag = "Seguridad";
            treeNode10.Text = "Seguridad";
            treeNode11.Name = "nInventario";
            treeNode11.Tag = "Gestionar Inventario";
            treeNode11.Text = "Gestionar Inventario";
            treeNode12.Name = "nInventario";
            treeNode12.Tag = "Gestionar Inventario";
            treeNode12.Text = "Gestionar Inventario";
            treeView1.Nodes.AddRange(new TreeNode[] { treeNode4, treeNode7, treeNode10, treeNode12 });
            treeView1.Size = new Size(450, 182);
            treeView1.TabIndex = 0;
            // 
            // FormDatosUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(638, 353);
            Controls.Add(tabUsuario);
            Name = "FormDatosUsuario";
            Text = "Mis datos";
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
        private Button btnCancelar;
        private GroupBox groupBox1;
        private TextBox txtEmail;
        private TextBox txtNombre;
        private TextBox txtUsuario;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TabPage tabGrupos;
        private Button button1;
        private GroupBox groupBox2;
        private TabPage tabAcciones;
        private Button button3;
        private GroupBox groupBox3;
        private TreeView treeView1;
        private CheckedListBox clbGrupos;
        private TextBox txtApellido;
        private Label label5;
        private TextBox txtEstadoUsuario;
        private ComboBox comboBox1;
    }
}