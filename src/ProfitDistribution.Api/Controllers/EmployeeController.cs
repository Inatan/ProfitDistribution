using Microsoft.AspNetCore.Mvc;
using ProfitDistribution.Api.DTO;
using ProfitDistribution.Api.Model;
using ProfitDistribution.Domain.Model;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace ProfitDistribution.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v1/[controller]")]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(
            Summary = "Recupera o lista de funcionários."
        )]
        [Produces("application/json")]
        [ProducesResponseType(statusCode: 200, Type = typeof(EmployeeDTO))]
        [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        public IActionResult Get()
        {
            var lista = new List<Employee>();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Recupera o funcionário identificado por seu {id}."
        )]
        [Produces("application/json")]
        [ProducesResponseType(statusCode: 200, Type = typeof(EmployeeDTO))]
        [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        [ProducesResponseType(statusCode: 404)]
        public IActionResult Get(int id)
        {
            EmployeeDTO employee = null;
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Registra novo funcionário na base.")]
        [ProducesResponseType(statusCode: 201, Type = typeof(EmployeeDTO))]
        [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        [ProducesResponseType(statusCode: 404)]
        public IActionResult Post([FromBody] string value)
        {
            if (ModelState.IsValid)
            {
                // Insert
                Employee employee = null;
                var uri = Url.Action("Recuperar", new { id = 1 });
                return Created(uri, employee); // 201
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Atualizada dados de funcionário identificado por seu {id}."
        )]
        [ProducesResponseType(statusCode: 200)]
        [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        [ProducesResponseType(statusCode: 404)]
        public IActionResult Put(int id, [FromBody] string value)
        {
            if (ModelState.IsValid)
            {
                // Find By id
                // Update
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deleta funcionário identificado por seu {id}."
        )]
        [ProducesResponseType(statusCode: 204)]
        [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        [ProducesResponseType(statusCode: 404)]
        public IActionResult Delete(int id)
        {
            Employee employee = null;
            if (employee == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
