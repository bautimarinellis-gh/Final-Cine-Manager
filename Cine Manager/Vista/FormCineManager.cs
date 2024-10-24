using Controladora.Seguridad;
using Modelo.Entidades;
using Modelo.Módulo_de_Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Vista.Módulo_de_Administración;
using Vista.Módulo_de_Compras;
using Vista.Módulo_de_Transacciones;
using Vista.Módulo_de_Ventas;

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




        #region Métodos de Configuración de Módulos

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

            // Asegurarse de que el "Modulo Mi Perfil" siempre esté disponible
            if (!modulos.Contains("Modulo Mi Perfil"))
            {
                modulos.Add("Modulo Mi Perfil");
            }

            return modulos;
        }


        private void RegistrarAuditoriaSesion(int usuarioId, string tipoMovimiento)
        {
            AuditoriaSesion auditoria = new AuditoriaSesion
            {
                UsuarioId = usuarioId,
                FechaMovimiento = DateTime.Now,
                TipoMovimiento = tipoMovimiento
            };

            // Aquí agregas la lógica para insertar la auditoría en la base de datos
            ControladoraIniciarSesion.Instancia.Registrar(auditoria);
        }

        #endregion



        #region Manejadores de Eventos de ToolStrip

        private void gestionarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formGestorUsuarios = new FormGestionarUsuarios(_sesion);
            formGestorUsuarios.ShowDialog();
        }


        private void gestionarGruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formGestorGrupos = new FormGestionarGrupos(_sesion);
            formGestorGrupos.ShowDialog();
        }


        private void misDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formDatosUsuario = new FormDatosUsuario(_sesion);
            formDatosUsuario.ShowDialog();
        }


        private void cambiarClaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formCambiarClave = new FormCambiarClave(_sesion);
            formCambiarClave.ShowDialog();
        }


        private void realizarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formRealizarPedido = new FormRealizarPedido();
            formRealizarPedido.ShowDialog();
        }


        private void gestionarProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formProveeores = new FormProveedores(_sesion);
            formProveeores.ShowDialog();
        }


        private void gestionarClientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var formGestionarClientes = new FormClientes(_sesion);
            formGestionarClientes.ShowDialog();
        }


        private void gestionarPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formGestionarPedidos = new FormGestorPedidos(_sesion);
            formGestionarPedidos.ShowDialog();
        }


        private void gestionarPeliculasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formGestionarPeliculas = new FormGestorPeliculas(_sesion);
            formGestionarPeliculas.ShowDialog();
        }


        private void órdenesDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formOrdenesCompra = new FormOrdenesCompra(_sesion);
            formOrdenesCompra.ShowDialog();

        }


        private void gestionarMetodosDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formMetodospago = new FormMetodosPago(_sesion);
            formMetodospago.ShowDialog();
        }


        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("¿Está seguro de que desea cerrar sesión?", "Confirmar Cierre de Sesión", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                // Registrar auditoría de logout
                if (_sesion != null && _sesion.UsuarioSesion != null)
                {
                    RegistrarAuditoriaSesion(_sesion.UsuarioSesion.UsuarioId, "Logout");
                }

                // Cerrar la sesión actual (asegurándonos de que todos los datos se destruyan)
                _sesion = null;

                // Mostrar un nuevo formulario de login, recargando todos los datos
                FormIniciarSesion formLogin = new FormIniciarSesion();
                formLogin.Show();

                // Cerrar el formulario actual (CineManager)
                this.Close();
            }
        }

        #endregion

    }
}
