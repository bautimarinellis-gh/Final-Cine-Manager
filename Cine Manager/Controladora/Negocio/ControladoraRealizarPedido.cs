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
        private Contexto context;


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




        public ReadOnlyCollection<Pelicula> FiltrarPeliculasDisponibles(string textoBusqueda)
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




        public Pedido Buscar(string codigo)
        {
            var pedido = context.Pedidos.FirstOrDefault(p => p.Codigo.ToLower() == codigo.ToLower());
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
                    var cliente = context.Clientes.FirstOrDefault(c => c.ClienteId == pedido.Cliente.ClienteId);
                    pedido.Cliente = cliente;

                    // Adjuntar detalles del pedido asegurando que las películas están adjuntas correctamente
                    foreach (var detalle in pedido.DetallesPedido)
                    {
                        // Adjuntar la película existente al detalle del pedido
                        var pelicula = context.Peliculas.FirstOrDefault(p => p.PeliculaId == detalle.Pelicula.PeliculaId);
                        if (pelicula != null)
                        {
                            detalle.Pelicula = pelicula;

                            // Actualizar la cantidad de películas
                            pelicula.Cantidad -= detalle.Cantidad;
                        }
                    }

                    context.Pedidos.Add(pedido);
                    context.SaveChanges();

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
            return context.Pedidos
                .Where(p => p.Cliente == cliente && p.DetallesPedido.OfType<DetalleAlquiler>().Any(da => !da.Devuelto))
                .Any();
        }
    }
}
