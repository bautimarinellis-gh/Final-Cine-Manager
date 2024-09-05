using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public class Cliente
    {
        private int clienteId;
        private string nombre;
        private string apellido;
        private int dni;



        public int ClienteId
        {
            get { return clienteId; }
            set { clienteId = value; }
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
        


        public int DNI
        {
            get { return dni; }
            set { dni = value; }
        }


        public override string ToString()
        {
            return $"{dni}";
        }
    }
}
