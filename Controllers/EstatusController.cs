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
    [Route("api/[controller]")]
    [ApiController]
    public class EstatusController : ControllerBase
    {
        private readonly EstatusService _estatusService;

        public EstatusController(EstatusService estatusService)
        {
            _estatusService = estatusService;
        }

        [HttpGet]
        public async Task<IEnumerable<EstatusResponse>> GetAll()
        {
            return await _estatusService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EstatusResponse>> GetById(Guid id)
        {
            var estatus = await _estatusService.GetById(id);
            if (estatus == null)
            {
                return NotFound();
            }
            return estatus;
        }

        [HttpPost]
        public async Task<ActionResult<EstatusResponse>> Create(EstatusRequest request)
        {
            try
            {
                var estatus = await _estatusService.Create(request);
                return Ok ("Estatus creado exitosamente papu."); //modificado
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error= "Ha ocurrido un error interno.", menssage = ex.Message});
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, EstatusRequest request)
        {
            var updatedEstatus = await _estatusService.Update(id, request);
            if (updatedEstatus == null)
            {
                return NotFound("No se pudo actualizar el estatus papu.");
            }
            return Ok("Estatus actualizado exitosamente papu.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _estatusService.Delete(id);
            if (!result)
            {
                return NotFound("No se pudo eliminar el estatus papu");
            }
            return Ok("Estatus eliminado exitosamente papu.");
        }
    }
}