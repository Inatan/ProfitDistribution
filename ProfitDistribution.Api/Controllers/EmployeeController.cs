using Microsoft.AspNetCore.Mvc;
using ProfitDistribution.Api.DTO;
using ProfitDistribution.Api.Model;
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
        [ProducesResponseType(statusCode: 404)]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Recupera o funcionário identificado por seu {id}."
        )]
        [Produces("application/json")]
        [ProducesResponseType(statusCode: 200, Type = typeof(EmployeeDTO))]
        [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        [ProducesResponseType(statusCode: 404)]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Registra novo funcionário na base.")]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Atualizada dados de funcionário identificado por seu {id}."
        )]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deleta funcionário identificado por seu {id}."
        )]
        public void Delete(int id)
        {
        }
    }
}
