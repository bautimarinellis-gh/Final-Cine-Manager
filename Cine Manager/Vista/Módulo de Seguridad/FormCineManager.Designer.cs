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
            groupBox1 = new GroupBox();
            toolStrip1 = new ToolStrip();
            toolstripPerfil = new ToolStripDropDownButton();
            misDatosToolStripMenuItem = new ToolStripMenuItem();
            cambiarClaveToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesiónToolStripMenuItem = new ToolStripMenuItem();
            toolStripTransacciones = new ToolStripDropDownButton();
            realizarPedidoToolStripMenuItem = new ToolStripMenuItem();
            gestionarClientesToolStripMenuItem1 = new ToolStripMenuItem();
            toolStripInventario = new ToolStripDropDownButton();
            gestionarPeliculasToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeguridad = new ToolStripDropDownButton();
            gestionarUsuariosToolStripMenuItem = new ToolStripMenuItem();
            gestionarGruposToolStripMenuItem = new ToolStripMenuItem();
            toolStripPedidos = new ToolStripDropDownButton();
            geastionarPedidosToolStripMenuItem = new ToolStripMenuItem();
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
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolstripPerfil, toolStripTransacciones, toolStripInventario, toolStripSeguridad, toolStripPedidos });
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
            misDatosToolStripMenuItem.Size = new Size(180, 22);
            misDatosToolStripMenuItem.Tag = "Mis Datos";
            misDatosToolStripMenuItem.Text = "Mis Datos";
            misDatosToolStripMenuItem.Click += misDatosToolStripMenuItem_Click;
            // 
            // cambiarClaveToolStripMenuItem
            // 
            cambiarClaveToolStripMenuItem.Name = "cambiarClaveToolStripMenuItem";
            cambiarClaveToolStripMenuItem.Size = new Size(180, 22);
            cambiarClaveToolStripMenuItem.Tag = "Cambiar Clave";
            cambiarClaveToolStripMenuItem.Text = "Cambiar Clave";
            cambiarClaveToolStripMenuItem.Click += cambiarClaveToolStripMenuItem_Click;
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            cerrarSesiónToolStripMenuItem.Size = new Size(180, 22);
            cerrarSesiónToolStripMenuItem.Tag = "Cerrar Sesion";
            cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            cerrarSesiónToolStripMenuItem.Click += cerrarSesiónToolStripMenuItem_Click;
            // 
            // toolStripTransacciones
            // 
            toolStripTransacciones.DropDownItems.AddRange(new ToolStripItem[] { realizarPedidoToolStripMenuItem, gestionarClientesToolStripMenuItem1 });
            toolStripTransacciones.Name = "toolStripTransacciones";
            toolStripTransacciones.Size = new Size(93, 22);
            toolStripTransacciones.Text = "Transacciones";
            // 
            // realizarPedidoToolStripMenuItem
            // 
            realizarPedidoToolStripMenuItem.Name = "realizarPedidoToolStripMenuItem";
            realizarPedidoToolStripMenuItem.Size = new Size(169, 22);
            realizarPedidoToolStripMenuItem.Tag = "Realizar Pedido";
            realizarPedidoToolStripMenuItem.Text = "Realizar Pedido";
            // 
            // gestionarClientesToolStripMenuItem1
            // 
            gestionarClientesToolStripMenuItem1.Name = "gestionarClientesToolStripMenuItem1";
            gestionarClientesToolStripMenuItem1.Size = new Size(169, 22);
            gestionarClientesToolStripMenuItem1.Tag = "Gestionar Clientes";
            gestionarClientesToolStripMenuItem1.Text = "Gestionar Clientes";
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
            // toolStripPedidos
            // 
            toolStripPedidos.DropDownItems.AddRange(new ToolStripItem[] { geastionarPedidosToolStripMenuItem });
            toolStripPedidos.Name = "toolStripPedidos";
            toolStripPedidos.Size = new Size(62, 22);
            toolStripPedidos.Text = "Pedidos";
            // 
            // geastionarPedidosToolStripMenuItem
            // 
            geastionarPedidosToolStripMenuItem.Name = "geastionarPedidosToolStripMenuItem";
            geastionarPedidosToolStripMenuItem.Size = new Size(175, 22);
            geastionarPedidosToolStripMenuItem.Tag = "Gestionar Pedidos";
            geastionarPedidosToolStripMenuItem.Text = "Geastionar Pedidos";
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
        private ToolStripDropDownButton toolStripTransacciones;
        private ToolStripMenuItem realizarPedidoToolStripMenuItem;
        private ToolStripMenuItem gestionarClientesToolStripMenuItem1;
        private ToolStripDropDownButton toolStripPedidos;
        private ToolStripMenuItem geastionarPedidosToolStripMenuItem;
    }
}