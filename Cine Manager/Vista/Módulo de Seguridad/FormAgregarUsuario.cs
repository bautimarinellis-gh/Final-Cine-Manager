using Controladora;
using Controladora.Seguridad;
using Modelo.Módulo_de_Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Vista.Módulo_de_Seguridad
{
    public partial class FormAgregarUsuario : Form
    {
        private Usuario usuario;
        private bool modificar;

        #region Constructores

        //Constructor Agregar
        public FormAgregarUsuario()
        {
            InitializeComponent();

            this.usuario = new Usuario();

            var estados = ControladoraGestionarUsuarios.Instancia.ObtenerEstadosUsuarios();

            // Configurar el ComboBox
            cmbEstado.DataSource = estados;
            cmbEstado.DisplayMember = "EstadoUsuarioNombre"; // Muestra el nombre del estado
            cmbEstado.ValueMember = "EstadoUsuarioId"; // Usa el ID del estado para la selección

            // Seleccionar el primer estado como predeterminado
            cmbEstado.SelectedIndex = 0;

            CargarGruposEnCheckedListBox();
        }

        //Constructor Modificar
        public FormAgregarUsuario(Usuario usuarioSeleccionado)
        {
            InitializeComponent();

            this.usuario = usuarioSeleccionado;
            this.modificar = true; // Estamos en modo modificar

            // Configurar el ComboBox de estados
            var estados = ControladoraGestionarUsuarios.Instancia.ObtenerEstadosUsuarios();
            cmbEstado.DataSource = estados;
            cmbEstado.DisplayMember = "EstadoUsuarioNombre";
            cmbEstado.ValueMember = "EstadoUsuarioId";
            cmbEstado.SelectedValue = usuario.EstadoUsuario;

            // Cargar datos del usuario
            CargarGruposEnCheckedListBox();
            CargarDatosUsuario();
        }

        #endregion



        #region  Eventos

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                return; // Si los datos no son válidos, no continuar
            }

            // Obtener los grupos, acciones asignadas, acciones personalizadas y acciones del módulo perfil
            var gruposSeleccionados = ObtenerGruposSeleccionados();
            var accionesAsignadas = ControladoraAcciones.Instancia.ObtenerAccionesPorGrupos(gruposSeleccionados);
            var accionesPersonalizadas = ObtenerAccionesPersonalizadas();

            // Combinar todos los componentes evitando duplicados
            var componentesAsignados = gruposSeleccionados.Cast<Componente>()
                .Concat(accionesAsignadas.Cast<Componente>())
                .Concat(accionesPersonalizadas.Cast<Componente>())
                .Distinct()
                .ToList();

            // Actualizar la información del usuario
            usuario.NombreUsuario = txtUsuario.Text;
            usuario.Nombre = txtNombre.Text;
            usuario.Apellido = txtApellido.Text;
            usuario.Email = txtEmail.Text;
            usuario.EstadoUsuario = (EstadoUsuario)cmbEstado.SelectedItem;

            // Asignar directamente los componentes seleccionados
            usuario.Componentes = componentesAsignados;

            // Si es un nuevo usuario, generar y asignar la clave ANTES de guardar
            if (!modificar)
            {
                var claveGenerada = GenerarClaveAleatoria();
                usuario.Clave = EncriptarClave(claveGenerada);

                // Intentar enviar la clave por correo
                if (!EnviarClavePorEmail(txtEmail.Text, claveGenerada))
                {
                    MessageBox.Show("No se pudo enviar la clave al email proporcionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Guardar el usuario en la base de datos
            string mensaje = modificar
                ? ControladoraGestionarUsuarios.Instancia.ModificarUsuario(usuario)
                : ControladoraGestionarUsuarios.Instancia.AgregarUsuario(usuario);

            // Mostrar mensaje al usuario
            MessageBox.Show(mensaje, "Información Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiar los campos y cerrar el formulario
            LimpiarCampos();
            Close();
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion



        #region Métodos Privados

        private List<Grupo> ObtenerGruposSeleccionados()
        {
            var gruposSeleccionados = new List<Grupo>();

            foreach (var item in clbGrupos.CheckedItems)
            {
                var grupo = ControladoraGestionarGrupos.Instancia.RecuperarGrupos()
                                .FirstOrDefault(g => g.Nombre == item.ToString());

                if (grupo != null)
                {
                    gruposSeleccionados.Add(grupo);
                }
            }

            return gruposSeleccionados;
        }

        private List<Accion> ObtenerAccionesPersonalizadas()
        {
            List<Accion> accionesSeleccionadas = new List<Accion>();

            // Recorre todos los nodos principales del TreeView
            foreach (TreeNode nodo in treeAcciones.Nodes)
            {
                // Verifica si el nodo principal está marcado
                if (nodo.Checked)
                {
                    // Añadir la acción correspondiente al nodo principal
                    var nombreAccion = nodo.Text;
                    var accion = ControladoraAcciones.Instancia.ObtenerAccionPorNombre(nombreAccion);
                    if (accion != null)
                    {
                        accionesSeleccionadas.Add(accion);
                    }

                    // Si el nodo principal está marcado, añade también las acciones de todos sus subnodos
                    foreach (TreeNode subNodo in nodo.Nodes)
                    {
                        nombreAccion = subNodo.Text;
                        accion = ControladoraAcciones.Instancia.ObtenerAccionPorNombre(nombreAccion);
                        if (accion != null)
                        {
                            accionesSeleccionadas.Add(accion);
                        }
                    }
                }
            }

            return accionesSeleccionadas;
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(this.txtUsuario.Text))
            {
                MessageBox.Show("Debe ingresar el nombre de usuario", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(this.txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(this.txtApellido.Text))
            {
                MessageBox.Show("Debe ingresar el apellido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(this.txtEmail.Text))
            {
                MessageBox.Show("Debe ingresar el email", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
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

                return true; // Retornar true si el envío fue exitoso
            }
            catch (Exception ex)
            {
                // Manejo de excepciones: se puede registrar el error o mostrar un mensaje según sea necesario
                Debug.WriteLine($"Error al enviar el correo: {ex.Message}");
                return false; // Retornar false si ocurrió un error durante el envío
            }
        }



        private void CargarGruposEnCheckedListBox()
        {
            // Obtiene la lista de grupos disponibles y los agrega al CheckedListBox
            var grupos = ControladoraGestionarGrupos.Instancia.RecuperarGrupos();
            clbGrupos.Items.Clear();

            foreach (var grupo in grupos)
            {
                clbGrupos.Items.Add(grupo.Nombre);
            }
        }



        private void CargarDatosUsuario()
        {
            txtUsuario.Text = usuario.NombreUsuario;
            txtNombre.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;
            txtEmail.Text = usuario.Email;

            // Establecer el estado del usuario
            cmbEstado.SelectedValue = usuario.EstadoUsuario.EstadoUsuarioId;

            // Cargar los grupos y acciones asignadas
            foreach (var grupo in usuario.Componentes.OfType<Grupo>())
            {
                int index = clbGrupos.Items.IndexOf(grupo.Nombre);
                if (index != -1)
                {
                    clbGrupos.SetItemChecked(index, true); // Marcar el grupo como seleccionado
                }
            }

            // Cargar acciones personalizadas en el TreeView
            foreach (var accion in usuario.Componentes.OfType<Accion>())
            {
                foreach (TreeNode nodo in treeAcciones.Nodes)
                {
                    if (nodo.Text == accion.Nombre)
                    {
                        nodo.Checked = true; // Marcar la acción como seleccionada
                    }
                }
            }
        }



        private void LimpiarCampos()
        {
            txtUsuario.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            cmbEstado.SelectedIndex = 0;

            // Desmarcar grupos y acciones en el CheckedListBox y TreeView
            for (int i = 0; i < clbGrupos.Items.Count; i++)
            {
                clbGrupos.SetItemChecked(i, false);
            }

            foreach (TreeNode nodo in treeAcciones.Nodes)
            {
                nodo.Checked = false; // Desmarcar acciones
            }
        }

        #endregion


        private void treeAcciones_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // Desactivar temporalmente el evento AfterCheck
            treeAcciones.AfterCheck -= treeAcciones_AfterCheck;

            try
            {
                if (e.Node.Nodes.Count > 0) // Nodo padre
                {
                    foreach (TreeNode subNodo in e.Node.Nodes)
                    {
                        subNodo.Checked = e.Node.Checked; // Marcar/desmarcar todos los subnodos
                    }
                }
                else // Nodo hijo
                {
                    TreeNode nodoPadre = e.Node.Parent;
                    if (nodoPadre != null)
                    {
                        // Si todos los subnodos están marcados, marca el nodo padre
                        nodoPadre.Checked = nodoPadre.Nodes.Cast<TreeNode>().All(n => n.Checked);
                    }
                }
            }
            finally
            {
                // Volver a activar el evento AfterCheck
                treeAcciones.AfterCheck += treeAcciones_AfterCheck;
            }
        }
    }
}
