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
    [ApiController]
    [Route("api/[controller]")]
    public class ServidoreController : ControllerBase
    {
        private readonly ServidoreService _servidoreService;

        public ServidoreController(ServidoreService servidoreService)
        {
            _servidoreService = servidoreService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServidoreResponse>>> GetAll()
        {
            var servidores = await _servidoreService.GetAll();
            return Ok(servidores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServidoreResponse>> GetById(Guid id)
        {
            var servidor = await _servidoreService.GetById(id);
            if (servidor == null)
            {
                return NotFound();
            }

            return Ok("Servidor encontrado papu.");
        }

        [HttpPost]
        public async Task<ActionResult<ServidoreResponse>> Create(ServidoreRequest request)
        {
            try
            {
                var servidor = await _servidoreService.Create(request);
                return Ok ("Servidor creado exitosamente papu."); //modificado
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error= "Ha ocurrido un error interno.", menssage = ex.Message});
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServidoreResponse>> Update(Guid id, ServidoreRequest request)
        {
            var servidor = await _servidoreService.Update(id, request);
            if (servidor == null)
            {
                return NotFound("No se pudo eliminar el servidor papu.");
            }

            return Ok("Servidor actualizado exitosamente papu.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleted = await _servidoreService.Delete(id);
            if (!deleted)
            {
                return NotFound("No se pudo eliminar el servidor papu.");
            }

            return Ok("Servidor eliminado exitosamente papu.");
        }
    }
}