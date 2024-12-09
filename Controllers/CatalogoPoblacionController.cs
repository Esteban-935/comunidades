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
    public class CatalogoPoblacionController : ControllerBase
    {
        private readonly CatalogoPoblacionService _catalogoPoblacionService;

        public CatalogoPoblacionController(CatalogoPoblacionService catalogoPoblacionService)
        {
            _catalogoPoblacionService = catalogoPoblacionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatalogoPoblacionResponse>>> GetCatalogoPoblaciones()
        {
            var catalogoPoblaciones = await _catalogoPoblacionService.GetCatalogoPoblacionesAsync();
            return Ok(catalogoPoblaciones);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CatalogoPoblacionResponse>> GetCatalogoPoblacionById(Guid id)
        {
            var catalogoPoblacion = await _catalogoPoblacionService.GetCatalogoPoblacionByIdAsync(id);

            if (catalogoPoblacion == null)
            {
                return NotFound("Error al Buscar el catalogo papu.");
            }

            return catalogoPoblacion;
        }

        [HttpPost]
        public async Task<ActionResult<CatalogoPoblacionResponse>> CreateCatalogoPoblacion(CatalogoPoblacionRequest request)
        {
            try
            {
                var catalogoPoblacion = await _catalogoPoblacionService.CreateCatalogoPoblacionAsync(request);
                return Ok("Catalogo creado exitosamente papu.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Ha ocurrido un error interno.", message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCatalogoPoblacion(Guid id, CatalogoPoblacionRequest request)
        {
            var result = await _catalogoPoblacionService.UpdateCatalogoPoblacionAsync(id, request);

            if (!result)
            {
                return NotFound("No se pudo actualizar el catalogo papu.");
            }

            return Ok("Catalogo actualizado exitosamente.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatalogoPoblacion(Guid id)
        {
            var result = await _catalogoPoblacionService.DeleteCatalogoPoblacionAsync(id);

            if (!result)
            {
                return NotFound("No existe el catalogo pupu.");
            }

            return Ok("Catalogo eliminado exitosamente papu.");
        }
    }
}