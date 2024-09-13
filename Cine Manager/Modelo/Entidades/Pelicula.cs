using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public class Pelicula
    {
        private int peliculaID;
        private string codigo;
        private string nombre;
        private int cantidad;
        private int precio;
        private Director director;
        private GeneroCinematografico generoCinematografico;
        private List<Actor> reparto;
        private List<Proveedor> proveedores;



        public int PeliculaId
        {
            get { return peliculaID; }
            set { peliculaID = value; }
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


        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }


        public int Precio
        {
            get { return precio; }
            set { precio = value; }
        }


        public Director Director
        {
            get { return director; }
            set { director = value; }
        }


        public GeneroCinematografico GeneroCinematografico
        {
            get { return generoCinematografico; }
            set { generoCinematografico = value; }
        }


        public List<Actor> Reparto
        {
            get{  return reparto; }
            set { reparto = value; }
        }


        public List<Proveedor> Proveedores
        {
            get { return proveedores; }
            set { proveedores = value; }
        }



        public Pelicula()
        {
            reparto = new List<Actor>();
            proveedores = new List<Proveedor>();
        }



        public override string ToString()
        {
            return $"{Codigo}";
        }
    }
}
