using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Módulo_de_Seguridad
{
    public class Sesion
    {
        private int sesionId;
        private Usuario usuarioSesion;
        private List<Accion> sesionPerfil;


        public int SesionId
        {
            get { return sesionId; }
            set { sesionId = value; }
        }

        public Usuario UsuarioSesion
        {
            get { return usuarioSesion; }
            set { usuarioSesion = value; }
        }

        public List<Accion> SesionPerfil
        {
            get { return sesionPerfil; }
            set { sesionPerfil = value; }
        }


        public Sesion()
        {
            sesionPerfil = new List<Accion>();
        }



        // Método para obtener todas las acciones del perfil de la sesión
        public List<Accion> GetPerfil()
        {
            return sesionPerfil;
        }
    }
}
