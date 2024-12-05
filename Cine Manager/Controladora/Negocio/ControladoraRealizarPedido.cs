using Microsoft.EntityFrameworkCore;
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
    public class ControladoraRealizarPedido
    {
        private static ControladoraRealizarPedido instancia;


        public static ControladoraRealizarPedido Instancia
        {
            get
            {
                if(instancia == null)
                {
                    instancia = new ControladoraRealizarPedido();
                }
                return instancia;
            }
        }



        public ControladoraRealizarPedido()
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
                throw;
            }
        }




        public ReadOnlyCollection<Pelicula> FiltrarPeliculasDisponibles(string textoBusqueda)
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




        public Pedido Buscar(string codigo)
        {
            var pedido = Contexto.Instancia.Pedidos.FirstOrDefault(p => p.Codigo.ToLower() == codigo.ToLower());
            return pedido;
        }




        public string AgregarPedido(Pedido pedido)
        {
            try
            {
                var pedidoExistente = Buscar(pedido.Codigo);

                if (pedidoExistente == null)
                {
                    // Asignar el cliente existente al pedido
                    var cliente = Contexto.Instancia.Clientes.FirstOrDefault(c => c.ClienteId == pedido.Cliente.ClienteId);
                    pedido.Cliente = cliente;

                    // Adjuntar detalles del pedido asegurando que las películas están adjuntas correctamente
                    foreach (var detalle in pedido.DetallesPedido)
                    {
                        // Obtener la película sin AsNoTracking
                        var pelicula = Contexto.Instancia.Peliculas
                            .FirstOrDefault(p => p.PeliculaId == detalle.Pelicula.PeliculaId);

                        if (pelicula != null)
                        {
                            // Actualizar la cantidad de la película
                            pelicula.Cantidad -= detalle.Cantidad;

                        }
                    }

                    // Agregar el pedido
                    Contexto.Instancia.Pedidos.Add(pedido);
                    Contexto.Instancia.SaveChanges();  // Guardar todos los cambios

                    return "Pedido realizado correctamente";
                }
                else
                {
                    return "Error desconocido";
                }
            }
            catch (Exception ex)
            {
                return ex.InnerException?.Message ?? ex.Message;
            }
        }






        public bool ClienteTieneAlquileresSinDevolver(Cliente cliente)
        {
            return Contexto.Instancia.Pedidos
                .Where(p => p.Cliente == cliente && p.DetallesPedido.OfType<DetalleAlquiler>().Any(da => !da.Devuelto))
                .Any();
        }
    }
}
