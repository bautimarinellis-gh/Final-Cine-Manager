using Controladora.Seguridad;
using Controladora;
using Modelo.Módulo_de_Seguridad;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Vista.Módulo_de_Seguridad
{
    public partial class FormDatosUsuario : Form
    {
        private Sesion _sesion;


        public FormDatosUsuario(Sesion sesion)
        {
            InitializeComponent();
            _sesion = sesion;
            CargarDatosUsuario();
        }


        #region Métodos de Carga de Datos

        private void CargarDatosUsuario()
        {
            var usuarioActual = _sesion.UsuarioSesion;

            txtUsuario.Text = usuarioActual.NombreUsuario;
            txtNombre.Text = usuarioActual.Nombre;
            txtApellido.Text = usuarioActual.Apellido;
            txtEmail.Text = usuarioActual.Email;

            var estadoUsuarioNombre = ControladoraMisDatos.Instancia.ObtenerEstadoUsuario(usuarioActual.UsuarioId);
            txtEstadoUsuario.Text = estadoUsuarioNombre;

            CargarGruposUsuario();
            CargarAccionesUsuario();
        }



        private void CargarGruposUsuario()
        {
            // Obtener todos los grupos del sistema
            var todosLosGrupos = ControladoraGestionarGrupos.Instancia.RecuperarGrupos();

            // Obtener los IDs de los grupos asignados al usuario desde la base de datos
            var gruposAsignados = ControladoraGestionarGrupos.Instancia.ObtenerGruposUsuario(_sesion.UsuarioSesion.UsuarioId)
                                   .Select(g => g.Id)
                                   .ToList();

            // Recorrer todos los grupos y marcar los que están asignados al usuario
            foreach (var grupo in todosLosGrupos)
            {
                // Añadir el nombre del grupo al CheckedListBox y obtener su índice
                int index = clbGrupos.Items.Add(grupo.Nombre);

                // Verificar si el grupo está asignado al usuario
                bool isChecked = gruposAsignados.Contains(grupo.Id);

                // Marcar el grupo en el CheckedListBox si está asignado al usuario
                clbGrupos.SetItemChecked(index, isChecked);
            }
        }



        private void CargarAccionesUsuario()
        {
            // Obtener los nombres de las acciones asignadas al usuario desde la base de datos
            var accionesAsignadas = ControladoraAcciones.Instancia.ObtenerAccionesUsuario(_sesion.UsuarioSesion).Select(a => a.Nombre).ToList();

            // Recorrer cada nodo en el TreeView 
            foreach (TreeNode nodoCategoria in treeView1.Nodes)
            {
                // Recorrer cada subnodo dentro de la categoría
                foreach (TreeNode nodoAccion in nodoCategoria.Nodes)
                {
                    // Verificar que el Tag no sea nulo y que sea de tipo string
                    if (nodoAccion.Tag is string nombreAccion)
                    {
                        // Si la acción está asignada al usuario, marcarla como seleccionada
                        if (accionesAsignadas.Contains(nombreAccion))
                        {
                            nodoAccion.Checked = true;
                        }
                    }
                }
            }
        }

        #endregion


        #region Manejadores de Eventos

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
