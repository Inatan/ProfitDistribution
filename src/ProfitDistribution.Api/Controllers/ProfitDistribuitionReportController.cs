using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProfitDistribution.Api.DTO;
using ProfitDistribution.Api.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProfitDistribution.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v1/[controller]")]
    public class ProfitDistribuitionReportController : ControllerBase
    {
        //private readonly ILogger<ProfitDistribuitionController> _logger;
        //ILogger<ProfitDistribuitionController> logger
        private readonly IMapper _mapper;

        public ProfitDistribuitionReportController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(statusCode: 200, Type = typeof(DistributeWillDTO))]
        [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        [ProducesResponseType(statusCode: 404)]
        public async Task<IActionResult> RunProfitDistribuition([FromBody] IEnumerable<EmployeeDTO> employeeDTO)
        {
            if (ModelState.IsValid)
            {
                //DTO
                return Ok();
            }
            return BadRequest();
            
        }
    }
}
