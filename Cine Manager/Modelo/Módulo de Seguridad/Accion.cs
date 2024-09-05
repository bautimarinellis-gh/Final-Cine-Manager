using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Módulo_de_Seguridad
{

    //Leaf
    public class Accion:Componente
    {
        private Formulario formulario;

        public Formulario Formulario
        {
            get { return formulario; }
            set { formulario = value; }
        }



        public Accion()
        {
            Usuarios = new List<Usuario>();
        }

        
        public override void Agregar(Componente componente)
        {
            throw new NotImplementedException("No se pueden agregar componentes a una acción individual.");
        }

        public override void Eliminar(Componente componente)
        {
            throw new NotImplementedException("No se pueden eliminar componentes de una acción individual.");
        }

        public override List<Componente> RecuperarHijos()
        {
            return new List<Componente>();
        }
    }
    
}
