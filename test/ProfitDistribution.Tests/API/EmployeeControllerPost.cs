using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ProfitDistribution.Api.Controllers;
using ProfitDistribution.Api.DTO;
using ProfitDistribution.Domain.Model;
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
            mock.Setup(s => s.InsertNewAsync(It.IsAny<Employee>())).Returns(Task.FromResult<bool>(true));

            var services = mock.Object;
            var mapper = mockMapper.Object;
            var logger = mockLogger.Object;

            var controller = new EmployeeController(services, mapper, logger);
            var model = new EmployeeDTO()
            {
                RegistrationId = "0014319",
                Name = "Abraham Jones",
                OccupationArea = "Diretoria",
                Office = "Diretor Tecnologia",
                GrossSalary = "R$ 18.053,25",
                AdmissionDate = new DateTime(2016, 07, 05)
            };
            var ret = await controller.Post(model);

            var statusCode = (ret as CreatedResult).StatusCode;
            Assert.Equal(201, statusCode);
        }

        [Fact]
        public async Task WhenPostExistentEmployee_ReturnsStatusCode409()
        {
            var mockMapper = new Mock<IMapper>();
            var mock = new Mock<IEmployeeServices>();
            var mockLogger = new Mock<ILogger<EmployeeController>>();
            mock.Setup(s => s.InsertNewAsync(It.IsAny<Employee>())).Returns(Task.FromResult<bool>(false));

            var services = mock.Object;
            var mapper = mockMapper.Object;
            var logger = mockLogger.Object;

            var controller = new EmployeeController(services, mapper, logger);
            var model = new EmployeeDTO()
            {
                RegistrationId = "0014319",
                Name = "Abraham Jones",
                OccupationArea = "Diretoria",
                Office = "Diretor Tecnologia",
                GrossSalary = "R$ 18.053,25",
                AdmissionDate = new DateTime(2016, 07, 05)
            };
            var ret = await controller.Post(model);

            var statusCode = (ret as ConflictObjectResult).StatusCode;
            Assert.Equal(409, statusCode);
        }

        [Fact]
        public async Task WhenPostWithException_ThrowsExcpetion()
        {
            var mockMapper = new Mock<IMapper>();
            var mock = new Mock<IEmployeeServices>();
            var mockLogger = new Mock<ILogger<EmployeeController>>();
            var mockModel = new Mock<EmployeeDTO>();
            mock.Setup(s => s.InsertNewAsync(It.IsAny<Employee>())).Throws(new Exception());

            var services = mock.Object;
            var mapper = mockMapper.Object;
            var logger = mockLogger.Object;
            var model = mockModel.Object;

            var controller = new EmployeeController(services, mapper, logger);
           
            await Assert.ThrowsAsync<Exception>(() => controller.Post(model));
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
            var model = new List<EmployeeDTO>()
            {
                new EmployeeDTO()
                {
                    RegistrationId = "0014319",
                    Name = "Abraham Jones",
                    OccupationArea = "Diretoria",
                    Office = "Diretor Tecnologia",
                    GrossSalary = "R$ 18.053,25",
                    AdmissionDate = new DateTime(2016, 07, 05)
                },
                new EmployeeDTO()
                {
                    RegistrationId = "0014319",
                    Name = "Abraham Jones",
                    OccupationArea = "Diretoria",
                    Office = "Diretor Tecnologia",
                    GrossSalary = "R$ 18.053,25",
                    AdmissionDate = new DateTime(2016, 07, 05)
                },
                new EmployeeDTO()
                {
                    RegistrationId = "0014319",
                    Name = "Abraham Jones",
                    OccupationArea = "Diretoria",
                    Office = "Diretor Tecnologia",
                    GrossSalary = "R$ 18.053,25",
                    AdmissionDate = new DateTime(2016, 07, 05)
                },
            };

            mock.Setup(s => s.InsertListAsync(It.IsAny<List<Employee>>())).Returns(Task.FromResult<bool>(true));

            var services = mock.Object;
            var mapper = mockMapper.Object;
            var logger = mockLogger.Object;

            var controller = new EmployeeController(services, mapper, logger);
            
            var ret = await controller.PostList(model);

            var statusCode = (ret as CreatedResult).StatusCode;
            Assert.Equal(201, statusCode);
        }


    }
}
