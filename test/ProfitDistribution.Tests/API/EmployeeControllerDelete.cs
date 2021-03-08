using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ProfitDistribution.Api.Controllers;
using ProfitDistribution.Domain.Model;
using ProfitDistribution.Infrastructure;
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

            var controlador = new EmployeeController(services, mapper, logger);
            
            var retorno = await controlador.Delete(key);

            var statusCodeRetornado = (retorno as StatusCodeResult).StatusCode;
            Assert.Equal(204, statusCodeRetornado);
        }
    }
}
