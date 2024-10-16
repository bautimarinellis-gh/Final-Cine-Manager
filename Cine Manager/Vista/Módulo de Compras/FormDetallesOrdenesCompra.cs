using Controladora.Negocio;
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

namespace Vista.Módulo_de_Compras
{
    public partial class FormDetallesOrdenesCompra : Form
    {
        private OrdenCompra ordenCompra;


        public FormDetallesOrdenesCompra(OrdenCompra orden)
        {
            InitializeComponent();
            this.ordenCompra = orden;
            dgvDetallesOrdenCompra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            ActualizarGrilla();
        }


        private void ActualizarGrilla()
        {
            dgvDetallesOrdenCompra.DataSource = null;
            dgvDetallesOrdenCompra.DataSource = ControladoraDetallesOrdenesCompra.Instancia.RecuperarDetalles(ordenCompra);
        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dgvDetallesOrdenCompra.SelectedRows.Count > 0)
            {
                var detalleOrdenSeleccionado = (DetalleOrdenCompra)dgvDetallesOrdenCompra.SelectedRows[0].DataBoundItem;
                var ordenCompra = detalleOrdenSeleccionado.OrdenCompra;

                // Realizar las validaciones necesarias
                if (!ValidarOrdenCerrada(ordenCompra) || !ValidarCantidad(txtCantidadPeliculas.Text) || !ValidarDetalleCompletado(detalleOrdenSeleccionado))
                {
                    return;
                }

                // Confirmación de entrega
                var cantEntrega = int.Parse(txtCantidadPeliculas.Text); // Cantidad ya validada
                var confirmResult = MessageBox.Show(
                    $"¿Estás seguro que quieres ingresar {cantEntrega} como cantidad entregada para este detalle de orden de compra?",
                    "Confirmar Entrega",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    var resultado = ControladoraDetallesOrdenesCompra.Instancia.EntregarDetalleOrdenCompra(detalleOrdenSeleccionado, cantEntrega);

                    MessageBox.Show(resultado, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarGrilla();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un detalle de orden de compra para procesar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        #region Métodos de validación

        private bool ValidarOrdenCerrada(OrdenCompra ordenCompra)
        {
            if (ordenCompra.Estado == "Cerrada Con Faltante")
            {
                MessageBox.Show("La orden de compra ha sido cerrada. No puedes realizar más entregas. Si necesitas restaurar películas, por favor, realiza una nueva orden de compra.", "Orden Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool ValidarCantidad(string cantidadTexto)
        {
            if (string.IsNullOrEmpty(cantidadTexto) || !int.TryParse(cantidadTexto, out int cantEntrega) || cantEntrega <= 0)
            {
                MessageBox.Show("Por favor, ingresa un número entero positivo válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool ValidarDetalleCompletado(DetalleOrdenCompra detalleOrden)
        {
            if (detalleOrden.Estado)
            {
                MessageBox.Show("No se puede entregar más películas porque este detalle ya está completado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        #endregion




        private void txtCantidadPeliculas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // No permite ingresar nada que no sea un número
            }
        }



        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();

        }


    }
}
