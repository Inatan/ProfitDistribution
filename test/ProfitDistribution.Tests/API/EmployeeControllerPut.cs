using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ProfitDistribution.Api.Controllers;
using ProfitDistribution.Api.DTO;
using ProfitDistribution.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ProfitDistribution.Tests.API
{
    public class EmployeeControllerPut
    {
        [Fact]
        public async Task WhenPostNewEmployee_ReturnsStatusCode200()
        {
            var mockMapper = new Mock<IMapper>();
            var mock = new Mock<IEmployeeServices>();
            var mockLogger = new Mock<ILogger<EmployeeController>>();
            var model = new EmployeeDTO()
            {
                Matricula = "0014319",
                Nome = "Abraham Jones",
                Area = "Diretoria",
                Cargo = "Diretor Tecnologia",
                Salario_Bruto = "R$ 18.053,25",
                Data_de_admissao = new DateTime(2016, 07, 05)
            };
            var services = mock.Object;
            var mapper = mockMapper.Object;
            var logger = mockLogger.Object;

            var controller = new EmployeeController(services, mapper, logger);
            var ret = await controller.Put(model);

            var statusCode = (ret as OkResult).StatusCode;
            Assert.Equal(200, statusCode);
        }

        [Fact]
        public async Task WhenPutIsInvalidFormat_ReturnsStatusCode400()
        {
            var mockMapper = new Mock<IMapper>();
            var mock = new Mock<IEmployeeServices>();
            var mockLogger = new Mock<ILogger<EmployeeController>>();
            
            var services = mock.Object;
            var mapper = mockMapper.Object;
            var logger = mockLogger.Object;

            var controller = new EmployeeController(services, mapper, logger);
            controller.ModelState.AddModelError("Matrícula", "Formato inválido");
            var ret = await controller.Put(null);

            var statusCode = (ret as BadRequestObjectResult).StatusCode;
            Assert.Equal(400, statusCode);
        }

    }
}
