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
    public class FormularioController : ControllerBase
    {
        private readonly FormularioService _formularioService;

        public FormularioController(FormularioService formularioService)
        {
            _formularioService = formularioService;
        }

        [HttpGet]
        public async Task<ActionResult<List<FormularioResponse>>> GetFormularios()
        {
            var formularios = await _formularioService.GetFormulariosAsync();
            return Ok(formularios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FormularioResponse>> GetFormularioById(Guid id)
        {
            var formulario = await _formularioService.GetFormularioByIdAsync(id);
            if (formulario == null)
            {
                return NotFound("Formulario no encontrado papu.");
            }

            return Ok("Formulario encontrado exitasamente papu.");
        }

        [HttpPost]
        public async Task<ActionResult<FormularioResponse>> CreateFormulario(FormularioRequest request)
        {
            try
            {
                var formulario = await _formularioService.CreateFormularioAsync(request);
                return Ok("Formulario agregado correctamente papu.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Ha ocurrido un error interno.", message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFormulario(Guid id, FormularioRequest request)
        {
            var result = await _formularioService.UpdateFormularioAsync(id, request);
            if (!result)
            {
                return NotFound("No exite el formulario papu.");
            }

            return Ok("Formulario actualizado correctamente.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormulario(Guid id)
        {
            var result = await _formularioService.DeleteFormularioAsync(id);
            if (!result)
            {
                return NotFound("No exite el formulario papu.");
            }

            return Ok("Formulario eliminado exitosamente papu.");
        }
    }
}