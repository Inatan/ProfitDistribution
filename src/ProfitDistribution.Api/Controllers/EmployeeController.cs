using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProfitDistribution.Api.DTO;
using ProfitDistribution.Api.Model;
using ProfitDistribution.Domain.Model;
using ProfitDistribution.Services;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProfitDistribution.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    //[ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v1/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _services;
        private readonly IMapper _mapper;


        public EmployeeController(IEmployeeServices services, IMapper mapper)
        {
            _services = services;
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
            var dict = await _services.GetAllEmployeesAsync();
            var dictDTO = _mapper.Map<IDictionary<string,EmployeeDTO>>(dict);
            return Ok(dictDTO);
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
            var employee = await _services.FindByKeyAsync(matricula);
            var employeeDTO = _mapper.Map<EmployeeDTO>(employee);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employeeDTO);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Registra novo funcionário na base.")]
        [ProducesResponseType(statusCode: 201, Type = typeof(EmployeeDTO))]
        [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        [ProducesResponseType(statusCode: 404)]
        public async Task<IActionResult> Post([FromBody] EmployeeDTO employeeDTO)
        {
            var mappedEmployee = _mapper.Map<Employee>(employeeDTO);

            if (!ModelState.IsValid)
                return BadRequest();

            await _services.InsertNewAsync(mappedEmployee);
            var uri = Url.Action("Get", new { matricula = mappedEmployee.Matricula });
            return Created(uri, mappedEmployee);
            
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Registra novo funcionário na base.")]
        [ProducesResponseType(statusCode: 201, Type = typeof(List<EmployeeDTO>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        [ProducesResponseType(statusCode: 404)]
        public async Task<IActionResult> Post([FromBody] IList<EmployeeDTO> employeesDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            var mappedEmployees = _mapper.Map<IList<Employee>>(employeesDTO);

            await _services.InsertListAsync(mappedEmployees);
            var uri = Url.Action("Get");
            return Created(uri, mappedEmployees);

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
            if (!ModelState.IsValid)
                return BadRequest();
            var mappedEmployee = _mapper.Map<Employee>(employeeDTO);
            await _services.UpdateAsync(mappedEmployee);
            return Ok();
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
            var employee = await _services.FindByKeyAsync(matricula);
            if (employee == null)
            {
                return NotFound();
            }
            await _services.DeleteAsync(matricula);
            return NoContent();
        }
    }
}
