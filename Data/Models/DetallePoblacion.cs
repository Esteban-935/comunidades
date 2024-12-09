using System;
using System.Collections.Generic;

namespace Comunidades.Data.Models
{
    public partial class DetallePoblacion
    {
        public Guid IdDetallePoblacion { get; set; }
        public Guid IdCatalogoPoblacion { get; set; }
        public string Cantidad { get; set; } = null!;
        public Guid IdConfiguracionlocal { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public Guid IdUsuarioRegistro { get; set; }
        public Guid? IdUsuarioActualizacion { get; set; }
        public string FechaSesion { get; set; } = null!;

        public virtual CatalogoPoblacion IdCatalogoPoblacionNavigation { get; set; } = null!;
        public virtual Configlocal IdConfiguracionlocalNavigation { get; set; } = null!;
    }
}
