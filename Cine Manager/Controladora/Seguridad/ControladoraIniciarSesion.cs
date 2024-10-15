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
    public class ControladoraIniciarSesion
    {
        private static ControladoraIniciarSesion instancia;
        private Contexto context;


        public static ControladoraIniciarSesion Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ControladoraIniciarSesion();
                }
                return instancia;
            }
        }


        public ControladoraIniciarSesion()
        {
            context = new Contexto();
        }



        

        public Usuario Buscar(string nombreUsuario)
        {
            var usuario = context.Usuarios.Include(u => u.EstadoUsuario).Include(u => u.Componentes).ThenInclude(c => (c as Accion).Formulario)
        .ThenInclude(f => f.Modulo)
        .FirstOrDefault(u => u.NombreUsuario == nombreUsuario);

            if (usuario != null)
            {
                var grupos = usuario.Componentes.OfType<Grupo>().ToList();
                foreach (var grupo in grupos)
                {
                    // Cargar el estado del grupo
                    context.Entry(grupo).Reference(g => g.EstadoGrupo).Load();

                    // Cargar todos los componentes del grupo (sin filtrar por Accion aún)
                    context.Entry(grupo).Collection(g => g.Componentes).Load();

                    // Filtrar los componentes que sean de tipo Accion
                    var accionesDelGrupo = grupo.Componentes.OfType<Accion>().ToList();

                }
            }

            return usuario;

        }



    }
}
