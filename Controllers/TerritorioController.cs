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
    public class TerritorioController : ControllerBase
    {
        private readonly TerritorioService _territorioService;

        public TerritorioController(TerritorioService territorioService)
        {
            _territorioService = territorioService;
        }

        [HttpGet]
        public IEnumerable<TerritorioResponse> GetAll()
        {
            return _territorioService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<TerritorioResponse> GetById(Guid id)
        {
            var territorio = _territorioService.GetById(id);
            if (territorio == null)
            {
                return NotFound();
            }

            return Ok("Territorio encontrado papu.");
        }

        [HttpPost]
        public ActionResult<TerritorioResponse> Create(TerritorioRequest request)
        {
            try
            {
                var territorio = _territorioService.Create(request);
                return Ok ("Territorio creado exitosamente papu"); //modificado
            }
            catch (Exception ex)
            {
                return StatusCode(500, new {error= "Ha ocurrido un error interno.", menssage = ex.Message});
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, TerritorioRequest request)
        {
            if (!_territorioService.Update(id, request))
            {
                return NotFound("No se pudo actualizar el territorio papu.");
            }

            return Ok("Territorio actualizado exitosamente papu.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (!_territorioService.Delete(id))
            {
                return NotFound("No se pudo eliminar el territorio papu.");
            }

            return Ok("Territorio eliminado exitosamente papu.");
        }
    }
}