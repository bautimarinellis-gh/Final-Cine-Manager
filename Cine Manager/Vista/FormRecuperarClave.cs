using Controladora;
using Controladora.Seguridad;
using System;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Vista.Módulo_de_Seguridad
{
    public partial class FormRecuperarClave : Form
    {
        public FormRecuperarClave()
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

            var usuarioValido = ControladoraIniciarSesion.Instancia.Buscar(txtUsuario.Text);

            // Generar una nueva clave aleatoria
            var nuevaClave = GenerarClaveAleatoria();

            // Encriptar la nueva clave
            usuarioValido.Clave = EncriptarClave(nuevaClave);

            // Actualizar la clave en la base de datos
            ControladoraGestionarUsuarios.Instancia.ActualizarClaveUsuario(usuarioValido);

            // Enviar la nueva clave al email del usuario
            if (!EnviarClavePorEmail(usuarioValido.Email, nuevaClave))
            {
                MessageBox.Show("No se pudo enviar la nueva clave al email proporcionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("La nueva clave ha sido enviada a su email registrado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Métodos de Validación

        private bool ValidarDatos()
        {
            // Verificar que los campos obligatorios estén completos
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var usuarioValido = ControladoraIniciarSesion.Instancia.Buscar(txtUsuario.Text);

            // Verificar que el usuario exista, esté activo y el email coincida
            if (usuarioValido == null)
            {
                MessageBox.Show("Usuario inválido.", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (usuarioValido.Email != txtEmail.Text)
            {
                MessageBox.Show("Email inválido.", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (usuarioValido.EstadoUsuario.EstadoUsuarioId == 2)
            {
                MessageBox.Show("El usuario no está activo.", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            txtUsuario.Text = "";
            txtEmail.Text = "";
        }

        #endregion

        #region Métodos de Generación y Encriptación de Clave

        private string GenerarClaveAleatoria(int longitud = 8)
        {
            const string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            using (var rng = new RNGCryptoServiceProvider())
            {
                var clave = new char[longitud];
                var bytesAleatorios = new byte[longitud];
                rng.GetBytes(bytesAleatorios);

                for (int i = 0; i < longitud; i++)
                {
                    clave[i] = caracteres[bytesAleatorios[i] % caracteres.Length];
                }

                return new string(clave);
            }
        }

        private string EncriptarClave(string clave)
        {
            // Crear una instancia del algoritmo SHA-256
            using (var sha256 = SHA256.Create())
            {
                // Convertir la cadena de texto 'clave' en un arreglo de bytes y calcular el hash
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(clave));

                // Crear un StringBuilder para construir la cadena encriptada en formato hexadecimal
                var claveEncriptada = new StringBuilder();

                // Recorrer cada byte en el arreglo 'bytes'
                foreach (var b in bytes)
                {
                    // Convertir cada byte a su representación en hexadecimal y agregarlo al StringBuilder
                    claveEncriptada.Append(b.ToString("x2"));
                }

                // Retornar la cadena encriptada (el hash en formato hexadecimal)
                return claveEncriptada.ToString();
            }
        }

        #endregion

        #region Métodos para Envío de Email

        private static bool EnviarClavePorEmail(string destinatario, string clave)
        {
            try
            {
                // Crear un nuevo mensaje de correo
                var mensaje = new MailMessage
                {
                    From = new MailAddress("tu_correo@gmail.com"), // Dirección de correo del remitente
                    Subject = "Tu nueva clave de acceso", // Asunto del correo
                    Body = $"Tu nueva clave de acceso es: {clave}", // Cuerpo del correo, incluyendo la clave generada
                    IsBodyHtml = false // Indica que el cuerpo del correo no es HTML
                };

                // Añadir el destinatario al mensaje
                mensaje.To.Add(destinatario); // Dirección de correo del destinatario (usuario al que se le envía la clave)

                // Configurar el cliente SMTP para enviar el correo
                using (var cliente = new SmtpClient("smtp.gmail.com"))
                {
                    cliente.Port = 587; // Puerto para TLS (Transport Layer Security)
                    cliente.EnableSsl = true; // Habilitar SSL (Secure Sockets Layer) para una conexión segura
                    cliente.Credentials = new NetworkCredential("bautimarinelli100@gmail.com", "ldzm yahi hvac osiu"); // Credenciales del remitente (correo y contraseña de aplicación)
                    cliente.Timeout = 10000; // Tiempo de espera máximo para el envío del correo en milisegundos (10 segundos)

                    // Enviar el correo electrónico
                    cliente.Send(mensaje);
                }

                // Si el envío fue exitoso, retornar true
                return true;
            }
            catch (SmtpException ex)
            {
                // Captura de excepciones específicas de SMTP (errores relacionados con el envío de correo)
                MessageBox.Show($"Error al enviar el email:\n{ex.Message}\n" +
                                "Verifica tus credenciales de Gmail, la configuración del servidor SMTP o si has habilitado el acceso para aplicaciones menos seguras.");
                return false; // Retornar false si ocurre un error durante el envío del correo
            }
            catch (Exception ex)
            {
                // Captura de cualquier otra excepción no relacionada con SMTP
                MessageBox.Show($"Error inesperado al enviar el email:\n{ex.Message}");
                return false; // Retornar false en caso de otro tipo de error
            }
        }

        #endregion
    }
}
