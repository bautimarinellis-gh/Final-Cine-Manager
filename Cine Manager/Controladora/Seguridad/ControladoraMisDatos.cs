using Microsoft.EntityFrameworkCore;
using Modelo.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.Seguridad
{
    public class ControladoraMisDatos
    {
        private static ControladoraMisDatos instancia;

        public static ControladoraMisDatos Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ControladoraMisDatos();
                }
                return instancia;
            }
        }


        public ControladoraMisDatos()
        {
        }


        public string ObtenerEstadoUsuario(int usuarioId)
        {
            var usuario = Contexto.Instancia.Usuarios
                         .Include(u => u.EstadoUsuario)
                         .FirstOrDefault(u => u.UsuarioId == usuarioId);

            if (usuario != null && usuario.EstadoUsuario != null)
            {
                return usuario.EstadoUsuario.EstadoUsuarioNombre;
            }

            return "EstadoUsuario inexistente";
        }
    }
}
