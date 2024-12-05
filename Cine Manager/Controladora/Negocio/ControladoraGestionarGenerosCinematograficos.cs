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
    public class ControladoraGestionarGenerosCinematograficos
    {
        private static ControladoraGestionarGenerosCinematograficos instancia;


        public static ControladoraGestionarGenerosCinematograficos Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ControladoraGestionarGenerosCinematograficos();
                }
                return instancia;
            }
        }


        public ControladoraGestionarGenerosCinematograficos()
        {
        }



        public ReadOnlyCollection<GeneroCinematografico> RecuperarGenerosCinematograficos()
        {
            try
            {
                return Contexto.Instancia.GenerosCinematograficos.ToList().AsReadOnly();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public GeneroCinematografico Buscar(string nombre)
        {
            var generoCinematografico = Contexto.Instancia.GenerosCinematograficos.FirstOrDefault(g => g.Nombre.ToLower() == nombre.ToLower());
            return generoCinematografico;
        }




        public ReadOnlyCollection<GeneroCinematografico> FiltrarGenerosCinematograficos(string textoBusqueda)
        {
            try
            {
                // Si el nombre está vacío, retorna todos los géneros
                if (string.IsNullOrEmpty(textoBusqueda))
                {
                    return RecuperarGenerosCinematograficos();
                }

                // Si hay un nombre, filtra por él
                return Contexto.Instancia.GenerosCinematograficos
                    .Where(g => g.Nombre.ToLower().Contains(textoBusqueda.ToLower()))
                    .ToList()
                    .AsReadOnly();
            }
            catch (Exception ex)
            {
                throw;
            }
        }




        public string AgregarGeneroCinematografico(GeneroCinematografico generoCinematografico)
        {
            try
            {
                var generoCinematograficoExistente = Buscar(generoCinematografico.Nombre);

                if (generoCinematograficoExistente == null)
                {
                    Contexto.Instancia.GenerosCinematograficos.Add(generoCinematografico);
                    Contexto.Instancia.SaveChanges();

                    return "Genero Cinematografico agregado correctamente";
                }
                else
                {
                    return "El genero cinematografico ya existe";
                }
            }
            catch (Exception ex)
            {
                return "Error desconocido";
            }
        }




        public string EliminarGeneroCinematografico(GeneroCinematografico generoCinematografico)
        {
            try
            {
                var generoCinematograficoExistente = Buscar(generoCinematografico.Nombre);

                if (generoCinematograficoExistente != null)
                {
                    Contexto.Instancia.GenerosCinematograficos.Remove(generoCinematografico);
                    Contexto.Instancia.SaveChanges();

                    return "Genero Cinematografico eliminado correctamente";
                }
                else
                {
                    return "El genero cinematografico no existe";
                }
            }
            catch (Exception ex)
            {
                return "Error desconocido";
            }
        }




        public string ModificarGeneroCinematografico(GeneroCinematografico generoCinematografico)
        {
            try
            {
                var generoCinematograficoExistente = Contexto.Instancia.GenerosCinematograficos.FirstOrDefault(g => g.GeneroCinematograficoId== generoCinematografico.GeneroCinematograficoId);

                if (generoCinematograficoExistente != null)
                {
                    generoCinematograficoExistente.Nombre = generoCinematografico.Nombre;

                    Contexto.Instancia.GenerosCinematograficos.Update(generoCinematograficoExistente);
                    Contexto.Instancia.SaveChanges();

                    return "Genero Cinematografico modifiado correctamente";
                }
                else
                {
                    return "El genero cinematografico no existe";
                }
            }
            catch (Exception ex)
            {
                return "Error desconocido";
            }
        }
    }
}
