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
    public class ControladoraGestionarActores
    {
        private static ControladoraGestionarActores instancia;
        private Contexto context;


        public static ControladoraGestionarActores Instancia
        {
            get
            {
                if(instancia == null)
                {
                    instancia = new ControladoraGestionarActores();
                }
                return instancia;
            }
        }



        public ControladoraGestionarActores()
        {
            context = new Contexto();
        }


        public ReadOnlyCollection<Actor> RecuperarActores()
        {
            try
            {
                return context.Actores.ToList().AsReadOnly();
            }
            catch (Exception ex)
            {
                throw;
            }
        }




        public Actor Buscar(string codigo)
        {
            var actor = context.Actores.FirstOrDefault(a => a.Codigo.ToLower() == codigo.ToLower());
            return actor;
        }



        public ReadOnlyCollection<Actor> FiltrarActores(string textoBusqueda)
        {
            try
            {
                if (string.IsNullOrEmpty(textoBusqueda))
                {
                    return RecuperarActores();
                }


                // Dividimos el texto de búsqueda en palabras
                string[] palabrasBusqueda = textoBusqueda.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                // Forzamos la evaluación en memoria con AsEnumerable()
                return context.Actores
                              .AsEnumerable() //Método para forzar a Entity Framework a traer todos los registros de la base de datos y luego aplicar el filtro en memoria
                              .Where(a => palabrasBusqueda.Any(palabra =>
                                  a.Nombre.ToLower().Contains(palabra.ToLower()) ||
                                  a.Apellido.ToLower().Contains(palabra.ToLower())))
                              .ToList()
                              .AsReadOnly();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar actores: " + ex.Message);
            }
        }




        public string AgregarActor(Actor actor)
        {
            try
            {
                var actorExistente = Buscar(actor.Codigo);

                if (actorExistente == null)
                {
                    context.Actores.Add(actor);
                    context.SaveChanges();

                    return "Actor agregado correctamente";
                }
                else
                {
                    return "El actor ya existe";
                }
            }
            catch (Exception ex)
            {
                return "Error desconocido";
            }
        }




        public string EliminarActor(Actor actor)
        {
            try
            {
                var actorExistente = Buscar(actor.Codigo);

                if (actorExistente != null)
                {
                    context.Actores.Remove(actor);
                    context.SaveChanges();

                    return "Actor eliminado correctamente";
                }
                else
                {
                    return "El actor no existe";
                }
            }
            catch (Exception ex)
            {
                return "Error desconocido";
            }
        }




        public string ModificarActor(Actor actor)
        {
            try
            {
                // Buscar actor existente por ID, no por Código
                var actorExistente = context.Actores.FirstOrDefault(a => a.ActorId == actor.ActorId);

                if (actorExistente != null)
                {
                    actorExistente.Codigo = actor.Codigo;
                    actorExistente.Nombre = actor.Nombre;
                    actorExistente.Apellido = actor.Apellido;

                    context.Actores.Update(actorExistente);
                    context.SaveChanges();

                    return "Actor modificado correctamente";
                }
                else
                {
                    return "El actor no existe";
                }
            }
            catch (Exception ex)
            {
                return "Error desconocido: " + ex.Message;
            }
        }

    }
}
