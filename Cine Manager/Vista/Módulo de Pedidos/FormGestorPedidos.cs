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

namespace Vista.Módulo_de_Administración
{
    public partial class FormGestorPedidos : Form
    {
        private Pedido pedido;

        public FormGestorPedidos()
        {
            InitializeComponent();
            dgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            pedido = new Pedido();

            pedido.AumentoPedido();
            ActualizarGrilla();

        }



        private void ActualizarGrilla()
        {
            dgvPedidos.DataSource = null;
            dgvPedidos.DataSource = ControladoraGestionarPedidos.Instancia.RecuperarPedidos();
        }




        private void btnInformacion_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.SelectedRows.Count > 0)
            {
                var pedidoSeleccionado = dgvPedidos.SelectedRows[0].DataBoundItem as Pedido;

                var formDetallesPedido = new FormDetallesPedido(pedidoSeleccionado);
                formDetallesPedido.ShowDialog();
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

                if (ValidarDatos(pedidoSeleccionado))
                {
                    var nuevoPagoPedido = new PagoPedido
                    {
                        Pedido = pedidoSeleccionado,
                        FechaPago = DateTime.Now,
                        Codigo = CodigoPagoUnico()
                    };

                    // Intentar agregar el pago del pedido
                    var mensaje = ControladoraPagarPedido.Instancia.AgregarPagoPedido(nuevoPagoPedido);

                    // Si se agregó correctamente, actualizar el estado del pedido
                    pedidoSeleccionado.Estado = true;
                    ControladoraPagarPedido.Instancia.ModificarPedido(pedidoSeleccionado);

                    MessageBox.Show(mensaje);
                    ActualizarGrilla();

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
                dgvPedidos.DataSource = ControladoraGestionarPedidos.Instancia.FiltrarPedidos(null);
            }
            else if (int.TryParse(textoBusqueda, out int dniBusqueda))
            {
                dgvPedidos.DataSource = ControladoraGestionarPedidos.Instancia.FiltrarPedidos(dniBusqueda);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un DNI válido (solo números).", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }




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




        private string CodigoPagoUnico()
        {
            return Guid.NewGuid().ToString();
        }




        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            var formAdmin = new FormModuloAdmin();
            formAdmin.Show();
        }
    }
}
