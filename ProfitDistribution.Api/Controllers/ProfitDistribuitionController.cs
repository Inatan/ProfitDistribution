using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProfitDistribution.Api.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfitDistribution.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfitDistribuitionController : ControllerBase
    {
        //private readonly ILogger<ProfitDistribuitionController> _logger;
        //ILogger<ProfitDistribuitionController> logger
        private readonly IMapper _mapper;

        public ProfitDistribuitionController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
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
