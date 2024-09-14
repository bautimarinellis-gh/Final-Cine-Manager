using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
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
    public class ControladoraGestionarPeliculas
    {
        private static ControladoraGestionarPeliculas instancia;
        private Contexto context;


        public static ControladoraGestionarPeliculas Instancia
        {
            get
            {
                if(instancia == null)
                {
                    instancia = new ControladoraGestionarPeliculas();
                }
                return instancia;
            }
        }


        public ControladoraGestionarPeliculas()
        {
            context = new Contexto();
        }



        public ReadOnlyCollection<Pelicula> RecuperarPeliculas()
        {
            try
            {
                return context.Peliculas.ToList().AsReadOnly();
            }
            catch (Exception ex)
            {
                throw;
            }
        }




        public ReadOnlyCollection<Pelicula> FiltrarPeliculas(string textoBusqueda)
        {
            try
            {
                if (string.IsNullOrEmpty(textoBusqueda))
                {
                    return RecuperarPeliculas(); // Devuelve todas las peliculas si el txtbox está vacío
                }

                return context.Peliculas
                    .Where(p => p.Nombre.ToLower().Contains(textoBusqueda.ToLower()))
                    .ToList()
                    .AsReadOnly();
            }
            catch (Exception ex)
            {
                throw;
            }
        }




        public Pelicula Buscar(string codigo)
        {
            var pelicula = context.Peliculas.FirstOrDefault(p => p.Codigo.ToLower() == codigo.ToLower());
            return pelicula;
        }



        public string AgregarPelicula(Pelicula pelicula)
        {
            try
            {
                var peliculaExistente = Buscar(pelicula.Codigo);

                if (peliculaExistente == null)
                {
                    // Cargar el Director y Género Cinematográfico desde la base de datos
                    var director = context.Directores.FirstOrDefault(d => d.DirectorId == pelicula.Director.DirectorId);
                    var generoCinematografico = context.GenerosCinematograficos.FirstOrDefault(g => g.GeneroCinematograficoId == pelicula.GeneroCinematografico.GeneroCinematograficoId);


                    var actoresIds = pelicula.Reparto.Select(a => a.ActorId).ToList();

                    // Asignar las entidades cargadas a la película
                    pelicula.Director = director;
                    pelicula.GeneroCinematografico = generoCinematografico;
                    pelicula.Reparto = context.Actores.Where(p => actoresIds.Contains(p.ActorId)).ToList();

                    

                    context.Peliculas.Add(pelicula);
                    context.SaveChanges();

                    return "Pelicula agregada correctamente";
                }
                else
                {
                    return "La pelicula ya existe";
                }
            }
            catch (Exception ex)
            {
                // Capturar y devolver detalles de la excepción
                return $"Error: {ex.Message}"; 
            }
        }








        public string EliminarPelicula(Pelicula pelicula)
        {
            try
            {
                var peliculaExistente = Buscar(pelicula.Codigo);

                if (peliculaExistente != null)
                {
                    context.Peliculas.Remove(pelicula);
                    context.SaveChanges();

                    return "Pelicula eliminada correctamente";
                }
                else
                {
                    return "La pelicula no existe";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }




        public string ModificarPelicula(Pelicula pelicula)
        {
            try
            {
                var peliculaExistente = Buscar(pelicula.Codigo);

                if(peliculaExistente != null)
                {
                    // Cargar el Director y Género Cinematográfico desde la base de datos
                    var director = context.Directores.FirstOrDefault(d => d.DirectorId == pelicula.Director.DirectorId);
                    var generoCinematografico = context.GenerosCinematograficos.FirstOrDefault(g => g.GeneroCinematograficoId == pelicula.GeneroCinematografico.GeneroCinematograficoId);

                   

                    var actoresIds = pelicula.Reparto.Select(a => a.ActorId).ToList();

                    // Asignar las entidades cargadas a la película
                    peliculaExistente.Nombre = pelicula.Nombre;
                    peliculaExistente.Cantidad = pelicula.Cantidad;
                    peliculaExistente.Precio = pelicula.Precio;
                    peliculaExistente.Director = director;
                    peliculaExistente.GeneroCinematografico = generoCinematografico;
                    peliculaExistente.Reparto = context.Actores.Where(p => actoresIds.Contains(p.ActorId)).ToList();


                    context.Peliculas.Update(pelicula);
                    context.SaveChanges();

                    return "Pelicula modificada correctamente";
                }
                else
                {
                    return "la pelicula no existe";
                }

            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }



        public bool ActualizarStockPeliculas(Pelicula pelicula)
        {
            try
            {
                var peliculaExistente = Buscar(pelicula.Codigo);

                if (peliculaExistente != null)
                {
                    peliculaExistente.Cantidad = pelicula.Cantidad;  

                    context.Peliculas.Update(peliculaExistente);
                    context.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        // Método para cargar la película con sus relaciones desde la base de datos
        public Pelicula CargarPeliculaConRelaciones(string codigo)
        {
            // Obtener la película con sus relaciones, como Reparto
            var pelicula = context.Peliculas.Include(p => p.Reparto).FirstOrDefault(p => p.Codigo == codigo);

            return pelicula;
        }



    }
}
