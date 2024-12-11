using Controladora;
using Controladora.Negocio;
using Modelo.Entidades;
using System;
using System.Linq;
using System.Windows.Forms;
using Vista.Módulo_de_Ventas;

namespace Vista.Módulo_de_Transacciones
{
    public partial class FormRealizarPedido : Form
    {
        private Pedido pedidoActual;
        private Cliente clienteActual;


        public FormRealizarPedido()
        {
            InitializeComponent();

            dgvPeliculasDisponibles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetallesPedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            pedidoActual = new Pedido();

            ActualizarGrilla();

        }


        #region Métodos de Actualización de Grillas y ComboBox



        private void ActualizarGrilla()
        {
            dgvPeliculasDisponibles.DataSource = null;
            dgvPeliculasDisponibles.DataSource = ControladoraGestionarPeliculas.Instancia.RecuperarPeliculas();



            dgvDetallesPedido.DataSource = null;
            dgvDetallesPedido.DataSource = pedidoActual.RecuperarDetalles();
        }




        #endregion



        #region Botones: Venta, Alquiler, Quitar, Finalizar Pedido

        private void btnVenta_Click(object sender, EventArgs e)
        {
            if (dgvPeliculasDisponibles.SelectedRows.Count > 0)
            {
                Pelicula peliculaSeleccionada = (Pelicula)dgvPeliculasDisponibles.SelectedRows[0].DataBoundItem;

                if (!ValidarDatos(peliculaSeleccionada))
                {
                    MessageBox.Show("Datos inválidos o cantidad de películas insuficientes.");
                    return;
                }

                DetalleVenta detalleVenta = new DetalleVenta
                {
                    Pelicula = peliculaSeleccionada,
                    Cantidad = int.Parse(txtCantidadPeliculas.Text),
                    Garantia = true,
                };

                string mensaje = pedidoActual.AgregarDetalle(detalleVenta, false);
                MessageBox.Show(mensaje);

                txtTotal.Text = pedidoActual.Total.ToString();
                ActualizarGrilla();
                txtCantidadPeliculas.Text = "";
            }
            else
            {
                MessageBox.Show("Seleccione una película de la lista.");
            }
        }



        private void btnAlquiler_Click(object sender, EventArgs e)
        {
            if (dgvPeliculasDisponibles.SelectedRows.Count > 0)
            {
                Pelicula peliculaSeleccionada = (Pelicula)dgvPeliculasDisponibles.SelectedRows[0].DataBoundItem;

                if (!ValidarDatos(peliculaSeleccionada))
                {
                    MessageBox.Show("Datos inválidos o cantidad de películas insuficientes.");
                    return;
                }

                DetalleAlquiler detalleAlquiler = new DetalleAlquiler
                {
                    Pelicula = peliculaSeleccionada,
                    Cantidad = int.Parse(txtCantidadPeliculas.Text),
                    FechaDevolucion = DateTime.Now.AddMinutes(1),
                };

                string mensaje = pedidoActual.AgregarDetalle(detalleAlquiler, true);
                MessageBox.Show(mensaje);

                txtTotal.Text = pedidoActual.Total.ToString();
                ActualizarGrilla();
                txtCantidadPeliculas.Text = "";
            }
            else
            {
                MessageBox.Show("Seleccione una película de la lista.");
            }
        }



        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvDetallesPedido.SelectedRows.Count > 0)
            {
                DetallePedido detalleSeleccionado = (DetallePedido)dgvDetallesPedido.SelectedRows[0].DataBoundItem;

                string mensaje;
                if (detalleSeleccionado is DetalleVenta)
                {
                    mensaje = pedidoActual.EliminarDetalle(detalleSeleccionado, false);
                }
                else if (detalleSeleccionado is DetalleAlquiler)
                {
                    mensaje = pedidoActual.EliminarDetalle(detalleSeleccionado, true);
                }
                else
                {
                    mensaje = "Tipo de detalle no reconocido.";
                }

                MessageBox.Show(mensaje);
                txtTotal.Text = pedidoActual.Total.ToString();
                ActualizarGrilla();
            }
            else
            {
                MessageBox.Show("Seleccione una pelicula de la lista.");
            }
        }



        private void btnFinalizarPedido_Click(object sender, EventArgs e)
        {
            if (!ValidarDatosCompra())
            {
                return; // Salir del método si los datos no son válidos
            }

            // Validar que se haya seleccionado un cliente
            if (clienteActual == null)
            {
                MessageBox.Show("Debe seleccionar un cliente antes de finalizar el pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult eleccion = MessageBox.Show("¿Confirmar el pedido?", "Confirmación de pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (eleccion == DialogResult.Yes)
            {
                // Crear el nuevo pedido
                var nuevoPedido = new Pedido
                {
                    Total = pedidoActual.Total,
                    Cliente = clienteActual, // Usamos la variable clienteActual
                    Fecha = DateTime.Now,
                    Codigo = CodigoPedidoUnico(),
                    Estado = false,
                    DetallesPedido = pedidoActual.DetallesPedido.ToList(),
                };

                // Agregar el pedido a la base de datos
                string mensajePedido = ControladoraRealizarPedido.Instancia.AgregarPedido(nuevoPedido);
                MessageBox.Show(mensajePedido);

                // Limpiar los detalles del pedido y actualizar la UI
                pedidoActual.LimpiarDetalles();
                ActualizarGrilla();
                txtTotal.Text = pedidoActual.Total.ToString();
            }
            else
            {
                MessageBox.Show("Pedido cancelado.");
            }
        }


        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            // Crear instancia del formulario de asignación de cliente
            var formAsignarCliente = new FormAsignarCliente();

            // Mostrar el formulario como modal
            if (formAsignarCliente.ShowDialog() == DialogResult.OK)
            {
                // Recuperar el cliente seleccionado desde el formulario
                var clienteSeleccionado = formAsignarCliente.Tag as Cliente;

                if (clienteSeleccionado != null)
                {
                    // Mostrar el DNI del cliente en el TextBox
                    txtDNICliente.Text = clienteSeleccionado.DNI.ToString();
                    // Guardar el cliente en una variable si es necesario para usarlo posteriormente
                    this.clienteActual = clienteSeleccionado;
                }
            }
        }

        #endregion



        #region Validaciones

        private bool ValidarDatos(Pelicula peliculaSeleccionada)
        {
            if (string.IsNullOrEmpty(txtCantidadPeliculas.Text) || !int.TryParse(txtCantidadPeliculas.Text, out int cantidad) || cantidad <= 0)
            {
                return false;
            }
            return true;
        }


        private bool ValidarDatosCompra()
        {
            // Verificar que haya al menos un detalle en el pedido
            if (dgvDetallesPedido.Rows.Count == 0)
            {
                MessageBox.Show("No hay películas para confirmar la compra.");
                return false;
            }

            // Validar que el TextBox tenga un cliente asociado
            if (string.IsNullOrWhiteSpace(txtDNICliente.Text))
            {
                MessageBox.Show("Debe seleccionar un cliente antes de realizar el pedido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar que la variable clienteActual no sea nula
            if (clienteActual == null)
            {
                MessageBox.Show("Debe seleccionar un cliente válido antes de realizar el pedido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Verificar si el cliente tiene alquileres sin devolver
            if (ControladoraRealizarPedido.Instancia.ClienteTieneAlquileresSinDevolver(clienteActual))
            {
                MessageBox.Show("El cliente tiene alquileres sin devolver. No se puede realizar un nuevo pedido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        #endregion



        #region Métodos Auxiliares

        private string CodigoPedidoUnico()
        {
            return Guid.NewGuid().ToString();
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string textoBusqueda = txtBuscar.Text.Trim();
            dgvPeliculasDisponibles.DataSource = ControladoraRealizarPedido.Instancia.FiltrarPeliculasDisponibles(textoBusqueda);
        }



        private void btnVolver_Click(object sender, EventArgs e)
        {
            if (dgvDetallesPedido.Rows.Count == 0)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, devuelve las ventas y/o alquileres de la grilla para volver.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion


    }
}
