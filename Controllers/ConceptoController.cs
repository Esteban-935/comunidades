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
    public class ConceptoController : ControllerBase
    {
        private readonly ConceptoService _conceptoService;

        public ConceptoController(ConceptoService conceptoService)
        {
            _conceptoService = conceptoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConceptoResponse>>> GetConceptos()
        {
            var conceptos = await _conceptoService.GetConceptosAsync();
            return Ok("Busqueda Exitosa papu.");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConceptoResponse>> GetConceptoById(Guid id)
        {
            var concepto = await _conceptoService.GetConceptoByIdAsync(id);

            if (concepto == null)
            {
                return NotFound("Concepto no encontrado papu.");
            }

            return concepto;
        }

        [HttpPost]
        public async Task<ActionResult<ConceptoResponse>> CreateConcepto(ConceptoRequest request)
        {
            try
            {
                var concepto = await _conceptoService.CreateConceptoAsync(request);
                return Ok("Concepto creado exitosamente papu.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Ha ocurrido un error interno.", message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConcepto(Guid id, ConceptoRequest request)
        {
            var result = await _conceptoService.UpdateConceptoAsync(id, request);

            if (!result)
            {
                return NotFound("No se pudo actualizar el concepto papu.");
            }

            return Ok("Concepto actualizado exitosamente papu.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConcepto(Guid id)
        {
            var result = await _conceptoService.DeleteConceptoAsync(id);

            if (!result)
            {
                return NotFound("No existe el consepto papu.");
            }

            return Ok("Concepto eliminado exitosamente papu.");
        }
    }
}