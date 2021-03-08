using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ProfitDistribution.Api.Controllers;
using ProfitDistribution.Api.DTO;
using ProfitDistribution.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ProfitDistribution.Tests.API
{
    public class EmployeeControllerPost
    {
        [Fact]
        public async Task WhenPostNewEmployee_ReturnsStatusCode201()
        {
            var mockMapper = new Mock<IMapper>();
            var mock = new Mock<IEmployeeServices>();
            var mockLogger = new Mock<ILogger<EmployeeController>>();

            var services = mock.Object;
            var mapper = mockMapper.Object;
            var logger = mockLogger.Object;

            var controller = new EmployeeController(services, mapper, logger);
            var model = new EmployeeDTO()
            {
                Matricula = "0014319",
                Nome = "Abraham Jones",
                Area = "Diretoria",
                Cargo = "Diretor Tecnologia",
                Salario_Bruto = "R$ 18.053,25",
                Data_de_admissao = new DateTime(2016, 07, 05)
            };
            var ret = await controller.Post(model);

            var statusCode = (ret as CreatedResult).StatusCode;
            Assert.Equal(201, statusCode);
        }

        [Fact]
        public async Task WhenPotIsInvalidFormat_ReturnsStatusCode400()
        {
            var mockMapper = new Mock<IMapper>();
            var mock = new Mock<IEmployeeServices>();
            var mockLogger = new Mock<ILogger<EmployeeController>>();

            var services = mock.Object;
            var mapper = mockMapper.Object;
            var logger = mockLogger.Object;

            var controller = new EmployeeController(services, mapper, logger);
            controller.ModelState.AddModelError("Matrícula", "Formato inválido");
            var ret = await controller.Post(null);

            var statusCode = (ret as BadRequestObjectResult).StatusCode;
            Assert.Equal(400, statusCode);
        }

        [Fact]
        public async Task WhenPostListOfNewEmployees_ReturnsStatusCode201()
        {
            var mockMapper = new Mock<IMapper>();
            var mock = new Mock<IEmployeeServices>();
            var mockLogger = new Mock<ILogger<EmployeeController>>();

            var services = mock.Object;
            var mapper = mockMapper.Object;
            var logger = mockLogger.Object;

            var controller = new EmployeeController(services, mapper, logger);
            var model = new List<EmployeeDTO>()
            { 
                new EmployeeDTO()
                {
                    Matricula = "0014319",
                    Nome = "Abraham Jones",
                    Area = "Diretoria",
                    Cargo = "Diretor Tecnologia",
                    Salario_Bruto = "R$ 18.053,25",
                    Data_de_admissao = new DateTime(2016, 07, 05)
                },
                new EmployeeDTO()
                {
                    Matricula = "0014319",
                    Nome = "Abraham Jones",
                    Area = "Diretoria",
                    Cargo = "Diretor Tecnologia",
                    Salario_Bruto = "R$ 18.053,25",
                    Data_de_admissao = new DateTime(2016, 07, 05)
                },
                new EmployeeDTO()
                {
                    Matricula = "0014319",
                    Nome = "Abraham Jones",
                    Area = "Diretoria",
                    Cargo = "Diretor Tecnologia",
                    Salario_Bruto = "R$ 18.053,25",
                    Data_de_admissao = new DateTime(2016, 07, 05)
                },
            };
            var ret = await controller.PostList(model);

            var statusCode = (ret as CreatedResult).StatusCode;
            Assert.Equal(201, statusCode);
        }
    }
}
