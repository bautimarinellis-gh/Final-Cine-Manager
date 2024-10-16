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
        private Sesion _sesion;

        public FormGestionarUsuarios(Sesion sesion)
        {
            InitializeComponent();
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _sesion = sesion;
            ActualizarGrilla();
            cmbEstado.SelectedIndex = 0;
            LlenarComboBox();
        }

        #region Métodos de Actualización
        private void ActualizarGrilla()
        {
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = ControladoraGestionarUsuarios.Instancia.RecuperarUsuarios();
            Refresh();
        }
        #endregion



        #region Eventos de Botones
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
                DialogResult respuesta = MessageBox.Show("¿Estás seguro que quieres eliminar el usuario: " + usuarioSeleccionado.NombreUsuario + " ?", "Eliminar usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    var mensaje = ControladoraGestionarUsuarios.Instancia.EliminarUsuario(usuarioSeleccionado);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarGrilla();
                }
            }
            else
            {
                MessageBox.Show("No tienes ningún usuario seleccionado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (dgvUsuarios.CurrentRow != null)
            {
                var usuarioSeleccionado = dgvUsuarios.SelectedRows[0].DataBoundItem as Usuario;
                var resultado = MessageBox.Show($"¿Estás seguro de que quieres resetear la clave del usuario '{usuarioSeleccionado.NombreUsuario}'?", "Confirmar Reseteo de Clave", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtroNombreUsuario = txtNombre.Text.Trim();
            Grupo filtroGrupo = cmbGrupo.SelectedItem as Grupo;
            bool? filtroEstado = null;

            if (cmbEstado.SelectedItem != null)
            {
                string estadoSeleccionado = cmbEstado.SelectedItem.ToString();
                filtroEstado = estadoSeleccionado == "Activo" ? true : (estadoSeleccionado == "Inactivo" ? false : (bool?)null);
            }

            var listaUsuarios = new List<Usuario>(ControladoraGestionarUsuarios.Instancia.RecuperarUsuarios());

            // Filtrar por nombre de usuario
            if (!string.IsNullOrEmpty(filtroNombreUsuario))
            {
                listaUsuarios = listaUsuarios.Where(u => u.Nombre.Contains(filtroNombreUsuario, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Filtrar por grupo
            if (filtroGrupo != null)
            {
                listaUsuarios = listaUsuarios.Where(u => u.Componentes != null && u.Componentes.OfType<Grupo>().Any(g => g.Codigo == filtroGrupo.Codigo)).ToList();
            }

            // Filtrar por estado
            if (filtroEstado.HasValue)
            {
                listaUsuarios = listaUsuarios.Where(u => u.EstadoUsuario.EstadoUsuarioNombre == "Activo" == filtroEstado.Value).ToList();
            }

            // Actualizar el DataGridView
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = listaUsuarios;
        }



        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion



        #region Métodos de Reseteo de Clave
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
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(clave));
                var claveEncriptada = new StringBuilder();

                foreach (var b in bytes)
                {
                    claveEncriptada.Append(b.ToString("x2"));
                }

                return claveEncriptada.ToString();
            }
        }



        private static bool EnviarClavePorEmail(string destinatario, string clave)
        {
            try
            {
                var mensaje = new MailMessage
                {
                    From = new MailAddress("tu_correo@gmail.com"),
                    Subject = "Tu nueva clave de acceso",
                    Body = $"Tu nueva clave de acceso es: {clave}",
                    IsBodyHtml = false
                };

                mensaje.To.Add(destinatario);

                using (var cliente = new SmtpClient("smtp.gmail.com"))
                {
                    cliente.Port = 587;
                    cliente.EnableSsl = true;
                    cliente.Credentials = new NetworkCredential("bautimarinelli100@gmail.com", "ldzm yahi hvac osiu");
                    cliente.Timeout = 10000;

                    cliente.Send(mensaje);
                }

                return true;
            }
            catch (SmtpException ex)
            {
                MessageBox.Show($"Error al enviar el email:\n{ex.Message}\nVerifica tus credenciales de Gmail, la configuración del servidor SMTP o si has habilitado el acceso para aplicaciones menos seguras.");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado al enviar el email:\n{ex.Message}");
                return false;
            }
        }
        #endregion



        #region Métodos de Inicialización
        private void LlenarComboBox()
        {
            cmbGrupo.DataSource = ControladoraGestionarGrupos.Instancia.RecuperarGrupos();
            cmbGrupo.DisplayMember = "Nombre";
        }
        #endregion
    }
}
