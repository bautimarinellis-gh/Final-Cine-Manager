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
using Vista.Módulo_de_Administración;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Vista.Módulo_de_Transacciones
{
    public partial class FormRealizarPedido : Form
    {
        private Pedido pedidoActual;

        public FormRealizarPedido()
        {
            InitializeComponent();

            dgvPeliculasDisponibles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetallesPedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            pedidoActual = new Pedido();

            ActualizarGrilla();
            LlenarComboBox();
        }


        private void ActualizarGrilla()
        {
            /*var peliculas = ControladoraRealizarPedido.Instancia.RecuperarPeliculas().Where(pelicula => pelicula.Cantidad > 0).ToList();*/

            dgvPeliculasDisponibles.DataSource = null;
            dgvPeliculasDisponibles.DataSource = ControladoraGestionarPeliculas.Instancia.RecuperarPeliculas();



            /*dgvPeliculasDisponibles.DataSource = null;
            dgvPeliculasDisponibles.DataSource = peliculas;*/

            dgvDetallesPedido.DataSource = null;
            dgvDetallesPedido.DataSource = pedidoActual.RecuperarDetalles();
        }




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

                // Actualizar UI
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
                    FechaDevolucion = DateTime.Now.AddMinutes(2),
                };

                string mensaje = pedidoActual.AgregarDetalle(detalleAlquiler, true);
                MessageBox.Show(mensaje);

                // Actualizar UI
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

            DialogResult eleccion = MessageBox.Show("¿Confirmar el pedido?", "Confirmación de pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (eleccion == DialogResult.Yes)
            {
                var clienteSeleccionado = (Cliente)cmbDNI.SelectedItem;

                var nuevoPedido = new Pedido
                {
                    Total = pedidoActual.Total,
                    Cliente = clienteSeleccionado,
                    Fecha = DateTime.Now,
                    Codigo = CodigoPedidoUnico(),
                    Estado = false,
                    DetallesPedido = pedidoActual.DetallesPedido.ToList(),
                };


                string mensajePedido = ControladoraRealizarPedido.Instancia.AgregarPedido(nuevoPedido);
                MessageBox.Show(mensajePedido);


                pedidoActual.LimpiarDetalles();

                ActualizarGrilla();

                // Reiniciar el total y actualizar el textbox
                txtTotal.Text = pedidoActual.Total.ToString();
            }
            else if (eleccion == DialogResult.No)
            {
                MessageBox.Show("Pedido cancelado.");

            }
        }




        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string textoBusqueda = txtBuscar.Text.Trim();
            dgvPeliculasDisponibles.DataSource = ControladoraRealizarPedido.Instancia.FiltrarPeliculasDisponibles(textoBusqueda);
        }




        private bool ValidarDatos(Pelicula peliculaSeleccionada)
        {
            if (string.IsNullOrEmpty(txtCantidadPeliculas.Text) || !int.TryParse(txtCantidadPeliculas.Text, out int cantidad) || cantidad <= 0)
            {
                return false;
            }

            /*if (cantidad > peliculaSeleccionada.Cantidad)
            {
                return false;
            }*/

            return true;
        }




        private bool ValidarDatosCompra()
        {
            if (dgvDetallesPedido.Rows.Count == 0)
            {
                MessageBox.Show("No hay peliculas para confirmar la compra.");
                return false;
            }

            var cliente = (Cliente)cmbDNI.SelectedItem;

            if (ControladoraRealizarPedido.Instancia.ClienteTieneAlquileresSinDevolver(cliente))
            {
                MessageBox.Show("El cliente tiene alquileres sin devolver. No se puede realizar un nuevo pedido.");
                return false;
            }

            return true;
        }



        private string CodigoPedidoUnico()
        {
            return Guid.NewGuid().ToString();
        }




        private void LlenarComboBox()
        {
            cmbDNI.DataSource = ControladoraGestionarClientes.Instancia.RecuperarClientes();
            cmbDNI.DisplayMember = "DNI";

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

    }
}
