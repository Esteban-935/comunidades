using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunidades.Data.Response
{
    public class ComunidadeResponse
    {
        public Guid IdComunidad { get; set; }
        public string Nombre { get; set; }
        public bool? Cabecera { get; set; }
        public string Direccion { get; set; }
        public Guid IdEstatus { get; set; }
        public Guid IdDistrito { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaUpdate { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid? IdUsuarioUpdate { get; set; }
    }
}