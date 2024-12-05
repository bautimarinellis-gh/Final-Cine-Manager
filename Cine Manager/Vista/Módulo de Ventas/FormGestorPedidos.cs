using Controladora;
using Controladora.Negocio;
using Modelo.Entidades;
using Modelo.Módulo_de_Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vista.Módulo_de_Administración
{
    public partial class FormGestorPedidos : Form
    {
        private Pedido pedido;
        private Sesion _sesion;



        public FormGestorPedidos(Sesion sesion)
        {
            InitializeComponent();
            dgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this._sesion = sesion;

            LlenarComboBox();
            pedido = new Pedido();

            ActualizarGrilla();
        }

        #region Métodos de Carga y Actualización

        private void ActualizarGrilla()
        {
            pedido.AumentoPedido();

            // Consulta actualizada a la base de datos
            var pedidos = ControladoraGestionarPedidos.Instancia.RecuperarPedidos();

            dgvPedidos.DataSource = null;
            dgvPedidos.DataSource = pedidos;
        }

        private void LlenarComboBox()
        {
            cmbMetodoPago.DataSource = ControladoraGestionarMetodosPago.Instancia.RecuperarMetodosPago();
            cmbMetodoPago.DisplayMember = "Codigo";
        }


        #endregion



        #region Botones de Acciones


        private void btnInformacion_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.SelectedRows.Count > 0)
            {
                var pedidoSeleccionado = dgvPedidos.SelectedRows[0].DataBoundItem as Pedido;

                if (pedidoSeleccionado != null)
                {
                    var formDetallesPedido = new FormDetallesPedido(pedidoSeleccionado);
                    formDetallesPedido.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No se pudo recuperar la información del pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un pedido para ver la información.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.SelectedRows.Count > 0)
            {
                var pedidoSeleccionado = dgvPedidos.SelectedRows[0].DataBoundItem as Pedido;

                // Validar si se seleccionó un pedido y el método de pago
                if (pedidoSeleccionado != null && ValidarDatos(pedidoSeleccionado))
                {
                    var metodoPagoSeleccionado = cmbMetodoPago.SelectedItem as MetodoPago; // Obtener el método de pago seleccionado

                    try
                    {
                        var nuevoPagoPedido = new PagoPedido
                        {
                            Pedido = pedidoSeleccionado,
                            FechaPago = DateTime.Now,
                            MetodoPago = metodoPagoSeleccionado, // Asignar el método de pago
                            Codigo = CodigoPagoUnico()
                        };

                        var mensaje = ControladoraPagarPedido.Instancia.AgregarPagoPedido(nuevoPagoPedido);

                        // Actualizar el estado del pedido a pagado
                        pedidoSeleccionado.Estado = true;
                        ControladoraPagarPedido.Instancia.ModificarPedido(pedidoSeleccionado);

                        MessageBox.Show(mensaje, "Pago realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarGrilla(); // Refrescar la grilla de pedidos
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al realizar el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un pedido para pagar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string textoBusqueda = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(textoBusqueda))
            {
                ActualizarGrilla();
            }
            else
            {
                try
                {
                    if (int.TryParse(textoBusqueda, out int dniBusqueda))
                    {
                        dgvPedidos.DataSource = ControladoraGestionarPedidos.Instancia.FiltrarPedidos(dniBusqueda);
                    }
                    else
                    {
                        MessageBox.Show("Por favor, ingrese un DNI válido (solo números).", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al realizar la búsqueda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


        #region Validaciones


        private bool ValidarDatos(Pedido pedido)
        {
            if (pedido.Estado == true)
            {
                MessageBox.Show("El pedido ya se encuentra pago.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            var detallesAlquiler = ControladoraDetallesPedidos.Instancia.RecuperarDetallesAlquiler(pedido);

            if (detallesAlquiler.Any(da => !da.Devuelto))
            {
                MessageBox.Show("No se puede pagar el pedido. Existen detalles de alquiler sin ser devueltos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            // Validar que se ha seleccionado un método de pago
            var metodoPagoSeleccionado = cmbMetodoPago.SelectedItem as MetodoPago;
            if (metodoPagoSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un método de pago.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        #endregion



        #region Utilidades

        private string CodigoPagoUnico()
        {
            return Guid.NewGuid().ToString();
        }

        #endregion
    }
}
