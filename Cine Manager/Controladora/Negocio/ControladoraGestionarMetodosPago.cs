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
        }



        public ReadOnlyCollection<MetodoPago> RecuperarMetodosPago()
        {
            try
            {
                return Contexto.Instancia.MetodosPago.ToList().AsReadOnly();
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public MetodoPago Buscar(string nombre)
        {
            var metodoPago = Contexto.Instancia.MetodosPago.FirstOrDefault(m => m.Nombre.ToLower() == nombre.ToLower());
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

                return Contexto.Instancia.MetodosPago
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
                    Contexto.Instancia.MetodosPago.Add(metodoPago);
                    Contexto.Instancia.SaveChanges();
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
                    Contexto.Instancia.MetodosPago.Remove(metodoPago);
                    Contexto.Instancia.SaveChanges();
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
                var metodoPagoExistente = Contexto.Instancia.MetodosPago.FirstOrDefault(m => m.MetodoPagoId == metodoPago.MetodoPagoId);

                if (metodoPagoExistente != null)
                {
                    metodoPagoExistente.Nombre = metodoPago.Nombre;

                    Contexto.Instancia.MetodosPago.Update(metodoPagoExistente);
                    Contexto.Instancia.SaveChanges();

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
