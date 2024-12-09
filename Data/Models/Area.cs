using System;
using System.Collections.Generic;

namespace Comunidades.Data.Models
{
    public partial class Area
    {
        public Area()
        {
            Conceptos = new HashSet<Concepto>();
        }

        public Guid IdArea { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public Guid IdUsuarioRegistro { get; set; }
        public Guid? IdUaurioActualizacion { get; set; }

        public virtual ICollection<Concepto> Conceptos { get; set; }
    }
}