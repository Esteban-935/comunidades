using System;
using System.Collections.Generic;

namespace Comunidades.Data.Models
{
    public partial class Comunidade
    {
        public Comunidade()
        {
            Nombramientos = new HashSet<Nombramiento>();
            Reportes = new HashSet<Reporte>();
        }

        public Guid IdComunidad { get; set; }
        public string Nombre { get; set; } = null!;
        public bool? Cabecera { get; set; }
        public string Direccion { get; set; } = null!;
        public Guid IdEstatus { get; set; }
        public Guid IdDistrito { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaUpdate { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid? IdUsuarioupdate { get; set; }

        public virtual Distrito IdDistritoNavigation { get; set; } = null!;
        public virtual Estatus IdEstatusNavigation { get; set; } = null!;
        public virtual ICollection<Nombramiento> Nombramientos { get; set; }
        public virtual ICollection<Reporte> Reportes { get; set; }
    }
}
