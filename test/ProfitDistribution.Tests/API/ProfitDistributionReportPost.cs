using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ProfitDistribution.Api.Controllers;
using ProfitDistribution.Api.DTO;
using ProfitDistribution.Services;
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

            var controller = new ProfitDistributionReportController(services, mapper, logger);
            var model = new DistributeValueDTO()
            {
                total_disponibilizado = "R$ 500.000,00"
            };
            var ret = await controller.DistributeProfitPost(model);

            var statusCode = (ret as OkObjectResult).StatusCode;
            Assert.Equal(200, statusCode);
        }

        [Fact]
        public async Task WhenPostIsInvalidFormat_ReturnsStatusCode400()
        {
            var mockMapper = new Mock<IMapper>();
            var mock = new Mock<IReportServices>();
            var mockLogger = new Mock<ILogger<ProfitDistributionReportController>>();
            var services = mock.Object;
            var mapper = mockMapper.Object;
            var logger = mockLogger.Object;

            var controller = new ProfitDistributionReportController(services, mapper, logger);
            controller.ModelState.AddModelError("ValorDistribuir", "Formato inválido");
            var ret = await controller.DistributeProfitPost(null);

            var statusCode = (ret as BadRequestObjectResult).StatusCode;
            Assert.Equal(400, statusCode);
        }
       

    }
}
