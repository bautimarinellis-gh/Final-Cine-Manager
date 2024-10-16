using Controladora;
using Controladora.Seguridad;
using Modelo.Entidades;
using Modelo.Módulo_de_Seguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista.Módulo_de_Seguridad
{
    public partial class FormGestionarGrupos : Form
    {
        private Sesion _sesion;

        public FormGestionarGrupos(Sesion sesion)
        {
            InitializeComponent();
            _sesion = sesion;

            dgvGrupos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cmbEstado.SelectedIndex = 0;

            ActualizarGrilla();
        }



        #region Métodos
        private void ActualizarGrilla()
        {
            dgvGrupos.DataSource = null;
            dgvGrupos.DataSource = ControladoraGestionarGrupos.Instancia.RecuperarGrupos();
            Refresh();
        }

        #endregion

        #region Eventos de Botones
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var formAgregarGrupo = new FormAgregarGrupo();
            formAgregarGrupo.ShowDialog();
            ActualizarGrilla();
        }




        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvGrupos.SelectedRows.Count > 0)
            {
                var grupoSeleccionado = dgvGrupos.SelectedRows[0].DataBoundItem as Grupo;

                DialogResult respuesta = MessageBox.Show(
                    "¿Estás seguro que quieres eliminar el grupo: " + grupoSeleccionado.Codigo + " ?",
                    "Eliminar Grupo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    var mensaje = ControladoraGestionarGrupos.Instancia.EliminarGrupo(grupoSeleccionado);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarGrilla();
                }
            }
            else
            {
                MessageBox.Show("No tienes ningún grupo seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvGrupos.CurrentRow != null)
            {
                var grupoSeleccionado = (Grupo)dgvGrupos.CurrentRow.DataBoundItem;
                var formModificar = new FormAgregarGrupo(grupoSeleccionado);
                formModificar.ShowDialog();
                ActualizarGrilla();
            }
            else
            {
                MessageBox.Show("No tienes ningún grupo seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtroNombre = txtNombre.Text.Trim();
            bool? filtroEstado = null;

            if (cmbEstado.SelectedItem != null)
            {
                string estadoSeleccionado = cmbEstado.SelectedItem.ToString();
                filtroEstado = estadoSeleccionado == "Activo";
            }

            var listaGrupos = new List<Grupo>(ControladoraGestionarGrupos.Instancia.RecuperarGrupos());

            if (!string.IsNullOrEmpty(filtroNombre))
            {
                listaGrupos = listaGrupos.Where(g => g.Nombre.Contains(filtroNombre, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Filtrar por estado
            if (filtroEstado.HasValue)
            {
                listaGrupos = listaGrupos.Where(g => g.EstadoGrupo.EstadoGrupoNombre == "Activo" == filtroEstado.Value).ToList();
            }

            dgvGrupos.DataSource = null;
            dgvGrupos.DataSource = listaGrupos;
        }



        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}


