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
                matricula = "0002105", 
                nome ="Dorthy Lee", 
                area = "Financeiro", 
                cargo ="Estagiário", 
                salario_bruto = 1491.45M, 
                data_de_admissao = new DateTime(2015, 03, 16)
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
                    matricula = "0007361",
                    nome = "Avila Kane",
                    area = "Contabilidade",
                    cargo = "Auxiliar Administrativo",
                    salario_bruto = 2166.25M,
                    data_de_admissao = new DateTime(2016, 09, 16) 
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
                    matricula = "0002949", 
                    nome = "Stephenson Stone", 
                    area = "Financeiro", 
                    cargo = "Analista de Finanças", 
                    salario_bruto = 5694.14M, 
                    data_de_admissao = new DateTime(2015, 03, 16) 
                };
            int weight = ActWageWeight(employee);
            Assert.Equal(2, weight);
        }

      
        [Fact]
        public void CategorizeEmployeeTill8Salarieso_Returns3()
        {
            Employee employee = new Employee()
            {
                matricula = "0002949",
                nome = "Stephenson Stone",
                area = "Financeiro",
                cargo = "Analista de Finanças",
                salario_bruto = 7694.14M,
                data_de_admissao = new DateTime(2015, 03, 16)
            };
            int weight = ActWageWeight(employee);
            Assert.Equal(3, weight);
        }

        [Fact]
        public void CategorizeEmployeeMoreThan8Salarieso_Returns5()
        {
            Employee employee = new Employee()
            { 
                matricula = "0009968", 
                nome = "Victor Wilson", 
                area = "Diretoria",
                cargo = "Diretor Financeiro", 
                salario_bruto = 12696.20M, 
                data_de_admissao = new DateTime(2012, 01, 05) 
            };
            int weight = ActWageWeight(employee);
            Assert.Equal(5, weight);
        }
    }
}
