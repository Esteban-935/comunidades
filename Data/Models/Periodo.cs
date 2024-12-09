using System;
using System.Collections.Generic;

namespace Comunidades.Data.Models
{
    public partial class Periodo
    {
        public Periodo()
        {
            Reportes = new HashSet<Reporte>();
        }

        public Guid IdPeriodo { get; set; }
        public string Nombre { get; set; } = null!;
        public bool Visible { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public Guid IdUsuarioRegistro { get; set; }
        public Guid? IdUsuarioActualizacion { get; set; }

        public virtual ICollection<Reporte> Reportes { get; set; }
    }
}
