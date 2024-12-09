using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunidades.Data.Request
{
    public class MeseRequest
    {
        public string IdMes { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public Guid IdUsuarioRegistro { get; set; }
        public Guid? IdUsuarioActualizacion { get; set; }
    }
}