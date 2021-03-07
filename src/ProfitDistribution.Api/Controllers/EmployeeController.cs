using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProfitDistribution.Api.DTO;
using ProfitDistribution.Api.Model;
using ProfitDistribution.Domain.Model;
using ProfitDistribution.Infrastructure;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace ProfitDistribution.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    //[ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v1/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepository<Employee> _repo;
        private readonly IMapper _mapper;


        public EmployeeController(IRepository<Employee> repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Recupera o lista de funcionários."
        )]
        [Produces("application/json")]
        [ProducesResponseType(statusCode: 200, Type = typeof(EmployeeDTO))]
        [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> Get()
        {
            var lista = await _repo.GetAllAsync();
            return Ok(lista);
        }

        [HttpGet("{matricula}")]
        [SwaggerOperation(
            Summary = "Recupera o funcionário identificado por seu {id}."
        )]
        [Produces("application/json")]
        [ProducesResponseType(statusCode: 200, Type = typeof(EmployeeDTO))]
        [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        [ProducesResponseType(statusCode: 404)]
        public async Task<IActionResult> Get(string matricula)
        {
            Employee employee = await _repo.FindAsync(matricula);
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
        public async Task<IActionResult> Post([FromBody] EmployeeDTO employee)
        {
            if (ModelState.IsValid)
            {
                await _repo.AddAsync(employee.matricula, _mapper.Map<Employee>(employee));
                var uri = Url.Action("Recuperar", new { matricula = employee.matricula });
                return Created(uri, employee);
            }
            return BadRequest();
        }

        [HttpPut("{matricula}")]
        [SwaggerOperation(
            Summary = "Atualizada dados de funcionário identificado por seu {id}."
        )]
        [ProducesResponseType(statusCode: 200)]
        [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        [ProducesResponseType(statusCode: 404)]
        public async Task<IActionResult> Put([FromBody] EmployeeDTO employee)
        {
            if (ModelState.IsValid)
            {
                await _repo.UpdateAsync(employee.matricula, _mapper.Map<Employee>(employee));
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{matricula}")]
        [SwaggerOperation(
            Summary = "Deleta funcionário identificado por seu {id}."
        )]
        [ProducesResponseType(statusCode: 204)]
        [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        [ProducesResponseType(statusCode: 404)]
        public async Task<IActionResult> Delete(string matricula)
        {
            var employee = await _repo.FindAsync(matricula);
            if (employee == null)
            {
                return NotFound();
            }
            await _repo.RemoveAsync(matricula);
            return NoContent();
        }
    }
}
