using Modelo.Módulo_de_Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public class Auditoria
    {
        // Atributos privados
        private int auditoriaId;
        private int directorId;
        private string codigo_director;
        private string nombre_director;
        private string apellido_director;
        private int usuario_AudId;
        private DateTime fecha_aud;
        private string tipoMovimientoAud;

        // Propiedad para el ID de auditoría
        public int AuditoriaId
        {
            get { return auditoriaId; }
            set { auditoriaId = value; }
        }

        // Propiedad para el ID del director
        public int DirectorId
        {
            get { return directorId; }
            set { directorId = value; }
        }

        // Propiedad para el código del director
        public string Codigo_Director
        {
            get { return codigo_director; }
            set { codigo_director = value; }
        }

        // Propiedad para el nombre del director
        public string Nombre_Director
        {
            get { return nombre_director; }
            set { nombre_director = value; }
        }

        // Propiedad para el apellido del director
        public string Apellido_Director
        {
            get { return apellido_director; }
            set { apellido_director = value; }
        }

        // Propiedad para el ID del usuario que audita
        public int Usuario_AudId
        {
            get { return usuario_AudId; }
            set { usuario_AudId = value; }
        }

        // Propiedad para la fecha de auditoría
        public DateTime Fecha_Aud
        {
            get { return fecha_aud; }
            set { fecha_aud = value; }
        }

        // Propiedad para el tipo de movimiento
        public string TipoMovimiento_Aud
        {
            get { return tipoMovimientoAud; }
            set { tipoMovimientoAud = value; }
        }

    }
}
