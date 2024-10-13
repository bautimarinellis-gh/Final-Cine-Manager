using Controladora;
using Microsoft.EntityFrameworkCore;
using Modelo.EFCore;
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

namespace Vista
{
    public partial class FormPelicula : Form
    {

        private Pelicula pelicula;
        private bool modificar = false;


        //Constructor Agregar
        public FormPelicula()
        {
            InitializeComponent();

            dgvActoresDisponibles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvActoresAsignados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.pelicula = new Pelicula();
            LlenarComboBox();
            ActualizarGrilla();
        }




        //Constructor Modificar
        public FormPelicula(Pelicula peliculaSeleccionada)
        {
            InitializeComponent();
            this.pelicula = ControladoraGestionarPeliculas.Instancia.CargarPeliculaConRelaciones(peliculaSeleccionada.Codigo);

            LlenarComboBox();
            CargarDatosPelicula();
            txtCodigo.Enabled = false;
            modificar = true;

            ActualizarGrilla();

        }





        private void ActualizarGrilla()
        {

            dgvActoresDisponibles.DataSource = null;
            dgvActoresDisponibles.DataSource = ControladoraGestionarActores.Instancia.RecuperarActores();

            dgvActoresAsignados.DataSource = null;
            dgvActoresAsignados.DataSource = pelicula.Reparto.ToList();
        }



        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                var directorSeleccionado = (Director)cmbDirector.SelectedItem;
                var generoSeleccionado = (GeneroCinematografico)cmbGenero.SelectedItem;

                pelicula.Director = directorSeleccionado;
                pelicula.GeneroCinematografico = generoSeleccionado;
                pelicula.Codigo = txtCodigo.Text;
                pelicula.Nombre = txtNombre.Text;
                /*pelicula.Cantidad = (int)numCantidad.Value;*/
                pelicula.Precio = (int)numPrecio.Value;

                string mensaje;
                if (modificar)
                {
                    mensaje = ControladoraGestionarPeliculas.Instancia.ModificarPelicula(pelicula);
                }
                else
                {
                    mensaje = ControladoraGestionarPeliculas.Instancia.AgregarPelicula(pelicula);
                }

                MessageBox.Show(mensaje, "Información Peliculas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }




        private void btnAsignarActor_Click(object sender, EventArgs e)
        {
            if (dgvActoresDisponibles.CurrentRow != null)
            {
                var actorAsignado = (Actor)dgvActoresDisponibles.CurrentRow.DataBoundItem;

                bool actorYaExiste = pelicula.Reparto.Any(p => p.Codigo == actorAsignado.Codigo);

                if (!actorYaExiste)
                {
                    pelicula.Reparto.Add(actorAsignado);
                    ActualizarGrilla();
                    MessageBox.Show("Actor asignado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El actor ya se encuentra asignado a la película.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un actor disponible para asignar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }




        private void btnEliminarActor_Click(object sender, EventArgs e)
        {
            if (dgvActoresAsignados.Rows.Count > 0)
            {
                var actorEliminado = (Actor)dgvActoresAsignados.CurrentRow.DataBoundItem;

                // Verificar si el proveedor a eliminar está en la lista de proveedores de la película
                if (pelicula.Reparto.Contains(actorEliminado))
                {
                    pelicula.Reparto.Remove(actorEliminado);
                    ActualizarGrilla();
                    MessageBox.Show("Actor elimnado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("El actor seleccionado no está asociado a la película.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un actor.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }




        private bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(this.txtCodigo.Text))
            {
                MessageBox.Show("Debe ingresar el código", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(this.txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (this.numPrecio.Value <= 0)
            {
                MessageBox.Show("El precio debe ser mayor que cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (this.cmbDirector.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un director", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (this.cmbGenero.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un género", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            // Validar que la película tenga al menos un proveedor
            if (this.dgvActoresAsignados == null || this.dgvActoresAsignados.Rows.Count == 0)
            {
                MessageBox.Show("Debe asignar al menos un actor a la película", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }




        private void CargarDatosPelicula()
        {
            txtCodigo.Text = pelicula.Codigo;
            txtNombre.Text = pelicula.Nombre;
            numPrecio.Value = pelicula.Precio;
            cmbDirector.SelectedItem = pelicula.Director;
            cmbGenero.SelectedItem = pelicula.GeneroCinematografico;

            // Cargar los actores asignados a la película
            dgvActoresAsignados.DataSource = pelicula.Reparto.ToList();
        }




        private void LlenarComboBox()
        {
            cmbDirector.DataSource = ControladoraGestionarDirectores.Instancia.RecuperarDirectores();
            cmbDirector.DisplayMember = "Codigo";

            cmbGenero.DataSource = ControladoraGestionarGenerosCinematograficos.Instancia.RecuperarGenerosCinematograficos();
            cmbGenero.DisplayMember = "Nombre";
        }




        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
