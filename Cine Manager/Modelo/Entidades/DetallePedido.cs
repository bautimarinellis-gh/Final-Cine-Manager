using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public class DetallePedido
    {
        private int detallePedidoId;
        private Pelicula pelicula;
        private int cantidad;
        private decimal subtotal;
        private Pedido pedido;
        private int pedidoId;



        public int DetallePedidoId
        {
            get { return detallePedidoId; }
            set { detallePedidoId = value; }
        }


        public Pelicula Pelicula
        {
            get { return pelicula; }
            set { pelicula = value; }
        }


        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }


        public decimal Subtotal
        {
            get { return cantidad * (pelicula?.Precio ?? 0); } // Usa 0 si pelicula es null.
            set { subtotal = value; }
        }


        public Pedido Pedido
        {
            get { return pedido; }
            set { pedido = value; }
        }


        public int PedidoId
        {
            get { return pedidoId; }
            set { pedidoId = value; }
        }
        
    }
}
