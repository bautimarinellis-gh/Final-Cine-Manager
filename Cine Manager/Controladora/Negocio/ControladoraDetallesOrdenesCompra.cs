using Microsoft.EntityFrameworkCore;
using Modelo.EFCore;
using Modelo.Entidades;
using Modelo.Entidades.EstadosOrdenesCompra;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.Negocio
{
    public class ControladoraDetallesOrdenesCompra
    {
        private Contexto context;
        private static ControladoraDetallesOrdenesCompra instancia;



        public static ControladoraDetallesOrdenesCompra Instancia
        {
            get
            {
                if(instancia == null)
                {
                    instancia = new ControladoraDetallesOrdenesCompra();
                }
                return instancia;
            }
        }


        public ControladoraDetallesOrdenesCompra()
        {
            context = new Contexto();
        }



        public ReadOnlyCollection<DetalleOrdenCompra> RecuperarDetalles(OrdenCompra ordenCompra)
        {
            try
            {
                // Recuperar detalles de venta con inclusión de la entidad Pelicula
                return context.DetallesOrdenesCompra
                              .Where(doc => doc.OrdenCompraId == ordenCompra.OrdenCompraId)
                              .Include(doc => doc.Pelicula).
                              Include(doc => doc.OrdenCompra)
                              .ToList()
                              .AsReadOnly();
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public string EntregarDetalleOrdenCompra(DetalleOrdenCompra detalleOrdenCompra, int cantidadEntregada)
        {
            try
            {
                var detalleOrdenCompraExistente = context.DetallesOrdenesCompra
                    .Include(d => d.OrdenCompra) 
                    .FirstOrDefault(d => d.DetalleOrdenCompraId == detalleOrdenCompra.DetalleOrdenCompraId);

                if (detalleOrdenCompraExistente == null)
                {
                    return "El detalle de la orden de compra no existe.";
                }

                // Verificamos que no exceda la cantidad ordenada
                if (detalleOrdenCompraExistente.CantidadEntregada + cantidadEntregada > detalleOrdenCompraExistente.CantidadOrdenada)
                {
                    return "La cantidad entregada no puede exceder la cantidad ordenada.";
                }

                // Actualizamos la cantidad entregada
                detalleOrdenCompraExistente.CantidadEntregada += cantidadEntregada;

                if (detalleOrdenCompraExistente.CantidadEntregada >= detalleOrdenCompraExistente.CantidadOrdenada)
                {
                    detalleOrdenCompraExistente.Estado = true; 
                }

                var mensaje = ProcesarDetalleOrdenCompra(detalleOrdenCompraExistente, cantidadEntregada);

                if (!mensaje)
                {
                    return "Error al procesar el detalle de la orden de compra.";
                }

                var ordenCompra = detalleOrdenCompraExistente.OrdenCompra;

                if (ordenCompra == null)
                {
                    return "El detalle de la orden no tiene una orden de compra asociada.";
                }

                if (ordenCompra.TodosLosDetallesEntregados())
                {
                    ordenCompra.CambiarEstado(new EstadoCompletada());
                }
                else if (ordenCompra.HayItemsEnDetalle())
                {
                    ordenCompra.CambiarEstado(new EstadoParcialmenteCompletada());
                }

                context.DetallesOrdenesCompra.Update(detalleOrdenCompraExistente);
                context.OrdenesCompra.Update(ordenCompra);
                context.SaveChanges();

                return "La cantidad entregada ha sido registrada correctamente y el stock actualizado.";
            }
            catch (Exception ex)
            {
                return $"Error desconocido: {ex.Message}";
            }
        }



        



        public bool ProcesarDetalleOrdenCompra(DetalleOrdenCompra detalleOrdenCompra, int cantidadEntregada)
        {
            try
            {
                var peliculaExistente = ControladoraGestionarPeliculas.Instancia.Buscar(detalleOrdenCompra.Pelicula.Codigo);

                if (peliculaExistente == null)
                {
                    return false;
                }

                // Actualizar el stock sumando solo la cantidad entregada en esta operación
                peliculaExistente.Cantidad += cantidadEntregada;

                // Actualizar en la base de datos el stock de la película
                var stockActualizado = ControladoraGestionarPeliculas.Instancia.ActualizarStockPeliculas(peliculaExistente);

                return stockActualizado;
            }
            catch (Exception ex)
            {
                return false;  // Retornar el mensaje de error correspondiente
            }
        }
    }
}
