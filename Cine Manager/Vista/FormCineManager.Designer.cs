namespace Vista.Módulo_de_Seguridad
{
    partial class FormCineManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCineManager));
            groupBox1 = new GroupBox();
            toolStrip1 = new ToolStrip();
            toolstripPerfil = new ToolStripDropDownButton();
            misDatosToolStripMenuItem = new ToolStripMenuItem();
            cambiarClaveToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesiónToolStripMenuItem = new ToolStripMenuItem();
            toolStripVentas = new ToolStripDropDownButton();
            realizarPedidoToolStripMenuItem = new ToolStripMenuItem();
            gestionarClientesToolStripMenuItem1 = new ToolStripMenuItem();
            gestionarPedidosToolStripMenuItem = new ToolStripMenuItem();
            toolStripCompras = new ToolStripDropDownButton();
            gestionarProveedoresToolStripMenuItem = new ToolStripMenuItem();
            órdenesDeCompraToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeguridad = new ToolStripDropDownButton();
            gestionarUsuariosToolStripMenuItem = new ToolStripMenuItem();
            gestionarGruposToolStripMenuItem = new ToolStripMenuItem();
            toolStripInventario = new ToolStripDropDownButton();
            gestionarPeliculasToolStripMenuItem = new ToolStripMenuItem();
            groupBox1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(toolStrip1);
            groupBox1.Location = new Point(12, 8);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(690, 360);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolstripPerfil, toolStripVentas, toolStripCompras, toolStripSeguridad, toolStripInventario });
            toolStrip1.Location = new Point(3, 19);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(684, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolstripPerfil
            // 
            toolstripPerfil.Alignment = ToolStripItemAlignment.Right;
            toolstripPerfil.DropDownItems.AddRange(new ToolStripItem[] { misDatosToolStripMenuItem, cambiarClaveToolStripMenuItem, cerrarSesiónToolStripMenuItem });
            toolstripPerfil.Name = "toolstripPerfil";
            toolstripPerfil.Size = new Size(64, 22);
            toolstripPerfil.Text = "Mi Perfil";
            // 
            // misDatosToolStripMenuItem
            // 
            misDatosToolStripMenuItem.Name = "misDatosToolStripMenuItem";
            misDatosToolStripMenuItem.Size = new Size(151, 22);
            misDatosToolStripMenuItem.Tag = "Mis Datos";
            misDatosToolStripMenuItem.Text = "Mis Datos";
            misDatosToolStripMenuItem.Click += misDatosToolStripMenuItem_Click;
            // 
            // cambiarClaveToolStripMenuItem
            // 
            cambiarClaveToolStripMenuItem.Name = "cambiarClaveToolStripMenuItem";
            cambiarClaveToolStripMenuItem.Size = new Size(151, 22);
            cambiarClaveToolStripMenuItem.Tag = "Cambiar Clave";
            cambiarClaveToolStripMenuItem.Text = "Cambiar Clave";
            cambiarClaveToolStripMenuItem.Click += cambiarClaveToolStripMenuItem_Click;
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            cerrarSesiónToolStripMenuItem.Size = new Size(151, 22);
            cerrarSesiónToolStripMenuItem.Tag = "Cerrar Sesion";
            cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            cerrarSesiónToolStripMenuItem.Click += cerrarSesiónToolStripMenuItem_Click;
            // 
            // toolStripVentas
            // 
            toolStripVentas.DropDownItems.AddRange(new ToolStripItem[] { realizarPedidoToolStripMenuItem, gestionarClientesToolStripMenuItem1, gestionarPedidosToolStripMenuItem });
            toolStripVentas.Name = "toolStripVentas";
            toolStripVentas.Size = new Size(54, 22);
            toolStripVentas.Tag = "Modulo de Ventas";
            toolStripVentas.Text = "Ventas";
            // 
            // realizarPedidoToolStripMenuItem
            // 
            realizarPedidoToolStripMenuItem.Name = "realizarPedidoToolStripMenuItem";
            realizarPedidoToolStripMenuItem.Size = new Size(169, 22);
            realizarPedidoToolStripMenuItem.Tag = "Realizar Pedido";
            realizarPedidoToolStripMenuItem.Text = "Realizar Pedido";
            realizarPedidoToolStripMenuItem.Click += realizarPedidoToolStripMenuItem_Click;
            // 
            // gestionarClientesToolStripMenuItem1
            // 
            gestionarClientesToolStripMenuItem1.Name = "gestionarClientesToolStripMenuItem1";
            gestionarClientesToolStripMenuItem1.Size = new Size(169, 22);
            gestionarClientesToolStripMenuItem1.Tag = "Gestionar Clientes";
            gestionarClientesToolStripMenuItem1.Text = "Gestionar Clientes";
            gestionarClientesToolStripMenuItem1.Click += gestionarClientesToolStripMenuItem1_Click;
            // 
            // gestionarPedidosToolStripMenuItem
            // 
            gestionarPedidosToolStripMenuItem.Name = "gestionarPedidosToolStripMenuItem";
            gestionarPedidosToolStripMenuItem.Size = new Size(169, 22);
            gestionarPedidosToolStripMenuItem.Tag = "Gestionar Pedidos";
            gestionarPedidosToolStripMenuItem.Text = "Gestionar Pedidos";
            gestionarPedidosToolStripMenuItem.Click += gestionarPedidosToolStripMenuItem_Click;
            // 
            // toolStripCompras
            // 
            toolStripCompras.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripCompras.DropDownItems.AddRange(new ToolStripItem[] { gestionarProveedoresToolStripMenuItem, órdenesDeCompraToolStripMenuItem });
            toolStripCompras.Image = (Image)resources.GetObject("toolStripCompras.Image");
            toolStripCompras.ImageTransparentColor = Color.Magenta;
            toolStripCompras.Name = "toolStripCompras";
            toolStripCompras.Size = new Size(68, 22);
            toolStripCompras.Tag = "Modulo de Compras";
            toolStripCompras.Text = "Compras";
            // 
            // gestionarProveedoresToolStripMenuItem
            // 
            gestionarProveedoresToolStripMenuItem.Name = "gestionarProveedoresToolStripMenuItem";
            gestionarProveedoresToolStripMenuItem.Size = new Size(192, 22);
            gestionarProveedoresToolStripMenuItem.Tag = "Gestionar Proveedores";
            gestionarProveedoresToolStripMenuItem.Text = "Gestionar Proveedores";
            gestionarProveedoresToolStripMenuItem.Click += gestionarProveedoresToolStripMenuItem_Click;
            // 
            // órdenesDeCompraToolStripMenuItem
            // 
            órdenesDeCompraToolStripMenuItem.Name = "órdenesDeCompraToolStripMenuItem";
            órdenesDeCompraToolStripMenuItem.Size = new Size(192, 22);
            órdenesDeCompraToolStripMenuItem.Tag = "Gestionar Ordenes de Compra";
            órdenesDeCompraToolStripMenuItem.Text = "Órdenes de Compra";
            órdenesDeCompraToolStripMenuItem.Click += órdenesDeCompraToolStripMenuItem_Click;
            // 
            // toolStripSeguridad
            // 
            toolStripSeguridad.DropDownItems.AddRange(new ToolStripItem[] { gestionarUsuariosToolStripMenuItem, gestionarGruposToolStripMenuItem });
            toolStripSeguridad.Name = "toolStripSeguridad";
            toolStripSeguridad.Size = new Size(73, 22);
            toolStripSeguridad.Text = "Seguridad";
            // 
            // gestionarUsuariosToolStripMenuItem
            // 
            gestionarUsuariosToolStripMenuItem.Name = "gestionarUsuariosToolStripMenuItem";
            gestionarUsuariosToolStripMenuItem.Size = new Size(172, 22);
            gestionarUsuariosToolStripMenuItem.Tag = "Gestionar Usuarios";
            gestionarUsuariosToolStripMenuItem.Text = "Gestionar Usuarios";
            gestionarUsuariosToolStripMenuItem.Click += gestionarUsuariosToolStripMenuItem_Click;
            // 
            // gestionarGruposToolStripMenuItem
            // 
            gestionarGruposToolStripMenuItem.Name = "gestionarGruposToolStripMenuItem";
            gestionarGruposToolStripMenuItem.Size = new Size(172, 22);
            gestionarGruposToolStripMenuItem.Tag = "Gestionar Grupos";
            gestionarGruposToolStripMenuItem.Text = "Gestionar Grupos";
            gestionarGruposToolStripMenuItem.Click += gestionarGruposToolStripMenuItem_Click;
            // 
            // toolStripInventario
            // 
            toolStripInventario.DropDownItems.AddRange(new ToolStripItem[] { gestionarPeliculasToolStripMenuItem });
            toolStripInventario.Name = "toolStripInventario";
            toolStripInventario.Size = new Size(73, 22);
            toolStripInventario.Text = "Inventario";
            // 
            // gestionarPeliculasToolStripMenuItem
            // 
            gestionarPeliculasToolStripMenuItem.Name = "gestionarPeliculasToolStripMenuItem";
            gestionarPeliculasToolStripMenuItem.Size = new Size(173, 22);
            gestionarPeliculasToolStripMenuItem.Tag = "Gestionar Peliculas";
            gestionarPeliculasToolStripMenuItem.Text = "Gestionar Peliculas";
            gestionarPeliculasToolStripMenuItem.Click += gestionarPeliculasToolStripMenuItem_Click;
            // 
            // FormCineManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(710, 380);
            Controls.Add(groupBox1);
            Name = "FormCineManager";
            Text = "FormCineManager";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolstripPerfil;
        private ToolStripMenuItem misDatosToolStripMenuItem;
        private ToolStripMenuItem cambiarClaveToolStripMenuItem;
        private ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private ToolStripDropDownButton toolStripInventario;
        private ToolStripMenuItem gestionarPeliculasToolStripMenuItem;
        private ToolStripDropDownButton toolStripSeguridad;
        private ToolStripMenuItem gestionarUsuariosToolStripMenuItem;
        private ToolStripMenuItem gestionarGruposToolStripMenuItem;
        private ToolStripDropDownButton toolStripVentas;
        private ToolStripMenuItem realizarPedidoToolStripMenuItem;
        private ToolStripMenuItem gestionarClientesToolStripMenuItem1;
        private ToolStripDropDownButton toolStripCompras;
        private ToolStripMenuItem gestionarPedidosToolStripMenuItem;
        private ToolStripMenuItem gestionarProveedoresToolStripMenuItem;
        private ToolStripMenuItem órdenesDeCompraToolStripMenuItem;
    }
}