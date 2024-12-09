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
    public class ConfiglocalController : ControllerBase
    {
        private readonly ConfiglocalService _configlocalService;

        public ConfiglocalController(ConfiglocalService configlocalService)
        {
            _configlocalService = configlocalService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConfiglocalResponse>>> GetAllConfiglocales()
        {
            var configlocales = await _configlocalService.GetAllConfiglocales();
            return Ok(configlocales);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConfiglocalResponse>> GetConfiglocalById(Guid id)
        {
            var configlocal = await _configlocalService.GetConfiglocalById(id);
            if (configlocal == null)
            {
                return NotFound();
            }

            return Ok(configlocal);
        }

        [HttpPost]
        public async Task<ActionResult<ConfiglocalResponse>> CreateConfiglocal(ConfiglocalRequest request)
        {
            try
            {
                var configlocal = await _configlocalService.CreateConfiglocal(request);
                return Ok("Configlocal creado exitosamente papu.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Ha ocurrido un error interno.", message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConfiglocal(Guid id, ConfiglocalRequest request)
        {
            if (!await _configlocalService.UpdateConfiglocal(id, request))
            {
                return NotFound();
            }

            return Ok("Configlocal actualizado exitosamente papu.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfiglocal(Guid id)
        {
            if (!await _configlocalService.DeleteConfiglocal(id))
            {
                return NotFound();
            }

            return Ok("Configlocal eliminado exitosamente papu.");
        }
    }
}
