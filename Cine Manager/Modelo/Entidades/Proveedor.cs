using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public class Proveedor
    {
        private int proveedorId;
        private string codigo;
        private long cuit;
        private string razonSocial;
        private List<Pelicula> peliculas;
        private List<OrdenCompra> ordenesCompra;
        

        public int ProveedorId
        {
            get { return proveedorId; }
            set { proveedorId = value;}
        }


        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }


        public long Cuit
        {
            get { return cuit; }
            set { cuit = value; }
        }


        public string RazonSocial
        {
            get { return razonSocial; }
            set { razonSocial = value; }
        }


        public List<Pelicula> Peliculas
        {
            get { return peliculas; }
            set { peliculas= value; }
        }


        public List<OrdenCompra> OrdenesCompra
        {
            get { return ordenesCompra;}
            set {  ordenesCompra = value; }
        }


        

        public Proveedor()
        {
            peliculas= new List<Pelicula>();
            ordenesCompra = new List<OrdenCompra>();
        }



        public override string ToString()
        {
            return $"{Codigo}";
        }


    }
}
