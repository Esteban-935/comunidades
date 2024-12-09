using System;
using System.Collections.Generic;

namespace Comunidades.Data.Models
{
    public partial class Estatus
    {
        public Estatus()
        {
            Comunidades = new HashSet<Comunidade>();
            Configlocals = new HashSet<Configlocal>();
            Distritos = new HashSet<Distrito>();
            Nombramientos = new HashSet<Nombramiento>();
            Territorios = new HashSet<Territorio>();
        }

        public Guid IdEstatus { get; set; }
        public string Nombre { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaUpdate { get; set; }
        public Guid IdUsuarioRegistro { get; set; }

        public virtual ICollection<Comunidade> Comunidades { get; set; }
        public virtual ICollection<Configlocal> Configlocals { get; set; }
        public virtual ICollection<Distrito> Distritos { get; set; }
        public virtual ICollection<Nombramiento> Nombramientos { get; set; }
        public virtual ICollection<Territorio> Territorios { get; set; }
    }
}
