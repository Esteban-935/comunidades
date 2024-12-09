using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunidades.Data.Response
{
    public partial class NombramientoResponse
    {
        public Guid IdNombramiento { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaTermino { get; set; }
        public object Estatus { get; set; } = null!;
        public object Servidor { get; set; } = null!;
        public object Comunidad { get; set; } = null!;
        public object Lugarservicio { get; set; } = null!;
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaUpdate { get; set; }
        public Guid IdUsuarioregistro { get; set; }
        public Guid? IdUsuarioUpdate { get; set; }

        public object Cambios { get; set; } = null!;
    }
}