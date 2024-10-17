using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public class MetodoPago
    {
        
        private int metodoPagoId;
        private string codigo;
        private string nombre;


        public int MetodoPagoId
        {
            get { return metodoPagoId; }
            set { metodoPagoId = value;}
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
    }
}
