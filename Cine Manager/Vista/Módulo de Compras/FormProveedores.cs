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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class FormProveedores : Form
    {

        private Sesion _sesion;



        public FormProveedores(Sesion sesion)
        {
            InitializeComponent();
            _sesion = sesion;
            dgvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ActualizarGrilla();
        }


        #region Métodos Privados

        private void ActualizarGrilla()
        {
            dgvProveedores.DataSource = null;
            dgvProveedores.DataSource = ControladoraGestionarProveedores.Instancia.RecuperarProveedores();
        }



        private void LimpiarDetalles()
        {
            txtCodigo.Text = "";
            numCUIT.Text = "";
            txtRazonSocial.Text = "";
        }



        private bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(this.txtCodigo.Text))
            {
                MessageBox.Show("Debe ingresar el código", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(this.txtRazonSocial.Text))
            {
                MessageBox.Show("Debe ingresar la razón social del proveedor", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string cuitString = this.numCUIT.Text;

            if (!Regex.IsMatch(cuitString, @"^\d{2}-\d{8}-\d$"))
            {
                MessageBox.Show("El CUIT ingresado no es válido. El formato correcto es: XX-XXXXXXXX-X (por ejemplo: 20-30123456-2)", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!Regex.IsMatch(cuitString.Replace("-", ""), @"^\d+$"))
            {
                MessageBox.Show("El CUIT debe contener solo números.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            long cuit = long.Parse(cuitString.Replace("-", ""));

            if (ControladoraGestionarProveedores.Instancia.ExisteProveedorConCUIT(cuit))
            {
                MessageBox.Show("Ya existe un proveedor con este CUIT.", "CUIT duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool ValidarDatosModificar(Proveedor proveedorSeleccionado)
        {
            if (string.IsNullOrEmpty(this.txtCodigo.Text))
            {
                MessageBox.Show("Debe ingresar el código", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(this.txtRazonSocial.Text))
            {
                MessageBox.Show("Debe ingresar la razón social del proveedor", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var proveedorConMismoCodigo = ControladoraGestionarProveedores.Instancia.Buscar(txtCodigo.Text);
            if (proveedorConMismoCodigo != null && proveedorConMismoCodigo.ProveedorId != proveedorSeleccionado.ProveedorId)
            {
                MessageBox.Show("El código ya está en uso por otro proveedor.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string cuitString = this.numCUIT.Text;

            if (!Regex.IsMatch(cuitString, @"^\d{2}-\d{8}-\d$"))
            {
                MessageBox.Show("El CUIT ingresado no es válido. El formato correcto es: XX-XXXXXXXX-X (por ejemplo: 20-30123456)", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!Regex.IsMatch(cuitString.Replace("-", ""), @"^\d+$"))
            {
                MessageBox.Show("El CUIT debe contener solo números.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            long cuit = long.Parse(cuitString.Replace("-", ""));

            if (ControladoraGestionarProveedores.Instancia.ExisteProveedorConCUIT(cuit))
            {
                MessageBox.Show("Ya existe un proveedor con este CUIT.", "CUIT duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        #endregion



        #region Eventos

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                var proveedor = new Proveedor
                {
                    Codigo = txtCodigo.Text,
                    Cuit = long.Parse(numCUIT.Text.Replace("-", "")),
                    RazonSocial = txtRazonSocial.Text,
                };

                var mensaje = ControladoraGestionarProveedores.Instancia.AgregarProveedor(proveedor);
                ActualizarGrilla();
                LimpiarDetalles();
                MessageBox.Show(mensaje, "Información Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                var proveedorSeleccionado = dgvProveedores.SelectedRows[0].DataBoundItem as Proveedor;

                DialogResult respuesta = MessageBox.Show("¿Estas seguro que quieres eliminar el proveedor: " + proveedorSeleccionado.Codigo + " ?", "Eliminar Proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    var mensaje = ControladoraGestionarProveedores.Instancia.EliminarProveedor(proveedorSeleccionado);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarGrilla();
                }

            }
            else
            {
                MessageBox.Show("No tienes ningun proveedor seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                var proveedorSeleccionado = dgvProveedores.SelectedRows[0].DataBoundItem as Proveedor;

                if (!ValidarDatosModificar(proveedorSeleccionado))
                {
                    return;
                }

                DialogResult respuesta = MessageBox.Show($"¿Estás seguro que quieres modificar el proveedor: {proveedorSeleccionado.Cuit} ?", "Modificar Proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    proveedorSeleccionado.Codigo = txtCodigo.Text;
                    proveedorSeleccionado.Cuit = long.Parse(numCUIT.Text.Replace("-", ""));
                    proveedorSeleccionado.RazonSocial = txtRazonSocial.Text;

                    var mensaje = ControladoraGestionarProveedores.Instancia.ModificarProveedor(proveedorSeleccionado);

                    ActualizarGrilla();
                    LimpiarDetalles();
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                MessageBox.Show("No tienes ningún proveedor seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string textoBusqueda = txtBuscar.Text.Trim();
            dgvProveedores.DataSource = ControladoraGestionarProveedores.Instancia.FiltrarProveedores(textoBusqueda);
        }



        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
