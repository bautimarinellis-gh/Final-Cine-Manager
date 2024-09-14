using Microsoft.EntityFrameworkCore;
using Modelo.EFCore;
using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.Negocio
{
    public class ControladoraGestionarOrdenesCompra
    {
        private Contexto context;
        private static ControladoraGestionarOrdenesCompra instancia;


        public static ControladoraGestionarOrdenesCompra Instancia
        {
            get
            {
                if(instancia == null)
                {
                    instancia = new ControladoraGestionarOrdenesCompra();
                }
                return instancia;
            }
        }


        public ControladoraGestionarOrdenesCompra()
        {
            context = new Contexto();
        }



        public ReadOnlyCollection<OrdenCompra> RecuperarOrdenesCompra()
        {
            try
            {
                return context.OrdenesCompra.ToList().AsReadOnly();

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public ReadOnlyCollection<OrdenCompra> FiltrarOrdenesCompra(string textoBusqueda)
        {
            try
            {
                if (string.IsNullOrEmpty(textoBusqueda))
                {
                    return RecuperarOrdenesCompra(); // Devuelve todas las peliculas si el txtbox está vacío
                }

                return context.OrdenesCompra
                    .Where(o => o.Codigo.ToLower().Contains(textoBusqueda.ToLower()))
                    .ToList()
                    .AsReadOnly();
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public OrdenCompra Buscar(string codigoOrden)
        {
            try
            {
                return context.OrdenesCompra
                              .Include(o => o.DetallesOrdenesCompra)
                              .ThenInclude(d => d.Pelicula)
                              .FirstOrDefault(o => o.Codigo == codigoOrden);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar la orden de compra: {ex.Message}");
            }
        }



        public string PagarOrdenCompra(OrdenCompra ordenCompra)
        {
            try
            {
                var ordenExistente = Buscar(ordenCompra.Codigo);

                if (ordenExistente == null)
                {
                    return "Orden de compra inexistente";
                }

                return ProcesarOrdenCompra(ordenExistente);
            }
            catch (Exception ex)
            {
                return $"Error desconocido: {ex.Message}";
            }
        }



        private string ProcesarOrdenCompra(OrdenCompra ordenExistente)
        {
            ordenExistente.Estado = true;

            foreach (var detalle in ordenExistente.DetallesOrdenesCompra)
            {
                try
                {
                    var peliculaExistente = ControladoraGestionarPeliculas.Instancia.Buscar(detalle.Pelicula.Codigo);

                    if (peliculaExistente == null)
                    {
                        ordenExistente.Estado = false;
                        return $"Error: no se encontró la película con el código {detalle.Pelicula.Codigo}";
                    }

                    // Actualizar el stock sumando la cantidad
                    peliculaExistente.Cantidad += detalle.Cantidad;

                    // Llamar al método de la controladora para actualizar la película en la base de datos
                    var stockActualizado = ControladoraGestionarPeliculas.Instancia.ActualizarStockPeliculas(peliculaExistente);

                    if (!stockActualizado)
                    {
                        ordenExistente.Estado = false;
                        return "Error al intentar actualizar el stock";
                    }
                }
                catch (Exception ex)
                {
                    ordenExistente.Estado = false;
                    return ex.Message; // Retornar el mensaje de error correspondiente
                }
            }

            // Guardar los cambios en la orden de compra y en la base de datos
            context.OrdenesCompra.Update(ordenExistente);
            context.SaveChanges();

            return "La orden de compra ha sido pagada y el stock actualizado";
        }
    }
}
