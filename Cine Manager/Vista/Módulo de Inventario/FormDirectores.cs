using Controladora;
using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class FormDirectores : Form
    {
        public FormDirectores()
        {
            InitializeComponent();

            dgvDirectores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ActualizarGrilla();
        }




        private void ActualizarGrilla()
        {
            dgvDirectores.DataSource = null;
            dgvDirectores.DataSource = ControladoraGestionarDirectores.Instancia.RecuperarDirectores();
        }




        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                var director = new Director
                {
                    Codigo = txtCodigo.Text,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                };

                var mensaje = ControladoraGestionarDirectores.Instancia.AgregarDirector(director);
                ActualizarGrilla();
                LimpiarDetalles();
                MessageBox.Show(mensaje, "Información Directores", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    var mensaje = ControladoraGestionarDirectores.Instancia.EliminarDirector(directorSeleccionado);
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

                    var mensaje = ControladoraGestionarDirectores.Instancia.ModificarDirector(directorSeleccionado);

                    ActualizarGrilla(); // Método para actualizar la grilla de actores.
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




        private bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(this.txtCodigo.Text))
            {
                MessageBox.Show("Debe ingresar el código", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(this.txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(this.txtApellido.Text))
            {
                MessageBox.Show("Debe ingresar el apellido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (this.txtNombre.Text.Any(char.IsDigit))
            {
                MessageBox.Show("El nombre no puede contener números", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (this.txtApellido.Text.Any(char.IsDigit))
            {
                MessageBox.Show("El apellido no puede contener números", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }



        private bool ValidarDatosModificar(Director directorSeleccionado)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Debe ingresar el código", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del actor", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("Debe ingresar el apellido del actor", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            if (this.txtNombre.Text.Any(char.IsDigit))
            {
                MessageBox.Show("El nombre no puede contener números", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (this.txtApellido.Text.Any(char.IsDigit))
            {
                MessageBox.Show("El apellido no puede contener números", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar que el código no esté en uso por otro actor
            var directorConMismoCodigo = ControladoraGestionarDirectores.Instancia.Buscar(txtCodigo.Text);
            if (directorConMismoCodigo != null && directorConMismoCodigo.DirectorId != directorSeleccionado.DirectorId)
            {
                MessageBox.Show("El código ya está en uso por otro director.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }



        private void LimpiarDetalles()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
        }



        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
