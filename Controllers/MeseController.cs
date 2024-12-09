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
    public class MeseController : ControllerBase
    {
        private readonly MeseService _meseService;

        public MeseController(MeseService meseService)
        {
            _meseService = meseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeseResponse>>> GetAll()
        {
            var meses = await _meseService.GetAllMesesAsync();
            return Ok(meses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MeseResponse>> GetById(string id)
        {
            var mese = await _meseService.GetMeseByIdAsync(id);

            if (mese == null)
            {
                return NotFound("No se encontro el registro papu.");
            }

            return Ok("Busqueda exitosa papu.");
        }

        [HttpPost]
        public async Task<ActionResult<MeseResponse>> CreateMese(MeseRequest request)
        {
            try
            {
                var mese = await _meseService.CreateMeseAsync(request);
                return Ok("Mese creado exitosamente papu.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Ha ocurrido un error interno.", message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, MeseRequest request)
        {
            if (!await _meseService.UpdateMeseAsync(id, request))
            {
                return NotFound("No existe ese registro papu.");
            }

            return Ok("Mes actualizado exitosamente papu.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (!await _meseService.DeleteMeseAsync(id))
            {
                return NotFound("No existe ese registro papu.");
            }

            return Ok("Mes eliminado exitosamente papu.");
        }
    }
}