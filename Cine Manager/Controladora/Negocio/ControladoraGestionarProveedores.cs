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
    public class ControladoraGestionarProveedores
    {
        private static ControladoraGestionarProveedores instancia;
        private Contexto context;



        public static ControladoraGestionarProveedores Instancia
        {
            get
            {
                if(instancia == null)
                {
                    instancia = new ControladoraGestionarProveedores();
                }
                return instancia;
            }
        }



        public ControladoraGestionarProveedores()
        {
            context = new Contexto();
        }




        public ReadOnlyCollection<Proveedor> RecuperarProveedores()
        {
            try
            {
                return context.Proveedores.ToList().AsReadOnly();
            }
            catch (Exception ex)
            {
                throw;
            }
        }




        public Proveedor Buscar(string codigo)
        {
            var proveedor = context.Proveedores.FirstOrDefault(p => p.Codigo.ToLower() == codigo.ToLower());
            return proveedor;
        }




        public ReadOnlyCollection<Proveedor> FiltrarProveedores(string textoBusqueda)
        {
            try
            {
                if (string.IsNullOrEmpty(textoBusqueda))
                {
                    return RecuperarProveedores(); // Devuelve todos los proveedores si el cuit está vacío
                }

                return context.Proveedores
                    .Where(p => p.Codigo.ToLower().Contains(textoBusqueda.ToLower()))
                    .ToList()
                    .AsReadOnly();
            }
            catch (Exception ex)
            {
                throw;
            }
        }




        public string AgregarProveedor(Proveedor proveedor)
        {
            try
            {
                var proveedorExistente = Buscar(proveedor.Codigo);

                if (proveedorExistente == null)
                {
                    context.Proveedores.Add(proveedor);
                    context.SaveChanges();

                    return "Proveedor agregado correctamente";
                }
                else
                {
                    return "El provedor ya existe";
                }
            }
            catch (Exception ex)
            {
                return "Error desconocido";
            }
        }




        public string EliminarProveedor(Proveedor proveedor)
        {
            try
            {
                var proveedorExistente = Buscar(proveedor.Codigo);

                if (proveedorExistente != null)
                {
                    context.Proveedores.Remove(proveedor);
                    context.SaveChanges();

                    return "Proveedor eliminado correctamente";
                }
                else
                {
                    return "El proveedor no existe";
                }
            }
            catch (Exception ex)
            {
                return "Error desconocido";
            }
        }




        public string ModificarProveedor(Proveedor proveedor)
        {
            try
            {
                //Buscar proveedor existente por ID, no por codigo
                var proveedorExistente = context.Proveedores.FirstOrDefault(p => p.ProveedorId== proveedor.ProveedorId);

                if (proveedorExistente != null)
                {
                    proveedorExistente.Codigo = proveedor.Codigo;
                    proveedorExistente.Cuit = proveedor.Cuit;
                    proveedorExistente.RazonSocial = proveedor.RazonSocial;
                    

                    context.Proveedores.Update(proveedorExistente);
                    context.SaveChanges();

                    return "Proveedor modificado correctamente";
                }
                else
                {
                    return "El proveedor no existe";
                }
            }
            catch (Exception ex)
            {
                return "Error desconocido";
            }
        }


        public bool ExisteProveedorConCUIT(long cuit)
        {
            return context.Proveedores.Any(p => p.Cuit == cuit);
        }
    }
}
