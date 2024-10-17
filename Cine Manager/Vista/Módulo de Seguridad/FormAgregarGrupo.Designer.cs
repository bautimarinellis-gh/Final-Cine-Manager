namespace Vista.Módulo_de_Seguridad
{
    partial class FormAgregarGrupo
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
            TreeNode treeNode4 = new TreeNode("Gestionar Metodos de Pago");
            TreeNode treeNode5 = new TreeNode("Ventas", new TreeNode[] { treeNode1, treeNode2, treeNode3, treeNode4 });
            TreeNode treeNode6 = new TreeNode("Gestionar Proveedores");
            TreeNode treeNode7 = new TreeNode("Gestionar Ordenes de Compra");
            TreeNode treeNode8 = new TreeNode("Compras", new TreeNode[] { treeNode6, treeNode7 });
            TreeNode treeNode9 = new TreeNode("Gestionar Grupos");
            TreeNode treeNode10 = new TreeNode("Gestionar Usuarios");
            TreeNode treeNode11 = new TreeNode("Seguridad", new TreeNode[] { treeNode9, treeNode10 });
            tabUsuario = new TabControl();
            tabDatos = new TabPage();
            btnCancelar = new Button();
            groupBox1 = new GroupBox();
            txtCodigo = new TextBox();
            label1 = new Label();
            cmbEstado = new ComboBox();
            txtDescripcion = new TextBox();
            txtNombre = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            tabAcciones = new TabPage();
            button3 = new Button();
            btnGuardar = new Button();
            groupBox3 = new GroupBox();
            treeViewAcciones = new TreeView();
            tabUsuario.SuspendLayout();
            tabDatos.SuspendLayout();
            groupBox1.SuspendLayout();
            tabAcciones.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // tabUsuario
            // 
            tabUsuario.Controls.Add(tabDatos);
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
            btnCancelar.Location = new Point(437, 261);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtCodigo);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cmbEstado);
            groupBox1.Controls.Add(txtDescripcion);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(15, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(488, 249);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(135, 20);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(124, 23);
            txtCodigo.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 28);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 8;
            label1.Text = "Codigo";
            // 
            // cmbEstado
            // 
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(135, 207);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(138, 23);
            cmbEstado.TabIndex = 4;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(135, 121);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(327, 57);
            txtDescripcion.TabIndex = 3;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(135, 74);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(327, 23);
            txtNombre.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 210);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 3;
            label4.Text = "Estado";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 82);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 2;
            label3.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 124);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 3;
            label2.Text = "Descripción";
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
            groupBox3.Controls.Add(treeViewAcciones);
            groupBox3.Location = new Point(26, 18);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(488, 229);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            // 
            // treeViewAcciones
            // 
            treeViewAcciones.CheckBoxes = true;
            treeViewAcciones.Location = new Point(19, 23);
            treeViewAcciones.Name = "treeViewAcciones";
            treeNode1.Name = "nRealizarPedido";
            treeNode1.Tag = "Realizar Pedido";
            treeNode1.Text = "Realizar Pedido";
            treeNode2.Name = "nClientes";
            treeNode2.Tag = "Gestionar Clientes";
            treeNode2.Text = "Gestionar Clientes";
            treeNode3.Name = "nPedidos";
            treeNode3.Tag = "Gestionar Pedidos";
            treeNode3.Text = "Gestionar Pedidos";
            treeNode4.Name = "nMetodosPago";
            treeNode4.Tag = "Gestionar Metodos de Pago";
            treeNode4.Text = "Gestionar Metodos de Pago";
            treeNode5.Name = "nVentas";
            treeNode5.Tag = "Ventas";
            treeNode5.Text = "Ventas";
            treeNode6.Name = "nProveedores";
            treeNode6.Tag = "Gestionar Proveedores";
            treeNode6.Text = "Gestionar Proveedores";
            treeNode7.Name = "nOrdenesCompra";
            treeNode7.Tag = "Gestionar Ordenes de Compra";
            treeNode7.Text = "Gestionar Ordenes de Compra";
            treeNode8.Name = "nCompras";
            treeNode8.Tag = "Compras";
            treeNode8.Text = "Compras";
            treeNode9.Name = "nGrupos";
            treeNode9.Tag = "Gestionar Grupos";
            treeNode9.Text = "Gestionar Grupos";
            treeNode10.Name = "nUsuarios";
            treeNode10.Tag = "Gestionar Usuarios";
            treeNode10.Text = "Gestionar Usuarios";
            treeNode11.Name = "nSeguridad";
            treeNode11.Tag = "Seguridad";
            treeNode11.Text = "Seguridad";
            treeViewAcciones.Nodes.AddRange(new TreeNode[] { treeNode5, treeNode8, treeNode11 });
            treeViewAcciones.Size = new Size(450, 182);
            treeViewAcciones.TabIndex = 1;
            // 
            // FormAgregarGrupo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(573, 355);
            Controls.Add(tabUsuario);
            Name = "FormAgregarGrupo";
            Text = "FormAgregarGrupo";
            tabUsuario.ResumeLayout(false);
            tabDatos.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabAcciones.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabUsuario;
        private TabPage tabDatos;
        private Button btnCancelar;
        private GroupBox groupBox1;
        private ComboBox cmbEstado;
        private TextBox txtDescripcion;
        private TextBox txtNombre;
        private Label label4;
        private Label label3;
        private Label label2;
        private TabPage tabAcciones;
        private Button button3;
        private Button btnGuardar;
        private GroupBox groupBox3;
        private TreeView treeViewAcciones;
        private TextBox txtCodigo;
        private Label label1;
    }
}