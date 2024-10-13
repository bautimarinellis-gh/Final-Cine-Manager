using Modelo.Entidades.EstadosOrdenesCompra;
using Modelo.Módulo_de_Seguridad;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
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
        private IOrdenCompraState estadoActual;
        private string estado; // Variable para almacenar el estado

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

        public string? CodigoProveedor
        {
            get { return proveedor?.Codigo ?? string.Empty; } // Manejo más explícito de null
        }

        [NotMapped]
        public IOrdenCompraState EstadoActual
        {
            get { return estadoActual; }
            set
            {
                estadoActual = value;
                Estado = ObtenerNombreEstado(estadoActual); // Actualizamos el string para la base de datos
            }
        }

        public string Estado
        {
            get { return estado; }
            set
            {
                estado = value;
                estadoActual = AsignarEstado(estado); // Asignamos el estado cuando se carga desde la base de datos
            }
        }

        // Método para obtener el nombre del estado actual
        private string ObtenerNombreEstado(IOrdenCompraState estado)
        {
            if (estado is EstadoCompletada)
                return "Completada";
            else if (estado is EstadoPendiente)
                return "Pendiente";
            else if (estado is EstadoCancelada)
                return "Cancelada";
            else if (estado is EstadoParcialmenteCompletada)
                return "Parcialmente Completada";
            else
                return "Desconocido"; // O un valor por defecto
        }

        public IOrdenCompraState AsignarEstado(string estado)
        {
            switch (estado)
            {
                case "Completada":
                    return new EstadoCompletada();
                case "Pendiente":
                    return new EstadoPendiente();
                case "Cancelada":
                    return new EstadoCancelada();
                case "Parcialmente Completada":
                    return new EstadoParcialmenteCompletada();
                default:
                    throw new InvalidOperationException("Estado desconocido");
            }
        }

        public OrdenCompra()
        {
            detallesOrdenesCompra = new List<DetalleOrdenCompra>();
            total = 0;
            estadoActual = new EstadoPendiente(); // Por defecto, el estado es "Pendiente"
            estado = "Pendiente";
        }



        public void Pagar()
        {
            EstadoActual.Pagar(this);
        }



        public void Cancelar()
        {
            EstadoActual.Cancelar(this);
        }



        public bool TodosLosDetallesPagos()
        {
            return detallesOrdenesCompra.All(detalle => detalle.Estado == true); 
        }



        public bool AlgunosDetallesPagos()
        {
            return detallesOrdenesCompra.Any(detalle => detalle.Estado == true) && detallesOrdenesCompra.Any(detalle => detalle.Estado == false);
        }



        public void CambiarEstado(IOrdenCompraState nuevoEstado)
        {
            EstadoActual = nuevoEstado;
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



        public override string ToString()
        {
            return $"Código: {Codigo}, Estado: {Estado}"; // Puedes incluir más información si lo deseas
        }

    }
}
