using Controladora;
using Modelo.Entidades;
using System;
using System.Windows.Forms;

namespace Vista.Módulo_de_Administración
{
    public partial class FormDetallesPedido : Form
    {
        private Pedido pedido;



        public FormDetallesPedido(Pedido pedidoSeleccionado) 
        {
            InitializeComponent();
            this.pedido = pedidoSeleccionado;
            ActualizarGrilla();
        }



        #region Métodos de Carga y Actualización

        private void ActualizarGrilla()
        {
            try
            {
                dgvDetallesVenta.DataSource = null;
                dgvDetallesVenta.DataSource = ControladoraDetallesPedidos.Instancia.RecuperarDetallesVenta(pedido);

                dgvDetallesAlquiler.DataSource = null;
                dgvDetallesAlquiler.DataSource = ControladoraDetallesPedidos.Instancia.RecuperarDetallesAlquiler(pedido);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar las grillas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion



        #region Botones de Acciones

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            if (dgvDetallesAlquiler.SelectedRows.Count > 0)
            {
                var alquilerSeleccionado = dgvDetallesAlquiler.SelectedRows[0].DataBoundItem as DetalleAlquiler;

                if (ValidarDatos(alquilerSeleccionado))
                {
                    try
                    {
                        var mensaje = ControladoraDetallesPedidos.Instancia.ModificarDetalleAlquiler(alquilerSeleccionado);
                        MessageBox.Show(mensaje, "Devolución Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarGrilla(); // Actualizar la grilla de alquileres
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al devolver el alquiler: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un alquiler de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion



        #region Validaciones

        private bool ValidarDatos(DetalleAlquiler detalleAlquiler)
        {
            if (detalleAlquiler == null)
            {
                MessageBox.Show("Seleccione un alquiler de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (detalleAlquiler.Devuelto)
            {
                MessageBox.Show("El alquiler seleccionado ya ha sido devuelto.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        #endregion
    }
}
