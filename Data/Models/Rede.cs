using System;
using System.Collections.Generic;

namespace Comunidades.Data.Models
{
    public partial class Rede
    {
        public Guid IdRed { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaUpdate { get; set; }
        public Guid IdUsuario { get; set; }
    }
}
