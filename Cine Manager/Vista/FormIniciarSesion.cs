using Controladora.Seguridad;
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
using System.Security.Cryptography;

namespace Vista.Módulo_de_Seguridad
{
    public partial class FormIniciarSesion : Form
    {
        public FormIniciarSesion()
        {
            InitializeComponent();
        }



        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                LimpiarCampos();
                return;
            }

            Usuario usuario = ControladoraIniciarSesion.Instancia.Buscar(txtUsuario.Text);

            // Verificar si el usuario está inactivo
            if (usuario.EstadoUsuario.EstadoUsuarioId != 1) 
            {
                MessageBox.Show("No puede ingresar porque su cuenta está inactiva.");
                LimpiarCampos();
                return;
            }

            // Crear la sesión y asignar las acciones del usuario
            Sesion sesion = new Sesion
            {
                UsuarioSesion = usuario,
                SesionPerfil = usuario.Componentes.OfType<Accion>().ToList() // Asignar las acciones del usuario
            };

            // Verificar si el usuario tiene un grupo inactivo
            bool usuarioEnGrupoInactivo = usuario.Componentes.OfType<Grupo>()
                .Any(grupo => grupo.EstadoGrupo.EstadoGrupoId == 2);

            if (usuarioEnGrupoInactivo)
            {
                // Limitar los formularios a las acciones personalizadas del usuario
                var accionesPersonalizadas = sesion.SesionPerfil
                    .Where(a => a.Id == 3 || a.Id == 6)
                    .ToList();

                sesion.SesionPerfil = accionesPersonalizadas;

                if (!accionesPersonalizadas.Any())
                {
                    MessageBox.Show("No tiene permisos para acceder al sistema.");
                    LimpiarCampos();
                    return;
                }
            }

            // Configurar y mostrar el formulario principal pasando la sesión
            var formCineManager = new FormCineManager(sesion);
            formCineManager.Show();
            this.Hide();

        }



        private void linkContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LimpiarCampos();
            var formRecuperarClave = new FormRecuperarClave();
            formRecuperarClave.ShowDialog();
        }



        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Campos obligatorios incompletos");
                return false;
            }

            Usuario usuario = ControladoraIniciarSesion.Instancia.Buscar(txtUsuario.Text);

            if (usuario == null)
            {
                MessageBox.Show("Usuario inexistente");
                return false;
            }

            string claveEncriptadaIngresada = EncriptarClave(txtClave.Text);
            if (usuario.Clave != claveEncriptadaIngresada)
            {
                MessageBox.Show("Clave incorrecta");
                return false;
            }

            // Verificar si el usuario pertenece a un grupo inactivo
            bool usuarioEnGrupoInactivo = usuario.Componentes.OfType<Grupo>()
                .Any(grupo => grupo.EstadoGrupo.EstadoGrupoId == 2);

            // Verificar si el usuario tiene acciones personalizadas que no forman parte de un grupo
            bool tieneAccionesPersonalizadas = usuario.Componentes.OfType<Accion>()
                .Any(acc => acc.Id == 3 || acc.Id == 6);

            // Validar acceso basado en las condiciones
            if (usuarioEnGrupoInactivo && !tieneAccionesPersonalizadas)
            {
                MessageBox.Show("El usuario pertenece a un grupo inactivo y no tiene acciones personalizadas.");
                LimpiarCampos();
                return false;
            }

            return true;


        }



        private string EncriptarClave(string clave)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(clave));
                var sb = new StringBuilder();

                foreach (var b in bytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }


        private void LimpiarCampos()
        {
            txtUsuario.Text = "";
            txtClave.Text = "";
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
