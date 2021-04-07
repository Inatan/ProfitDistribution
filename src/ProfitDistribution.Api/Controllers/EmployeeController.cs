using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProfitDistribution.Api.DTO;
using ProfitDistribution.Api.Model;
using ProfitDistribution.Domain.Model;
using ProfitDistribution.Services;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfitDistribution.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _services;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeServices services, IMapper mapper, ILogger<EmployeeController> logger)
        {
            _services = services;
            _mapper = mapper;
            _logger = logger;
        }

        private void logError(string msgIntro)
        {
            var errorList = ModelState.ToDictionary(
                   error => error.Key,
                   error => error.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

            _logger.LogError($"{msgIntro}: {JsonConvert.SerializeObject(errorList)}");
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
            Summary = "Recupera o funcionário identificado por sua {matricula}."
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

        //[HttpPost]
        //[SwaggerOperation(Summary = "Registra novo funcionário na base.")]
        //[ProducesResponseType(statusCode: 201, Type = typeof(EmployeeDTO))]
        //[ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        //[ProducesResponseType(statusCode: 409, Type = typeof(ErrorResponse))]
        //[ProducesResponseType(statusCode: 404, Type = typeof(ErrorResponse))]
        //public async Task<IActionResult> Post([FromBody] EmployeeDTO employeeDTO)
        //{
        //    var mappedEmployee = _mapper.Map<Employee>(employeeDTO);

        //    if (!ModelState.IsValid)
        //    {
        //        logError("Erro no envio de funcionário");
        //        return BadRequest(ErrorResponse.FromModelState(ModelState));
        //    }

        //    bool isSuccess = await _services.InsertNewAsync(mappedEmployee);
        //    if(isSuccess)
        //    { 
        //        var uri = Url==null ? "/": Url.Action("Get", new { matricula = mappedEmployee.RegistrationId });
        //        return Created(uri, mappedEmployee);
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("Employee", "Funcionário já possui matrícula cadastrada");
        //        logError("Erro no envio de funcionários");
        //        return Conflict(ErrorResponse.FromModelState(ModelState));
        //    }
            
        //}

        [HttpPost]
        [SwaggerOperation(Summary = "Registra novos funcionários na base.")]
        [ProducesResponseType(statusCode: 201, Type = typeof(List<EmployeeDTO>))]
        [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        [ProducesResponseType(statusCode: 409, Type = typeof(ErrorResponse))]
        [ProducesResponseType(statusCode: 404, Type = typeof(ErrorResponse))]
        //[Route("list")]
        public async Task<IActionResult> PostList([FromBody] IList<EmployeeDTO> employeesDTO)
        {
            if (!ModelState.IsValid)
            {
                logError("Erro no envio de funcionários");
                return BadRequest(ErrorResponse.FromModelState(ModelState));
            }
            
            var mappedEmployees = _mapper.Map<IList<Employee>>(employeesDTO);

            bool isSuccess = await _services.InsertListAsync(mappedEmployees);
            if(isSuccess)
            {
                var uri = Url == null ? "/" : Url.Action("Get");
                return Created(uri, mappedEmployees);
            }
            else
            {
                ModelState.AddModelError("Employee", "Há Funcionário(s) que já possuem matrícula cadastrada");
                logError("Erro no envio de funcionários");
                return Conflict(ErrorResponse.FromModelState(ModelState));
            }
        }

        [HttpPut]
        [SwaggerOperation(
            Summary = "Atualizada dados de funcionário identificado por sua {matricula}."
        )]
        [ProducesResponseType(statusCode: 200)]
        [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        [ProducesResponseType(statusCode: 404)]
        public async Task<IActionResult> Put([FromBody] EmployeeDTO employeeDTO)
        {
            if (!ModelState.IsValid) 
            {
                logError("Erro no envio de funcionário");
                return BadRequest(ErrorResponse.FromModelState(ModelState));
            }
            var mappedEmployee = _mapper.Map<Employee>(employeeDTO);
            await _services.UpdateAsync(mappedEmployee);
            return Ok();
        }

        [HttpDelete("{matricula}")]
        [SwaggerOperation(
            Summary = "Deleta funcionário identificado por sua {matricula}."
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
