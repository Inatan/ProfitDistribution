using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProfitDistribution.Api.Controllers;
using ProfitDistribution.Domain.Model;
using ProfitDistribution.Infrastructure;
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
            var mock = new Mock<IRepository<Employee>>();
            
            mock.Setup(r => r.FindAsync(key)).ReturnsAsync(
                new Employee()
                { 
                    matricula = "0014319",
                    nome = "Abraham Jones", 
                    area = "Diretoria", 
                    cargo = "Diretor Tecnologia", 
                    salario_bruto = 18053.25M, 
                    data_de_admissao = new DateTime(2016, 07, 05)
                }
            );
            var repo = mock.Object;
            var mapper = mockMapper.Object;

            var controlador = new EmployeeController(repo, mapper);
            
            var retorno = await controlador.Delete(key);

            var statusCodeRetornado = (retorno as StatusCodeResult).StatusCode;
            Assert.Equal(204, statusCodeRetornado);
        }
    }
}
