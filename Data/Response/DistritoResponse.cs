using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunidades.Data.Response
{
    public class DistritoResponse
    {
        public Guid IdDistrito { get; set; }
        public string Nombre { get; set; }
        public string Entidad { get; set; }
        public Guid IdEstatus { get; set; }
        public Guid IdTerritorio { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaUpdate { get; set; }
        public Guid IdUsuarioRegistro { get; set; }
        public Guid? IdUsuarioUpdate { get; set; }
    }
}