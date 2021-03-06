using ProfitDistribution.Domain.Model;
using ProfitDistribution.Services.Handlers;
using System;
using Xunit;

namespace ProfitDistribution.Tests
{
    public class WageWeight
    {
       
        private int ActWageWeight(Employee employee)
        {
            Services.Handlers.WageWeight wageWeight = new Services.Handlers.WageWeight();
            WeightCalculatorHandler calculatorHandler = new WeightCalculatorHandler();
            int weight = calculatorHandler.Calculate(wageWeight, employee);
            return weight;
        }

        [Fact]
        public void CategorizeEmployeeEstagiario_Returns1()
        {
            Employee employee = new Employee("0002105", "Dorthy Lee", "Financeiro", "Estagiário", 1491.45M, new DateTime(2015, 03, 16));
            int weight = ActWageWeight(employee);
            Assert.Equal(1, weight);
        }

        [Fact]
        public void CategorizeEmployeeTill3Salaries_Returns1()
        {
            Employee employee = new Employee("0007361", "Avila Kane", "Contabilidade", "Auxiliar Administrativo", 2166.25M, new DateTime(2016, 09, 16));
            int weight = ActWageWeight(employee);
            Assert.Equal(1, weight);
        }

        [Fact]
        public void CategorizeEmployeeTill5Salarieso_Returns2()
        {
            Employee employee = new Employee("0002949", "Stephenson Stone", "Financeiro", "Analista de Finanças", 5694.14M, new DateTime(2015, 03, 16));
            int weight = ActWageWeight(employee);
            Assert.Equal(2, weight);
        }

      
        [Fact]
        public void CategorizeEmployeeTill8Salarieso_Returns3()
        {
            Employee employee = new Employee("0002949", "Stephenson Stone", "Financeiro", "Analista de Finanças", 7694.14M, new DateTime(2015, 03, 16));
            int weight = ActWageWeight(employee);
            Assert.Equal(3, weight);
        }

        [Fact]
        public void CategorizeEmployeeMoreThan8Salarieso_Returns5()
        {
            Employee employee = new Employee("0009968", "Victor Wilson", "Diretoria", "Diretor Financeiro", 12696.20M, new DateTime(2012, 01, 05));
            int weight = ActWageWeight(employee);
            Assert.Equal(5, weight);
        }
    }
}
