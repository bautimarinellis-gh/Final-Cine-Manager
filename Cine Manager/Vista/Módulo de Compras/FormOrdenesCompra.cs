using Controladora;
using Controladora.Negocio;
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

namespace Vista.Módulo_de_Compras
{
    public partial class FormOrdenesCompra : Form
    {
        private Sesion _sesion;

        public FormOrdenesCompra(Sesion sesion)
        {
            InitializeComponent();
            _sesion = sesion;

            dgvOrdenesCompra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ActualizarGrilla();
        }



        private void btnRealizarOrden_Click(object sender, EventArgs e)
        {
            var formRealizarOrden = new FormRealizarOrdenCompra(_sesion);
            formRealizarOrden.ShowDialog();

            ActualizarGrilla();
        }


        private void ActualizarGrilla()
        {
            dgvOrdenesCompra.DataSource = null;
            dgvOrdenesCompra.DataSource = ControladoraGestionarOrdenesCompra.Instancia.RecuperarOrdenesCompra();
        }




        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
