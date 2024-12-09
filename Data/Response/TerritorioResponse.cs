using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunidades.Data.Response
{
    public class TerritorioResponse
    {
        public Guid IdTerritorio { get; set; }
        public string Nombre { get; set; }
        public Guid IdEstatus { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaUpdate { get; set; }
        public Guid IdUsuarioregistro { get; set; }
        public Guid? IdUsuarioupdate { get; set; }
    }
}