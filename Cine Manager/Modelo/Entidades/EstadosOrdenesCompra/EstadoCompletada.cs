using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades.EstadosOrdenesCompra
{
    public class EstadoCompletada:IOrdenCompraState
    {
        public void Pagar(OrdenCompra orden)
        {
            throw new InvalidOperationException("La orden ya se encuentra completada.");
        }

        public void Cancelar(OrdenCompra orden)
        {
            throw new InvalidOperationException("No se puede cancelar una orden completada.");
        }

        public void Cerrar(OrdenCompra orden)
        {
            throw new InvalidOperationException("No se puede cerrar una orden completada.");
        }
    }
}
