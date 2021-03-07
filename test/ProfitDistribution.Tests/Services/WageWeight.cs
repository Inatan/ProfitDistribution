using ProfitDistribution.Domain.Model;
using ProfitDistribution.Services.Handlers;
using System;
using Xunit;

namespace ProfitDistribution.Tests.Services
{
    public class WageWeight
    {
       
        private int ActWageWeight(Employee employee)
        {
            WageWeightServices wageWeight = new WageWeightServices();
            WeightCalculatorServices calculatorHandler = new WeightCalculatorServices();
            int weight = calculatorHandler.Calculate(wageWeight, employee);
            return weight;
        }

        [Fact]
        public void CategorizeEmployeeEstagiario_Returns1()
        {
            Employee employee = new Employee()
            {
                Matricula = "0002105", 
                Nome ="Dorthy Lee", 
                Area = "Financeiro", 
                Cargo ="Estagi�rio", 
                salario_bruto = 1491.45M, 
                Data_de_admissao = new DateTime(2015, 03, 16)
            };
            int weight = ActWageWeight(employee);
            Assert.Equal(1, weight);
        }

        [Fact]
        public void CategorizeEmployeeTill3Salaries_Returns1()
        {
            Employee employee = 
                new Employee()
                {
                    Matricula = "0007361",
                    Nome = "Avila Kane",
                    Area = "Contabilidade",
                    Cargo = "Auxiliar Administrativo",
                    salario_bruto = 2166.25M,
                    Data_de_admissao = new DateTime(2016, 09, 16) 
                };
            int weight = ActWageWeight(employee);
            Assert.Equal(1, weight);
        }

        [Fact]
        public void CategorizeEmployeeTill5Salarieso_Returns2()
        {
            Employee employee = 
                new Employee()
                { 
                    Matricula = "0002949", 
                    Nome = "Stephenson Stone", 
                    Area = "Financeiro", 
                    Cargo = "Analista de Finan�as", 
                    salario_bruto = 5694.14M, 
                    Data_de_admissao = new DateTime(2015, 03, 16) 
                };
            int weight = ActWageWeight(employee);
            Assert.Equal(2, weight);
        }

      
        [Fact]
        public void CategorizeEmployeeTill8Salarieso_Returns3()
        {
            Employee employee = new Employee()
            {
                Matricula = "0002949",
                Nome = "Stephenson Stone",
                Area = "Financeiro",
                Cargo = "Analista de Finan�as",
                salario_bruto = 7694.14M,
                Data_de_admissao = new DateTime(2015, 03, 16)
            };
            int weight = ActWageWeight(employee);
            Assert.Equal(3, weight);
        }

        [Fact]
        public void CategorizeEmployeeMoreThan8Salarieso_Returns5()
        {
            Employee employee = new Employee()
            { 
                Matricula = "0009968", 
                Nome = "Victor Wilson", 
                Area = "Diretoria",
                Cargo = "Diretor Financeiro", 
                salario_bruto = 12696.20M, 
                Data_de_admissao = new DateTime(2012, 01, 05) 
            };
            int weight = ActWageWeight(employee);
            Assert.Equal(5, weight);
        }
    }
}
