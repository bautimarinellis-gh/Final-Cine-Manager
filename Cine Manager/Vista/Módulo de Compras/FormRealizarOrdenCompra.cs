using Controladora;
using Controladora.Nueva_Iteración;
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

namespace Vista.Módulo_de_Compras
{
    public partial class FormRealizarOrdenCompra : Form
    {
        private Sesion _sesion;
        private OrdenCompra ordenActual;

        public FormRealizarOrdenCompra(Sesion sesion)
        {
            InitializeComponent();
            _sesion = sesion;

            ordenActual = new OrdenCompra();

            dgvPeliculas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            ActualizarGrilla();
            LlenarComboBox();
        }


        private void ActualizarGrilla()
        {
            dgvPeliculas.DataSource = null;
            dgvPeliculas.DataSource = ControladoraGestionarPeliculas.Instancia.RecuperarPeliculas();

            dgvDetalles.DataSource = null;
            dgvDetalles.DataSource = ordenActual.RecuperarDetalles();
        }



        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            if (dgvPeliculas.SelectedRows.Count > 0)
            {
                Pelicula peliculaSeleccionada = (Pelicula)dgvPeliculas.SelectedRows[0].DataBoundItem;

                if (!ValidarDatos())
                {
                    return;
                }

                DetalleOrdenCompra detalleOrdenCompra = new DetalleOrdenCompra
                {
                    Pelicula = peliculaSeleccionada,
                    Cantidad = int.Parse(txtCantidadPeliculas.Text),
                };

                // Agregar el detalle a la orden actual
                string mensaje = ordenActual.AgregarDetalle(detalleOrdenCompra);
                MessageBox.Show(mensaje);

                // Actualizar la UI
                txtTotal.Text = ordenActual.Total.ToString();
                ActualizarGrilla();

                // Limpiar el campo de cantidad
                txtCantidadPeliculas.Text = "";
            }
            else
            {
                MessageBox.Show("Seleccione una película de la lista.");
            }
        }



        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvDetalles.SelectedRows.Count > 0)
            {
                if (dgvDetalles.SelectedRows.Count > 0)
                {
                    DetalleOrdenCompra detalleSeleccionado = (DetalleOrdenCompra)dgvDetalles.SelectedRows[0].DataBoundItem;

                    string mensaje;

                    mensaje = ordenActual.EliminarDetalle(detalleSeleccionado);


                    MessageBox.Show(mensaje);
                    txtTotal.Text = ordenActual.Total.ToString();

                    ActualizarGrilla();
                }

            }
            else
            {
                MessageBox.Show("Seleccione un detalle de la lista.");
            }
        }



        private void btnEmitirOrden_Click(object sender, EventArgs e)
        {
            if (!ValidarDatosEmitirOrden())
            {
                return;
            }

            DialogResult eleccion = MessageBox.Show("¿Esta seguro que desea emitir la órden de compra?", "Confirmación de orden de compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (eleccion == DialogResult.Yes)
            {
                var proveedorSeleccionado = (Proveedor)cmbProveedores.SelectedItem;

                var nuevaOrdenCompra = new OrdenCompra
                {
                    Codigo = CodigoOrdenUnico(),
                    Proveedor = proveedorSeleccionado,
                    FechaOrden = DateTime.Now,
                    Total = ordenActual.Total,
                    Estado = false,
                    DetallesOrdenesCompra = ordenActual.DetallesOrdenesCompra.ToList(),
                };

                string mensaje = ControladoraEmitirOrdenCompra.Instancia.AgregarOrdenCompra(nuevaOrdenCompra);
                MessageBox.Show(mensaje);

                ordenActual.LimpiarDetalles();

                ActualizarGrilla();

                txtTotal.Text = ordenActual.Total.ToString();


            }
            else if (eleccion == DialogResult.No)
            {
                MessageBox.Show("Orden de compra cancelada");
            }


        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string textoBusqueda = txtBuscar.Text.Trim();
            dgvPeliculas.DataSource = ControladoraRealizarPedido.Instancia.FiltrarPeliculasDisponibles(textoBusqueda);
        }



        private bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(txtCantidadPeliculas.Text))
            {
                MessageBox.Show("El campo de cantidad no puede estar vacío.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(txtCantidadPeliculas.Text, out int cantidad))
            {
                MessageBox.Show("Debe ingresar un número válido en la cantidad.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cantidad <= 0 || cantidad > 100)
            {
                MessageBox.Show("La cantidad debe ser mayor que 0 y menor o igual a 100.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }



        private bool ValidarDatosEmitirOrden()
        {
            if (dgvDetalles.Rows.Count == 0)
            {
                MessageBox.Show("No hay peliculas para confirmar la compra.");
                return false;
            }
            return true;
        }




        private string CodigoOrdenUnico()
        {
            return Guid.NewGuid().ToString();
        }



        private void LlenarComboBox()
        {
            cmbProveedores.DataSource = ControladoraGestionarProveedores.Instancia.RecuperarProveedores();
            cmbProveedores.DisplayMember = "Codigo";
        }



        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
