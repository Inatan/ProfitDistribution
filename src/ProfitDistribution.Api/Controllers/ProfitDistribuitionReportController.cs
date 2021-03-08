using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProfitDistribution.Api.DTO;
using ProfitDistribution.Api.Model;
using ProfitDistribution.Services;
using System.Linq;
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
        private readonly ILogger<ProfitDistribuitionReportController> _logger;

        public ProfitDistribuitionReportController(IReportServices services, IMapper mapper, ILogger<ProfitDistribuitionReportController> logger)
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

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(statusCode: 200, Type = typeof(DistributeValueDTO))]
        [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        [ProducesResponseType(statusCode: 404)]
        public async Task<IActionResult> DistributeProfitPost([FromBody] DistributeValueDTO distributeValueDTO)
        {
            if (!ModelState.IsValid)
            {
                logError("Erro no envio de valor para distribuir");
                return BadRequest(ErrorResponse.FromModelState(ModelState));
            }
            
            var report = await _services.PresentReport(distributeValueDTO.ValorDistribuir);
            var reportDTO = _mapper.Map<ProfitDistributionReportDTO>(report);

            return Ok(reportDTO);
        }
    }
}
