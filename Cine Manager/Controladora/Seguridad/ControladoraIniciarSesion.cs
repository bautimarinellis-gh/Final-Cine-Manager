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
        }


        public Usuario Buscar(string nombreUsuario)
        {
            var usuario = Contexto.Instancia.Usuarios
                .AsNoTracking() // Evita que Entity Framework rastree los cambios en las entidades cargadas
                .Include(u => u.EstadoUsuario) 
                .Include(u => u.Componentes)
                    .ThenInclude(c => (c as Grupo).EstadoGrupo) 
                .Include(u => u.Componentes)
                    .ThenInclude(c => (c as Grupo).Componentes) 
                        .ThenInclude(gc => (gc as Accion).Formulario) 
                            .ThenInclude(f => f.Modulo) 
                .Include(u => u.Componentes)
                    .ThenInclude(c => (c as Accion).Formulario) 
                        .ThenInclude(f => f.Modulo) 
                .FirstOrDefault(u => u.NombreUsuario == nombreUsuario); 


            if (usuario != null)
            {
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
                Contexto.Instancia.AuditoriasSesiones.Add(auditoriaSesion);
                Contexto.Instancia.SaveChanges();
            }
            catch (Exception ex)
            {
                throw; // Manejo de excepciones en caso de algún error
            }
        }



    }
}
