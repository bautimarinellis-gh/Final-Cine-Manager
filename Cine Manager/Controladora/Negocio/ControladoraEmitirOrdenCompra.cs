using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Modelo.EFCore;
using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.Nueva_Iteración
{
    public class ControladoraEmitirOrdenCompra
    {
        private Contexto context;
        private static ControladoraEmitirOrdenCompra instancia;


        public static ControladoraEmitirOrdenCompra Instancia
        {
            get
            {
                if(instancia == null)
                {
                    instancia = new ControladoraEmitirOrdenCompra();
                }
                return instancia;
            }
        }


        public ControladoraEmitirOrdenCompra()
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


        public OrdenCompra Buscar(string codigo)
        {
            var orden = context.OrdenesCompra.FirstOrDefault(o => o.Codigo.ToLower() == codigo.ToLower());
            return orden;
        }



        public string AgregarOrdenCompra(OrdenCompra orden)
        {
            try
            {
                var ordenExistente = Buscar(orden.Codigo);

                if (ordenExistente == null)
                {
                    // Asignar el proveedor existente a la orden
                    var proveedor = context.Proveedores.FirstOrDefault(p => p.ProveedorId == orden.Proveedor.ProveedorId);
                    orden.Proveedor = proveedor;

                    // Adjuntar detalles de la orden de compra sin modificar el stock
                    foreach (var detalle in orden.DetallesOrdenesCompra)
                    {
                        // Adjuntar la película existente al detalle de la orden de compra
                        var pelicula = context.Peliculas.FirstOrDefault(p => p.PeliculaId == detalle.Pelicula.PeliculaId);
                        if (pelicula != null)
                        {
                            detalle.Pelicula = pelicula;
                        }
                    }

                    context.OrdenesCompra.Add(orden);
                    context.SaveChanges();

                    return "Orden de compra emitida correctamente";
                }
                else
                {
                    return "Ya existe una orden con este código";
                }
            }
            catch (Exception ex)
            {
                return ex.InnerException?.Message ?? ex.Message;
            }
        }
    }
}
