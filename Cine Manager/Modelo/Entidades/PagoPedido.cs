using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public class PagoPedido
    {
        private int pagoPedidoId;
        private Pedido pedido;
        private DateTime fechaPago;
        private string codigo;


        public int PagoPedidoId
        {
            get { return pagoPedidoId; }
            set { pagoPedidoId = value; }
        }
        

        public Pedido Pedido
        {
            get { return pedido; }
            set { pedido = value; }
        }


        public DateTime FechaPago
        {
            get { return fechaPago; }
            set { fechaPago = value; }
        }


        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

    }
}
