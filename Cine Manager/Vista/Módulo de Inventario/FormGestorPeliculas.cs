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
using Vista.Módulo_de_Administración;

namespace Vista
{
    public partial class FormGestorPeliculas : Form
    {
        public FormGestorPeliculas()
        {
            InitializeComponent();
            dgvPeliculas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            ActualizarGrilla();
        }




        private void ActualizarGrilla()
        {
            dgvPeliculas.DataSource = null;
            dgvPeliculas.DataSource = ControladoraGestionarPeliculas.Instancia.RecuperarPeliculas();
        }




        private void directoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formDirectores = new FormDirectores();
            formDirectores.ShowDialog();
        }




        private void generosCinematograficosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formGenerosCinematograficos = new FormGenerosCinematograficos();
            formGenerosCinematograficos.ShowDialog();
        }




        private void actoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formActores = new FormActores();
            formActores.ShowDialog();
        }




        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formProveedores = new FormProveedores();
            formProveedores.ShowDialog();
        }




        //Abre Formulario "FormPelicula" constructor para agregar
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var formPelicula = new FormPelicula();
            formPelicula.ShowDialog();
            ActualizarGrilla();
        }



        //Abre Formulario "FormPelicula" constructor para Modificar
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvPeliculas.CurrentRow != null)
            {
                var peliculaSeleccionada = (Pelicula)dgvPeliculas.CurrentRow.DataBoundItem;
                var formModificar = new FormPelicula(peliculaSeleccionada);
                formModificar.ShowDialog();
                ActualizarGrilla();
            }
            else
            {
                MessageBox.Show("No tienes ninguna pelicula seleccionada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }




        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPeliculas.SelectedRows.Count > 0)
            {
                var peliculaSeleccionada = dgvPeliculas.SelectedRows[0].DataBoundItem as Pelicula;

                DialogResult respuesta = MessageBox.Show("¿Estas seguro que quieres eliminar la pelicula:  " + peliculaSeleccionada.Nombre + " ?", "Eliminar Pelicula", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    var mensaje = ControladoraGestionarPeliculas.Instancia.EliminarPelicula(peliculaSeleccionada);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarGrilla();
                }

            }
            else
            {
                MessageBox.Show("No tienes ninguna pelicula seleccionada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }




        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string textoBusqueda = txtBuscar.Text.Trim();
            dgvPeliculas.DataSource = ControladoraGestionarPeliculas.Instancia.FiltrarPeliculas(textoBusqueda);
        }




        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            var formAdmin = new FormModuloAdmin();
            formAdmin.Show();
        }
    }
}
