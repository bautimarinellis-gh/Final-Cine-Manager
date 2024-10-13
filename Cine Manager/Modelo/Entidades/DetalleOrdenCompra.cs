using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public class DetalleOrdenCompra
    {
        private int detalleOrdenCompraId;
        private Pelicula pelicula;
        private int cantidad;
        private decimal subtotal;
        private bool estado;
        private OrdenCompra ordenCompra;
        private int ordenCompraId;


        public int DetalleOrdenCompraId
        {
            get { return detalleOrdenCompraId; }
            set { detalleOrdenCompraId = value; }
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
            get { return subtotal * pelicula.Precio; }
            set { subtotal = value; }
        }


        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }


        public OrdenCompra OrdenCompra
        {
            get { return ordenCompra; }
            set { ordenCompra = value; }
        }


        public int OrdenCompraId
        {
            get { return ordenCompraId; }
            set { ordenCompraId = value; }
        }
    } 
}
 