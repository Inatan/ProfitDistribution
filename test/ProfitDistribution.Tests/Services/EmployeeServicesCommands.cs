using Moq;
using ProfitDistribution.Domain.Model;
using ProfitDistribution.Infrastructure;
using ProfitDistribution.Services;
using ProfitDistribution.Services.Handlers;
using System;
using System.Collections.Generic;
using Xunit;

namespace ProfitDistribution.Tests.Services
{
    public class EmployeeServicesCommands
    {
        [Fact]
        public void WhenInsertNewEmployee_EmployeeIsNotNull()
        {
            Employee obj = new Employee();
            var mock = new Mock<IEmployeeServices>();
            var services = mock.Object;

            //act
            services.InsertNewAsync(obj);

            //assert
            var ret = services.FindByKeyAsync(obj.Matricula);
            Assert.NotNull(ret);
        }

        [Fact]
        public void WhenUpdateEmployee_EmployeeIsNotNull()
        {
            Employee obj = new Employee();
            var mock = new Mock<IEmployeeServices>();
            var services = mock.Object;

            //act
            services.UpdateAsync(obj);

            //assert
            var ret = services.FindByKeyAsync(obj.Matricula);
            Assert.NotNull(ret);
        }

        [Fact]
        public void WhenInsertListNewEmployees_EmployeesAreNotNull()
        {
            Employee obj = new Employee();
            var mock = new Mock<IEmployeeServices>();
            var services = mock.Object;
            var mocklist = new Mock<IList<Employee>>();
            //act
            var list = mocklist.Object;
            services.InsertListAsync(list);

            //assert
            mock.Verify(s => s.InsertListAsync(list), Times.Once());
        }

        [Fact]
        public void FindByKeyEmployee_ReturnsEmployee()
        {
            Employee obj = new Employee();
            string key = "0008601";
            var mock = new Mock<IEmployeeServices>();
            var services = mock.Object;

            //act
            var ret = services.FindByKeyAsync(key);

            //assert
            mock.Verify(s => s.FindByKeyAsync(key), Times.Once());
        }

        [Fact]
        public void WhenGetAllEmployees_ReturnsEmployees()
        {
            Employee obj = new Employee();
            var mock = new Mock<IEmployeeServices>();
            var services = mock.Object;

            //act
            var ret = services.GetAllEmployeesAsync();

            //assert
            mock.Verify(s => s.GetAllEmployeesAsync(), Times.Once());
        }

        [Fact]
        public void WhenDeleteEmployees_RegisterOfEmployeeIsErased()
        {
            Employee obj = new Employee();
            string key = "0008601";
            var mock = new Mock<IEmployeeServices>();
            var services = mock.Object;

            //act
            var ret = services.DeleteAsync(key);

            //assert
            mock.Verify(s => s.DeleteAsync(key), Times.Once());
        }

        [Fact]
        public void WhenEmployeeIsNotValid_ThrowsException()
        {
            Employee obj = new Employee();
            var mock = new Mock<IRepository<Employee>>();
            var repository = mock.Object;
            var services = new EmployeeServices(repository);
            Employee employee = new Employee()
            {
                Matricula = "0014319",
                Nome = "Abraham Jones",
                Area = "Diretoria",
                Cargo = "Diretor Tecnologia",
                Salario_bruto = 18053.25M,
                Data_de_admissao = new DateTime(2022, 07, 05)
            };
            Employee employee2 = new Employee()
            {
                Matricula = "0014319",
                Nome = "Abraham Jones",
                Area = "Diretoria",
                Cargo = "Diretor Tecnologia",
                Salario_bruto = -18053.25M,
                Data_de_admissao = new DateTime(2016, 07, 05)
            };
            Employee employee3 = new Employee()
            {
                Matricula = "0014319",
                Nome = "Abraham Jones",
                Area = "Diretoriaaa",
                Cargo = "Diretor Tecnologia",
                Salario_bruto = 18053.25M,
                Data_de_admissao = new DateTime(2016, 07, 05)
            };
            //act
            //assert
            Assert.Throws<ArgumentException>(() => services.ValidateEmployeeValues(employee));
            Assert.Throws<ArgumentException>(() => services.ValidateEmployeeValues(employee2));
            Assert.Throws<ArgumentException>(() => services.ValidateEmployeeValues(employee3));
        }

        [Fact]
        public void WhenEmployeeIsValid_ReturnsTrue()
        {
            Employee obj = new Employee();
            var mock = new Mock<IRepository<Employee>>();
            var repository = mock.Object;
            var services = new EmployeeServices(repository);
            Employee employee = new Employee()
            {
                Matricula = "0014319",
                Nome = "Abraham Jones",
                Area = "Diretoria",
                Cargo = "Diretor Tecnologia",
                Salario_bruto = 18053.25M,
                Data_de_admissao = new DateTime(2016, 07, 05)
            };

            //act
            var ret = services.ValidateEmployeeValues(employee);
            //assert
            Assert.True(ret);
        }

        [Fact]
        public void WhenListEmployeeIsNotValid_ThrowsException()
        {
            Employee obj = new Employee();
            var mock = new Mock<IRepository<Employee>>();
            var repository = mock.Object;
            var services = new EmployeeServices(repository);
            List<Employee> employees = new List<Employee>()
            {
                new Employee()
                {
                    Matricula = "0014319",
                    Nome = "Abraham Jones",
                    Area = "Diretoria",
                    Cargo = "Diretor Tecnologia",
                    Salario_bruto = 18053.25M,
                    Data_de_admissao = new DateTime(2022, 07, 05)
                },
                new Employee()
                {
                        Matricula = "0014319",
                        Nome = "Abraham Jones",
                        Area = "Diretoria",
                        Cargo = "Diretor Tecnologia",
                        Salario_bruto = 18053.25M,
                        Data_de_admissao = new DateTime(2022, 07, 05)
                },
                new Employee()
                {
                        Matricula = "0014319",
                        Nome = "Abraham Jones",
                        Area = "Diretoria",
                        Cargo = "Diretor Tecnologia",
                        Salario_bruto = 18053.25M,
                        Data_de_admissao = new DateTime(2022, 07, 05)
                },
                new Employee()
                {
                    Matricula = "0014319",
                    Nome = "Abraham Jones",
                    Area = "Diretoria",
                    Cargo = "Diretor Tecnologia",
                    Salario_bruto = 18053.25M,
                    Data_de_admissao = new DateTime(2016, 07, 05)
                },
            };
            //act
            //assert
            Assert.Throws<ArgumentException>(() => services.ValidateEmployeeList(employees));
        }

        [Fact]
        public void WhenListEmployeeIsValid_ReturnsTrue()
        {
            Employee obj = new Employee();
            var mock = new Mock<IRepository<Employee>>();
            var repository = mock.Object;
            var services = new EmployeeServices(repository);
            List<Employee> employees = new List<Employee>()
            {
                new Employee()
                {
                    Matricula = "0014319",
                    Nome = "Abraham Jones",
                    Area = "Diretoria",
                    Cargo = "Diretor Tecnologia",
                    Salario_bruto = 18053.25M,
                    Data_de_admissao = new DateTime(2016, 07, 05)
                },
                new Employee()
                {
                    Matricula ="0004468",
                    Nome ="Flossie Wilson",
                    Area ="Contabilidade",
                    Cargo ="Auxiliar de Contabilidade",
                    Salario_bruto = 1396.52M,
                    Data_de_admissao = new DateTime(2015, 01, 05)
                },
            };
            //act
            var ret = services.ValidateEmployeeList(employees);
            //assert
            Assert.True(ret);
        }
    }
}
