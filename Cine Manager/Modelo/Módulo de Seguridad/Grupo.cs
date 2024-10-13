using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Módulo_de_Seguridad
{

    //Composite
    public class Grupo:Componente
    {
        private string codigo;
        private string descripcionGrupo;
        private EstadoGrupo estadoGrupo;
        private List<Componente> componentes;


        

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string DescripcionGrupo
        {
            get { return descripcionGrupo; }
            set { descripcionGrupo = value; }
        }

        public EstadoGrupo EstadoGrupo
        {
            get { return estadoGrupo; }
            set { estadoGrupo = value; }
        }


       
       
        public List<Componente> Componentes
        {
            get { return componentes; }
            set { componentes = value; }
        }


        public Grupo()
        {
            componentes = new List<Componente>();
            Usuarios = new List<Usuario>();
            Grupos = new List<Grupo>();
        }


        public override void Agregar(Componente componente)
        {
            componentes.Add(componente);
        }

        public override void Eliminar(Componente componente)
        {
            componentes.Remove(componente);
        }

        public override List<Componente> RecuperarHijos()
        {
            return componentes.ToList();
        }


        public override string ToString()
        {
            return $"{Nombre}";
        }

    }
}
