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
    public partial class FormDetallesPedido : Form
    {
        private Pedido pedido;

        public FormDetallesPedido(Pedido pedidoSeleccionado) //Parametro del pedido seleccionado en el dgv
        {
            InitializeComponent();
            this.pedido = pedidoSeleccionado;


            ActualizarGrilla();
        }


        private void ActualizarGrilla()
        {
            dgvDetallesVenta.DataSource = null;
            dgvDetallesVenta.DataSource = ControladoraDetallesPedidos.Instancia.RecuperarDetallesVenta(pedido);


            dgvDetallesAlquiler.DataSource = null;
            dgvDetallesAlquiler.DataSource = ControladoraDetallesPedidos.Instancia.RecuperarDetallesAlquiler(pedido);
        }




        private void btnDevolver_Click(object sender, EventArgs e)
        {
            if (dgvDetallesAlquiler.SelectedRows.Count > 0)
            {
                var alquilerSeleccionado = (DetalleAlquiler)dgvDetallesAlquiler.SelectedRows[0].DataBoundItem;

                if (ValidarDatos(alquilerSeleccionado))
                {
                    var mensaje = ControladoraDetallesPedidos.Instancia.ModificarDetalleAlquiler(alquilerSeleccionado);

                    MessageBox.Show(mensaje);
                    ActualizarGrilla(); // Actualizar la grilla de alquileres
                }
            }
            else
            {
                MessageBox.Show("Seleccione un alquiler de la lista.");
            }
        }




        private bool ValidarDatos(DetalleAlquiler detalleAlquiler)
        {
            if (detalleAlquiler == null)
            {
                MessageBox.Show("Seleccione un alquiler de la lista.");
                return false;
            }

            if (detalleAlquiler.Devuelto == true)
            {
                MessageBox.Show("El alquiler seleccionado ya ha sido devuelto.");
                return false;
            }

            return true;
        }



        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
