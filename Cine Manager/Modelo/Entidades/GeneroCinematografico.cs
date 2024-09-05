using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public class GeneroCinematografico
    {
        private int generoCinematograficoId;
        private string nombre;


        public int GeneroCinematograficoId
        {
            get { return generoCinematograficoId; }
            set { generoCinematograficoId = value; }
        }


        public string Nombre
        {
            get { return nombre; } 
            set { nombre  = value; }
        }


        public override string ToString()
        {
            return $"{Nombre}";
        }
    }
}
