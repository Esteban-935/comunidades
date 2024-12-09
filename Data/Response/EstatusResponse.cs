using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunidades.Data.Response
{
    public class EstatusResponse
    {
        public Guid IdEstatus { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaUpdate { get; set; }
        public Guid IdUsuario { get; set; }
    }
}