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
    public class ControladoraPagarPedido
    {
        private static ControladoraPagarPedido instancia;
        private Contexto context;


        public static ControladoraPagarPedido Instancia
        {
            get
            {
                if(instancia == null)
                {
                    instancia = new ControladoraPagarPedido();
                }
                return instancia;
            }
        }


        public ControladoraPagarPedido()
        {
            context = new Contexto();
        }



        public Pedido Buscar(string codigo)
        {
            var pedido = context.Pedidos.FirstOrDefault(p => p.Codigo.ToLower() == codigo.ToLower());
            return pedido;
        }


        public string AgregarPagoPedido(PagoPedido pagoPedido)
        {
            try
            {

                var pedido = context.Pedidos.FirstOrDefault(p => p.PedidoId == pagoPedido.Pedido.PedidoId);

                var metodoPago = context.MetodosPago.FirstOrDefault(mp => mp.MetodoPagoId == pagoPedido.MetodoPago.MetodoPagoId);


                // Asignar la entidad del pedido cargada al pago
                pagoPedido.Pedido = pedido;
                pagoPedido.MetodoPago = metodoPago;

                context.PagosPedidos.Add(pagoPedido);
                context.SaveChanges();

                return "Pago realizado correctamente";
            }
            catch (Exception ex)
            {
                return ex.InnerException?.Message ?? ex.Message;
            }
        }



        //Mover a controladora PAGAR PEDIDO
        public bool ModificarPedido(Pedido pedido)
        {
            try
            {
                var pedidoExistente = Buscar(pedido.Codigo);

                if (pedidoExistente != null)
                {
                    pedidoExistente.Estado = pedido.Estado;

                    context.Pedidos.Update(pedidoExistente);
                    context.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
