﻿using Controladora;
using Controladora.Negocio;
using Modelo.Entidades;
using Modelo.Entidades.EstadosOrdenesCompra;
using Modelo.Módulo_de_Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Vista.Módulo_de_Administración;

namespace Vista.Módulo_de_Compras
{
    public partial class FormOrdenesCompra : Form
    {
        #region Atributos
        private Sesion _sesion;
        private string filtroActual = "Todas";
        private List<OrdenCompra> _todasLasOrdenes = new List<OrdenCompra>();

        #endregion



        #region Constructor
        public FormOrdenesCompra(Sesion sesion)
        {
            InitializeComponent();
            _sesion = sesion;
            dgvOrdenesCompra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cmbEstado.SelectedIndex = 0;
            cmbEstado.SelectedIndexChanged += cmbEstado_SelectedIndexChanged;

            ActualizarGrilla();
        }
        #endregion



        #region Métodos Privados
        private void ActualizarGrilla()
        {

            // Obtener todas las órdenes de compra actualizadas desde la base de datos
            var ordenesCompraActualizadas = ControladoraGestionarOrdenesCompra.Instancia.RecuperarOrdenesCompra();

            // Actualizar el listado interno de todas las órdenes para aplicar el filtro actual
            _todasLasOrdenes = ordenesCompraActualizadas.ToList();

            // Aplicar el filtro actual
            FiltrarGrilla();
        }
        #endregion



        #region Eventos
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

                // Verificar si la orden está cerrada con faltante
                if (ordenCompraSeleccionada.Estado == "Cerrada Con Faltante")
                {
                    MessageBox.Show("Estás por abrir una orden de compra que ya ha sido cerrada. No podrás realizar entregas en esta orden.", "Orden Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Mostrar el formulario de detalles
                var formDetallesOrdenCompra = new FormDetallesOrdenesCompra(ordenCompraSeleccionada);
                formDetallesOrdenCompra.ShowDialog();

                // Recargar los datos de la grilla desde la base de datos
                ActualizarGrilla();
            }
            else
            {
                MessageBox.Show("Seleccione una orden de compra para ver la información.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (dgvOrdenesCompra.SelectedRows.Count > 0)
            {
                var ordenSeleccionada = (OrdenCompra)dgvOrdenesCompra.SelectedRows[0].DataBoundItem;

                var confirmResult = MessageBox.Show(
                    "¿Estás seguro que deseas cerrar esta orden de compra? No podrás entregar más detalles.",
                    "Confirmar Cierre",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                // Si el usuario confirma
                if (confirmResult == DialogResult.Yes)
                {
                    var mensaje = ControladoraGestionarOrdenesCompra.Instancia.CerrarOrdenCompra(ordenSeleccionada);

                    MessageBox.Show(mensaje, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarGrilla();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una orden de compra para cerrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    ActualizarGrilla();
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
            filtroActual = cmbEstado.SelectedItem.ToString();
            FiltrarGrilla();
        }


        private void FiltrarGrilla()
        {
            IEnumerable<OrdenCompra> ordenesFiltradas;

            switch (filtroActual)
            {
                case "Pendientes":
                    ordenesFiltradas = _todasLasOrdenes.Where(o => o.Estado == "Pendiente");
                    break;
                case "Completadas":
                    ordenesFiltradas = _todasLasOrdenes.Where(o => o.Estado == "Completada");
                    break;
                case "Canceladas":
                    ordenesFiltradas = _todasLasOrdenes.Where(o => o.Estado == "Cancelada");
                    break;
                case "Parcialmente Completadas":
                    ordenesFiltradas = _todasLasOrdenes.Where(o => o.Estado == "Parcialmente Completada");
                    break;
                case "Cerradas Con Faltante":
                    ordenesFiltradas = _todasLasOrdenes.Where(o => o.Estado == "Cerrada Con Faltante");
                    break;
                default:
                    ordenesFiltradas = _todasLasOrdenes;
                    break;
            }

            // Asignar las órdenes filtradas a la grilla
            dgvOrdenesCompra.DataSource = null;
            dgvOrdenesCompra.DataSource = ordenesFiltradas.ToList();
        }


        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
