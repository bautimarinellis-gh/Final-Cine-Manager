using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public class ControladoraGestionarMetodosPago
    {
        private Contexto context;
        private static ControladoraGestionarMetodosPago instancia;



        public static ControladoraGestionarMetodosPago Instancia
        {
            get
            {
                if(instancia == null)
                {
                    instancia = new ControladoraGestionarMetodosPago();
                }
                return instancia;
            }
        }


        public ControladoraGestionarMetodosPago()
        {
            context = new Contexto();
        }



        public ReadOnlyCollection<MetodoPago> RecuperarMetodosPago()
        {
            try
            {
                return context.MetodosPago.ToList().AsReadOnly();
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public MetodoPago Buscar(string nombre)
        {
            var metodoPago = context.MetodosPago.FirstOrDefault(m => m.Nombre.ToLower() == nombre.ToLower());
            return metodoPago;
        }



        public ReadOnlyCollection<MetodoPago> FiltrarMetodosPago(string textoBusqueda)
        {
            try
            {
                if (string.IsNullOrEmpty(textoBusqueda))
                {
                    return RecuperarMetodosPago();
                }

                return context.MetodosPago
                    .Where(m => m.Nombre.ToLower().Contains(textoBusqueda.ToLower()))
                    .ToList()
                    .AsReadOnly();
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public string AgregarMetodoPago(MetodoPago metodoPago)
        {
            try
            {
                var metodoPagoExistente = Buscar(metodoPago.Nombre);

                if (metodoPagoExistente == null)
                {
                    context.MetodosPago.Add(metodoPago);
                    context.SaveChanges();
                    return "Método de pago agregado correctamente";
                }
                else
                {
                    return "El método de pago ya existe";
                }
            }
            catch (Exception ex)
            {
                return "Error desconocido";
            }
        }



        public string EliminarMetodoPago(MetodoPago metodoPago)
        {
            try
            {
                var metodoPagoExistente = Buscar(metodoPago.Nombre);

                if (metodoPagoExistente != null)
                {
                    context.MetodosPago.Remove(metodoPago);
                    context.SaveChanges();
                    return "Método de pago eliminado correctamente";
                }
                else
                {
                    return "El método de pago no existe";
                }
            }
            catch (Exception ex)
            {
                return "Error desconocido";
            }
        }



        public string ModificarMetodoPago(MetodoPago metodoPago)
        {
            try
            {
                var metodoPagoExistente = context.MetodosPago.FirstOrDefault(m => m.MetodoPagoId == metodoPago.MetodoPagoId);

                if (metodoPagoExistente != null)
                {
                    metodoPagoExistente.Nombre = metodoPago.Nombre;

                    context.MetodosPago.Update(metodoPagoExistente);
                    context.SaveChanges();

                    return "Método de pago modificado correctamente";
                }
                else
                {
                    return "El método de pago no existe";
                }
            }
            catch (Exception ex)
            {
                return "Error desconocido";
            }
        }
    }
}
