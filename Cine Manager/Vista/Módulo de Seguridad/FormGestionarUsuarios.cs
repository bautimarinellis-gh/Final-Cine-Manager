using Controladora;
using Controladora.Seguridad;
using Modelo.Módulo_de_Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Vista.Módulo_de_Seguridad
{
    public partial class FormGestionarUsuarios : Form
    {
        public FormGestionarUsuarios()
        {
            InitializeComponent();
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            ActualizarGrilla();
        }



        private void ActualizarGrilla()
        {
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = ControladoraGestionarUsuarios.Instancia.RecuperarUsuarios();

            Refresh();
        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var formAgregarUsuario = new FormAgregarUsuario();
            formAgregarUsuario.ShowDialog();

            ActualizarGrilla();
        }



        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                var usuarioSeleccionado = dgvUsuarios.SelectedRows[0].DataBoundItem as Usuario;

                DialogResult respuesta = MessageBox.Show("¿Estas seguro que quieres eliminar el usuario: " + usuarioSeleccionado.NombreUsuario + " ?", "Eliminar usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    var mensaje = ControladoraGestionarUsuarios.Instancia.EliminarUsuario(usuarioSeleccionado);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarGrilla();
                }
            }
            else
            {
                MessageBox.Show("No tienes ningun usuario seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }



        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null)
            {
                var usuarioSeleccionado = (Usuario)dgvUsuarios.CurrentRow.DataBoundItem;
                var formModificar = new FormAgregarUsuario(usuarioSeleccionado);
                formModificar.ShowDialog();
                ActualizarGrilla();
            }
            else
            {
                MessageBox.Show("No tienes ningún usuario seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void btnResetear_Click(object sender, EventArgs e)
        {
            if(dgvUsuarios.CurrentRow != null)
            {
                // Obtener el usuario seleccionado
                var usuarioSeleccionado = dgvUsuarios.SelectedRows[0].DataBoundItem as Usuario;

                // Confirmación de reseteo
                var resultado = MessageBox.Show($"¿Estás seguro de que quieres resetear la clave del usuario '{usuarioSeleccionado.NombreUsuario}'?",
                                                "Confirmar Reseteo de Clave",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    ResetearClaveUsuario(usuarioSeleccionado);

                }
            }
            else
            {
                MessageBox.Show("No tienes ningún usuario seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }


        private void ResetearClaveUsuario(Usuario usuario)
        {
            var nuevaClave = GenerarClaveAleatoria();
            usuario.Clave = EncriptarClave(nuevaClave);

            ControladoraGestionarUsuarios.Instancia.ActualizarClaveUsuario(usuario);

            if (!EnviarClavePorEmail(usuario.Email, nuevaClave))
            {
                MessageBox.Show("No se pudo enviar la nueva clave al email proporcionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("La clave ha sido reseteada exitosamente y enviada al usuario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private string GenerarClaveAleatoria(int longitud = 8)
        {
            const string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var rng = new Random();
            var clave = new char[longitud];

            for (int i = 0; i < longitud; i++)
            {
                clave[i] = caracteres[rng.Next(caracteres.Length)];
            }

            return new string(clave);
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



        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            var formCineManager = new FormCineManager();
            formCineManager.Show();
        }

        
    }
}
