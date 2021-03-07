using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProfitDistribution.Api.DTO;
using ProfitDistribution.Api.Model;
using ProfitDistribution.Domain.Model;
using ProfitDistribution.Infrastructure;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Globalization;
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
            var dict = await _repo.GetAllAsync();
            return Ok(dict);
        }

        [HttpGet("{matricula}")]
        [SwaggerOperation(
            Summary = "Recupera o funcionário identificado por seu {matricula}."
        )]
        [Produces("application/json")]
        [ProducesResponseType(statusCode: 200, Type = typeof(EmployeeDTO))]
        [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        [ProducesResponseType(statusCode: 404)]
        public async Task<IActionResult> Get(string matricula)
        {
            var employee = await _repo.FindAsync(matricula);
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
        public async Task<IActionResult> Post([FromBody] EmployeeDTO employeeDTO)
        {
            //var mappedEmployee = _mapper.Map<Employee>(employeeDTO);
            var provider = new CultureInfo("pt-BR");
            var mappedEmployee = new Employee(
                employeeDTO.matricula,
                employeeDTO.nome,
                employeeDTO.area,
                employeeDTO.cargo,
                Decimal.Parse(employeeDTO.salario_bruto, NumberStyles.Currency, provider),
                employeeDTO.data_de_admissao
                );


            if (ModelState.IsValid)
            {
                await _repo.AddAsync(mappedEmployee.matricula, mappedEmployee);
                var uri = Url.Action("Get", new { matricula = mappedEmployee.matricula });
                return Created(uri, mappedEmployee);
            }
            return BadRequest();
        }

        [HttpPut]
        [SwaggerOperation(
            Summary = "Atualizada dados de funcionário identificado por seu {matricula}."
        )]
        [ProducesResponseType(statusCode: 200)]
        [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        [ProducesResponseType(statusCode: 404)]
        public async Task<IActionResult> Put([FromBody] EmployeeDTO employeeDTO)
        {
            var provider = new CultureInfo("pt-BR");
            var mappedEmployee = new Employee(
                employeeDTO.matricula,
                employeeDTO.nome,
                employeeDTO.area,
                employeeDTO.cargo,
                Decimal.Parse(employeeDTO.salario_bruto, NumberStyles.Currency, provider),
                employeeDTO.data_de_admissao
                );
            if (ModelState.IsValid)
            {
                await _repo.UpdateAsync(mappedEmployee.matricula,mappedEmployee);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{matricula}")]
        [SwaggerOperation(
            Summary = "Deleta funcionário identificado por seu {matricula}."
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
