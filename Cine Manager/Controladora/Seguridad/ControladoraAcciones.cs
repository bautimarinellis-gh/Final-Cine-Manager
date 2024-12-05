using Controladora.Seguridad;
using Microsoft.EntityFrameworkCore;
using Modelo.EFCore;
using Modelo.Módulo_de_Seguridad;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class ControladoraAcciones
    {
        private static ControladoraAcciones instancia;


        public static ControladoraAcciones Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ControladoraAcciones();
                }
                return instancia;
            }
        }


        public ControladoraAcciones()
        {
        }



        public ReadOnlyCollection<Accion> RecuperarAcciones()
        {
            try
            {
                return Contexto.Instancia.Acciones.ToList().AsReadOnly();
            }
            catch(Exception ex)
            {
                throw;
            }
        }


        public Accion ObtenerAccionPorNombre(string nombreAccion)
        {
            return Contexto.Instancia.Acciones.FirstOrDefault(a => a.Nombre== nombreAccion);
        }


        public List<Accion> ObtenerAccionesPorGrupos(List<Grupo> gruposSeleccionados)
        {
            // Obtener las acciones asociadas a los grupos seleccionados
            var acciones = Contexto.Instancia.Grupos
                .Where(g => gruposSeleccionados.Select(grupo => grupo.Id).Contains(g.Id))
                .SelectMany(g => g.Componentes)
                .OfType<Accion>() // Filtrar solo acciones
                .Distinct() // Eliminar duplicados
                .ToList();

            return acciones;
        }



        public List<Accion> ObtenerAccionesPorModulo(string nombreModulo)
        {
            try
            {
                // Obtener las acciones relacionadas con el módulo especificado
                var acciones = Contexto.Instancia.Acciones.Include(a => a.Formulario)
                                      .ThenInclude(f => f.Modulo)  // Incluimos la relación con Modulo
                                      .Where(a => a.Formulario.Modulo.NombreModulo == nombreModulo)
                                      .ToList();

                return acciones;
                
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine("Error al obtener las acciones del módulo: " + ex.Message);
                return new List<Accion>(); // Retorna una lista vacía en caso de error
            }
        }



        public List<Accion> ObtenerAccionesUsuario(Usuario usuario)
        { 
            // Obtener las acciones personalizadas asociadas al usuario
            var acciones = usuario.Componentes
                .OfType<Accion>() // Filtrar solo acciones
                .Distinct() // Eliminar duplicados
                .ToList();

            return acciones;
        }



        public List<Accion> ObtenerAccionesGrupo(Grupo grupo)
        {
            // Obtener el grupo desde la base de datos con sus componentes
            var grupoExistente = Contexto.Instancia.Grupos
                .Include(g => g.Componentes) // Incluir componentes asociados
                .FirstOrDefault(g => g.Id == grupo.Id);

            // Obtener las acciones personalizadas asociadas al grupo
            var acciones = grupoExistente.Componentes
                .OfType<Accion>() // Filtrar solo acciones
                .Distinct() // Eliminar duplicados
                .ToList();

            return acciones;
        }

        
    }
}
