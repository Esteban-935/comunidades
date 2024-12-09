using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunidades.Data.Response
{
    public class LugaresservicioResponse
    {
        public Guid IdLugarservicio { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaUpdate { get; set; }
        public Guid IdUsuarioregistro { get; set; }
        public Guid? IdUsuarioupdate { get; set; }
        public bool Vigencia { get; set; }
    }
}