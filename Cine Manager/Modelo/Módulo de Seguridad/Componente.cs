using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Módulo_de_Seguridad
{
    public abstract class Componente
    {

        private int id;
        private string nombre;
        private List<Usuario> usuarios;
        private List<Grupo> grupos;


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        public List<Usuario> Usuarios
        {
            get { return usuarios; }
            set { usuarios = value; }
        }

        public List<Grupo> Grupos
        {
            get { return grupos; }
            set { grupos = value;}
        }


        public Componente()
        {
            usuarios = new List<Usuario>();
            grupos = new List<Grupo>();
        }


        public abstract void Agregar(Componente componente);
        public abstract void Eliminar(Componente componente);
        public abstract List<Componente> RecuperarHijos();

        
    }

    
}
