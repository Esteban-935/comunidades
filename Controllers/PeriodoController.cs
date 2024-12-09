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
    public class PeriodoController : ControllerBase
    {
        private readonly PeriodoService _periodoService;

        public PeriodoController(PeriodoService periodoService)
        {
            _periodoService = periodoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PeriodoResponse>>> GetAll()
        {
            var periodos = await _periodoService.GetAllPeriodosAsync();
            return Ok(periodos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PeriodoResponse>> GetById(Guid id)
        {
            var periodo = await _periodoService.GetPeriodoByIdAsync(id);

            if (periodo == null)
            {
                return NotFound("No hay registro papu");
            }

            return Ok("Busqueda exitosa papu.");
        }

        [HttpPost]
        public async Task<ActionResult<PeriodoResponse>> CreatePeriodo(PeriodoRequest request)
        {
            try
            {
                var periodo = await _periodoService.CreatePeriodoAsync(request);
                return Ok("Periodo creado exitosamente papu.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Ha ocurrido un error interno.", message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, PeriodoRequest request)
        {
            if (!await _periodoService.UpdatePeriodoAsync(id, request))
            {
                return NotFound("No existe ese registro papu.");
            }

            return Ok("Periodo actualizado exitosamente papu.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!await _periodoService.DeletePeriodoAsync(id))
            {
                return NotFound("No se pudo eliminar el periodo papu.");
            }

            return Ok("Periodo eliminado exitosamente papu.");
        }
    }
}