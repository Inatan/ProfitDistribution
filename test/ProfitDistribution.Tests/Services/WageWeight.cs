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
            SalaryServices salaryServices = new SalaryServices(1100.00M);
            WageWeightServices wageWeight = new WageWeightServices(salaryServices);
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
                Cargo ="Estagiário", 
                Salario_bruto = 1491.45M, 
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
                    Salario_bruto = 2166.25M,
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
                    Cargo = "Analista de Finanças", 
                    Salario_bruto = 5694.14M, 
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
                Cargo = "Analista de Finanças",
                Salario_bruto = 7694.14M,
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
                Salario_bruto = 12696.20M, 
                Data_de_admissao = new DateTime(2012, 01, 05) 
            };
            int weight = ActWageWeight(employee);
            Assert.Equal(5, weight);
        }
    }
}
