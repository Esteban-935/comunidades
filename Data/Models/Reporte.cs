using System;
using System.Collections.Generic;

namespace Comunidades.Data.Models
{
    public partial class Reporte
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

        public virtual Comunidade IdComunidadNavigation { get; set; } = null!;
        public virtual Concepto IdConceptoNavigation { get; set; } = null!;
        public virtual Mese IdMesNavigation { get; set; } = null!;
        public virtual Periodo IdPeriodoNavigation { get; set; } = null!;
    }
}
