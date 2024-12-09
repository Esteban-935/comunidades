using System;
using System.Collections.Generic;

namespace Comunidades.Data.Models
{
    public partial class Territorio
    {
        public Territorio()
        {
            Distritos = new HashSet<Distrito>();
        }

        public Guid IdTerritorio { get; set; }
        public string Nombre { get; set; } = null!;
        public Guid IdEstatus { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaUpdate { get; set; }
        public Guid IdUsuarioregistro { get; set; }
        public Guid? IdUsuarioupdate { get; set; }

        public virtual Estatus IdEstatusNavigation { get; set; } = null!;
        public virtual ICollection<Distrito> Distritos { get; set; }
    }
}
