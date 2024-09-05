using Modelo.EFCore;
using Modelo.Entidades;
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
        private Contexto context;


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
            context = new Contexto();
        }




        public ReadOnlyCollection<Director> RecuperarDirectores()
        {
            try
            {
                return context.Directores.ToList().AsReadOnly();
            }
            catch (Exception ex)
            {
                throw;
            }
        }




        public Director Buscar(string codigo)
        {
            var director = context.Directores.FirstOrDefault(d => d.Codigo.ToLower() == codigo.ToLower());
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
                return context.Directores
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




        public string AgregarDirector(Director director)
        {
            try
            {
                var directorExistente = Buscar(director.Codigo);

                if (directorExistente == null)
                {
                    context.Directores.Add(director);
                    context.SaveChanges();

                    return "Director agregado correctamente";
                }
                else
                {
                    return "El director ya existe";
                }
            }
            catch (Exception ex)
            {
                return "Error desconocido";
            }
        }




        public string EliminarDirector(Director director)
        {
            try
            {
                var directorExistente = Buscar(director.Codigo);

                if (directorExistente != null)
                {
                    context.Directores.Remove(director);
                    context.SaveChanges();

                    return "Director eliminado correctamente";
                }
                else
                {
                    return "El director no existe";
                }
            }
            catch (Exception ex)
            {
                return "Error desconocido";
            }
        }




        public string ModificarDirector(Director director)
        {
            try
            {
                var directorExistente = context.Directores.FirstOrDefault(d => d.DirectorId == director.DirectorId);

                if (directorExistente != null)
                {

                    directorExistente.Codigo = director.Codigo;
                    directorExistente.Nombre = director.Nombre;
                    directorExistente.Apellido = director.Apellido;

                    context.Directores.Update(directorExistente);
                    context.SaveChanges();

                    return "Director modificado correctamente";
                }
                else
                {
                    return "El director no existe";
                }
            }
            catch (Exception ex)
            {
                return "Error desconocido";
            }
        }
    }
}
