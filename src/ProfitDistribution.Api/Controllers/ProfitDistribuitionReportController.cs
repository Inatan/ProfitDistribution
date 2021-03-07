using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProfitDistribution.Api.DTO;
using ProfitDistribution.Api.Model;
using ProfitDistribution.Domain.Model;
using ProfitDistribution.Infrastructure;
using ProfitDistribution.Services;
using System;
using System.Globalization;
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
        private readonly IRepository<Employee> _repo;
        private readonly IParticipationServices _services;

        public ProfitDistribuitionReportController(IMapper mapper, IRepository<Employee> repo, IParticipationServices services)
        {
            _mapper = mapper;
            _repo = repo;
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
            
            var dict = await _repo.GetAllAsync();
            var participations = _services.GenerateParticipations(dict);
            var provider = new CultureInfo("pt-BR");
            decimal toDistribution = Decimal.Parse(distributeValueDTO.ValorDistribuir, NumberStyles.Currency, provider);
            var report = new ProfitDistributionReport(participations, toDistribution);
            var reportDTO = _mapper.Map<ProfitDistributionReportDTO>(report);
            return Ok(reportDTO);
            
        }
    }
}
