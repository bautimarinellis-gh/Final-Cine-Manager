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

namespace Vista.Módulo_de_Compras
{
    public partial class FormAsignarProveedor : Form
    {
        public FormAsignarProveedor()
        {
            InitializeComponent();
            dgvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            ActualizarGrilla();
        }


        private void ActualizarGrilla()
        {
            dgvProveedores.DataSource = null;
            dgvProveedores.DataSource = ControladoraGestionarProveedores.Instancia.RecuperarProveedores();
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string textoBusqueda = txtBuscar.Text.Trim();
            dgvProveedores.DataSource = ControladoraGestionarProveedores.Instancia.FiltrarProveedores(textoBusqueda);
        }



        private void btnAsginar_Click(object sender, EventArgs e)
        {
            // Validar que se haya seleccionado un cliente
            if (dgvProveedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un prroveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var proveedorSeleccionado = dgvProveedores.SelectedRows[0].DataBoundItem as Proveedor;


            MessageBox.Show($"Proveedor {proveedorSeleccionado.RazonSocial} asignado a la orden de compra.",
                            "Proveedor Asignado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Tag = proveedorSeleccionado;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }



        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
