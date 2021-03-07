﻿using AutoMapper;
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

        public ProfitDistribuitionReportController(IMapper mapper, IReportServices services, ILogger<ProfitDistribuitionReportController> logger)
        {
            _mapper = mapper;
            _services = services;
            _logger = logger;
        }

        private void logError()
        {
            var errorList = ModelState.ToDictionary(
                   error => error.Key,
                   error => error.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

            _logger.LogError($"Erro no envio de funcionário: {JsonConvert.SerializeObject(errorList)}");
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(statusCode: 200, Type = typeof(DistributeValueDTO))]
        [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
        [ProducesResponseType(statusCode: 404)]
        public async Task<IActionResult> DistributeProfit([FromBody] DistributeValueDTO distributeValueDTO)
        {
            if (!ModelState.IsValid)
            {
                logError();
                return BadRequest(ErrorResponse.FromModelState(ModelState));
            }
            
            var report = await _services.PresentReport(distributeValueDTO.ValorDistribuir);
            var reportDTO = _mapper.Map<ProfitDistributionReportDTO>(report);

            return Ok(reportDTO);
        }
    }
}
