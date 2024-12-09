using System;
using System.Collections.Generic;

namespace Comunidades.Data.Models
{
    public partial class Mese
    {
        public Mese()
        {
            Reportes = new HashSet<Reporte>();
        }

        public string IdMes { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public Guid IdUsuarioRegistro { get; set; }
        public Guid? IdUsuarioActualizacion { get; set; }

        public virtual ICollection<Reporte> Reportes { get; set; }
    }
}
