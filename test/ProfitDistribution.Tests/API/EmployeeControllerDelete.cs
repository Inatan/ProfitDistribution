using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ProfitDistribution.Api.Controllers;
using ProfitDistribution.Domain.Model;
using ProfitDistribution.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ProfitDistribution.Tests.API
{
    public class EmployeeControllerDelete
    {
        [Fact]
        public async Task WhenDeleteEmployee_ReturnsStatusCode204()
        {
            string key = "0014319";
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<EmployeeController>>();
            var mock = new Mock<IEmployeeServices>();

            mock.Setup(r => r.FindByKeyAsync(key)).ReturnsAsync(
                new Employee()
                {
                    Matricula = "0014319",
                    Nome = "Abraham Jones",
                    Area = "Diretoria",
                    Cargo = "Diretor Tecnologia",
                    Salario_bruto = 18053.25M,
                    Data_de_admissao = new DateTime(2016, 07, 05)
                }
            );
            var services = mock.Object;
            var mapper = mockMapper.Object;
            var logger = mockLogger.Object;

            var controller = new EmployeeController(services, mapper, logger);

            var ret = await controller.Delete(key);

            var statusCode = (ret as StatusCodeResult).StatusCode;
            Assert.Equal(204, statusCode);
        }

        [Fact]
        public async Task WhenDeleteEmployeeNotExists_ReturnsStatusCode404()
        {
            string key = "0014319";
            var mockMapper = new Mock<IMapper>();
            var mock = new Mock<IEmployeeServices>();
            var mockLogger = new Mock<ILogger<EmployeeController>>();
            mock.Setup(r => r.FindByKeyAsync(key)).Returns(Task.FromResult<Employee>(null));
            var services = mock.Object;
            var mapper = mockMapper.Object;
            var logger = mockLogger.Object;

            var controller = new EmployeeController(services, mapper, logger);

            var ret = await controller.Delete(key);

            var statusCode = (ret as NotFoundResult).StatusCode;
            Assert.Equal(404, statusCode);
        }

        public async Task WhenDeleteWithException_ThrowsExcpetion()
        {
            var mockMapper = new Mock<IMapper>();
            var mock = new Mock<IEmployeeServices>();
            var mockLogger = new Mock<ILogger<EmployeeController>>();
            mock.Setup(s => s.DeleteAsync(It.IsAny<string>())).Throws(new Exception());

            var services = mock.Object;
            var mapper = mockMapper.Object;
            var logger = mockLogger.Object;

            var controller = new EmployeeController(services, mapper, logger);

            await Assert.ThrowsAsync<Exception>(() => controller.Delete(It.IsAny<string>()));

        }
    }
}
