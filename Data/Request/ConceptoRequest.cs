using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunidades.Data.Request
{
    public class ConceptoRequest
    {
        public string Nombre { get; set; }
        public Guid IdArea { get; set; }
        public Guid IdFormulario { get; set; }
        public Guid IdUsuarioRegistro { get; set; }
        public Guid? IdUsuarioActualizacion { get; set; }
    }
}