using Api_RecursosHidricos.Models;
using Api_RecursosHidricos.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api_RecursosHidricos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecursosHidricosController : ControllerBase
    {

        private readonly ILogger<RecursosHidricosController> _logger;

        private readonly RecursosHidricosService _recursosHidricosService;

        public RecursosHidricosController(ILogger<RecursosHidricosController> logger, RecursosHidricosService recursosHidricosService)
        {
            _logger = logger;
            _recursosHidricosService = recursosHidricosService;
        }

        [HttpGet(Name = "GetRecursosHidricos")]
        public ActionResult<IEnumerable<RecursosHidricos>> GetAll()
        {
            try
            {
                return Ok(_recursosHidricosService.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los recursos hidricos");
                return StatusCode(500, "Error al obtener los recursos hidricos");
            }
        }

        [HttpGet("{id}", Name = "GetRecursoHidrico")]
        public ActionResult<RecursosHidricos> GetById(int id)
        {
            try
            {
                var recursoHidrico = _recursosHidricosService.GetById(id);
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
        public ActionResult<RecursosHidricos> Create([FromBody] RecursosHidricos recursoHidrico)
        {
            try
            {
                return Ok(_recursosHidricosService.Create(recursoHidrico));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el recurso hidrico");
                return StatusCode(500, "Error al crear el recurso hidrico");
            }
        }

        [HttpPut(Name = "UpdateRecursoHidrico")]
        public ActionResult<RecursosHidricos> Update([FromBody] RecursosHidricos recursoHidrico)
        {
            try
            {
                return Ok(_recursosHidricosService.Update(recursoHidrico));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el recurso hidrico");
                return StatusCode(500, "Error al actualizar el recurso hidrico");
            }
        }

        [HttpDelete("{id}", Name = "DeleteRecursoHidrico")]
        public ActionResult Delete(int id)
        {
            try
            {
                _recursosHidricosService.Delete(id);
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