using Controladora;
using Controladora.Negocio;
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

namespace Vista.Módulo_de_Ventas
{
    public partial class FormMetodosPago : Form
    {
        private Sesion sesion;

        public FormMetodosPago(Sesion _sesion)
        {
            InitializeComponent();
            dgvMetodosPago.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.sesion = _sesion;
            ActualizarGrilla();
        }


        #region Métodos de Actualización

        private void ActualizarGrilla()
        {
            dgvMetodosPago.DataSource = null;
            dgvMetodosPago.DataSource = ControladoraGestionarMetodosPago.Instancia.RecuperarMetodosPago();
        }

        private void LimpiarDetalles()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
        }

        #endregion



        #region Eventos de Botones

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                var metodoPago = new MetodoPago
                {
                    Codigo = txtCodigo.Text,
                    Nombre = txtNombre.Text,
                };

                var mensaje = ControladoraGestionarMetodosPago.Instancia.AgregarMetodoPago(metodoPago);
                ActualizarGrilla();
                LimpiarDetalles();
                MessageBox.Show(mensaje, "Información Métodos de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvMetodosPago.SelectedRows.Count > 0)
            {
                var metodoSeleccionado = dgvMetodosPago.SelectedRows[0].DataBoundItem as MetodoPago;

                if (!ValidarDatosModificar(metodoSeleccionado))
                {
                    return;
                }

                DialogResult respuesta = MessageBox.Show($"¿Estás seguro que quieres modificar el método de pago: {metodoSeleccionado.Nombre}?", "Modificar Método de Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    metodoSeleccionado.Codigo = txtCodigo.Text;
                    metodoSeleccionado.Nombre = txtNombre.Text;

                    var mensaje = ControladoraGestionarMetodosPago.Instancia.ModificarMetodoPago(metodoSeleccionado);

                    ActualizarGrilla();
                    LimpiarDetalles();
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No tienes ningún método de pago seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMetodosPago.SelectedRows.Count > 0)
            {
                var metodoPagoSeleccionado = dgvMetodosPago.SelectedRows[0].DataBoundItem as MetodoPago;

                DialogResult respuesta = MessageBox.Show($"¿Estás seguro que quieres eliminar el método de pago: {metodoPagoSeleccionado.Nombre}?", "Eliminar Método de Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    var mensaje = ControladoraGestionarMetodosPago.Instancia.EliminarMetodoPago(metodoPagoSeleccionado);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarGrilla();
                }
            }
            else
            {
                MessageBox.Show("No tienes ningún método de pago seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string textoBusqueda = txtBuscar.Text.Trim(); //El método Trim()  elimina cualquier espacio en blanco al principio o al final del texto
            dgvMetodosPago.DataSource = ControladoraGestionarMetodosPago.Instancia.FiltrarMetodosPago(textoBusqueda);
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
                MessageBox.Show("Debe ingresar el nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool ValidarDatosModificar(MetodoPago metodoPagoSeleccionado)
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

            // Validar que el código no esté en uso por otro método de pago
            var metodoConMismoCodigo = ControladoraGestionarMetodosPago.Instancia.Buscar(txtCodigo.Text);
            if (metodoConMismoCodigo != null && metodoConMismoCodigo.MetodoPagoId != metodoPagoSeleccionado.MetodoPagoId)
            {
                MessageBox.Show("El código ya está en uso por otro método de pago.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        #endregion
    }
}
