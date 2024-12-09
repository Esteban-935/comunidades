using System;
using System.Collections.Generic;

namespace Comunidades.Data.Models
{
    public partial class Formulario
    {
        public Formulario()
        {
            Conceptos = new HashSet<Concepto>();
        }

        public Guid IdFormulario { get; set; }
        public string Nombre { get; set; } = null!;
        public Guid IdPeriodo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public Guid IdUsuarioRegistro { get; set; }
        public Guid? IdUsuarioActualizacion { get; set; }

        public virtual ICollection<Concepto> Conceptos { get; set; }
    }
}
