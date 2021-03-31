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
            Employee employee = new Employee()
            {
                RegistrationId = "0009968",
                Name = "Victor Wilson",
                Office = "Diretoria",
                OccupationArea = "Diretor Financeiro",
                GrossSalary = 12696.20M,
                AdmissionDate = new DateTime(2012, 01, 05) 
            };
            int weight = ActAdmissionTimeWeight(employee);
            Assert.Equal(5, weight);
        }

        [Fact]
        public void CategorizeMoreThan3YearsAdmission_Returns3()
        {
            Employee employee = new Employee()
            {
                RegistrationId = "0004468",
                Name = "Flossie Wilson",
                Office = "Contabilidade",
                OccupationArea = "Auxiliar de Contabilidade",
                GrossSalary = 1396.52M,
                AdmissionDate = new DateTime(2015,01,05) 
            };
            int weight = ActAdmissionTimeWeight(employee);
            Assert.Equal(3, weight);
        }

        [Fact]
        public void CategorizeMoreThan1YearAdmission_Returns2()
        {
            Employee employee = new Employee() 
            {
                RegistrationId = "0002105",
                Name = "Dorthy Lee",
                Office = "Financeiro",
                OccupationArea = "Estagiário",
                GrossSalary = 1491.45M,
                AdmissionDate = new DateTime(2019, 03, 16) 
            };
            int weight = ActAdmissionTimeWeight(employee);
            Assert.Equal(2, weight);
        }

       
        [Fact]
        public void CategorizeLessThan1YearAdmission_Returns1()
        {
            Employee employee = new Employee()
            {
                RegistrationId = "0008601",
                Name = "Taylor Mccarthy",
                Office = "Relacionamento com o Cliente",
                OccupationArea = "Auxiliar de Ouvidoria",
                GrossSalary = 1800.16M,
                AdmissionDate = new DateTime(2021, 01, 31)
            };
            int weight = ActAdmissionTimeWeight(employee);
            Assert.Equal(1, weight);
        }
    }
}
