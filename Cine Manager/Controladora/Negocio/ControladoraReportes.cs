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
        private Contexto context;
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
            context = new Contexto();
        }



        public ReadOnlyCollection<(Pelicula, int)> RecuperarPeliculasMasVendidas()
        {
            var peliculasVendidas = context.DetallesPedidos
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

    }
}
