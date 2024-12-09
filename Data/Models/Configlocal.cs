using System;
using System.Collections.Generic;

namespace Comunidades.Data.Models
{
    public partial class Configlocal
    {
        public Configlocal()
        {
            DetallePoblacions = new HashSet<DetallePoblacion>();
        }

        public Guid IdConfiglocal { get; set; }
        public Guid IdEstatus { get; set; }
        public Guid IdNombramiento { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaUpdate { get; set; }
        public Guid IdUsuarioRegistro { get; set; }
        public Guid? IdUsuarioActualizacion { get; set; }

        public virtual Estatus IdEstatusNavigation { get; set; } = null!;
        public virtual Nombramiento IdNombramientoNavigation { get; set; } = null!;
        public virtual ICollection<DetallePoblacion> DetallePoblacions { get; set; }
    }
}
