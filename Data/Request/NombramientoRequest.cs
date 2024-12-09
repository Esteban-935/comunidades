using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunidades.Data.Request
{
    public class NombramientoRequest
    {
        public Guid IdNombramiento { get; set; }
        public Guid IdServidor { get; set; }
        public Guid IdComunidad { get; set; }
        public Guid IdLugarservicio { get; set; }
        public Guid IdEstatus { get; set; }
        public DateTime? FechaInicio { get; set; }
        //public DateTime? FechaTermino { get; set; }
        public DateTime FechaRegistro { get; set; }
        public Guid IdUsuarioregistro { get; set; }
        public Guid? IdUsuarioupdate { get; set; }
        //public DateTime? FechaActualizacion { get; set; }
    }
}