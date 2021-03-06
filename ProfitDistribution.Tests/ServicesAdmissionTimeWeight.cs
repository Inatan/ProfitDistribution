using ProfitDistribution.Domain.Model;
using ProfitDistribution.Services.Handlers;
using System;
using Xunit;

namespace ProfitDistribution.Tests
{
    public class ServicesAdmissionTimeWeight
    {
        [Fact]
        public void CategorizeMoreThan8YearsAdmissionReturns5()
        {
            Employee employee = new Employee("0009968", "Victor Wilson", "Diretoria", "Diretor Financeiro", "R$ 12.696,20", new DateTime(2012, 01, 05));
            AdmissionTimeWeight admissionTimeWeight = new AdmissionTimeWeight();
            WeightCalculatorHandler calculatorHandler = new WeightCalculatorHandler();
            int weight = calculatorHandler.Calculate(admissionTimeWeight, employee);
            Assert.Equal(5, weight);
        }

        [Fact]
        public void CategorizeMoreThan3YearsAdmissionReturns3()
        {
            Employee employee = new Employee("0004468", "Flossie Wilson", "Contabilidade", "Auxiliar de Contabilidade", "R$ 1.396,52",new DateTime(2015,01,05));
            AdmissionTimeWeight admissionTimeWeight = new AdmissionTimeWeight();
            WeightCalculatorHandler calculatorHandler = new WeightCalculatorHandler();
            int weight = calculatorHandler.Calculate(admissionTimeWeight, employee);
            Assert.Equal(3, weight);
        }

        [Fact]
        public void CategorizeMoreThan1YearAdmissionReturns2()
        {
            Employee employee = new Employee("0002105", "Dorthy Lee", "Financeiro", "Estagiário", "R$ 1.491,45", new DateTime(2019, 03, 16));
            AdmissionTimeWeight admissionTimeWeight = new AdmissionTimeWeight();
            WeightCalculatorHandler calculatorHandler = new WeightCalculatorHandler();
            int weight = calculatorHandler.Calculate(admissionTimeWeight, employee);
            Assert.Equal(2, weight);
        }

       
        [Fact]
        public void CategorizeLessThan1YearAdmissionReturns1()
        {
            Employee employee = new Employee("0008601", "Taylor Mccarthy", "Relacionamento com o Cliente", "Auxiliar de Ouvidoria", "R$ 1.800,16", new DateTime(2021, 01, 31));
            AdmissionTimeWeight admissionTimeWeight = new AdmissionTimeWeight();
            WeightCalculatorHandler calculatorHandler = new WeightCalculatorHandler();
            int weight = calculatorHandler.Calculate(admissionTimeWeight, employee);
            Assert.Equal(1, weight);
        }
    }
}
