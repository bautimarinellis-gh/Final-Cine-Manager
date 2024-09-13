using Modelo.EFCore;
using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.Negocio
{
    public class ControladoraGestionarOrdenesCompra
    {
        private Contexto context;
        private static ControladoraGestionarOrdenesCompra instancia;


        public static ControladoraGestionarOrdenesCompra Instancia
        {
            get
            {
                if(instancia == null)
                {
                    instancia = new ControladoraGestionarOrdenesCompra();
                }
                return instancia;
            }
        }


        public ControladoraGestionarOrdenesCompra()
        {
            context = new Contexto();
        }



        public ReadOnlyCollection<OrdenCompra> RecuperarOrdenesCompra()
        {
            try
            {
                return context.OrdenesCompra.ToList().AsReadOnly();

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
