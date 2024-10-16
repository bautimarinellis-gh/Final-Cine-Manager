using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades.EstadosOrdenesCompra
{
    public class EstadoCerradaConFaltante:IOrdenCompraState
    {
        public void Pagar(OrdenCompra orden)
        {
            throw new InvalidOperationException("No puedes pagar una orden cerrada con faltante.");
        }

        public void Cancelar(OrdenCompra orden)
        {
            throw new InvalidOperationException("No se puede cancelar una orden que ya fue cerrada con faltante.");
        }

        public void Cerrar(OrdenCompra orden)
        {
            throw new InvalidOperationException("La orden ya está cerrada.");
        }
    }
}
