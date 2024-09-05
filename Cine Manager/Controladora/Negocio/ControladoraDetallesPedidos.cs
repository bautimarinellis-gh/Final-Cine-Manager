using Microsoft.EntityFrameworkCore;
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
    public class ControladoraDetallesPedidos
    {
        private static ControladoraDetallesPedidos instancia;
        private Contexto context;

        public static ControladoraDetallesPedidos Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ControladoraDetallesPedidos();
                }
                return instancia;
            }
        }

        public ControladoraDetallesPedidos()
        {
            context = new Contexto();
        }



        public DetallePedido Buscar(int id)
        {
            var detallePedido = context.DetallesPedidos.FirstOrDefault(dp=> dp.DetallePedidoId== id);
            return detallePedido;
        }


        public ReadOnlyCollection<DetalleVenta> RecuperarDetallesVenta(Pedido pedido)
        {
            try
            {
                // Recuperar detalles de venta directamente desde la base de datos
                return context.DetallesVentas.Where(dv => dv.PedidoId == pedido.PedidoId).ToList().AsReadOnly();
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public ReadOnlyCollection<DetalleAlquiler> RecuperarDetallesAlquiler(Pedido pedido)
        {
            try
            {
                // Recuperar detalles de alquiler directamente desde la base de datos
                return context.DetallesAlquileres.Where(da => da.PedidoId == pedido.PedidoId).ToList().AsReadOnly();
            }
            catch (Exception ex)
            {
                throw; ;
            }
        }



        public string ModificarDetalleAlquiler(DetalleAlquiler detalleAlquiler)
        {
            try
            {
                var detalleAlquilerExistente = ObtenerDetalleAlquilerExistente(detalleAlquiler.DetallePedidoId);

                if (detalleAlquilerExistente == null)
                    return "El detalle alquiler no existe";

                var detalleAlquilerExistenteCast = detalleAlquilerExistente as DetalleAlquiler;
                if (detalleAlquilerExistenteCast == null)
                    return "El Detalle no es un DetalleAlquiler";

                detalleAlquilerExistenteCast.Devuelto = true;

                var pedidoDetalle = detalleAlquilerExistenteCast.Pedido;
                if (pedidoDetalle == null)
                    return "No se encontró un pedido asociado para este detalle de alquiler";

                var resultado = RestaurarCantidadPeliculas(pedidoDetalle);
                if (resultado != "Éxito")
                    return resultado;

                context.DetallesPedidos.Update(detalleAlquilerExistenteCast);
                context.SaveChanges();

                return "Detalle Alquiler devuelto correctamente";
            }
            catch (Exception ex)
            {
                return "Error desconocido: " + ex.Message;
            }
        }


        private DetallePedido ObtenerDetalleAlquilerExistente(int detallePedidoId)
        {
            return context.DetallesPedidos
                .Include(dp => dp.Pedido) // Incluir el pedido asociado
                .Include(dp => dp.Pelicula) // Incluir las películas asociadas a los detalles
                .FirstOrDefault(dp => dp.DetallePedidoId == detallePedidoId);
        }



        private string RestaurarCantidadPeliculas(Pedido pedidoDetalle)
        {
            var detalles = pedidoDetalle.RecuperarDetalles();
            if (detalles == null || detalles.Count == 0)
                return "No se encontraron detalles en el pedido asociado";

            foreach (var detalle in detalles)
            {
                var peliculaAlquilada = detalle.Pelicula;
                if (peliculaAlquilada == null)
                    return "PeliculaAlquilada es null";

                peliculaAlquilada.Cantidad += detalle.Cantidad; // Restaurar la cantidad de películas disponibles

                var actualizado = ControladoraGestionarPeliculas.Instancia.ActualizarStockPeliculas(peliculaAlquilada);
                if (!actualizado)
                    return $"No se pudo actualizar el stock para Pelicula ID: {peliculaAlquilada.Codigo}";
            }
            return "Éxito";
        }
    }
}
