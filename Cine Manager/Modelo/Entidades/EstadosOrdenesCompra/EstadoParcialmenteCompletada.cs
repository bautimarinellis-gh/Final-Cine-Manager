using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades.EstadosOrdenesCompra
{
    public class EstadoParcialmenteCompletada:IOrdenCompraState
    {
        public void Pagar(OrdenCompra orden)
        {
            if (orden.TodosLosDetallesEntregados())
            {
                orden.CambiarEstado(new EstadoCompletada());
            }
            else
            {
                throw new InvalidOperationException("La orden sigue parcialmente completada, aún quedan detalles por pagar.");
            }
        }



        public void Cancelar(OrdenCompra orden)
        {
            orden.CambiarEstado(new EstadoCancelada());
        }



        public void Cerrar(OrdenCompra orden)
        {
            if (!orden.TodosLosDetallesEntregados())
            {
                orden.CambiarEstado(new EstadoCerradaConFaltante());
            }
            else
            {
                throw new InvalidOperationException("No se puede cerrar una orden parcialmente completada cuando todos los detalles están entregados.");
            }
        }
    }
}
