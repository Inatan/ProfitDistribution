﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProfitDistribution.Api.Controllers;
using ProfitDistribution.Api.DTO;
using ProfitDistribution.Domain.Model;
using ProfitDistribution.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
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
            var mock = new Mock<IRepository<Employee>>();
            
            var repo = mock.Object;
            var mapper = mockMapper.Object;

            var controlador = new EmployeeController(repo, mapper);
            var model = new EmployeeDTO()
            {
                Matricula = "0014319",
                Nome = "Abraham Jones",
                Area = "Diretoria",
                Cargo = "Diretor Tecnologia",
                Salario_Bruto = "R$ 18.053,25",
                Data_de_admissao = new DateTime(2016, 07, 05)
            };
            var retorno = await controlador.Post(model);

            var statusCodeRetornado = (retorno as StatusCodeResult).StatusCode;
            Assert.Equal(201, statusCodeRetornado);
        }
    }
}