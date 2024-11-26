using Microsoft.EntityFrameworkCore;
using Modelo.EFCore;
using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class ControladoraGestionarPedidos
    {
        private static ControladoraGestionarPedidos instancia;
        private Contexto context;



        public static ControladoraGestionarPedidos Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ControladoraGestionarPedidos();
                }
                return instancia;
            }
        }



        private ControladoraGestionarPedidos()
        {
            context = new Contexto();
        }


        public ReadOnlyCollection<Pedido> RecuperarPedidos()
        {
            try
            {
                return context.Pedidos.AsNoTracking().Include(c => c.Cliente).ToList().AsReadOnly();
            }
            catch(Exception ex)
            {
                throw;
            }
        }



        public ReadOnlyCollection<Pedido> FiltrarPedidos(int? dniBusqueda = null) //admite valores nulos o un valor entero
        {
            try
            {
                if (!dniBusqueda.HasValue)
                {
                    // Si no se pasa un DNI específico, devolver todos los clientes
                    return RecuperarPedidos();
                }
                else
                {
                    // Filtrar clientes cuyo DNI coincida con la búsqueda
                    return context.Pedidos
                        .Where(p => p.Cliente.DNI == dniBusqueda.Value)
                        .ToList()
                        .AsReadOnly();
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción
                throw new Exception("Ocurrió un error al filtrar pedidos.", ex);
            }
        }
    }
}
