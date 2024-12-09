using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comunidades.Data.Models;

namespace Comunidades.Data.Response
{
    public class ConfiglocalResponse
    {
        public Guid IdConfiglocal { get; set; }
        public Guid IdEstatus { get; set; }
        public Guid IdNombramiento { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaUpdate { get; set; }
        public Guid IdUsuarioRegistro { get; set; }
        public Guid? IdUsuarioActualizacion { get; set; }

        public ICollection<DetallePoblacion> DetallePoblacions { get; set; }
    }
}