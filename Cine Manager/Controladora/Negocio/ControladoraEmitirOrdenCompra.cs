using Microsoft.EntityFrameworkCore;
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
        }




        public ReadOnlyCollection<Pelicula> RecuperarPeliculas()
        {
            try
            {
                return Contexto.Instancia.Peliculas.ToList().AsReadOnly();
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


        public OrdenCompra Buscar(string codigo)
        {
            var orden = Contexto.Instancia.OrdenesCompra.FirstOrDefault(o => o.Codigo.ToLower() == codigo.ToLower());
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
                    var proveedor = Contexto.Instancia.Proveedores
                                           .Include(p => p.Peliculas) // Incluir las películas asociadas
                                           .FirstOrDefault(p => p.ProveedorId == orden.Proveedor.ProveedorId);
                    if (proveedor == null)
                    {
                        return "Proveedor no encontrado.";
                    }
                    orden.Proveedor = proveedor;

                    // Adjuntar detalles de la orden de compra
                    foreach (var detalle in orden.DetallesOrdenesCompra)
                    {
                        // Adjuntar la película existente al detalle de la orden de compra
                        var pelicula = Contexto.Instancia.Peliculas
                                             .Include(p => p.Proveedores) // Incluir los proveedores asociados
                                             .FirstOrDefault(p => p.PeliculaId == detalle.Pelicula.PeliculaId);
                        if (pelicula != null)
                        {
                            detalle.Pelicula = pelicula;

                            // Verificar y agregar la relación película-proveedor si no existe
                            if (!pelicula.Proveedores.Contains(proveedor))
                            {
                                pelicula.Proveedores.Add(proveedor);
                            }
                        }
                    }

                    // Agregar la nueva orden de compra a la base de datos
                    Contexto.Instancia.OrdenesCompra.Add(orden);
                    Contexto.Instancia.SaveChanges();

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
