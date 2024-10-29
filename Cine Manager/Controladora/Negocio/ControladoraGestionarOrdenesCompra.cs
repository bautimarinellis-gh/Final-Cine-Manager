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
                return context.OrdenesCompra.Include(o => o.Proveedor).ToList().AsReadOnly();
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
                var orden = context.OrdenesCompra
                                   .Include(o => o.DetallesOrdenesCompra)
                                   .ThenInclude(d => d.Pelicula)
                                   .FirstOrDefault(o => o.Codigo == codigoOrden);

                if (orden != null)
                {
                    orden.EstadoActual = orden.AsignarEstado(orden.Estado); // Mapea el string al estado correspondiente
                }

                return orden;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar la orden de compra: {ex.Message}");
            }
        }



        public string CerrarOrdenCompra(OrdenCompra ordenCompra)
        {
            try
            {

                var ordenExistente = Buscar(ordenCompra.Codigo);

                if (ordenExistente == null)
                {
                    return "Orden de compra inexistente";
                }


                // Cambiar el estado de la orden
                ordenExistente.Cerrar();
                ordenExistente.CambiarEstado(new EstadoCerradaConFaltante());

                // Actualizar la orden en el contexto
                context.OrdenesCompra.Update(ordenExistente);
                context.SaveChanges();

                return "La orden de compra ha sido cerrada correctamente.";
            }
            catch (Exception ex)
            {
                return $"Error al cerrar la orden de compra: {ex.Message}";
            }
        }



        public string CancelarOrdenCompra(OrdenCompra ordenCompra)
        {
            try
            {
                var ordenExistente = Buscar(ordenCompra.Codigo);

                if (ordenExistente == null)
                {
                    return "Orden de compra inexistente";
                }

                // Validar si algún detalle de la orden ya ha sido entregado
                if (ordenExistente.DetallesOrdenesCompra.Any(detalle => detalle.CantidadEntregada > 0))
                {
                    return "No se puede cancelar la orden de compra porque uno o más detalles ya han sido entregados.";
                }

                // Delegar la operación al estado actual
                ordenExistente.Cancelar();

                // Cambiar el estado a Cancelada
                ordenExistente.CambiarEstado(new EstadoCancelada());

                context.OrdenesCompra.Update(ordenExistente);
                context.SaveChanges();

                return "La orden de compra ha sido cancelada.";
            }
            catch (Exception ex)
            {
                return $"Error desconocido: {ex.Message}";
            }
        }
    }
}
