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
            CargarDatosUsuario();
        }



        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                return;
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
                    MessageBox.Show("No se pudo enviar la clave al email proporcionado.");
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
                else
                {
                    // Si el nodo principal no está marcado, verifica individualmente los subnodos
                    foreach (TreeNode subNodo in nodo.Nodes)
                    {
                        if (subNodo.Checked)
                        {
                            var nombreAccion = subNodo.Text;
                            var accion = ControladoraAcciones.Instancia.ObtenerAccionPorNombre(nombreAccion);
                            if (accion != null)
                            {
                                accionesSeleccionadas.Add(accion);
                            }
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


        private void LimpiarCampos()
        {
            txtUsuario.Clear();
            txtNombre.Clear();
            txtEmail.Clear();
            cmbEstado.SelectedIndex = 1;
        }



        private void CargarGruposEnCheckedListBox()
        {
            // Limpiar cualquier elemento previo en el CheckedListBox
            clbGrupos.Items.Clear();

            // Obtener todos los grupos del sistema
            var todosLosGrupos = ControladoraGestionarGrupos.Instancia.RecuperarGrupos();

            // Agregar cada grupo al CheckedListBox sin marcar
            foreach (var grupo in todosLosGrupos)
            {
                clbGrupos.Items.Add(grupo.Nombre, false);
            }
        }



        private void CargarGruposUsuario()
        {
            // Obtener todos los grupos del sistema
            var todosLosGrupos = ControladoraGestionarGrupos.Instancia.RecuperarGrupos();

            // Obtener los IDs de los grupos asignados al usuario desde la base de datos
            var gruposAsignados = ControladoraGestionarGrupos.Instancia.ObtenerGruposUsuario(usuario.UsuarioId)
                                   .Select(g => g.Id)
                                   .ToList();



            // Recorrer todos los grupos y marcar los que están asignados al usuario
            foreach (var grupo in todosLosGrupos)
            {
                // Añadir el nombre del grupo al CheckedListBox y obtener su índice
                int index = clbGrupos.Items.Add(grupo.Nombre);

                // Verificar si el grupo está asignado al usuario
                bool isChecked = gruposAsignados.Contains(grupo.Id);



                // Marcar el grupo en el CheckedListBox si está asignado al usuario
                clbGrupos.SetItemChecked(index, isChecked);
            }
        }



        private void CargarAccionesUsuario()
        {
            // Obtener los nombres de las acciones asignadas al usuario desde la base de datos
            var accionesAsignadas = ControladoraAcciones.Instancia.ObtenerAccionesUsuario(usuario).Select(a => a.Nombre).ToList();

            // Recorrer cada nodo en el TreeView 
            foreach (TreeNode nodoCategoria in treeAcciones.Nodes)
            {
                // Recorrer cada subnodo dentro de la categoría
                foreach (TreeNode nodoAccion in nodoCategoria.Nodes)
                {
                    // Verificar que el Tag no sea nulo y que sea de tipo string
                    if (nodoAccion.Tag is string nombreAccion)
                    {
                        // Si la acción está asignada al usuario, marcarla como seleccionada
                        if (accionesAsignadas.Contains(nombreAccion))
                        {
                            nodoAccion.Checked = true;
                        }
                    }

                }
            }
        }

        private void CargarDatosUsuario()
        {

            txtUsuario.Text = usuario.NombreUsuario;
            txtNombre.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;
            txtEmail.Text = usuario.Email;
            cmbEstado.SelectedItem = usuario.EstadoUsuario;

            // Cargar los grupos del usuario
            CargarGruposUsuario();

            CargarAccionesUsuario();
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
    }
}
