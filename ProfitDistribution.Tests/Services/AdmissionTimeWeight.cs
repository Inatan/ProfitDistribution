using ProfitDistribution.Domain.Model;
using ProfitDistribution.Services.Handlers;
using System;
using Xunit;

namespace ProfitDistribution.Tests.Services
{
    public class AdmissionTimeWeight
    {
        private int ActAdmissionTimeWeight(Employee employee)
        {
            ProfitDistribution.Services.Handlers.AdmissionTimeWeightServices admissionTimeWeight = new ProfitDistribution.Services.Handlers.AdmissionTimeWeightServices();
            WeightCalculatorServices calculatorHandler = new WeightCalculatorServices();
            int weight = calculatorHandler.Calculate(admissionTimeWeight, employee);
            return weight;
        }

        [Fact]
        public void CategorizeMoreThan8YearsAdmission_Returns5()
        {
            Employee employee = new Employee("0009968", "Victor Wilson", "Diretoria", "Diretor Financeiro", 12696.20M, new DateTime(2012, 01, 05));
            int weight = ActAdmissionTimeWeight(employee);
            Assert.Equal(5, weight);
        }

        [Fact]
        public void CategorizeMoreThan3YearsAdmission_Returns3()
        {
            Employee employee = new Employee("0004468", "Flossie Wilson", "Contabilidade", "Auxiliar de Contabilidade", 1396.52M,new DateTime(2015,01,05));
            int weight = ActAdmissionTimeWeight(employee);
            Assert.Equal(3, weight);
        }

        [Fact]
        public void CategorizeMoreThan1YearAdmission_Returns2()
        {
            Employee employee = new Employee("0002105", "Dorthy Lee", "Financeiro", "Estagiário", 1491.45M, new DateTime(2019, 03, 16));
            int weight = ActAdmissionTimeWeight(employee);
            Assert.Equal(2, weight);
        }

       
        [Fact]
        public void CategorizeLessThan1YearAdmission_Returns1()
        {
            Employee employee = new Employee("0008601", "Taylor Mccarthy", "Relacionamento com o Cliente", "Auxiliar de Ouvidoria", 1800.16M, new DateTime(2021, 01, 31));
            int weight = ActAdmissionTimeWeight(employee);
            Assert.Equal(1, weight);
        }
    }
}
