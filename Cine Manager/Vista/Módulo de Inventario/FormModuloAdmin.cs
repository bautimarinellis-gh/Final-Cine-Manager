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
    public partial class FormModuloAdmin : Form
    {
        public FormModuloAdmin()
        {
            InitializeComponent();
        }



        private void btnPeliculas_Click(object sender, EventArgs e)
        {
            var formPeliculas = new FormGestorPeliculas();
            formPeliculas.Show();
            this.Hide();
        }



        private void btnClientes_Click(object sender, EventArgs e)
        {
            var formClientes = new FormClientes();
            formClientes.Show();
            this.Hide();
        }



        private void btnPedidos_Click(object sender, EventArgs e)
        {
            var formPedidos = new FormGestorPedidos();
            formPedidos.Show();
            this.Hide();
        }



        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            var formInicio = new FormInicio();
            formInicio.Show();
        }
    }
}
