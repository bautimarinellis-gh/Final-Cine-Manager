using Controladora;
using Controladora.Negocio;
using Modelo.Entidades;
using Modelo.Entidades.EstadosOrdenesCompra;
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
using Vista.Módulo_de_Administración;

namespace Vista.Módulo_de_Compras
{
    public partial class FormOrdenesCompra : Form
    {
        private Sesion _sesion;

        public FormOrdenesCompra(Sesion sesion)
        {
            InitializeComponent();
            _sesion = sesion;
            dgvOrdenesCompra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cmbEstado.SelectedIndex = 0;
            cmbEstado.SelectedIndexChanged += cmbEstado_SelectedIndexChanged;

            ActualizarGrilla();
        }


        private void ActualizarGrilla()
        {
            dgvOrdenesCompra.DataSource = null;
            dgvOrdenesCompra.DataSource = ControladoraGestionarOrdenesCompra.Instancia.RecuperarOrdenesCompra();
        }



        private void btnRealizarOrden_Click(object sender, EventArgs e)
        {
            var formRealizarOrden = new FormRealizarOrdenCompra(_sesion);
            formRealizarOrden.ShowDialog();

            ActualizarGrilla();
        }



        private void btnInformacion_Click(object sender, EventArgs e)
        {

            if (dgvOrdenesCompra.SelectedRows.Count > 0)
            {
                var ordenCompraSeleccionada = dgvOrdenesCompra.SelectedRows[0].DataBoundItem as OrdenCompra;

                // Verificar si la orden está cancelada
                if (ordenCompraSeleccionada.Estado == "Cancelada")
                {
                    MessageBox.Show("La orden de compra ha sido cancelada y no puede ser visualizada.", "Orden Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var formDetallesOrdenCompra = new FormDetallesOrdenesCompra(ordenCompraSeleccionada);
                formDetallesOrdenCompra.ShowDialog();
                ActualizarGrilla();
            }
            else
            {
                MessageBox.Show("Seleccione una orden de compra para ver la información.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }




        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (dgvOrdenesCompra.SelectedRows.Count > 0)
            {
                var ordenSeleccionada = (OrdenCompra)dgvOrdenesCompra.SelectedRows[0].DataBoundItem;

                // Mostrar ventana de confirmación
                var confirmResult = MessageBox.Show(
                    "¿Estás seguro que quieres cancelar la orden de compra? No se podrá reanudar.",
                    "Confirmar Cancelación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                // Si el usuario confirma la cancelación
                if (confirmResult == DialogResult.Yes)
                {
                    var mensaje = ControladoraGestionarOrdenesCompra.Instancia.CancelarOrdenCompra(ordenSeleccionada);

                    MessageBox.Show(mensaje, "Cancelación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarGrilla();  // Actualiza el DataGridView para reflejar los cambios
                }
            }
            else
            {
                MessageBox.Show("Seleccione una orden de compra para cancelar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string textoBusqueda = txtBuscar.Text.Trim();
            dgvOrdenesCompra.DataSource = ControladoraGestionarOrdenesCompra.Instancia.FiltrarOrdenesCompra(textoBusqueda);

        }



        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            var estadoSeleccionado = cmbEstado.SelectedItem.ToString();

            // Obtener todas las órdenes de compra
            var todasLasOrdenes = ControladoraGestionarOrdenesCompra.Instancia.RecuperarOrdenesCompra();

            if (estadoSeleccionado == "Todas")
            {
                dgvOrdenesCompra.DataSource = null;
                dgvOrdenesCompra.DataSource = todasLasOrdenes.ToList();
            }
            else if (estadoSeleccionado == "Pendientes")
            {
                dgvOrdenesCompra.DataSource = null;
                dgvOrdenesCompra.DataSource = todasLasOrdenes
                    .Where(o => o.Estado == "Pendiente") // Filtrar por estado
                    .ToList();
            }
            else if (estadoSeleccionado == "Completadas")
            {
                dgvOrdenesCompra.DataSource = null;
                dgvOrdenesCompra.DataSource = todasLasOrdenes
                    .Where(o => o.Estado == "Completada") // Filtrar por estado
                    .ToList();
            }
            else if (estadoSeleccionado == "Canceladas")
            {
                dgvOrdenesCompra.DataSource = null;
                dgvOrdenesCompra.DataSource = todasLasOrdenes
                    .Where(o => o.Estado == "Cancelada") // Filtrar por estado
                    .ToList();
            }
            else if (estadoSeleccionado == "Parcialmente Completadas")
            {
                dgvOrdenesCompra.DataSource = null;
                dgvOrdenesCompra.DataSource = todasLasOrdenes
                    .Where(o => o.Estado == "Parcialmente Completada") // Filtrar por estado
                    .ToList();
            }
        }


      
        

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
