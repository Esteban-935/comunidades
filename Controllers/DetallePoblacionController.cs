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
    public class DetallePoblacionController : ControllerBase
    {
        private readonly DetallePoblacionService _detallePoblacionService;

        public DetallePoblacionController(DetallePoblacionService detallePoblacionService)
        {
            _detallePoblacionService = detallePoblacionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallePoblacionResponse>>> GetAll()
        {
            var detallePoblacion = await _detallePoblacionService.GetAllDetallePoblacionAsync();
            return Ok(detallePoblacion);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetallePoblacionResponse>> GetById(Guid id)
        {
            var detallePoblacion = await _detallePoblacionService.GetDetallePoblacionByIdAsync(id);
            if (detallePoblacion == null)
            {
                return NotFound("No existe el detalle papu.");
            }

            return detallePoblacion;
        }

        [HttpPost]
        public async Task<ActionResult<DetallePoblacionResponse>> CreateDetallePoblacion(DetallePoblacionRequest request)
        {
            try
            {
                var detallePoblacion = await _detallePoblacionService.CreateDetallePoblacionAsync(request);
                return Ok("Detalle de la poblacion creada exitosamente papu.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Ha ocurrido un error interno.", message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, DetallePoblacionRequest request)
        {
            if (!await _detallePoblacionService.UpdateDetallePoblacionAsync(id, request))
            {
                return NotFound("No exite el detalle de la poblacion papu.");
            }

            return Ok("Detalle de población actualizado exitosamente papu.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!await _detallePoblacionService.DeleteDetallePoblacionAsync(id))
            {
                return NotFound("No existe el detalle de la poblacion papu.");
            }

            return Ok("Detalle de población eliminado exitosamente papu.");
        }
    }
}