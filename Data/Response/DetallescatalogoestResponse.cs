using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comunidades.Data.Models;

namespace Comunidades.Data.Response
{
    public class DetallescatalogoestResponse
    {
        public Guid IdDetallecatalogoest { get; set; }
        public Guid IdCatalogolc { get; set; }
        public Guid IdComunidad { get; set; }
        public string Cantidad { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaUpdate { get; set; }
        public Guid IdUsuarioregistro { get; set; }
        public Guid? IdUsuarioupdate { get; set; }
        public string Indicador { get; set; }
    }
}