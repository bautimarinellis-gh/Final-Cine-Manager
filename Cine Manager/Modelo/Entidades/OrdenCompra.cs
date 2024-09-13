using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public class OrdenCompra
    {
        private int ordenCompraId;
        private string codigo;
        private Proveedor proveedor;
        private List<DetalleOrdenCompra> detallesOrdenesCompra;
        private DateTime fechaOrden;
        private decimal total;
        private bool estado;



        public int OrdenCompraId
        {
            get { return ordenCompraId; }
            set { ordenCompraId = value; }
        }


        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }


        public Proveedor Proveedor
        {
            get { return proveedor; }
            set { proveedor = value; }
        }


        public List<DetalleOrdenCompra> DetallesOrdenesCompra
        {
            get { return detallesOrdenesCompra; }
            set { detallesOrdenesCompra = value; }
        }


        public DateTime FechaOrden
        {
            get { return fechaOrden; }
            set { fechaOrden = value; }
        }


        public decimal Total
        {
            get { return total; }
            set { total = value; }
        }


        public bool Estado
        {
            get { return estado;}
            set { estado = value; }
        }


        public string EstadoTexto
        {
            get { return estado ? "Completada" : "Pendiente"; }
        }


        public string? CodigoProveedor
        {
            get { return proveedor?.Codigo; }
        }



        public OrdenCompra()
        {
            detallesOrdenesCompra= new List<DetalleOrdenCompra>();
            total = 0;
        }



        public string AgregarDetalle(DetalleOrdenCompra detalle)
        {
            // Calcular el subtotal basado en la cantidad de películas y el precio por unidad
            decimal subtotal = detalle.Pelicula.Precio * detalle.Cantidad;

            // Agregar el detalle a la lista de detalles de la orden de compra
            detallesOrdenesCompra.Add(detalle);

            // Actualizar el total de la orden de compra sumando el subtotal del nuevo detalle
            Total += subtotal;

            // Retornar un mensaje de éxito
            return "Detalle agregado a la orden de compra.";
        }



        public string EliminarDetalle(DetalleOrdenCompra detalle)
        {
            // Buscar si el detalle (película) existe en la lista de detalles de la orden de compra
            var detalleExistente = detallesOrdenesCompra.FirstOrDefault(d => d.Pelicula == detalle.Pelicula);

            // Validar si el detalle no existe
            if (detalleExistente == null)
            {
                return "El detalle no está en la orden de compra.";
            }

            // Calcular el subtotal del detalle que se eliminará
            decimal subtotal = detalleExistente.Pelicula.Precio * detalleExistente.Cantidad;

            // Restar el subtotal del total de la orden
            Total -= subtotal;

            // Remover el detalle de la lista de detalles de la orden de compra
            detallesOrdenesCompra.Remove(detalleExistente);

            // Retornar mensaje de éxito
            return "Detalle eliminado de la orden de compra.";
        }


        public ReadOnlyCollection<DetalleOrdenCompra> RecuperarDetalles()
        {
            return detallesOrdenesCompra.ToList().AsReadOnly();
        }


        public void LimpiarDetalles()
        {
            detallesOrdenesCompra.Clear();
            Total = 0;
        }
    }
}
