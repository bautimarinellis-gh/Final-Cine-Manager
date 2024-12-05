using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public class Director
    {
        private int directorId;
        private string codigo;
        private string nombre;
        private string apellido;
        private bool estado;



        public int DirectorId
        {
            get { return directorId; }
            set { directorId = value; }
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


        public bool Estado
        {
            get { return estado; }
            set { estado = value;}
        }


        public override string ToString()
        {
            return $"{Apellido}";
        }
    }
}

