using Modelo.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public class DetalleAlquiler:DetallePedido
    {
        private int detalleAlquilerId;
        private DateTime fechaDevolucion;
        private bool devuelto;



        public int DetalleAlquilerId
        {
            get { return detalleAlquilerId;}
            set { detalleAlquilerId = value; }
        }


        public DateTime FechaDevolucion
        {
            get { return fechaDevolucion; }
            set { fechaDevolucion = value; }
        }


        public bool Devuelto
        {
            get { return devuelto; }
            set { devuelto = value; }
        }

    }
}
