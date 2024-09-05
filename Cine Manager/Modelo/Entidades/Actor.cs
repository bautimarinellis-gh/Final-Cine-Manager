using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public class Actor
    {
        private int actorId;
        private string codigo;
        private string nombre;
        private string apellido;
        private List<Pelicula> listaPeliculas;


        public int ActorId
        {
            get { return actorId; }
            set { actorId = value; }
        }


        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
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


        public List<Pelicula> ListaPeliculas
        {
            get { return listaPeliculas; }
            set { listaPeliculas = value; }
        }


        public Actor()
        {
            listaPeliculas = new List<Pelicula>();
        }

        public override string ToString()
        {
            return $"{Codigo}";
        }
    }
}
