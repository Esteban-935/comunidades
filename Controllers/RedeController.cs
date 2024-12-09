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
    public class RedeController : ControllerBase
    {
        private readonly RedeService _redeService;

        public RedeController(RedeService redeService)
        {
            _redeService = redeService;
        }

        [HttpGet]
        public async Task<IEnumerable<RedeResponse>> GetAll()
        {
            return await _redeService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RedeResponse>> GetById(Guid id)
        {
            var rede = await _redeService.GetById(id);
            if (rede == null)
            {
                return NotFound();
            }
            return Ok("Rede encontrado exitosamente papu.");
        }

        [HttpPost]
        public async Task<ActionResult<RedeResponse>> Create(RedeRequest request)
        {
            try
            {
                var rede = await _redeService.Create(request);
                return Ok ("Rede creado exitosamente papu."); //modificado
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error= "Ha ocurrido un error interno.", menssage = ex.Message});
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, RedeRequest request)
        {
            var updatedRede = await _redeService.Update(id, request);
            if (updatedRede == null)
            {
                return NotFound("No se pudo actualizar la rede papu.");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _redeService.Delete(id);
            if (!result)
            {
                return NotFound("No se pudo eliminar la rede papu.");
            }
            return Ok("Rede eliminado exitosamente papu.");
        }
    }
}