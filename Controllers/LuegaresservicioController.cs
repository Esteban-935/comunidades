using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comunidades.Data.Request;
using Comunidades.Data.Response;
using Comunidades.Services;
using Microsoft.AspNetCore.Mvc;

namespace Comunidades.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LugaresservicioController : ControllerBase
    {
        private readonly LugaresservicioService _lugaresservicioService;

        public LugaresservicioController(LugaresservicioService lugaresservicioService)
        {
            _lugaresservicioService = lugaresservicioService;
        }

        [HttpGet]
        public IEnumerable<LugaresservicioResponse> GetAll()
        {
            return _lugaresservicioService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<LugaresservicioResponse> GetById(Guid id)
        {
            var lugaresservicio = _lugaresservicioService.GetById(id);
            if (lugaresservicio == null)
            {
                return NotFound();
            }

            return lugaresservicio;
        }

        [HttpPost]
        public ActionResult<LugaresservicioResponse> Create(LugaresservicioRequest request)
        {
            try
            {
                var lugaresservicio = _lugaresservicioService.Create(request);
                return Ok ("Lugar creado exitosamente papu"); //modificado
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error= "Ha ocurrido un error interno.", menssage = ex.Message});
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, LugaresservicioRequest request)
        {
            if (!_lugaresservicioService.Update(id, request))
            {
                return NotFound("No se pudo actualizar el lugar papu.");
            }

            return Ok("Lugar actualizado exitosamente papu.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (!_lugaresservicioService.Delete(id))
            {
                return NotFound("No se pudo eliminar el lugar papu");
            }

            return Ok("Lugar eliminado exitosamente papu.");
        }
    }
}