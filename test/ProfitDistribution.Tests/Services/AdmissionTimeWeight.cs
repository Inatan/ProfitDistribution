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
                matricula = "0009968",
                nome = "Victor Wilson",
                cargo = "Diretoria",
                area = "Diretor Financeiro",
                salario_bruto = 12696.20M,
                data_de_admissao = new DateTime(2012, 01, 05) 
            };
            int weight = ActAdmissionTimeWeight(employee);
            Assert.Equal(5, weight);
        }

        [Fact]
        public void CategorizeMoreThan3YearsAdmission_Returns3()
        {
            Employee employee = new Employee()
            {
                matricula = "0004468",
                nome = "Flossie Wilson",
                cargo = "Contabilidade",
                area = "Auxiliar de Contabilidade",
                salario_bruto = 1396.52M,
                data_de_admissao = new DateTime(2015,01,05) 
            };
            int weight = ActAdmissionTimeWeight(employee);
            Assert.Equal(3, weight);
        }

        [Fact]
        public void CategorizeMoreThan1YearAdmission_Returns2()
        {
            Employee employee = new Employee() 
            {
                matricula = "0002105",
                nome = "Dorthy Lee",
                cargo = "Financeiro",
                area = "Estagiário",
                salario_bruto = 1491.45M,
                data_de_admissao = new DateTime(2019, 03, 16) 
            };
            int weight = ActAdmissionTimeWeight(employee);
            Assert.Equal(2, weight);
        }

       
        [Fact]
        public void CategorizeLessThan1YearAdmission_Returns1()
        {
            Employee employee = new Employee()
            {
                matricula = "0008601",
                nome = "Taylor Mccarthy",
                cargo = "Relacionamento com o Cliente",
                area = "Auxiliar de Ouvidoria",
                salario_bruto = 1800.16M,
                data_de_admissao = new DateTime(2021, 01, 31)
            };
            int weight = ActAdmissionTimeWeight(employee);
            Assert.Equal(1, weight);
        }
    }
}
