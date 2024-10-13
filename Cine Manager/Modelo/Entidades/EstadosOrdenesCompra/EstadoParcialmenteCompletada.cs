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
            if (orden.TodosLosDetallesPagos())
            {
                // La orden pasa de "Parcialmente Completada" a "Completada"
                orden.CambiarEstado(new EstadoCompletada());
            }
            else
            {
                // Sigue en estado "Parcialmente Completada" hasta que todos los detalles estén pagados
                throw new InvalidOperationException("La orden sigue parcialmente completada, aún quedan detalles por pagar.");
            }
        }

        public void Cancelar(OrdenCompra orden)
        {
            // Se permite cancelar incluso cuando está parcialmente completada
            orden.CambiarEstado(new EstadoCancelada());
        }
    }
}
