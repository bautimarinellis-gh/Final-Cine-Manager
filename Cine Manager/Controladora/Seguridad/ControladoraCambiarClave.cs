using Microsoft.EntityFrameworkCore;
using Modelo.EFCore;
using Modelo.Módulo_de_Seguridad;
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



        public Usuario Buscar(string nombreUsuario)
        {
            var usuario = context.Usuarios.Include(u => u.EstadoUsuario)
                .Include(u => u.Componentes)
                .ThenInclude(c => (c as Accion).Formulario)
                .ThenInclude(f => f.Modulo).FirstOrDefault(u => u.NombreUsuario == nombreUsuario);

            if (usuario != null)
            {
                var grupos = usuario.Componentes.OfType<Grupo>().ToList();
                foreach (var grupo in grupos)
                {
                    // Cargar el estado del grupo
                    context.Entry(grupo).Reference(g => g.EstadoGrupo).Load();
                }
            }

            return usuario;

        }



        public string CambiarClave(int usuarioId, string nuevaClaveEncriptada)
        {
            try
            {
                var usuario = context.Usuarios.FirstOrDefault(u => u.UsuarioId == usuarioId);
                if (usuario != null)
                {
                    usuario.Clave = nuevaClaveEncriptada;
                    context.Usuarios.Update(usuario);
                    context.SaveChanges();
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
