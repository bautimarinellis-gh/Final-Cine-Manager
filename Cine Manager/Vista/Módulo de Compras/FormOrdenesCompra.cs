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



        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (dgvOrdenesCompra.SelectedRows.Count > 0)
            {
                var ordenSeleccionada = (OrdenCompra)dgvOrdenesCompra.SelectedRows[0].DataBoundItem;

                if (ordenSeleccionada.Estado)
                {
                    MessageBox.Show("Esta orden de compra ya ha sido pagada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var mensaje = ControladoraGestionarOrdenesCompra.Instancia.PagarOrdenCompra(ordenSeleccionada);

                MessageBox.Show(mensaje);
                ActualizarGrilla();
            }
            else
            {
                MessageBox.Show("Seleccione una orden de compra para pagar .", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

            if (estadoSeleccionado == "Todas")
            {
                dgvOrdenesCompra.DataSource = null;
                dgvOrdenesCompra.DataSource = ControladoraGestionarOrdenesCompra.Instancia.RecuperarOrdenesCompra();
            }
            else if (estadoSeleccionado == "Pendientes")
            {
                dgvOrdenesCompra.DataSource = null;
                dgvOrdenesCompra.DataSource = ControladoraGestionarOrdenesCompra.Instancia.RecuperarOrdenesCompra()
                    .Where(o => !o.Estado)
                    .ToList();
            }
            else if (estadoSeleccionado == "Completadas")
            {
                dgvOrdenesCompra.DataSource = null;
                dgvOrdenesCompra.DataSource = ControladoraGestionarOrdenesCompra.Instancia.RecuperarOrdenesCompra()
                    .Where(o => o.Estado)
                    .ToList();
            }
        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
