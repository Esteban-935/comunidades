using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunidades.Data.Request
{
    public class ReporteRequest
    {
        public Guid IdConcepto { get; set; }
        public string Valor { get; set; } = null!;
        public string IdMes { get; set; } = null!;
        public Guid IdPeriodo { get; set; }
        public Guid IdComunidad { get; set; }
        public Guid IdUsuarioRegistro { get; set; }
        public Guid? IdUsuarioActualizacion { get; set; }
    }
}