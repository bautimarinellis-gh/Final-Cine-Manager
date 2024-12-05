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
    public class ControladoraReportes
    {
        private static ControladoraReportes instancia;


        public static ControladoraReportes Instancia
        {
            get
            {
                if(instancia == null)
                {
                    instancia = new ControladoraReportes();
                }
                return instancia;
            }
        }



        public ControladoraReportes()
        {
        }



        public ReadOnlyCollection<(Pelicula, int)> RecuperarPeliculasMasVendidas()
        {
            var peliculasVendidas = Contexto.Instancia.DetallesPedidos
                .OfType<DetalleVenta>()
                .Include(dv => dv.Pelicula) 
                .Where(dv => dv.Pedido != null && dv.Pedido.Estado)
                .AsEnumerable()
                .GroupBy(dv => dv.Pelicula)
                .Select(grupo => new
                {
                    Pelicula = grupo.Key,
                    CantidadVendida = grupo.Sum(dv => dv.Cantidad)
                })
                .OrderByDescending(resultado => resultado.CantidadVendida)
                .ToList();

            return peliculasVendidas.Select(p => (p.Pelicula, p.CantidadVendida)).ToList().AsReadOnly();
        }



        public ReadOnlyCollection<(string RazonSocial, string Codigo, int CantidadOrdenesPendientes)> RecuperarProveedoresConOrdenesPendientes()
        {
            // Recuperar los proveedores y contar las órdenes de compra con estado pendiente o parcialmente completadas
            var proveedoresConPendientes = Contexto.Instancia.Proveedores
                .Select(proveedor => new
                {
                    Proveedor = proveedor,
                    CantidadOrdenesPendientes = proveedor.OrdenesCompra
                        .Count(o => o.Estado == "Pendiente" || o.Estado == "Parcialmente Completadas") // Contamos las órdenes de compra
                })
                .ToList()
                .Where(item => item.CantidadOrdenesPendientes > 0); // Filtramos solo los proveedores con órdenes pendientes

          // Convertir el resultado a una lista de tuplas y crear la colección de solo lectura
         var resultado = proveedoresConPendientes
         .Select(p => (
            RazonSocial: p.Proveedor.RazonSocial,
            Codigo: p.Proveedor.Codigo,
            CantidadOrdenesPendientes: p.CantidadOrdenesPendientes
         ))
        .OrderByDescending(p => p.CantidadOrdenesPendientes) // Ordenar de mayor a menor cantidad de órdenes pendientes
        .ToList();

            return new ReadOnlyCollection<(string RazonSocial, string Codigo, int CantidadOrdenesPendientes)>(resultado);
        }


        public ReadOnlyCollection<Pelicula> RecuperarPeliculasConBajaDisponibilidad()
        {
            var peliculasBajaDisponibilidad = Contexto.Instancia.Peliculas
                .Where(p => p.Cantidad< 30) 
                .ToList().AsReadOnly();

            return peliculasBajaDisponibilidad;
        }

    }
}
