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
        }



        public ReadOnlyCollection<Pelicula> RecuperarPeliculas()
        {
            try
            {
                return Contexto.Instancia.Peliculas
                    .Include(d => d.Director)
                    .Include(g => g.GeneroCinematografico)
                    .ToList()
                    .AsReadOnly(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al recuperar películas: {ex.Message}");
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

                return Contexto.Instancia.Peliculas
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
            var pelicula = Contexto.Instancia.Peliculas.FirstOrDefault(p => p.Codigo.ToLower() == codigo.ToLower());
            return pelicula;
        }



        public string AgregarPelicula(Pelicula pelicula)
        {
            try
            {
                var peliculaExistente = Buscar(pelicula.Codigo);

                if (peliculaExistente == null)
                {
                    


                    Contexto.Instancia.Peliculas.Add(pelicula);
                    Contexto.Instancia.SaveChanges();

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
                    Contexto.Instancia.Peliculas.Remove(pelicula);
                    Contexto.Instancia.SaveChanges();

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
                   
                    var actoresIds = pelicula.Reparto.Select(a => a.ActorId).ToList();

                    peliculaExistente.Nombre = pelicula.Nombre;
                    peliculaExistente.Precio = pelicula.Precio;
                    peliculaExistente.Director = pelicula.Director;
                    peliculaExistente.GeneroCinematografico = pelicula.GeneroCinematografico;
                    peliculaExistente.Reparto = pelicula.Reparto;


                    Contexto.Instancia.Peliculas.Update(pelicula);
                    Contexto.Instancia.SaveChanges();

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
                var peliculaExistente = Contexto.Instancia.Peliculas.FirstOrDefault(p => p.PeliculaId == pelicula.PeliculaId);
                if (peliculaExistente == null)
                    return false;

                peliculaExistente.Cantidad = pelicula.Cantidad;
                Contexto.Instancia.Peliculas.Update(peliculaExistente);
                Contexto.Instancia.SaveChanges();


                return true;
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
            var pelicula = Contexto.Instancia.Peliculas.Include(p => p.Reparto).FirstOrDefault(p => p.Codigo == codigo);
            return pelicula;
        }



    }
}
