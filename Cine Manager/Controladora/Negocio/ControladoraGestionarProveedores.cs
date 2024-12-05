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
        }




        public ReadOnlyCollection<Proveedor> RecuperarProveedores()
        {
            try
            {
                return Contexto.Instancia.Proveedores.ToList().AsReadOnly();
            }
            catch (Exception ex)
            {
                throw;
            }
        }




        public Proveedor Buscar(string codigo)
        {
            var proveedor = Contexto.Instancia.Proveedores.FirstOrDefault(p => p.Codigo.ToLower() == codigo.ToLower());
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

                return Contexto.Instancia.Proveedores
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
                    Contexto.Instancia.Proveedores.Add(proveedor);
                    Contexto.Instancia.SaveChanges();

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
                    Contexto.Instancia.Proveedores.Remove(proveedor);
                    Contexto.Instancia.SaveChanges();

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
                var proveedorExistente = Contexto.Instancia.Proveedores.FirstOrDefault(p => p.ProveedorId== proveedor.ProveedorId);

                if (proveedorExistente != null)
                {
                    proveedorExistente.Codigo = proveedor.Codigo;
                    proveedorExistente.Cuit = proveedor.Cuit;
                    proveedorExistente.RazonSocial = proveedor.RazonSocial;
                    

                    Contexto.Instancia.Proveedores.Update(proveedorExistente);
                    Contexto.Instancia.SaveChanges();

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
            return Contexto.Instancia.Proveedores.Any(p => p.Cuit == cuit);
        }
    }
}
