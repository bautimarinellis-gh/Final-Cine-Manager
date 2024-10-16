using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades.EstadosOrdenesCompra
{
    public class EstadoPendiente:IOrdenCompraState
    {
        public void Pagar(OrdenCompra orden)
        {
            if (orden.TodosLosDetallesEntregados())
            {
                orden.CambiarEstado(new EstadoCompletada());
            }
            else if (orden.HayItemsEnDetalle())
            {
                orden.CambiarEstado(new EstadoParcialmenteCompletada());
            }
        }



        public void Cancelar(OrdenCompra orden)
        {
            orden.CambiarEstado(new EstadoCancelada());
        }



        public void Cerrar(OrdenCompra orden)
        {
            if (orden.HayItemsEnDetalle())
            {
                orden.CambiarEstado(new EstadoCerradaConFaltante());
            }
            else
            {
                throw new InvalidOperationException("No se puede cerrar una orden pendiente sin al menos algún detalle entregado.");
            }
        }
    }
}
