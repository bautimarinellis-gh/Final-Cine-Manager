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
                              .Include(doc => doc.Pelicula) // Incluimos Pelicula
                              .ToList()
                              .AsReadOnly();
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public string PagarDetalleOrdenCompra(DetalleOrdenCompra detalleOrdenCompra)
        {
            try
            {
                // Cargar el detalle incluyendo la OrdenCompra asociada
                var detalleOrdenCompraExistente = context.DetallesOrdenesCompra
                    .Include(d => d.OrdenCompra) // Asegurar que OrdenCompra está cargada
                    .FirstOrDefault(d => d.DetalleOrdenCompraId == detalleOrdenCompra.DetalleOrdenCompraId);

                if (detalleOrdenCompraExistente == null)
                {
                    return "El detalle de la orden de compra no existe.";
                }

                // Verificar si el detalle ya ha sido pagado
                if (detalleOrdenCompraExistente.Estado)
                {
                    return "El detalle de la orden ya ha sido pagado.";
                }

                // Marcar el detalle como pagado
                detalleOrdenCompraExistente.Estado = true;

                // Procesar el detalle y actualizar el stock
                var mensaje = ProcesarDetalleOrdenCompra(detalleOrdenCompraExistente);

                if (!mensaje)
                {
                    return "Error al procesar el detalle de la orden de compra.";
                }

                // Actualizar el estado de la orden de compra basado en los detalles
                var ordenCompra = detalleOrdenCompraExistente.OrdenCompra;

                if (ordenCompra == null)
                {
                    return "El detalle de la orden no tiene una orden de compra asociada.";
                }

                if (ordenCompra.TodosLosDetallesPagos())
                {
                    ordenCompra.CambiarEstado(new EstadoCompletada());
                }
                else if (ordenCompra.AlgunosDetallesPagos())
                {
                    ordenCompra.CambiarEstado(new EstadoParcialmenteCompletada());
                }

                // Guardar los cambios en la base de datos
                context.DetallesOrdenesCompra.Update(detalleOrdenCompraExistente);
                context.OrdenesCompra.Update(ordenCompra);
                context.SaveChanges();

                return "El detalle de la orden de compra ha sido pagado y el stock actualizado.";

            }
            catch (Exception ex)
            {
                return $"Error desconocido: {ex.Message}";
            }
        }




        public bool ProcesarDetalleOrdenCompra(DetalleOrdenCompra detalleOrdenCompra)
        {
            try
            {
                var peliculaExistente = ControladoraGestionarPeliculas.Instancia.Buscar(detalleOrdenCompra.Pelicula.Codigo);

                if (peliculaExistente == null)
                {
                    return false;
                }

                // Actualizar el stock sumando la cantidad del detalle
                peliculaExistente.Cantidad += detalleOrdenCompra.Cantidad;

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
