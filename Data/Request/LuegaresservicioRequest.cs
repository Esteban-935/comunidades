using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunidades.Data.Request
{
    public class LugaresservicioRequest
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public Guid IdUsuarioregistro { get; set; }
    }
}