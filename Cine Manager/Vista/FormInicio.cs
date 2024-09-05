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
using Vista.Módulo_de_Transacciones;

namespace Vista
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }



        private void btnModuloAdmin_Click(object sender, EventArgs e)
        {
            var formModuloAdmin = new FormModuloAdmin();
            formModuloAdmin.Show();
            this.Hide();
        }




        private void btnModuloTransacc_Click(object sender, EventArgs e)
        {
            var formModuloTransacciones = new FormRealizarPedido();
            formModuloTransacciones.Show();
            this.Hide();
        }




        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
