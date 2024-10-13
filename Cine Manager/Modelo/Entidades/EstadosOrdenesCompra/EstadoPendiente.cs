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
            if (orden.TodosLosDetallesPagos())
            {
                orden.CambiarEstado(new EstadoCompletada());
            }
            else if (orden.AlgunosDetallesPagos())
            {
                orden.CambiarEstado(new EstadoParcialmenteCompletada());
            }
        }

        public void Cancelar(OrdenCompra orden)
        {
            orden.CambiarEstado(new EstadoCancelada());
        }
    }
}
