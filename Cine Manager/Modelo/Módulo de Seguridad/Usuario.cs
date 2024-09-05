using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Módulo_de_Seguridad
{
    public class Usuario
    {
        private int usuarioId;
        private string nombreUsuario;
        private string nombre;
        private string apellido;
        private string clave;
        private string email;
        private EstadoUsuario estadoUsuario;
        private List<Componente> componentes;

       

        public int UsuarioId
        {
            get { return usuarioId; }
            set { usuarioId = value; }
        }

        public string NombreUsuario
        {
            get { return nombreUsuario; }
            set { nombreUsuario = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string Clave
        {
            get { return clave; }
            set { clave = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public EstadoUsuario EstadoUsuario
        {
            get { return estadoUsuario; }
            set { estadoUsuario = value; }
        }

        public List<Componente> Componentes
        {
            get { return componentes; }
            set { componentes = value; }
        }
       

      

        public Usuario()
        {
            componentes = new List<Componente>();
        }
    }
}

