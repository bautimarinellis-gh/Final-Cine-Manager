using Microsoft.EntityFrameworkCore;
using Modelo.EFCore;
using Modelo.Entidades;
using Modelo.Módulo_de_Seguridad;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.Seguridad
{
    public class ControladoraGestionarGrupos
    {
        private static ControladoraGestionarGrupos instancia;
        private Contexto context;


        public static ControladoraGestionarGrupos Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ControladoraGestionarGrupos();
                }
                return instancia;
            }
        }


        public ControladoraGestionarGrupos()
        {
            context = new Contexto();
        }



        public ReadOnlyCollection<Grupo> RecuperarGrupos()
        {
            try
            {
                return context.Grupos
                              .Include(g => g.EstadoGrupo) // Incluimos la relación con Estado
                              .ToList()
                              .AsReadOnly();
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public Grupo Buscar(string codigoGrupo)
        {
            var grupo = context.Grupos.FirstOrDefault(g => g.Codigo.ToLower() == codigoGrupo.ToLower());
            return grupo;
        }



        public string AgregarGrupo(Grupo grupo)
        {
            try
            {
                // Verificar si el grupo ya existe por su código
                var grupoExistente = Buscar(grupo.Codigo);

                if (grupoExistente != null)
                {
                    return "Ya existe un grupo con ese código";
                }

                var estadoGrupo = context.EstadosGrupo.FirstOrDefault(eg=> eg.EstadoGrupoId == grupo.EstadoGrupo.EstadoGrupoId);


                // Asignar el estado del grupo
                grupo.EstadoGrupo = estadoGrupo;

                // Asegurarse de que las acciones están en el contexto
                for (int i = 0; i < grupo.Componentes.Count; i++)
                {
                    if (grupo.Componentes[i] is Accion accion)
                    {
                        var accionExistente = context.Acciones
                            .FirstOrDefault(a => a.Id == accion.Id);

                        if (accionExistente != null)
                        {
                            grupo.Componentes[i] = accionExistente; // Reemplazar con la instancia rastreada
                        }
                    }
                }

                // Agregar el grupo a la base de datos
                context.Grupos.Add(grupo);
                context.SaveChanges();

                return "Grupo agregado correctamente";
            }
            catch (Exception ex)
            {
                var innerExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : "No hay detalles adicionales.";
                return $"Error: {ex.Message}. Detalles: {innerExceptionMessage}";
            }
        }



        public bool TieneUsuariosConGrupo(Grupo grupo)
        {
            var usuarios = context.Usuarios.Include(u => u.Componentes).ToList();

            return usuarios.Any(u => u.Componentes.Any(c => c is Grupo g && g.Codigo == grupo.Codigo));
        }
    



        public string EliminarGrupo(Grupo grupo)
        {
            try
            {
                var grupoExistente = Buscar(grupo.Codigo);

                if (grupoExistente != null)
                {
                    // Verificar si el grupo tiene usuarios asociados
                    if (TieneUsuariosConGrupo(grupoExistente))
                    {
                        return "No se puede eliminar el grupo porque tiene usuarios asociados.";
                    }

                    context.Grupos.Remove(grupoExistente);
                    context.SaveChanges();
                    return "Grupo eliminado correctamente";
                }
                else
                {
                    return "El grupo no existe";
                }
            }
            catch (Exception ex)
            {
                return "Error desconocido: " + ex.Message;
            }
        }



        public string ModificarGrupo(Grupo grupo)
        {
            try
            {
                var grupoExistente = context.Grupos.Include(g => g.Componentes)
                                     .Include(g => g.Usuarios)
                                     .ThenInclude(u => u.Componentes)  // Incluir componentes de cada usuario
                                     .FirstOrDefault(g => g.Codigo == grupo.Codigo);

                if (grupoExistente == null)
                {
                    return "Grupo no encontrado";
                }

                // Actualizar la información básica del grupo
                ActualizarInformacionBasicaGrupo(grupoExistente, grupo);

                var nuevasAcciones = ObtenerNuevasAcciones(grupo.Componentes)
                                     .Cast<Componente>()
                                     .Distinct()
                                     .ToList();

                // Actualizar los componentes del grupo
                grupoExistente.Componentes = nuevasAcciones;

                // Actualizar los componentes de los usuarios asociados
                var usuariosParaActualizar = grupoExistente.Usuarios.ToList();

                foreach (var usuario in usuariosParaActualizar)
                {
                    // Actualiza las acciones del usuario
                    ActualizarComponentesUsuario(usuario, grupoExistente);

                    // Guardar cambios en el usuario
                    context.Usuarios.Update(usuario);
                    context.SaveChanges();
                }

                // Guardar los cambios en el grupo
                context.Grupos.Update(grupoExistente);
                context.SaveChanges();

                return "Grupo modificado correctamente";
            }
            catch (Exception ex)
            {
                var innerExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : "No hay detalles adicionales.";
                return $"Error: {ex.Message}. Detalles: {innerExceptionMessage}";
            }
        }



        private void ActualizarComponentesUsuario(Usuario usuario, Grupo grupoActualizado)
        {
            // Obtener las acciones del grupo actual
            var accionesDelGrupo = grupoActualizado.Componentes.OfType<Accion>().ToList();

            // Eliminar solo las acciones del usuario que pertenecen al grupo y ya no están en el grupo actualizado
            usuario.Componentes.RemoveAll(c => c is Accion accion && accionesDelGrupo.Any(a => a.Id == accion.Id) && !accionesDelGrupo.Contains(accion));

            // Agregar nuevas acciones del grupo al usuario si no las tiene ya
            foreach (var nuevaAccion in accionesDelGrupo)
            {
                if (!usuario.Componentes.OfType<Accion>().Any(a => a.Id == nuevaAccion.Id))
                {
                    usuario.Componentes.Add(nuevaAccion);
                }
            }
        }



        private void ActualizarInformacionBasicaGrupo(Grupo grupoExistente, Grupo grupoModificado)
        {
            grupoExistente.Nombre = grupoModificado.Nombre;
            grupoExistente.DescripcionGrupo = grupoModificado.DescripcionGrupo;
            grupoExistente.EstadoGrupo = context.EstadosGrupo
                .FirstOrDefault(e => e.EstadoGrupoId == grupoModificado.EstadoGrupo.EstadoGrupoId);
        }



        private List<Accion> ObtenerNuevasAcciones(List<Componente> componentes)
        {
            // Obtener los IDs de las acciones seleccionadas
            var accionesIds = componentes.OfType<Accion>().Select(a => a.Id).ToList();

            // Cargar nuevas acciones desde la base de datos usando sus IDs
            return context.Acciones.Where(a => accionesIds.Contains(a.Id)).ToList();
        }



        public ReadOnlyCollection<EstadoGrupo> ObtenerEstadosGrupos()
        {
            try
            {
                // Obtener todos los estados desde la base de datos
                return context.EstadosGrupo.ToList().AsReadOnly();
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                throw new Exception("Error al obtener los estados de grupo", ex);
            }
        }



        public ReadOnlyCollection<Grupo> ObtenerGruposUsuario(int usuarioId)
        {
            try
            {
                var grupos = context.Grupos
                    .Where(g => g.Usuarios.Any(u => u.UsuarioId == usuarioId))
                    .ToList()
                    .AsReadOnly();

                return grupos;
            }
            catch (Exception e)
            {
                // Manejo de excepciones
                throw;
            }
        }



        public ReadOnlyCollection<Componente> ObtenerComponentesDelGrupo(int grupoId)
        {
            // Recuperar el grupo específico con sus componentes
            var grupo = context.Grupos
                               .Include(g => g.Componentes) // Incluir los componentes relacionados
                               .FirstOrDefault(g => g.Id == grupoId);

            if (grupo != null)
            {
                return grupo.Componentes.AsReadOnly();
            }
            return new List<Componente>().AsReadOnly();
        }


    }
}
