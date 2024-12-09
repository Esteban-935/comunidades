using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comunidades.Data.Response
{
    public class ConceptoResponse
    {
        public Guid IdConcepto { get; set; }
        public string Nombre { get; set; }
        public Guid IdArea { get; set; }
        public Guid IdFormulario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public Guid IdUsuarioRegistro { get; set; }
        public Guid? IdUsuarioActualizacion { get; set; }
    }
}