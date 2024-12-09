using System;
using System.Collections.Generic;

namespace Comunidades.Data.Models
{
    public partial class Distrito
    {
        public Distrito()
        {
            Comunidades = new HashSet<Comunidade>();
        }

        public Guid IdDistrito { get; set; }
        public string Nombre { get; set; } = null!;
        public string Entidad { get; set; } = null!;
        public Guid IdEstatus { get; set; }
        public Guid IdTerritorio { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaUpdate { get; set; }
        public Guid IdUsuarioregistro { get; set; }
        public Guid? IdUsuarioupdate { get; set; }

        public virtual Estatus IdEstatusNavigation { get; set; } = null!;
        public virtual Territorio IdTerritorioNavigation { get; set; } = null!;
        public virtual ICollection<Comunidade> Comunidades { get; set; }
    }
}
