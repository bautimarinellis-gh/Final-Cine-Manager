using Controladora;
using Modelo.Entidades;
using Modelo.Módulo_de_Seguridad;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Vista
{
    public partial class FormDirectores : Form
    {
        private Sesion _sesion;

        public FormDirectores(Sesion sesion)
        {
            InitializeComponent();
            _sesion = sesion;
            dgvDirectores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ActualizarGrilla();
        }



        #region Métodos de Actualización y Carga

        private void ActualizarGrilla()
        {
            dgvDirectores.DataSource = null;
            dgvDirectores.DataSource = ControladoraGestionarDirectores.Instancia.RecuperarDirectores();
        }

        private void LimpiarDetalles()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
        }

        #endregion



        #region Métodos de Eventos

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatosComunes())
            {
                return; // Si la validación falla, salimos del método
            }

            var director = new Director
            {
                Codigo = txtCodigo.Text,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
            };

            try
            {
                var mensaje = ControladoraGestionarDirectores.Instancia.AgregarDirector(director, _sesion.UsuarioSesion);
                ActualizarGrilla();
                LimpiarDetalles();
                MessageBox.Show(mensaje, "Información Directores", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDirectores.SelectedRows.Count > 0)
            {
                var directorSeleccionado = dgvDirectores.SelectedRows[0].DataBoundItem as Director;
                DialogResult respuesta = MessageBox.Show("¿Estas seguro que quieres eliminar el director: " + directorSeleccionado.Nombre + " ?", "Eliminar Director", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    var mensaje = ControladoraGestionarDirectores.Instancia.EliminarDirector(directorSeleccionado, _sesion.UsuarioSesion);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarGrilla();
                }
            }
            else
            {
                MessageBox.Show("No tienes ningun director seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDirectores.SelectedRows.Count > 0)
            {
                var directorSeleccionado = dgvDirectores.SelectedRows[0].DataBoundItem as Director;

                if (!ValidarDatosModificar(directorSeleccionado))
                {
                    return;
                }

                DialogResult respuesta = MessageBox.Show($"¿Estás seguro que quieres modificar el director: {directorSeleccionado.Nombre} {directorSeleccionado.Apellido}?", "Modificar Director", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    directorSeleccionado.Codigo = txtCodigo.Text;
                    directorSeleccionado.Nombre = txtNombre.Text;
                    directorSeleccionado.Apellido = txtApellido.Text;

                    var mensaje = ControladoraGestionarDirectores.Instancia.ModificarDirector(directorSeleccionado, _sesion.UsuarioSesion);
                    ActualizarGrilla();
                    LimpiarDetalles();
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                MessageBox.Show("No tienes ningún director seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string textoBusqueda = txtBuscar.Text.Trim(); //El método Trim()  elimina cualquier espacio en blanco al principio o al final del texto
            dgvDirectores.DataSource = ControladoraGestionarDirectores.Instancia.FiltrarDirectores(textoBusqueda);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion



        #region Métodos de Validación

        private bool ValidarDatosComunes()
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Debe ingresar el código", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("Debe ingresar el apellido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtNombre.Text.Any(char.IsDigit))
            {
                MessageBox.Show("El nombre no puede contener números", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtApellido.Text.Any(char.IsDigit))
            {
                MessageBox.Show("El apellido no puede contener números", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }



        private bool ValidarDatosModificar(Director directorSeleccionado)
        {
            if (!ValidarDatosComunes()) return false;

            // Validar que el código no esté en uso por otro director
            var directorConMismoCodigo = ControladoraGestionarDirectores.Instancia.Buscar(txtCodigo.Text);
            if (directorConMismoCodigo != null && directorConMismoCodigo.DirectorId != directorSeleccionado.DirectorId)
            {
                MessageBox.Show("El código ya está en uso por otro director.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        #endregion
    }
}
