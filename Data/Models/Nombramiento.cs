using System;
using System.Collections.Generic;

namespace Comunidades.Data.Models
{
    public partial class Nombramiento
    {
        public Nombramiento()
        {
            Configlocals = new HashSet<Configlocal>();
        }

        public Guid IdNombramiento { get; set; }
        public Guid IdServidor { get; set; }
        public Guid IdComunidad { get; set; }
        public Guid IdLugarservicio { get; set; }
        public Guid IdEstatus { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaTermino { get; set; }
        public DateTime FechaRegistro { get; set; }
        public Guid IdUsuarioregistro { get; set; }
        public Guid? IdUsuarioupdate { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual Comunidade IdComunidadNavigation { get; set; } = null!;
        public virtual Estatus IdEstatusNavigation { get; set; } = null!;
        public virtual Lugaresservicio IdLugarservicioNavigation { get; set; } = null!;
        public virtual Servidore IdServidorNavigation { get; set; } = null!;
        public virtual ICollection<Configlocal> Configlocals { get; set; }
    }
}
