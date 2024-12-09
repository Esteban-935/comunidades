using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunidades.Data.Response
{
    public class ServidoreResponse
    {
        public Guid IdServidor { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
       // public string Documento { get; set; }
        public Guid IdLugarServicio { get; set; }
        public Guid IdEstatus { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaUpdate { get; set; }
        public Guid IdUsuarioRegistro { get; set; }
        public Guid? IdUsuarioUpdate { get; set; }
    }
}