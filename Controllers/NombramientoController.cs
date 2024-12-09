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
    public class NombramientoController : ControllerBase
    {
        private readonly NombramientoService _nombramientoService;

        public NombramientoController(NombramientoService nombramientoService)
        {
            _nombramientoService = nombramientoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NombramientoResponse>>> Get(Guid idNombramiento = default, DateTime? fechaInicio = default, DateTime? fechaTermino = default, Guid idEstatus = default, Guid idServidor = default, Guid? idComunidad = null, DateTime fechaRegistro = default, DateTime? fechaActualizacion = null, Guid idUsuarioRegistro = default, Guid idLugarServicio = default, Guid idUsuarioUpdate = default, int page = 1, int pageSize = 10)
        {
            var nombramientos = await _nombramientoService.Get(idNombramiento, fechaInicio, fechaTermino, idEstatus, idServidor, idComunidad, fechaRegistro, fechaActualizacion, idUsuarioRegistro, idLugarServicio, idUsuarioUpdate, page, pageSize);
            return Ok(nombramientos);
        }

        [HttpGet("{id}")]
        public ActionResult<NombramientoResponse> GetById(Guid id)
        {
            var nombramiento = _nombramientoService.GetById(id);
            if (nombramiento == null)
            {
                return NotFound();
            }

            return nombramiento;
        }

        [HttpPost]
        public ActionResult<NombramientoResponse> Create(NombramientoRequest request)
        {
            try
            {
                var nombramiento = _nombramientoService.Create(request);
                return Ok("Nombramentiento creado exitosamente papu.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Ha ocurrido un error interno.", message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Guid idEstatus, Guid idUsuarioUpdate)
        {
            if (!_nombramientoService.ChangeStatus(id, idEstatus, idUsuarioUpdate))
            {
                return NotFound();
            }

            return Ok("Nombramiento actualizado exitosamente papu.");
        }


        // [HttpDelete("{id}")]
        // public IActionResult Delete(Guid id, Guid idEstatus)
        // {
        //     if (!_nombramientoService.ChangeStatus(id, idEstatus))
        //     {
        //         return NotFound();
        //     }

        //     return Ok("Nombramiento eliminado correctamente.");
        // }
    }
}