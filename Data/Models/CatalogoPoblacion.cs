using System;
using System.Collections.Generic;

namespace Comunidades.Data.Models
{
    public partial class CatalogoPoblacion
    {
        public CatalogoPoblacion()
        {
            DetallePoblacions = new HashSet<DetallePoblacion>();
        }

        public Guid IdCatalogoPoblacion { get; set; }
        public string Grupo { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public Guid IdUsuarioRegistro { get; set; }
        public Guid? IdUsuarioActualizacion { get; set; }

        public virtual ICollection<DetallePoblacion> DetallePoblacions { get; set; }
    }
}
