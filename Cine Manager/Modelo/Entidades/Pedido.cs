using Microsoft.EntityFrameworkCore;
using Modelo.EFCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public class Pedido
    {
        private int pedidoId;
        private string codigo;
        private List<DetallePedido> detallesPedido;
        private decimal total;
        private Cliente cliente;
        private DateTime fecha;
        private bool estado;
        private bool recargo;



        public int PedidoId
        {
            get { return pedidoId; }
            set { pedidoId = value; }
        }


        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }



        public List<DetallePedido> DetallesPedido
        {
            get { return detallesPedido; }
            set {  detallesPedido = value; }
        }


        public decimal Total
        {
            get { return total; }
            set { total = value; }
        }


        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }


        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }


        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }


        public bool Recargo
        {
            get { return recargo; }
            set { recargo = value; }
        }




        private Contexto context;


        public Pedido()
        {
            detallesPedido = new List<DetallePedido>();
            total = 0;

            context = new Contexto();
        }



        public string AgregarDetalle(DetallePedido detalle, bool esAlquiler)
        {
            if (detalle.Pelicula.Cantidad <= 0 || detalle.Pelicula.Cantidad < detalle.Cantidad)
            {
                return "No hay suficiente stock de la película seleccionada.";
            }

            decimal subtotal = detalle.Pelicula.Precio * detalle.Cantidad; // Calcula el subtotal basado en el precio y la cantidad
            detallesPedido.Add(detalle);

            if (esAlquiler)
            {
                Total += subtotal / 2; // Añade la mitad del subtotal al total del pedido
            }
            else
            {
                Total += subtotal;
            }

            return "Película agregada al carrito.";
        }




        public string EliminarDetalle(DetallePedido detalle, bool esAlquiler)
        {
            var detalleExistente = detallesPedido.FirstOrDefault(d => d.Pelicula == detalle.Pelicula);
            if (detalleExistente == null)
            {
                return "La película no está en el carrito.";
            }

            decimal subtotal = detalleExistente.Subtotal;

            if (esAlquiler)
            {
                Total -= subtotal / 2;
            }
            else
            {
                Total -= subtotal;
            }

            detallesPedido.Remove(detalleExistente);

            return "Película eliminada del carrito.";
        }



        public ReadOnlyCollection<DetallePedido> RecuperarDetalles()
        {
            return detallesPedido.ToList().AsReadOnly();
        }




        public void AumentoPedido()
        {
            // Obtener todos los pedidos del contexto
            var pedidos = context.Pedidos.Include(p => p.DetallesPedido).ToList();
            // Iterar sobre los pedidos en paralelo
            Parallel.ForEach(pedidos, pedido =>
            {
                lock (pedido) // Bloquear el pedido para evitar concurrencia
                {
                    // Filtrar los detalles de alquiler del pedido actual
                    var detallesAlquiler = pedido.DetallesPedido.OfType<DetalleAlquiler>().ToList();
                    // Verificar si hay algún detalle de alquiler vencido y el recargo no ha sido aplicado
                    if (!pedido.recargo && detallesAlquiler.Any(alquiler => alquiler.FechaDevolucion < DateTime.Now && !alquiler.Devuelto))
                    {
                        // Calcula el aumento del 30%
                        decimal aumento = pedido.total * 0.3m;
                        // Actualiza el total del pedido con el aumento
                        pedido.total += aumento;
                        // Marca el recargo como aplicado
                        pedido.recargo = true;
                        // Guardar los cambios en la base de datos
                        context.SaveChanges();
                    }
                }
            });
        }








        public void LimpiarDetalles()
        {
            detallesPedido.Clear();
            Total = 0;
        }



        public override string ToString()
        {
            return $"{Codigo}";
        }
    }
}
