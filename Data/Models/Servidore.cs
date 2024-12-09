using System;
using System.Collections.Generic;

namespace Comunidades.Data.Models
{
    public partial class Servidore
    {
        public Servidore()
        {
            Nombramientos = new HashSet<Nombramiento>();
        }

        public Guid IdServidor { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public Guid Idestatus { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaUpdate { get; set; }
        public Guid IdUsuarioregistro { get; set; }
        public Guid? IdUsuarioupdate { get; set; }

        public virtual ICollection<Nombramiento> Nombramientos { get; set; }
    }
}
