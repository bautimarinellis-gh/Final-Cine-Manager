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

            if (UsuarioInactivo(usuario))
            {
                MessageBox.Show("No puede ingresar porque su cuenta está inactiva.");
                LimpiarCampos();
                return;
            }

            Sesion sesion = CrearSesion(usuario);

            if (!VerificarPermisos(sesion))
            {
                MessageBox.Show("No tiene permisos para acceder al sistema.");
                LimpiarCampos();
                return;
            }

            MostrarFormularioPrincipal(sesion);

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
                MessageBox.Show("Campos obligatorios incompletos.");
                return false;
            }

            Usuario usuario = ControladoraIniciarSesion.Instancia.Buscar(txtUsuario.Text);
            if (usuario == null)
            {
                MessageBox.Show("Usuario inexistente.");
                return false;
            }

            if (!ClaveCorrecta(usuario))
            {
                MessageBox.Show("Clave incorrecta.");
                return false;
            }

            if (PerteneceAGrupoInactivoSinPermisos(usuario))
            {
                MessageBox.Show("El usuario pertenece a un grupo inactivo y no tiene acciones personalizadas.");
                return false;
            }

            return true;
        }



        private bool ClaveCorrecta(Usuario usuario)
        {
            string claveEncriptadaIngresada = EncriptarClave(txtClave.Text);
            return usuario.Clave == claveEncriptadaIngresada;
        }



        private bool UsuarioInactivo(Usuario usuario)
        {
            return usuario.EstadoUsuario.EstadoUsuarioId != 1;
        }



        private bool PerteneceAGrupoInactivoSinPermisos(Usuario usuario)
        {
            bool usuarioEnGrupoInactivo = usuario.Componentes.OfType<Grupo>()
                .Any(grupo => grupo.EstadoGrupo.EstadoGrupoId == 2);

            bool tieneAccionesPersonalizadas = usuario.Componentes.OfType<Accion>()
                .Any(acc => acc.Id == 34);

            return usuarioEnGrupoInactivo && !tieneAccionesPersonalizadas;
        }



        private Sesion CrearSesion(Usuario usuario)
        {
            return new Sesion
            {
                UsuarioSesion = usuario,
                SesionPerfil = usuario.Componentes.OfType<Accion>().ToList()
            };
        }



        private bool VerificarPermisos(Sesion sesion)
        {
            bool usuarioEnGrupoInactivo = sesion.UsuarioSesion.Componentes.OfType<Grupo>()
                .Any(grupo => grupo.EstadoGrupo.EstadoGrupoId == 2);

            if (usuarioEnGrupoInactivo)
            {
                var accionesPersonalizadas = sesion.SesionPerfil
                    .Where(a => a.Id == 34)
                    .ToList();

                sesion.SesionPerfil = accionesPersonalizadas;
                return accionesPersonalizadas.Any();
            }

            return true;
        }



        private void MostrarFormularioPrincipal(Sesion sesion)
        {
            var formCineManager = new FormCineManager(sesion);
            formCineManager.Show();
            this.Hide();
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
