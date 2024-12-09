using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunidades.Data.Response
{
    public class ReporteResponse
    {
        public Guid IdReporte { get; set; }
        public Guid IdConcepto { get; set; }
        public string Valor { get; set; } = null!;
        public string IdMes { get; set; } = null!;
        public Guid IdPeriodo { get; set; }
        public Guid IdComunidad { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public Guid IdUsuarioRegistro { get; set; }
        public Guid? IdUsuarioActualizacion { get; set; }
    }
}