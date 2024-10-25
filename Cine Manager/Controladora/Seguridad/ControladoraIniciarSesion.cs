using Microsoft.EntityFrameworkCore;
using Modelo.EFCore;
using Modelo.Entidades;
using Modelo.Módulo_de_Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.Seguridad
{
    public class ControladoraIniciarSesion
    {
        private static ControladoraIniciarSesion instancia;
        private Contexto context;


        public static ControladoraIniciarSesion Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ControladoraIniciarSesion();
                }
                return instancia;
            }
        }


        public ControladoraIniciarSesion()
        {
            context = new Contexto();
        }


        public Usuario Buscar(string nombreUsuario)
        {
            // Cargar el usuario y todas sus relaciones sin seguimiento para mejorar el rendimiento
            var usuario = context.Usuarios
                .AsNoTracking() // Evita que Entity Framework rastree los cambios en las entidades cargadas
                .Include(u => u.EstadoUsuario) // Cargar el estado del usuario
                .Include(u => u.Componentes)
                    .ThenInclude(c => (c as Grupo).EstadoGrupo) // Incluir el estado del grupo en los componentes de tipo Grupo
                .Include(u => u.Componentes)
                    .ThenInclude(c => (c as Grupo).Componentes) // Incluir los componentes de los grupos
                        .ThenInclude(gc => (gc as Accion).Formulario) // Incluir los formularios de las acciones dentro de los grupos
                            .ThenInclude(f => f.Modulo) // Incluir los módulos asociados a los formularios
                .Include(u => u.Componentes)
                    .ThenInclude(c => (c as Accion).Formulario) // Incluir los formularios de las acciones personalizadas
                        .ThenInclude(f => f.Modulo) // Incluir los módulos de los formularios personalizados
                .FirstOrDefault(u => u.NombreUsuario == nombreUsuario); // Obtener el primer usuario que coincide con el nombre


            if (usuario != null)
            {
                // Filtra los Componentes del usuario para obtener solo aquellos que son de tipo Grupo
                var grupos = usuario.Componentes.OfType<Grupo>().ToList();


                // Para cada grupo, se filtran sus componentes para obtener solo las Acciones asociadas a ese grupo
                foreach (var grupo in grupos)
                {
                    var accionesDelGrupo = grupo.Componentes.OfType<Accion>().ToList();
                }

                //  Filtra los componentes del usuario para obtener todas las Acciones que no están dentro de ningún grupo (acciones personalizadas)
                var accionesPersonalizadas = usuario.Componentes.OfType<Accion>().ToList();
                
            }

            return usuario;
        }



        public void Registrar(AuditoriaSesion auditoriaSesion)
        {
            try
            {
                // Agregar la auditoría de sesión a la base de datos
                context.AuditoriasSesiones.Add(auditoriaSesion);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw; // Manejo de excepciones en caso de algún error
            }
        }



    }
}
