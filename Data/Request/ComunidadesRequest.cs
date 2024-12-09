using System;
using System.ComponentModel.DataAnnotations;

namespace Comunidades.Data.Request
{
    public class ComunidadeRequest
    {
        public Guid IdComunidad { get; set; } //modificado
        public string Nombre { get; set; }
        public bool? Cabecera { get; set; }
        public string Direccion { get; set; }
        public Guid IdEstatus { get; set; }
        public Guid IdDistrito { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid? IdUsuarioupdate { get; set; } //modificado
    }
}