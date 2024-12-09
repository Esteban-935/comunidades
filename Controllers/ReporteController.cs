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
    public class ReporteController : ControllerBase
    {
        private readonly ReporteService _reporteService;

        public ReporteController(ReporteService reporteService)
        {
            _reporteService = reporteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReporteResponse>>> GetAll()
        {
            var reportes = await _reporteService.GetAllReportesAsync();
            return Ok(reportes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReporteResponse>> GetById(Guid id)
        {
            var reporte = await _reporteService.GetReporteByIdAsync(id);

            if (reporte == null)
            {
                return NotFound("No existe ese reporte papu.");
            }

            return Ok("Reporte encontrado papu.");
        }

        [HttpPost]
        public async Task<ActionResult<ReporteResponse>> CreateReporte(ReporteRequest request)
        {
            try
            {
                var reporte = await _reporteService.CreateReporteAsync(request);
                return Ok("Reporte creado exitosamente papu.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Ha ocurrido un error interno.", message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, ReporteRequest request)
        {
            if (!await _reporteService.UpdateReporteAsync(id, request))
            {
                return NotFound("No se pudo actualizar ese reporte papu.");
            }

            return Ok("Reporte actualizado exitosamente papu.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!await _reporteService.DeleteReporteAsync(id))
            {
                return NotFound();
            }

            return Ok("Reporte eliminado exitosamente papu.");
        }
    }
}