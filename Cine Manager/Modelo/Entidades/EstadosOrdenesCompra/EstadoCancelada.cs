using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades.EstadosOrdenesCompra
{
    public class EstadoCancelada:IOrdenCompraState
    {
        public void Pagar(OrdenCompra orden)
        {
            throw new InvalidOperationException("No puedes pagar una orden cancelada.");
        }

        public void Cancelar(OrdenCompra orden)
        {
            throw new InvalidOperationException("La orden ya ha sido cancelada.");
        }
    }
}
