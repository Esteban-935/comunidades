using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunidades.Data.Response
{
    public class RedeResponse
    {
        public Guid IdRed { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaUpdate { get; set; }
        public Guid IdUsuario { get; set; }
    }
}