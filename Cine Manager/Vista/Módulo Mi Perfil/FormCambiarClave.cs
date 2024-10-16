using Controladora;
using Controladora.Seguridad;
using Modelo.Módulo_de_Seguridad;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Vista.Módulo_de_Seguridad
{
    public partial class FormCambiarClave : Form
    {
        private Sesion _sesion;


        public FormCambiarClave(Sesion sesion)
        {
            InitializeComponent();
            _sesion = sesion;
        }




        #region Manejadores de Eventos


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                LimpiarCampos();
                return;
            }

            var usuarioActual = _sesion.UsuarioSesion;

            // Encriptar la nueva clave
            var nuevaClaveEncriptada = EncriptarClave(txtClaveNueva.Text);

            // Actualizar la clave en la base de datos
            var mensaje = ControladoraCambiarClave.Instancia.CambiarClave(usuarioActual.UsuarioId, nuevaClaveEncriptada);

            MessageBox.Show(mensaje, "Cambiar Clave", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Si la clave fue cambiada exitosamente, cerrar el formulario
            if (mensaje == "La clave ha sido cambiada exitosamente.")
            {
                // Recargar al usuario en la sesión con la nueva clave
                _sesion.UsuarioSesion = ControladoraCambiarClave.Instancia.Buscar(usuarioActual.NombreUsuario);

                // Verificar que la sesión actualizada esté siendo utilizada correctamente
                MessageBox.Show($"Usuario actualizado: {_sesion.UsuarioSesion.NombreUsuario}");

                this.Close(); // Cierra el formulario de cambio de clave
            }
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion



        #region Métodos de Validación

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

        private bool ValidarDatos()
        {
            // Validar que los campos obligatorios estén completos
            if (string.IsNullOrWhiteSpace(txtClaveActual.Text) || string.IsNullOrWhiteSpace(txtClaveNueva.Text) || string.IsNullOrEmpty(txtConfirmar.Text))
            {
                MessageBox.Show("Campos obligatorios incompletos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar que las claves nuevas coincidan
            if (txtClaveNueva.Text != txtConfirmar.Text)
            {
                MessageBox.Show("Las claves nuevas ingresadas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar la clave actual
            var usuarioActual = _sesion.UsuarioSesion;
            var claveIngresadaEncriptada = EncriptarClave(txtClaveActual.Text);

            if (usuarioActual.Clave != claveIngresadaEncriptada)
            {
                MessageBox.Show("La clave actual es incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validar las restricciones de la nueva clave
            if (!ValidarClave(txtClaveNueva.Text))
            {
                return false;
            }

            return true;
        }

        private bool ValidarClave(string clave)
        {
            // Exigir como mínimo ocho caracteres
            if (clave.Length < 8)
            {
                MessageBox.Show("La clave debe tener al menos 8 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Exigir al menos una minúscula
            if (!clave.Any(char.IsLower))
            {
                MessageBox.Show("La clave debe incluir al menos una letra minúscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Exigir al menos una mayúscula
            if (!clave.Any(char.IsUpper))
            {
                MessageBox.Show("La clave debe incluir al menos una letra mayúscula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Exigir al menos un carácter numérico
            if (!clave.Any(char.IsDigit))
            {
                MessageBox.Show("La clave debe incluir al menos un número.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Exigir al menos un carácter especial
            if (!clave.Any(ch => "!@#$%^&*()_+-=[]{}|;:'\",.<>?/\\~`".Contains(ch)))
            {
                MessageBox.Show("La clave debe incluir al menos un carácter especial (*,#,$, etc.).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        #endregion

        #region Otros Métodos

        private void LimpiarCampos()
        {
            txtClaveActual.Text = "";
            txtClaveNueva.Text = "";
            txtConfirmar.Text = "";
        }

        #endregion

        
    }
}
