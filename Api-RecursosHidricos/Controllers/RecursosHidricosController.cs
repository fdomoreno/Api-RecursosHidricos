using Api_RecursosHidricos.Models;
using Api_RecursosHidricos.Services;
using Api_RecursosHidricos.Services.Impl;
using Microsoft.AspNetCore.Mvc;

namespace Api_RecursosHidricos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecursosHidricosController : ControllerBase
    {

        private readonly ILogger<RecursosHidricosController> _logger;

        private readonly IRecursosHidricosService _recursosHidricosService;

        public RecursosHidricosController(ILogger<RecursosHidricosController> logger, IRecursosHidricosService recursosHidricosService)
        {
            _logger = logger;
            _recursosHidricosService = recursosHidricosService;
        }

        [HttpGet(Name = "GetRecursosHidricos")]
        public async Task<ActionResult<IEnumerable<RecursoHidrico>>> GetAll()
        {
            try
            {
                var recursoHidrico = await _recursosHidricosService.GetAllAsync();
                return Ok(recursoHidrico);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los recursos hidricos");
                return StatusCode(500, "Error al obtener los recursos hidricos");
            }
        }

        [HttpGet("{id}", Name = "GetRecursoHidrico")]
        public async Task<ActionResult<RecursoHidrico>> GetById(int id)
        {
            try
            {
                var recursoHidrico = await _recursosHidricosService.GetByIdAsync(id);
                if (recursoHidrico == null)
                {
                    return NotFound();
                }
                return Ok(recursoHidrico);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el recurso hidrico");
                return StatusCode(500, "Error al obtener el recurso hidrico");
            }
        }

        [HttpPost(Name = "CreateRecursoHidrico")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<RecursoHidrico>> Create([FromBody] RecursoHidrico recursoHidrico)
        {
            try
            {
                var recurso = await _recursosHidricosService.AddAsync(recursoHidrico);
                return Ok(recurso);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el recurso hidrico");
                return StatusCode(500, "Error al crear el recurso hidrico");
            }
        }

        [HttpPut(Name = "UpdateRecursoHidrico")]
        public async Task<ActionResult<RecursoHidrico>> Update([FromBody] RecursoHidrico recursoHidrico)
        {
            try
            {
                var recurso = await _recursosHidricosService.UpdateAsync(recursoHidrico);
                return Ok(recurso);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el recurso hidrico");
                return StatusCode(500, "Error al actualizar el recurso hidrico");
            }
        }

        [HttpDelete("{id}", Name = "DeleteRecursoHidrico")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _recursosHidricosService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el recurso hidrico");
                return StatusCode(500, "Error al eliminar el recurso hidrico");
            }
        }
    }
}