using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunidades.Data.Request
{
    public class DistritoRequest
    {
        
        public Guid IdDistrito { get; set; }
        public string Nombre { get; set; }
        public string Entidad { get; set; }
        public Guid IdEstatus { get; set; }
        public Guid IdTerritorio { get; set; }
        public Guid IdUsuarioRegistro { get; set; }
        public Guid? IdUsuarioUpdate { get; set; }
    }
}