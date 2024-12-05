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
        }



        public ReadOnlyCollection<OrdenCompra> RecuperarOrdenesCompra()
        {
            try
            {
                return Contexto.Instancia.OrdenesCompra.AsNoTracking()
                    .Include(o => o.Proveedor)
                    .ToList()
                    .AsReadOnly();
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
                    return RecuperarOrdenesCompra();
                }

                return Contexto.Instancia.OrdenesCompra
                    .Where(o => o.Codigo.ToLower().Contains(textoBusqueda.ToLower()))
                    .ToList()
                    .AsReadOnly();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        private OrdenCompra ObtenerOrdenCompra(string codigoOrden, bool noTracking = false)
        {
            var query = Contexto.Instancia.OrdenesCompra.AsQueryable();

            if (noTracking)
            {
                query = query.AsNoTracking();
            }

            query = query.Include(o => o.DetallesOrdenesCompra)
                         .ThenInclude(d => d.Pelicula);

            return query.FirstOrDefault(o => o.Codigo == codigoOrden);
        }




        public OrdenCompra Buscar(string codigoOrden)
        {
            var orden = Contexto.Instancia.OrdenesCompra
                    .AsNoTracking()
                    .Include(o => o.DetallesOrdenesCompra)
                    .ThenInclude(d => d.Pelicula)
                    .FirstOrDefault(o => o.Codigo == codigoOrden);

            if (orden != null)
            {
                orden.EstadoActual = orden.AsignarEstado(orden.Estado);
            }

            return orden;
        }






        public string CerrarOrdenCompra(OrdenCompra ordenCompra)
        {
            try
            {
                var ordenExistente = Contexto.Instancia.OrdenesCompra
                        .Include(o => o.DetallesOrdenesCompra)
                        .FirstOrDefault(o => o.Codigo == ordenCompra.Codigo);

                if (ordenExistente == null)
                {
                    return "Orden de compra inexistente";
                }

                // Validar y cerrar orden
                ordenExistente.EstadoActual = ordenExistente.AsignarEstado(ordenExistente.Estado);
                ordenExistente.Cerrar();

                Contexto.Instancia.SaveChanges();
                return "La orden de compra ha sido cerrada correctamente.";
            }
            catch (InvalidOperationException ex)
            {
                return ex.Message; // Mensaje específico de la lógica de negocio
            }
            catch (Exception ex)
            {
                return $"Error inesperado al cerrar la orden: {ex.Message}";
            }
        }






        public string CancelarOrdenCompra(OrdenCompra ordenCompra)
        {
            try
            {
                var ordenExistente = Contexto.Instancia.OrdenesCompra
                       .Include(o => o.DetallesOrdenesCompra)
                       .FirstOrDefault(o => o.Codigo == ordenCompra.Codigo);

                if (ordenExistente == null)
                {
                    return "Orden de compra inexistente";
                }

                ordenExistente.EstadoActual = ordenExistente.AsignarEstado(ordenExistente.Estado);
                ordenExistente.Cancelar();

                Contexto.Instancia.SaveChanges();
                return "La orden de compra ha sido cancelada.";
            }
            catch (InvalidOperationException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return $"Error inesperado al cancelar la orden: {ex.Message}";
            }
        }


        public OrdenCompra RecargarOrdenCompra(string codigoOrden)
        {
            return ObtenerOrdenCompra(codigoOrden, true);
        }
    }
}
