using Controladora;
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
            _sesion = sesion;
            pedido = new Pedido();

            try
            {
                pedido.AumentoPedido();
                ActualizarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los pedidos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Métodos de Carga y Actualización

        private void ActualizarGrilla()
        {
            try
            {
                dgvPedidos.DataSource = null;
                dgvPedidos.DataSource = ControladoraGestionarPedidos.Instancia.RecuperarPedidos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la grilla: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                if (pedidoSeleccionado != null && ValidarDatos(pedidoSeleccionado))
                {
                    try
                    {
                        var nuevoPagoPedido = new PagoPedido
                        {
                            Pedido = pedidoSeleccionado,
                            FechaPago = DateTime.Now,
                            Codigo = CodigoPagoUnico()
                        };

                        var mensaje = ControladoraPagarPedido.Instancia.AgregarPagoPedido(nuevoPagoPedido);

                        pedidoSeleccionado.Estado = true;
                        ControladoraPagarPedido.Instancia.ModificarPedido(pedidoSeleccionado);

                        MessageBox.Show(mensaje, "Pago realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarGrilla();
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
