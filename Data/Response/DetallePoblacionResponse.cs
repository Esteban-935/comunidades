using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunidades.Data.Response
{
    public class DetallePoblacionResponse
    {
        public Guid IdDetallePoblacion { get; set; }
        public Guid IdCatalogoPoblacion { get; set; }
        public string Cantidad { get; set; }
        public Guid IdConfiguracionlocal { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public Guid IdUsuarioRegistro { get; set; }
        public Guid? IdUsuarioActualizacion { get; set; }
        public string FechaSesion { get; set; }
    }
}