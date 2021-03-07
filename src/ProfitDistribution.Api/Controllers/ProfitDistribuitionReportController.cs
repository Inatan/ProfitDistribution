using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProfitDistribution.Api.DTO;
using ProfitDistribution.Api.Model;
using ProfitDistribution.Services;
using System.Threading.Tasks;

namespace ProfitDistribution.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v1/[controller]")]
    public class ProfitDistribuitionReportController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IReportServices _services;

        public ProfitDistribuitionReportController(IMapper mapper, IReportServices services)
        {
            _mapper = mapper;
            _services = services;
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(statusCode: 200, Type = typeof(DistributeValueDTO))]
        [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        [ProducesResponseType(statusCode: 404)]
        public async Task<IActionResult> DistributeProfit([FromBody] DistributeValueDTO distributeValueDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            var report = await _services.PresentReport(distributeValueDTO.ValorDistribuir);
            var reportDTO = _mapper.Map<ProfitDistributionReportDTO>(report);

            return Ok(reportDTO);
        }
    }
}
