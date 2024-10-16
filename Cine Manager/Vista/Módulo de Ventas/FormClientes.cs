using Controladora;
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

namespace Vista.Módulo_de_Administración
{
    public partial class FormClientes : Form
    {
        private Sesion _sesion;

        
        public FormClientes(Sesion sesion)
        {
            InitializeComponent();
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _sesion = sesion;
            ActualizarGrilla();
        }


        #region Métodos de Actualización de Datos

        
        private void ActualizarGrilla()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = ControladoraGestionarClientes.Instancia.RecuperarClientes();
        }

        #endregion

        #region Botones de Gestión de Clientes

        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                var cliente = new Cliente
                {
                    DNI = (int)numDNI.Value,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                };

                var mensaje = ControladoraGestionarClientes.Instancia.AgregarCliente(cliente);
                ActualizarGrilla();
                LimpiarDetalles();
                MessageBox.Show(mensaje, "Información Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                var clienteSeleccionado = dgvClientes.SelectedRows[0].DataBoundItem as Cliente;

                DialogResult respuesta = MessageBox.Show("¿Estás seguro que quieres eliminar el cliente: " + clienteSeleccionado.DNI + " ?", "Eliminar Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    var mensaje = ControladoraGestionarClientes.Instancia.EliminarCliente(clienteSeleccionado);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarGrilla();
                }
            }
            else
            {
                MessageBox.Show("No tienes ningún cliente seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                var clienteSeleccionado = dgvClientes.SelectedRows[0].DataBoundItem as Cliente;

                if (!ValidarDatosModificar(clienteSeleccionado))
                {
                    return;
                }

                DialogResult respuesta = MessageBox.Show($"¿Estás seguro que quieres modificar el cliente: {clienteSeleccionado.Nombre} {clienteSeleccionado.Apellido}?", "Modificar Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    clienteSeleccionado.Nombre = txtNombre.Text;
                    clienteSeleccionado.Apellido = txtApellido.Text;
                    clienteSeleccionado.DNI = (int)numDNI.Value;

                    var mensaje = ControladoraGestionarClientes.Instancia.ModificarCliente(clienteSeleccionado);

                    ActualizarGrilla();
                    LimpiarDetalles();
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                MessageBox.Show("No tienes ningún cliente seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        #endregion



        #region Métodos de Validación

        
        private bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(this.txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(this.txtApellido.Text))
            {
                MessageBox.Show("Debe ingresar el apellido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (this.numDNI.Value <= 0)
            {
                MessageBox.Show("El DNI debe ser mayor que cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }


        private bool ValidarDatosModificar(Cliente clienteSeleccionado)
        {
            if (string.IsNullOrEmpty(this.txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(this.txtApellido.Text))
            {
                MessageBox.Show("Debe ingresar el apellido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (this.numDNI.Value <= 0)
            {
                MessageBox.Show("El DNI debe ser mayor que cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (this.txtNombre.Text.Any(char.IsDigit))
            {
                MessageBox.Show("El nombre no puede contener números", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (this.txtApellido.Text.Any(char.IsDigit))
            {
                MessageBox.Show("El apellido no puede contener números", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var clienteConMismoDNI = ControladoraGestionarClientes.Instancia.Buscar((int)numDNI.Value);
            if (clienteConMismoDNI != null && clienteConMismoDNI.ClienteId != clienteSeleccionado.ClienteId)
            {
                MessageBox.Show("El DNI ya está en uso por otro cliente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        #endregion


        #region Métodos de Interfaz

       
        private void LimpiarDetalles()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            numDNI.Value = 0;
        }

        
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
