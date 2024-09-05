using Modelo.EFCore;
using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class ControladoraGestionarClientes
    {
        private static ControladoraGestionarClientes instancia;
        private Contexto context;


        public static ControladoraGestionarClientes Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ControladoraGestionarClientes();
                }
                return instancia;
            }
        }



        public ControladoraGestionarClientes()
        {
            context = new Contexto();
        }


        public ReadOnlyCollection<Cliente> RecuperarClientes()
        {
            try
            {
                return context.Clientes.ToList().AsReadOnly();
            }
            catch(Exception ex)
            {
                throw;
            }
        }



        public ReadOnlyCollection<Cliente> FiltrarClientes(int? dniBusqueda = null) //admite valores nulos o un valor entero
        {
            try
            {
                if (!dniBusqueda.HasValue)
                {                    
                    // Si no se pasa un DNI específico, devolver todos los clientes
                    return RecuperarClientes(); 
                }
                else
                {
                    // Filtrar clientes cuyo DNI coincida con la búsqueda
                    return context.Clientes
                        .Where(p => p.DNI == dniBusqueda.Value)
                        .ToList()
                        .AsReadOnly();
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción
                throw new Exception("Ocurrió un error al filtrar clientes.", ex);
            }
        }



        public Cliente Buscar(int dni)
        {
            var cliente = context.Clientes.FirstOrDefault(c => c.DNI == dni);
            return cliente;
        }



        public string AgregarCliente(Cliente cliente)
        {
            try
            {
                var clienteExistente = Buscar(cliente.DNI);

                if (clienteExistente == null)
                {
                    context.Clientes.Add(cliente);
                    context.SaveChanges();

                    return "Cliente agregado correctamente";
                }
                else
                {
                    return "El cliente ya existe";
                }
            }
            catch (Exception ex)
            {
                return "Error desconocido";
            }
        }



        public string EliminarCliente(Cliente cliente)
        {
            try
            {
                var clienteExistente = Buscar(cliente.DNI);

                if (clienteExistente != null)
                {
                    context.Clientes.Remove(cliente);
                    context.SaveChanges();

                    return "Cliente eliminado correctamente";
                }
                else
                {
                    return "El cliente no existe";
                }
            }
            catch (Exception ex)
            {
                return "Error desconocido";
            }
        }



        public string ModificarCliente(Cliente cliente)
        {
            try
            {
                // Buscar cliente existente por ID, no por DNI
                var clienteExistente = context.Clientes.FirstOrDefault(c => c.ClienteId== cliente.ClienteId);

                if (clienteExistente != null)
                {
                    clienteExistente.Nombre= cliente.Nombre;
                    clienteExistente.Apellido = cliente.Apellido;
                    clienteExistente.DNI= cliente.DNI;


                    context.Clientes.Update(clienteExistente);
                    context.SaveChanges();

                    return "Cliente modificado correctamente";
                }
                else
                {
                    return "El cliente no existe";
                }
            }
            catch (Exception ex)
            {
                return "Error desconocido";
            }
        }
    }
}
