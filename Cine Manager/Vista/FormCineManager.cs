using Modelo.Módulo_de_Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.Módulo_de_Administración;
using Vista.Módulo_de_Transacciones;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Vista.Módulo_de_Seguridad
{
    public partial class FormCineManager : Form
    {
        private Sesion? _sesion;

        public FormCineManager(Sesion sesion)
        {
            InitializeComponent();
            _sesion = sesion;
            ConfigurarModulosDisponibles();
        }



        private void ConfigurarModulosDisponibles()
        {
            if (_sesion == null)
            {
                MessageBox.Show("No se ha iniciado sesión.");
                return;
            }

            var modulosDisponibles = ObtenerModulosDisponiblesDesdeSesion();
            var accionesUsuario = _sesion.GetPerfil();

            // Mostrar solo los ToolStrip correspondientes a los módulos disponibles
            toolStripVentas.Visible = modulosDisponibles.Contains("Modulo de Ventas");
            toolStripCompras.Visible = modulosDisponibles.Contains("Modulo de Compras");
            toolStripSeguridad.Visible = modulosDisponibles.Contains("Modulo de Seguridad");
            toolStripInventario.Visible = modulosDisponibles.Contains("Modulo de Inventario");
            toolstripPerfil.Visible = true; // Asegurarse de que el "Modulo Mi Perfil" esté siempre visible


            // Configurar la visibilidad de los formularios dentro de cada ToolStrip
            ConfigurarElementosToolStrip(toolStripVentas, accionesUsuario);
            ConfigurarElementosToolStrip(toolStripCompras, accionesUsuario);
            ConfigurarElementosToolStrip(toolStripInventario, accionesUsuario);
            ConfigurarElementosToolStrip(toolStripSeguridad, accionesUsuario);
            ConfigurarElementosToolStrip(toolstripPerfil, accionesUsuario);
        }



        private void ConfigurarElementosToolStrip(ToolStripDropDownButton toolStripDropDownButton, List<Accion> accionesUsuario)
        {
            foreach (ToolStripItem subItem in toolStripDropDownButton.DropDownItems)
            {
                var nombreAccion = subItem.Tag as string;

                if (nombreAccion == "Cerrar Sesion")
                {
                    subItem.Visible = true;
                }
                else if (nombreAccion == "Mis Datos" || nombreAccion == "Cambiar Clave")
                {
                    // Asegurar que "Mis Datos" y "Cambiar Clave" siempre sean visibles
                    subItem.Visible = true;
                }
                else
                {
                    // Verificar si el usuario tiene permisos para las demás acciones
                    subItem.Visible = accionesUsuario.Any(a => a.Nombre == nombreAccion);
                }
            }
        }


        private List<string> ObtenerModulosDisponiblesDesdeSesion()
        {
            var modulos = new List<string>();
            var acciones = _sesion.GetPerfil();

            foreach (var accion in acciones)
            {
                var formulario = accion.Formulario;
                var modulo = formulario?.Modulo;

                if (modulo != null && !modulos.Contains(modulo.NombreModulo))
                {
                    modulos.Add(modulo.NombreModulo);
                }
            }

            // Asegurarte de que el "Modulo Mi Perfil" siempre esté disponible
            if (!modulos.Contains("Modulo Mi Perfil"))
            {
                modulos.Add("Modulo Mi Perfil");
            }

            return modulos;
        }



        private void gestionarUsuariosToolStripMenuItem_Click(object sender, EventArgs e) //Toolstrip Gestionar Usuarios
        {
            var formGestorUsuarios = new FormGestionarUsuarios(/*_sesion*/);
            formGestorUsuarios.ShowDialog();
        }



        private void gestionarGruposToolStripMenuItem_Click(object sender, EventArgs e) //Toolstrip Gestionar Grupos
        {
            var formGestorGrupos = new FormGestionarGrupos(_sesion);
            formGestorGrupos.ShowDialog();
        }



        private void misDatosToolStripMenuItem_Click(object sender, EventArgs e) //Toolstrip Mis Datos
        {
            var formDatosUsuario = new FormDatosUsuario(_sesion);
            formDatosUsuario.ShowDialog();
        }



        private void cambiarClaveToolStripMenuItem_Click(object sender, EventArgs e) //Toolstrip Cambiar Clave
        {
            var formCambiarClave = new FormCambiarClave(_sesion);
            formCambiarClave.ShowDialog();
        }




        private void realizarPedidoToolStripMenuItem_Click(object sender, EventArgs e) //Toolstrip Realizar Pedido
        {
            var formRealizarPedido = new FormRealizarPedido();
            formRealizarPedido.ShowDialog();
        }



        private void gestionarProveedoresToolStripMenuItem_Click(object sender, EventArgs e) //Toolstrip Gestionar Proveedores
        {
            var formProveeores = new FormProveedores(_sesion);
            formProveeores.ShowDialog();
        }


        private void gestionarClientesToolStripMenuItem1_Click(object sender, EventArgs e) //Toolstrip Gestionar Usuarios
        {
            var formGestionarClientes = new FormClientes(_sesion); 
            formGestionarClientes.ShowDialog();
        }


        private void gestionarPedidosToolStripMenuItem_Click(object sender, EventArgs e) //Toolstrip Gestionar Pedidos
        {
            var formGestionarPedidos = new FormGestorPedidos(_sesion); 
            formGestionarPedidos.ShowDialog();
        }


        private void gestionarPeliculasToolStripMenuItem_Click(object sender, EventArgs e) //Toolstrip Gestionar Peliculas
        {
            var formGestionarPeliculas = new FormGestorPeliculas(_sesion);
            formGestionarPeliculas.ShowDialog();
        }



        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e) //Toolstrip Cerrar Sesión
        {
            _sesion = null;

            var formLogin = new FormIniciarSesion();
            formLogin.Show();

            this.Close();
        }   
    }
}


