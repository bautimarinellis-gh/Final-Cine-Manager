using Modelo.EFCore;
using Modelo.Entidades;
using Modelo.Módulo_de_Seguridad;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class ControladoraGestionarDirectores
    {

        private static ControladoraGestionarDirectores instancia;


        public static ControladoraGestionarDirectores Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ControladoraGestionarDirectores();
                }
                return instancia;
            }
        }


        public ControladoraGestionarDirectores()
        {
        }




        public ReadOnlyCollection<Director> RecuperarDirectores()
        {
            try
            {
                return Contexto.Instancia.Directores.Where(d => d.Estado == true).ToList().AsReadOnly();
            }
            catch (Exception ex)
            {
                throw;
            }
        }




        public Director Buscar(string codigo)
        {
            var director = Contexto.Instancia.Directores.FirstOrDefault(d => d.Codigo.ToLower() == codigo.ToLower() && d.Estado == true);
            return director;
        }




        public ReadOnlyCollection<Director> FiltrarDirectores(string textoBusqueda)
        {
            try
            {
                if (string.IsNullOrEmpty(textoBusqueda))
                {
                    return RecuperarDirectores();
                }

                // Dividimos el texto de búsqueda en palabras
                string[] palabrasBusqueda = textoBusqueda.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                // Forzamos la evaluación en memoria con AsEnumerable()
                return Contexto.Instancia.Directores
                              .AsEnumerable() //Método para forzar a entity a traer todos los registros de la BD y despues aplicar filtro en memoria
                              .Where(a => palabrasBusqueda.Any(palabra =>
                                  a.Nombre.ToLower().Contains(palabra.ToLower()) ||
                                  a.Apellido.ToLower().Contains(palabra.ToLower())))
                              .ToList()
                              .AsReadOnly();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar directores: " + ex.Message);
            }
        }




        public string AgregarDirector(Director director, Usuario usuario)
        {
            try
            {
                var directorExistente = Contexto.Instancia.Directores.FirstOrDefault(d => d.Codigo.ToLower() == director.Codigo.ToLower());

                if (directorExistente == null)
                {
                    director.Estado = true;
                    Contexto.Instancia.Directores.Add(director);
                    Contexto.Instancia.SaveChanges();

                    // Auditoría de la creación del nuevo director
                    var nuevoDirector = Contexto.Instancia.Directores.FirstOrDefault(d => d.DirectorId == director.DirectorId);
                    var usuarioAud = Contexto.Instancia.Usuarios.FirstOrDefault(u => u.UsuarioId == usuario.UsuarioId);

                    var auditoria = new Auditoria
                    {
                        DirectorId = nuevoDirector.DirectorId,
                        Codigo_Director = nuevoDirector.Codigo,
                        Nombre_Director = nuevoDirector.Nombre,
                        Apellido_Director = nuevoDirector.Apellido,
                        Usuario_AudId = usuarioAud.UsuarioId,
                        Fecha_Aud = DateTime.Now,
                        TipoMovimiento_Aud = "Alta"
                    };

                    Contexto.Instancia.Auditorias.Add(auditoria);
                    Contexto.Instancia.SaveChanges();

                    return "Director agregado correctamente";
                }
                else if (directorExistente.Estado == false)
                {
                    // Si el director existe pero fue eliminado, lo reactivamos
                    return ReactivarDirector(directorExistente, director, usuario);
                }
                else
                {
                    return "El director ya existe y está activo";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message} - {ex.InnerException?.Message}";
            }
        }




        public string EliminarDirector(Director director, Usuario usuario)
        {
            try
            {
                var directorExistente = Buscar(director.Codigo);

                if (directorExistente != null)
                {
                    // Registramos la auditoría primero
                    var usuarioAud = Contexto.Instancia.Usuarios.FirstOrDefault(u => u.UsuarioId == usuario.UsuarioId);

                    var auditoria = new Auditoria
                    {
                        DirectorId = directorExistente.DirectorId,
                        Codigo_Director = directorExistente.Codigo,
                        Nombre_Director = directorExistente.Nombre,
                        Apellido_Director = directorExistente.Apellido,

                        Usuario_AudId = usuarioAud.UsuarioId,
                        Fecha_Aud = DateTime.Now,
                        TipoMovimiento_Aud = "Eliminación",
                    };

                    Contexto.Instancia.Auditorias.Add(auditoria);
                    Contexto.Instancia.SaveChanges();

                    // Baja lógica, establecemos el estado a 0
                    directorExistente.Estado = false;
                    Contexto.Instancia.Directores.Update(directorExistente);
                    Contexto.Instancia.SaveChanges();

                    return "Director eliminado correctamente";
                }
                else
                {
                    return "El director no existe";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message} - {ex.InnerException?.Message}";
            }
        }






        public string ModificarDirector(Director director, Usuario usuario)
        {
            try
            {
                var directorExistente = Contexto.Instancia.Directores.FirstOrDefault(d => d.DirectorId == director.DirectorId);

                if (directorExistente != null)
                {
                    var codigoAnterior = directorExistente.Codigo;
                    var nombreAnterior = directorExistente.Nombre;
                    var apellidoAnterior = directorExistente.Apellido;

                    // Actualizamos los valores
                    directorExistente.Codigo = director.Codigo;
                    directorExistente.Nombre = director.Nombre;
                    directorExistente.Apellido = director.Apellido;

                    Contexto.Instancia.Directores.Update(directorExistente);
                    Contexto.Instancia.SaveChanges();

                    var auditoria = new Auditoria
                    {
                        DirectorId = directorExistente.DirectorId,
                        Codigo_Director = directorExistente.Codigo,
                        Nombre_Director = directorExistente.Nombre,
                        Apellido_Director = directorExistente.Apellido,

                        Usuario_AudId = usuario.UsuarioId,
                        Fecha_Aud = DateTime.Now,
                        TipoMovimiento_Aud = "Modificación",
                    };

                    Contexto.Instancia.Auditorias.Add(auditoria);
                    Contexto.Instancia.SaveChanges();

                    return "Director modificado correctamente";
                }
                else
                {
                    return "El director no existe";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message} - {ex.InnerException?.Message}";
            }
        }



        private string ReactivarDirector(Director directorExistente, Director director, Usuario usuario)
        {
            // Reactivamos el director eliminado lógicamente
            directorExistente.Estado = true;

            // Actualizamos sus datos en caso de que hayan cambiado
            directorExistente.Nombre = director.Nombre;
            directorExistente.Apellido = director.Apellido;

            Contexto.Instancia.Directores.Update(directorExistente);
            Contexto.Instancia.SaveChanges();

            // Auditoría de la reactivación
            var usuarioAud = Contexto.Instancia.Usuarios.FirstOrDefault(u => u.UsuarioId == usuario.UsuarioId);

            var auditoria = new Auditoria
            {
                DirectorId = directorExistente.DirectorId,
                Codigo_Director = directorExistente.Codigo,
                Nombre_Director = directorExistente.Nombre,
                Apellido_Director = directorExistente.Apellido,
                Usuario_AudId = usuarioAud.UsuarioId,
                Fecha_Aud = DateTime.Now,
                TipoMovimiento_Aud = "Alta"
            };

            Contexto.Instancia.Auditorias.Add(auditoria);
            Contexto.Instancia.SaveChanges();

            return "Director agregado correctamente";
        }
    }
}
