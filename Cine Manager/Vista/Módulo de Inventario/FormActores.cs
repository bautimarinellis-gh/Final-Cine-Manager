using Controladora;
using Modelo.Entidades;
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

namespace Vista
{
    public partial class FormActores : Form
    {

        private Sesion _sesion;

        public FormActores(Sesion sesion)
        {
            InitializeComponent();
            this._sesion = sesion;
            dgvActores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ActualizarGrilla();
        }

        #region Métodos de Actualización y Carga

        private void ActualizarGrilla()
        {
            dgvActores.DataSource = null;
            dgvActores.DataSource = ControladoraGestionarActores.Instancia.RecuperarActores();
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
            if (ValidarDatos())
            {
                var actor = new Actor
                {
                    Codigo = txtCodigo.Text,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                };

                var mensaje = ControladoraGestionarActores.Instancia.AgregarActor(actor);
                ActualizarGrilla();
                LimpiarDetalles();
                MessageBox.Show(mensaje, "Información Actores", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvActores.SelectedRows.Count > 0)
            {
                var actorSeleccionado = dgvActores.SelectedRows[0].DataBoundItem as Actor;

                DialogResult respuesta = MessageBox.Show("¿Estás seguro que quieres eliminar el actor: " + actorSeleccionado.Codigo + " ?", "Eliminar Actor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    var mensaje = ControladoraGestionarActores.Instancia.EliminarActor(actorSeleccionado);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarGrilla();
                }
            }
            else
            {
                MessageBox.Show("No tienes ningún actor seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvActores.SelectedRows.Count > 0)
            {
                var actorSeleccionado = dgvActores.SelectedRows[0].DataBoundItem as Actor;

                // Validar datos antes de proceder con la modificación
                if (!ValidarDatosModificar(actorSeleccionado))
                {
                    return;
                }

                DialogResult respuesta = MessageBox.Show($"¿Estás seguro que quieres modificar el actor: {actorSeleccionado.Nombre} {actorSeleccionado.Apellido}?", "Modificar Actor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    actorSeleccionado.Codigo = txtCodigo.Text;
                    actorSeleccionado.Nombre = txtNombre.Text;
                    actorSeleccionado.Apellido = txtApellido.Text;

                    var mensaje = ControladoraGestionarActores.Instancia.ModificarActor(actorSeleccionado);

                    ActualizarGrilla(); // Método para actualizar la grilla de actores.
                    LimpiarDetalles();
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                MessageBox.Show("No tienes ningún actor seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string textoBusqueda = txtBuscar.Text.Trim(); //El método Trim() elimina cualquier espacio en blanco al principio o al final del texto
            dgvActores.DataSource = ControladoraGestionarActores.Instancia.FiltrarActores(textoBusqueda);
        }



        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion



        #region Métodos de Validación

        private bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(this.txtCodigo.Text))
            {
                MessageBox.Show("Debe ingresar el código", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(this.txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del actor", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(this.txtApellido.Text))
            {
                MessageBox.Show("Debe ingresar el apellido del actor", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar que el código no esté en uso por otro actor
            var actorConMismoCodigo = ControladoraGestionarActores.Instancia.Buscar(txtCodigo.Text);
            if (actorConMismoCodigo != null)
            {
                MessageBox.Show("El código ya está en uso por otro actor.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }



        private bool ValidarDatosModificar(Actor actorSeleccionado)
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

            // Validar que el código no esté en uso por otro actor
            var actorConMismoCodigo = ControladoraGestionarActores.Instancia.Buscar(txtCodigo.Text);
            if (actorConMismoCodigo != null && actorConMismoCodigo.ActorId != actorSeleccionado.ActorId)
            {
                MessageBox.Show("El código ya está en uso por otro actor.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        #endregion
    }
}
