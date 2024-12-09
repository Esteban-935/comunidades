using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunidades.Data.Request
{
    public class CatalogoPoblacionRequest
    {
        public string Grupo { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public Guid IdUsuarioRegistro { get; set; }
        public Guid? IdUsuarioActualizacion { get; set; }
    }
}