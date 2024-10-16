using Controladora.Seguridad;
using Modelo.Módulo_de_Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Vista.Módulo_de_Seguridad
{
    public partial class FormIniciarSesion : Form
    {
        public FormIniciarSesion()
        {
            InitializeComponent();
        }



        #region Eventos
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



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion



        #region Métodos de validación
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
        #endregion




        #region Métodos de manejo de sesiones y permisos
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
            var accionesPersonalizadas = sesion.SesionPerfil
                .Where(a => a.Id == 34)
                .ToList();

            var accionesGruposActivos = sesion.UsuarioSesion.Componentes.OfType<Grupo>()
                .Where(grupo => grupo.EstadoGrupo.EstadoGrupoId == 1)
                .SelectMany(grupo => grupo.Componentes.OfType<Accion>())
                .ToList();

            bool usuarioEnGrupoInactivo = sesion.UsuarioSesion.Componentes.OfType<Grupo>()
                .Any(grupo => grupo.EstadoGrupo.EstadoGrupoId == 2);

            if (usuarioEnGrupoInactivo)
            {
                if (accionesGruposActivos.Any())
                {
                    sesion.SesionPerfil = accionesGruposActivos.Concat(accionesPersonalizadas).ToList();
                }
                else if (accionesPersonalizadas.Any())
                {
                    sesion.SesionPerfil = accionesPersonalizadas;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                sesion.SesionPerfil = accionesGruposActivos.Concat(accionesPersonalizadas).ToList();
            }

            return sesion.SesionPerfil.Any();
        }
        #endregion



        #region Métodos auxiliares
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

        private void MostrarFormularioPrincipal(Sesion sesion)
        {
            var formCineManager = new FormCineManager(sesion);
            formCineManager.Show();
            this.Hide();
        }
        #endregion
    }
}
