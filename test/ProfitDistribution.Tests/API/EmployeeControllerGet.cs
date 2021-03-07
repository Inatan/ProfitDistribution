using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProfitDistribution.Api.Controllers;
using ProfitDistribution.Api.DTO;
using ProfitDistribution.Domain.Model;
using ProfitDistribution.Infrastructure;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ProfitDistribution.Tests.API
{
    public class EmployeeControllerGet
    {
        [Fact]
        public async Task WhenGetEmployee_ReturnsStatusCode200()
        {
            string key = "0014319";
            var mockMapper = new Mock<IMapper>();
            var mock = new Mock<IRepository<Employee>>();
            
            mock.Setup(r => r.FindAsync(key)).ReturnsAsync(
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
            var repo = mock.Object;
            var mapper = mockMapper.Object;

            var controlador = new EmployeeController(repo, mapper);
            var retorno = await controlador.Get(key);

            var statusCodeRetornado = (retorno as OkObjectResult).StatusCode;
            Assert.Equal(200, statusCodeRetornado);
        }

        [Fact]
        public async Task WhenGetAllEmployee_ReturnsStatusCode200()
        {
            
            var mockMapper = new Mock<IMapper>();
            var mock = new Mock<IRepository<Employee>>();

            var repo = mock.Object;
            var mapper = mockMapper.Object;

            var controlador = new EmployeeController(repo, mapper);
            var retorno = await controlador.Get();

            var statusCodeRetornado = (retorno as OkObjectResult).StatusCode;
            Assert.Equal(200, statusCodeRetornado);
        }
    }
}
