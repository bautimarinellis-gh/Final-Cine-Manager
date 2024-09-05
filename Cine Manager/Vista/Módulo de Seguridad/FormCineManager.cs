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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Vista.Módulo_de_Seguridad
{
    public partial class FormCineManager : Form
    {
        public FormCineManager()
        {
            InitializeComponent();
            ConfigurarModulosDisponibles();
        }



        private void ConfigurarModulosDisponibles()
        {
            if (Sesion.Instancia == null)
            {
                MessageBox.Show("No se ha iniciado sesión.");
                return;
            }

            var modulosDisponibles = ObtenerModulosDisponiblesDesdeSesion();
            var accionesUsuario = Sesion.Instancia.GetPerfil();

            // Mostrar solo los ToolStrip correspondientes a los módulos disponibles
            toolStripInventario.Visible = modulosDisponibles.Contains("Modulo de Inventario");
            toolStripTransacciones.Visible = modulosDisponibles.Contains("Modulo de Transacciones");
            toolStripSeguridad.Visible = modulosDisponibles.Contains("Modulo de Seguridad");
            toolstripPerfil.Visible = true; // Asegurarse de que el "Modulo Mi Perfil" esté siempre visible
            toolStripPedidos.Visible = modulosDisponibles.Contains("Modulo de Pedidos");

            // Configurar la visibilidad de los formularios dentro de cada ToolStrip
            ConfigurarElementosToolStrip(toolStripInventario, accionesUsuario);
            ConfigurarElementosToolStrip(toolStripTransacciones, accionesUsuario);
            ConfigurarElementosToolStrip(toolStripSeguridad, accionesUsuario);
            ConfigurarElementosToolStrip(toolstripPerfil, accionesUsuario); 
            ConfigurarElementosToolStrip(toolStripPedidos, accionesUsuario);
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
            var acciones = Sesion.Instancia.GetPerfil();

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



        private void gestionarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formGestorUsuarios = new FormGestionarUsuarios();
            formGestorUsuarios.Show();
            this.Hide();
        }



        private void gestionarGruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formGestorGrupos = new FormGestionarGrupos();
            formGestorGrupos.Show();
            this.Hide();
        }



        private void misDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formDatosUsuario = new FormDatosUsuario();
            formDatosUsuario.Show();
            this.Hide();
        }



        private void cambiarClaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formCambiarClave = new FormCambiarClave();
            formCambiarClave.Show();
            this.Hide();
        }




        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIniciarSesion formLogin = new FormIniciarSesion();
            formLogin.Show();
            this.Close();
        }
    }
}

    
