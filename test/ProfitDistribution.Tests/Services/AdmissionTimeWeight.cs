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
                Matricula = "0009968",
                Nome = "Victor Wilson",
                Cargo = "Diretoria",
                Area = "Diretor Financeiro",
                Salario_bruto = 12696.20M,
                Data_de_admissao = new DateTime(2012, 01, 05) 
            };
            int weight = ActAdmissionTimeWeight(employee);
            Assert.Equal(5, weight);
        }

        [Fact]
        public void CategorizeMoreThan3YearsAdmission_Returns3()
        {
            Employee employee = new Employee()
            {
                Matricula = "0004468",
                Nome = "Flossie Wilson",
                Cargo = "Contabilidade",
                Area = "Auxiliar de Contabilidade",
                Salario_bruto = 1396.52M,
                Data_de_admissao = new DateTime(2015,01,05) 
            };
            int weight = ActAdmissionTimeWeight(employee);
            Assert.Equal(3, weight);
        }

        [Fact]
        public void CategorizeMoreThan1YearAdmission_Returns2()
        {
            Employee employee = new Employee() 
            {
                Matricula = "0002105",
                Nome = "Dorthy Lee",
                Cargo = "Financeiro",
                Area = "Estagiário",
                Salario_bruto = 1491.45M,
                Data_de_admissao = new DateTime(2019, 03, 16) 
            };
            int weight = ActAdmissionTimeWeight(employee);
            Assert.Equal(2, weight);
        }

       
        [Fact]
        public void CategorizeLessThan1YearAdmission_Returns1()
        {
            Employee employee = new Employee()
            {
                Matricula = "0008601",
                Nome = "Taylor Mccarthy",
                Cargo = "Relacionamento com o Cliente",
                Area = "Auxiliar de Ouvidoria",
                Salario_bruto = 1800.16M,
                Data_de_admissao = new DateTime(2021, 01, 31)
            };
            int weight = ActAdmissionTimeWeight(employee);
            Assert.Equal(1, weight);
        }
    }
}
