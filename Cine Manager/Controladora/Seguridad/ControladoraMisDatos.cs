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
        private Contexto context;


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
            context = new Contexto();
        }


        public string ObtenerEstadoUsuario(int usuarioId)
        {
            var usuario = context.Usuarios
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
