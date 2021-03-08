using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ProfitDistribution.Api.Controllers;
using ProfitDistribution.Api.DTO;
using ProfitDistribution.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProfitDistribution.Tests.API
{
    public class ProfitDistributionReportPost
    {
        [Fact]
        public async Task WhenPostNewEmployee_ReturnsStatusCode200()
        {
            var mockMapper = new Mock<IMapper>();
            var mock = new Mock<IReportServices>();
            var mockLogger = new Mock<ILogger<ProfitDistributionReportController>>();

            var services = mock.Object;
            var mapper = mockMapper.Object;
            var logger = mockLogger.Object;

            var controlador = new ProfitDistributionReportController(services, mapper, logger);
            var model = new DistributeValueDTO()
            {
                ValorDistribuir = "R$ 500.000,00"
            };
            var retorno = await controlador.DistributeProfitPost(model);

            var statusCodeRetornado = (retorno as OkObjectResult).StatusCode;
            Assert.Equal(200, statusCodeRetornado);
        }

    }
}
