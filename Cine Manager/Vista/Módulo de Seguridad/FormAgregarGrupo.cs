using Controladora;
using Controladora.Seguridad;
using Modelo.EFCore;
using Modelo.Entidades;
using Modelo.Módulo_de_Seguridad;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Vista.Módulo_de_Administración;
using Vista.Módulo_de_Transacciones;

namespace Vista.Módulo_de_Seguridad
{
    public partial class FormAgregarGrupo : Form
    {

        private Grupo grupo;
        private bool modificar = false;


        #region Constructores

        // Constructor Agregar
        public FormAgregarGrupo()
        {
            InitializeComponent();
            InicializarFormulario();
        }

        // Constructor Modificar
        public FormAgregarGrupo(Grupo grupoSeleccionado)
        {
            InitializeComponent();
            this.grupo = grupoSeleccionado; // Asignar el grupo seleccionado a la variable de instancia
            CargarDatosGrupo(); // Cargar los datos correctamente
            InicializarFormulario();
            txtCodigo.Enabled = false;
            modificar = true;
        }

        #endregion



        #region Métodos de Inicialización

        private void InicializarFormulario()
        {
            var estados = ControladoraGestionarGrupos.Instancia.ObtenerEstadosGrupos();

            // Configurar el ComboBox
            cmbEstado.DataSource = estados;
            cmbEstado.DisplayMember = "EstadoGrupoNombre"; // Muestra el nombre del estado
            cmbEstado.ValueMember = "EstadoGrupoId"; // Usa el ID del estado para la selección

            // Seleccionar el primer estado como predeterminado
            cmbEstado.SelectedIndex = 0;
        }

        #endregion



        #region Métodos de Eventos

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                return;
            }

            List<Componente> accionesSeleccionadas = ObtenerAccionesSeleccionadas().Distinct().ToList();

            grupo.Codigo = txtCodigo.Text;
            grupo.Nombre = txtNombre.Text;
            grupo.DescripcionGrupo = txtDescripcion.Text;
            grupo.EstadoGrupo = (EstadoGrupo)cmbEstado.SelectedItem;

            // Asigna directamente las acciones seleccionadas
            grupo.Componentes = accionesSeleccionadas;

            string mensaje = modificar
                ? ControladoraGestionarGrupos.Instancia.ModificarGrupo(grupo)
                : ControladoraGestionarGrupos.Instancia.AgregarGrupo(grupo);

            MessageBox.Show(mensaje, "Información Grupo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


        #region Métodos Privados

        private List<Componente> ObtenerAccionesSeleccionadas()
        {
            List<Componente> accionesSeleccionadas = new List<Componente>();

            foreach (TreeNode nodo in treeViewAcciones.Nodes)
            {
                if (nodo.Checked)
                {
                    // Agregar la acción del nodo padre
                    var nombreAccion = nodo.Text;
                    var accion = ControladoraAcciones.Instancia.ObtenerAccionPorNombre(nombreAccion);
                    if (accion != null)
                    {
                        accionesSeleccionadas.Add(accion);
                    }

                    // Agregar todas las acciones de los subnodos si el nodo padre está marcado
                    foreach (TreeNode subNodo in nodo.Nodes)
                    {
                        var nombreSubAccion = subNodo.Text;
                        var subAccion = ControladoraAcciones.Instancia.ObtenerAccionPorNombre(nombreSubAccion);
                        if (subAccion != null)
                        {
                            accionesSeleccionadas.Add(subAccion);
                        }
                    }
                }
                else
                {
                    // Si el nodo padre no está marcado, verificar los subnodos individualmente
                    foreach (TreeNode subNodo in nodo.Nodes)
                    {
                        if (subNodo.Checked) // Si el subnodo está marcado, agregarlo
                        {
                            var nombreSubAccion = subNodo.Text;
                            var subAccion = ControladoraAcciones.Instancia.ObtenerAccionPorNombre(nombreSubAccion);
                            if (subAccion != null)
                            {
                                accionesSeleccionadas.Add(subAccion);
                            }
                        }
                    }
                }
            }

            return accionesSeleccionadas.Distinct().ToList(); // Asegurarse de que no haya duplicados
        }



        private void CargarAccionesGrupo()
        {
            // Obtener los nombres de las acciones asignadas al usuario desde la base de datos
            var accionesAsignadas = ControladoraAcciones.Instancia.ObtenerAccionesGrupo(grupo).Select(a => a.Nombre).ToList();

            // Recorrer cada nodo en el TreeView 
            foreach (TreeNode nodoCategoria in treeViewAcciones.Nodes)
            {
                // Recorrer cada subnodo dentro de la categoría
                foreach (TreeNode nodoAccion in nodoCategoria.Nodes)
                {
                    // Verificar que el Tag no sea nulo y que sea de tipo string
                    if (nodoAccion.Tag is string nombreAccion)
                    {
                        // Si la acción está asignada al grupo, marcarla como seleccionada
                        if (accionesAsignadas.Contains(nombreAccion))
                        {
                            nodoAccion.Checked = true;
                        }
                    }
                }
            }
        }



        private void CargarDatosGrupo()
        {
            txtCodigo.Text = grupo.Codigo;
            txtNombre.Text = grupo.Nombre;
            txtDescripcion.Text = grupo.DescripcionGrupo;
            cmbEstado.SelectedItem = grupo.EstadoGrupo;

            CargarAccionesGrupo();
        }



        private bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(this.txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del grupo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(this.txtDescripcion.Text))
            {
                MessageBox.Show("Debe ingresar una descripción", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        #endregion
    }
}
