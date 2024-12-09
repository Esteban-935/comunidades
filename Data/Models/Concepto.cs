using System;
using System.Collections.Generic;

namespace Comunidades.Data.Models
{
    public partial class Concepto
    {
        public Concepto()
        {
            Reportes = new HashSet<Reporte>();
        }

        public Guid IdConcepto { get; set; }
        public string Nombre { get; set; } = null!;
        public Guid IdArea { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public Guid IdUsuarioRegistro { get; set; }
        public Guid? IdUsuarioActualizacion { get; set; }
        public Guid IdFormulario { get; set; }

        public virtual Area IdAreaNavigation { get; set; } = null!;
        public virtual Formulario IdFormularioNavigation { get; set; } = null!;
        public virtual ICollection<Reporte> Reportes { get; set; }
    }
}
