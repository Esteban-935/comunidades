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
    public class DistritoController : ControllerBase
    {
        private readonly DistritoService _distritoService;

        public DistritoController(DistritoService distritoService)
        {
            _distritoService = distritoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DistritoResponse>>> GetAll()
        {
            var distritos = await _distritoService.GetAll();
            return Ok(distritos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DistritoResponse>> GetById(Guid id)
        {
            var distrito = await _distritoService.GetById(id);
            if (distrito == null)
            {
                return NotFound();
            }

            return Ok(distrito);
        }

        [HttpPost]
        public async Task<ActionResult<DistritoResponse>> Create(DistritoRequest request)
        {
            try
            {
                var distrito = await _distritoService.Create(request);
                return Ok ("Distrito creado exitosamente papu."); //modificado
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error= "Ha ocurrido un error interno.", menssage = ex.Message});
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DistritoResponse>> Update(Guid id, DistritoRequest request)
        {
            var distrito = await _distritoService.Update(id, request);
            if (distrito == null)
            {
                return NotFound("No se pudo actualizar el distrito papu.");
            }

            return Ok("Distrito actulizado exitosamente papu.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleted = await _distritoService.Delete(id);
            if (!deleted)
            {
                return NotFound("No se pudo eliminar el distrito papu.");
            }

            return Ok("Distrito eliminado exitosamente papu.");
        }
    }
}