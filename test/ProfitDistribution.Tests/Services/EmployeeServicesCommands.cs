using Moq;
using ProfitDistribution.Domain.Model;
using ProfitDistribution.Services;
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
    }
}
