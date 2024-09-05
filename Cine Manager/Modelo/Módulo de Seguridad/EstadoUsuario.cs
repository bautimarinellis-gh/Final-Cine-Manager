using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Modelo.Módulo_de_Seguridad
{
    public class EstadoUsuario
    {
        private int estadoUsuarioId;
        private string estadoUsuarioNombre;


        public int EstadoUsuarioId
        {
            get { return estadoUsuarioId; }
            set { estadoUsuarioId = value; }
        }

        public string EstadoUsuarioNombre
        {
            get { return estadoUsuarioNombre; }
            set { estadoUsuarioNombre = value; }
        }

        public override string ToString()
        {
            return $"{EstadoUsuarioNombre}";
        }
    }



}
