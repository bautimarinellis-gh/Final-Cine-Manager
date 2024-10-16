using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public interface IOrdenCompraState
    {
        void Pagar(OrdenCompra orden);
        void Cancelar(OrdenCompra orden);
        void Cerrar(OrdenCompra orden);

    }
}
