using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Módulo_de_Seguridad
{
    public class Modulo
    {
        public int moduloId;
        public string nombreModulo;

        public int ModuloId
        {
            get { return moduloId; }
            set { moduloId = value; }
        }

        public string NombreModulo
        {
            get { return nombreModulo; }
            set { nombreModulo = value; }
        }
    }
}
