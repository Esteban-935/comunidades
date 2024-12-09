using System;
using System.Collections.Generic;

namespace Comunidades.Data.Models
{
    public partial class Lugaresservicio
    {
        public Lugaresservicio()
        {
            Nombramientos = new HashSet<Nombramiento>();
        }

        public Guid IdLugarservicio { get; set; }
        public string Nombre { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaUpdate { get; set; }
        public Guid IdUsuarioregistro { get; set; }
        public Guid? IdUsuarioupdate { get; set; }
        public bool Vigencia { get; set; }

        public virtual ICollection<Nombramiento> Nombramientos { get; set; }
    }
}
