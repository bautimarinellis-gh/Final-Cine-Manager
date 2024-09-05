using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public class DetalleVenta:DetallePedido
    {
        private int detalleVentaId;
        private bool garantia;
        


        public int DetalleVentaId
        {
            get { return detalleVentaId; }
            set { detalleVentaId = value; }
        }


        public bool Garantia
        {
            get { return garantia; }
            set { garantia = value; }
        }
    }
}
