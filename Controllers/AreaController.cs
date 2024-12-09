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
    public class AreaController : ControllerBase
    {
        private readonly AreaService _areaService;

        public AreaController(AreaService areaService)
        {
            _areaService = areaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AreaResponse>>> GetAreas()
        {
            var areas = await _areaService.GetAreasAsync();
            return Ok(areas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AreaResponse>> GetAreaById(Guid id)
        {
            var area = await _areaService.GetAreaByIdAsync(id);

            if (area == null)
            {
                return NotFound();
            }

            return Ok(area);
        }

        [HttpPost]
        public async Task<ActionResult<AreaResponse>> CreateArea(AreaRequest request)
        {
            try
            {
                var area = await _areaService.CreateAreaAsync(request);
                return Ok ("Area creado correctamente papu.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Ha ocurrido un error interno.", message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArea(Guid id, AreaRequest request)
        {
            if (!await _areaService.UpdateAreaAsync(id, request))
            {
                return NotFound("No se pudo actualizar el area papu.");
            }

            return Ok("Area actualizado exitosamente papu.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArea(Guid id)
        {
            if (!await _areaService.DeleteAreaAsync(id))
            {
                return NotFound("No existe el area papu.");
            }

            return Ok("Area Eliminado exitosamente papu.");
        }
    }
}