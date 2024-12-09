using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comunidades.Data;
using Comunidades.Data.Models;
using Comunidades.Data.Request;
using Comunidades.Data.Response;
using Comunidades.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Comunidades.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComunidadeController : ControllerBase
    {
        private readonly ComunidadeService _comunidadeService;

        public ComunidadeController(ComunidadeService comunidadeService)
        {
            _comunidadeService = comunidadeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComunidadeResponse>>> GetAll()
        {
            var comunidades = await _comunidadeService.GetAll();
            return Ok(comunidades);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ComunidadeResponse>> GetById(Guid id)
        {
            var comunidade = await _comunidadeService.GetById(id);
            if (comunidade == null)
            {
                return NotFound();
            }

            return Ok(comunidade);
        }

        [HttpPost]
        public async Task<ActionResult<ComunidadeResponse>> Create(ComunidadeRequest request)
        {
            try
            {
                var comunidade = await _comunidadeService.Create(request);
                return Ok ("Comunidad creado correctamente papu."); //modificado
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error= "Ha ocurrido un error interno.", menssage = ex.Message});
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ComunidadeResponse>> Update(Guid id, ComunidadeRequest request)
        {
            var comunidade = await _comunidadeService.Update(id, request);
            if (comunidade == null)
            {
                return NotFound();
            }

            return Ok("Comunidad actualizada correctamente papu."); //modificado
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleted = await _comunidadeService.Delete(id);
            if (!deleted)
            {
                return NotFound("No se pudo eliminar la comunidad papu.");
            }

            return NoContent();
        }
    }
}