using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Modelo.EFCore;
using Modelo.Módulo_de_Seguridad;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace Controladora
{
    public class ControladoraGestionarUsuarios
    {
        private static ControladoraGestionarUsuarios instancia;
        private Contexto context;


        public static ControladoraGestionarUsuarios Instancia
        {
            get
            {
                if(instancia == null)
                {
                    instancia = new ControladoraGestionarUsuarios();
                }
                return instancia;
            }
        }



        public ControladoraGestionarUsuarios()
        {
            context = new Contexto();
        }



        public ReadOnlyCollection<Usuario> RecuperarUsuarios()
        {
            try
            {
                // Incluimos el Estado si es una entidad relacionada.
                return context.Usuarios
                              .Include(u => u.Componentes) // Aseguramos que los componentes se carguen
                              .Include(u => u.EstadoUsuario) // Incluimos la relación con Estado
                              .ToList()
                              .AsReadOnly();
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public Usuario Buscar(string nombreUsuario)
        {
            var usuario = context.Usuarios.FirstOrDefault(u => u.NombreUsuario.ToLower() == nombreUsuario.ToLower());
            return usuario;
        }



        public string AgregarUsuario(Usuario usuario)
        {
            try
            {
                // Verificamos si el usuario ya existe en la base de datos
                var usuarioExistente = Buscar(usuario.NombreUsuario);

                if (usuarioExistente == null)
                {
                    // Obtener el estado del usuario desde la base de datos
                    var estadoUsuario = context.EstadosUsuario.FirstOrDefault(e => e.EstadoUsuarioId == usuario.EstadoUsuario.EstadoUsuarioId);

                    // Asignar el estado al usuario
                    usuario.EstadoUsuario = estadoUsuario;

                    // Obtener los IDs de los componentes (acciones y grupos)
                    var componentesIds = usuario.Componentes.Select(c => c.Id).ToList();

                    // Obtener todas las acciones y grupos correspondientes a los IDs
                    var acciones = context.Acciones.Where(a => componentesIds.Contains(a.Id)).ToList();
                    var grupos = context.Grupos.Where(g => componentesIds.Contains(g.Id)).ToList();

                    // Combinar las acciones y grupos en una sola lista de componentes
                    var componentes = acciones.Cast<Componente>().Concat(grupos.Cast<Componente>()).ToList();

                    // Asignar los componentes recuperados al usuario
                    usuario.Componentes = componentes;

                    // Guardar el usuario en la base de datos
                    context.Usuarios.Add(usuario);
                    context.SaveChanges();

                    return "Usuario agregado correctamente y se envió la contraseña por correo";
                }
                else
                {
                    return "Ya existe un usuario con ese nombre de usuario";
                }
            }
            catch (Exception ex)
            {
                // Para mayor detalle, puedes registrar el mensaje de la excepción en un log o devolverlo para depuración.
                return "Error desconocido: " + ex.InnerException.Message;
            }
        }



        public string EliminarUsuario(Usuario usuario)
        {
            try
            {
                var usuarioExistente = Buscar(usuario.NombreUsuario);

                if (usuarioExistente != null)
                {
                    context.Usuarios.Remove(usuario);
                    context.SaveChanges();

                    return "Usuario eliminado correctamente";
                }
                else
                {
                    return "El usuario no existe";
                }
            }
            catch (Exception ex)
            {
                return "Error desconocido";
            }
        }



        public string ModificarUsuario(Usuario usuario)
        {
            try
            {
                // Buscar el usuario existente junto con sus componentes
                var usuarioExistente = ObtenerUsuarioExistente(usuario.UsuarioId);

                if (usuarioExistente == null)
                {
                    return "El usuario no existe";
                }

                // Actualizar los datos básicos del usuario
                ActualizarInformacionBasicaUsuario(usuarioExistente, usuario);

                // Obtener los componentes actualizados para el usuario
                var nuevosComponentes = ObtenerComponentesActualizados(usuario);

                // Asignar los nuevos componentes al usuario
                usuarioExistente.Componentes = nuevosComponentes;

                // Guardar los cambios en la base de datos
                context.Usuarios.Update(usuarioExistente);
                context.SaveChanges();
                return "Usuario modificado correctamente";
            }
            catch (Exception ex)
            {
                // Manejo de errores
                return $"Error al guardar los cambios: {ex.Message}";
            }
        }



        public string ActualizarClaveUsuario(Usuario usuario)
        {
            // Buscar el usuario existente junto con sus componentes
            var usuarioExistente = ObtenerUsuarioExistente(usuario.UsuarioId);

            if (usuarioExistente == null)
            {
                return "El usuario no existe";
            }

            usuarioExistente.Clave = usuario.Clave;

            context.Update(usuarioExistente);
            context.SaveChanges();
            return "Usuario modificado correctamente";
        }



        private Usuario ObtenerUsuarioExistente(int usuarioId)
        {
            return context.Usuarios
                .Include(u => u.Componentes)
                .FirstOrDefault(u => u.UsuarioId == usuarioId);
        }



        private void ActualizarInformacionBasicaUsuario(Usuario usuarioExistente, Usuario usuario)
        {
            usuarioExistente.NombreUsuario = usuario.NombreUsuario;
            usuarioExistente.Nombre = usuario.Nombre;
            usuarioExistente.Apellido = usuario.Apellido;
            usuarioExistente.Email = usuario.Email;
            usuarioExistente.EstadoUsuario = context.EstadosUsuario
                .FirstOrDefault(e => e.EstadoUsuarioId == usuario.EstadoUsuario.EstadoUsuarioId);
        }



        private List<Componente> ObtenerComponentesActualizados(Usuario usuario)
        {
            var accionesIds = usuario.Componentes.OfType<Accion>().Select(a => a.Id).ToList();
            var gruposIds = usuario.Componentes.OfType<Grupo>().Select(g => g.Id).ToList();

            var nuevasAcciones = context.Acciones.Where(a => accionesIds.Contains(a.Id)).ToList();
            var nuevosGrupos = context.Grupos.Include(g => g.Componentes).Where(g => gruposIds.Contains(g.Id)).ToList();

            var nuevosComponentes = nuevasAcciones.Cast<Componente>()
                .Concat(nuevosGrupos.Cast<Componente>())
                .Concat(nuevosGrupos.SelectMany(g => g.Componentes))
                .Distinct().ToList();

            return nuevosComponentes;
        }




        public ReadOnlyCollection<EstadoUsuario> ObtenerEstadosUsuarios()
        {
            try
            {
                // Obtener todos los estados desde la base de datos
                return context.EstadosUsuario.ToList().AsReadOnly();
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                throw new Exception("Error al obtener los estados de usuario", ex);
            }
        }
    }
}
