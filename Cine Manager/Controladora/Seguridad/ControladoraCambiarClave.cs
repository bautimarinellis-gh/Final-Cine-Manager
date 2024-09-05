using Modelo.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.Seguridad
{
    public class ControladoraCambiarClave
    {
        private static ControladoraCambiarClave instancia;
        private Contexto context;

        
        public static ControladoraCambiarClave Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ControladoraCambiarClave();
                }
                return instancia;
            }
        }


        public ControladoraCambiarClave()
        {
            context = new Contexto();
        }



        public string CambiarClave(int usuarioId, string nuevaClaveEncriptada)
        {
            try
            {
                var usuario = context.Usuarios.FirstOrDefault(u => u.UsuarioId == usuarioId);
                if (usuario != null)
                {
                    usuario.Clave = nuevaClaveEncriptada;
                    context.SaveUsuario(usuario);
                    return "La clave ha sido cambiada exitosamente.";
                }
                else
                {
                    return "Usuario no encontrado.";
                }
            }
            catch (Exception ex)
            {
                return $"Error al cambiar la clave: {ex.Message}";
            }
        }
    }
}
