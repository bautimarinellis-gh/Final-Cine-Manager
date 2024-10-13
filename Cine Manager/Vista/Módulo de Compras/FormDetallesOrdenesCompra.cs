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



        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (dgvDetallesOrdenCompra.SelectedRows.Count > 0)
            {
                var detalleOrdenSeleccionado = (DetalleOrdenCompra)dgvDetallesOrdenCompra.SelectedRows[0].DataBoundItem;

                // Mostrar ventana de confirmación
                var confirmResult = MessageBox.Show(
                    "¿Estás seguro que quieres pagar el detalle orden de compra?",
                    "Confirmar Pago",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                // Si el usuario confirma el pago
                if (confirmResult == DialogResult.Yes)
                {
                    var mensaje = ControladoraDetallesOrdenesCompra.Instancia.PagarDetalleOrdenCompra(detalleOrdenSeleccionado);

                    MessageBox.Show(mensaje, "Resultado del Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarGrilla();  // Actualiza el DataGridView para reflejar los cambios
                }
            }
            else
            {
                MessageBox.Show("Seleccione un detalle de orden de compra para pagar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
