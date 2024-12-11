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

namespace Vista.Módulo_de_Ventas
{
    public partial class FormAsignarCliente : Form
    {
        public FormAsignarCliente()
        {
            InitializeComponent();
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            ActualizarGrilla();
        }


        private void ActualizarGrilla()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = ControladoraGestionarClientes.Instancia.RecuperarClientes();
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string textoBusqueda = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(textoBusqueda))
            {
                dgvClientes.DataSource = ControladoraGestionarClientes.Instancia.FiltrarClientes(null);
            }
            else if (int.TryParse(textoBusqueda, out int dniBusqueda))
            {
                dgvClientes.DataSource = ControladoraGestionarClientes.Instancia.FiltrarClientes(dniBusqueda);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un DNI válido (solo números).", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnAsginar_Click(object sender, EventArgs e)
        {
            // Validar que se haya seleccionado un cliente
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener el cliente seleccionado (suponiendo que tienes una clase Cliente enlazada)
            var clienteSeleccionado = dgvClientes.SelectedRows[0].DataBoundItem as Cliente;


            // Enviar un mensaje indicando el cliente asignado
            MessageBox.Show($"Cliente {clienteSeleccionado.Nombre} {clienteSeleccionado.Apellido} asignado al pedido.",
                            "Cliente Asignado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Establecer el cliente como resultado del formulario
            this.Tag = clienteSeleccionado; // Pasamos el cliente seleccionado al formulario principal
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    



        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
