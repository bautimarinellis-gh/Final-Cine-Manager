using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public class AuditoriaSesion
    {
        private int auditoriaSesionId;
        private int usuarioId;
        private DateTime fechaMovimiento;
        private string tipoMovimiento;

        public int AuditoriaSesionId
        {
            get { return auditoriaSesionId; }
            set { auditoriaSesionId = value; }
        }

        public int UsuarioId
        {
            get { return usuarioId; }
            set { usuarioId = value; }
        }

        public DateTime FechaMovimiento
        {
            get { return fechaMovimiento; }
            set { fechaMovimiento = value; }
        }

        public string TipoMovimiento
        {
            get { return tipoMovimiento; }
            set { tipoMovimiento = value; }
        }
    }
}
