using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunidades.Data.Request
{
    public class TerritorioRequest
    {
        public Guid IdTerritorio { get; set; }
        public string Nombre { get; set; }
        public Guid IdEstatus { get; set; }
        public Guid IdUsuarioregistro { get; set; }
    }
}