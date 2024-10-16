using Controladora;
using Modelo.Entidades;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Vista
{
    public partial class FormGenerosCinematograficos : Form
    {

        public FormGenerosCinematograficos()
        {
            InitializeComponent();
            dgvGenerosCinematograficos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ActualizarGrilla();
        }


        #region Métodos de Actualización

        private void ActualizarGrilla()
        {
            dgvGenerosCinematograficos.DataSource = null;
            dgvGenerosCinematograficos.DataSource = ControladoraGestionarGenerosCinematograficos.Instancia.RecuperarGenerosCinematograficos();
        }

        private void LimpiarDetalles()
        {
            txtNombre.Text = "";
        }

        #endregion



        #region Eventos de Botones


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                var generoCinematografico = new GeneroCinematografico
                {
                    Nombre = txtNombre.Text,
                };

                var mensaje = ControladoraGestionarGenerosCinematograficos.Instancia.AgregarGeneroCinematografico(generoCinematografico);
                ActualizarGrilla();
                LimpiarDetalles();
                MessageBox.Show(mensaje, "Información Géneros Cinematograficos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvGenerosCinematograficos.SelectedRows.Count > 0)
            {
                var generoCinematograficoSeleccionado = dgvGenerosCinematograficos.SelectedRows[0].DataBoundItem as GeneroCinematografico;

                DialogResult respuesta = MessageBox.Show("¿Estas seguro que quieres eliminar el género cinematografico: " + generoCinematograficoSeleccionado.Nombre + " ?", "Eliminar Género Cinematografico", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    var mensaje = ControladoraGestionarGenerosCinematograficos.Instancia.EliminarGeneroCinematografico(generoCinematograficoSeleccionado);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarGrilla();
                }
            }
            else
            {
                MessageBox.Show("No tienes ningun género cinematografico seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvGenerosCinematograficos.SelectedRows.Count > 0)
            {
                var generoSeleccionado = dgvGenerosCinematograficos.SelectedRows[0].DataBoundItem as GeneroCinematografico;

                if (!ValidarDatosModificar(generoSeleccionado))
                {
                    return;
                }

                DialogResult respuesta = MessageBox.Show($"¿Estás seguro que quieres modificar el genero cinematografico: {generoSeleccionado.Nombre} ?", "Modificar Genero Cinematografico", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    generoSeleccionado.Nombre = txtNombre.Text;

                    var mensaje = ControladoraGestionarGenerosCinematograficos.Instancia.ModificarGeneroCinematografico(generoSeleccionado);

                    ActualizarGrilla(); // Método para actualizar la grilla de actores.
                    LimpiarDetalles();
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                MessageBox.Show("No tienes ningún genero cinematografico seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string textoBusqueda = txtBuscar.Text.Trim(); //El método Trim()  elimina cualquier espacio en blanco al principio o al final del texto
            dgvGenerosCinematograficos.DataSource = ControladoraGestionarGenerosCinematograficos.Instancia.FiltrarGenerosCinematograficos(textoBusqueda);
        }



        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion



        #region Métodos de Validación

        private bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(this.txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (this.txtNombre.Text.Any(char.IsDigit))
            {
                MessageBox.Show("El nombre no puede contener números", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool ValidarDatosModificar(GeneroCinematografico generoCinematograficoSeleccionado)
        {
            if (string.IsNullOrEmpty(this.txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (this.txtNombre.Text.Any(char.IsDigit))
            {
                MessageBox.Show("El nombre no puede contener números", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar que el código no esté en uso por otro actor
            var generoConMismoNombre = ControladoraGestionarGenerosCinematograficos.Instancia.Buscar(txtNombre.Text);
            if (generoConMismoNombre != null && generoConMismoNombre.GeneroCinematograficoId != generoCinematograficoSeleccionado.GeneroCinematograficoId)
            {
                MessageBox.Show("El nombre ya está en uso por otro genero cinematografico.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        #endregion
    }
}
