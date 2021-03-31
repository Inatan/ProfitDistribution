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
                RegistrationId = "0002105", 
                Name ="Dorthy Lee", 
                OccupationArea = "Financeiro", 
                Office ="Estagiário", 
                GrossSalary = 1491.45M, 
                AdmissionDate = new DateTime(2015, 03, 16)
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
                    RegistrationId = "0007361",
                    Name = "Avila Kane",
                    OccupationArea = "Contabilidade",
                    Office = "Auxiliar Administrativo",
                    GrossSalary = 2166.25M,
                    AdmissionDate = new DateTime(2016, 09, 16) 
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
                    RegistrationId = "0002949", 
                    Name = "Stephenson Stone", 
                    OccupationArea = "Financeiro", 
                    Office = "Analista de Finanças", 
                    GrossSalary = 5694.14M, 
                    AdmissionDate = new DateTime(2015, 03, 16) 
                };
            int weight = ActWageWeight(employee);
            Assert.Equal(2, weight);
        }

      
        [Fact]
        public void CategorizeEmployeeTill8Salarieso_Returns3()
        {
            Employee employee = new Employee()
            {
                RegistrationId = "0002949",
                Name = "Stephenson Stone",
                OccupationArea = "Financeiro",
                Office = "Analista de Finanças",
                GrossSalary = 7694.14M,
                AdmissionDate = new DateTime(2015, 03, 16)
            };
            int weight = ActWageWeight(employee);
            Assert.Equal(3, weight);
        }

        [Fact]
        public void CategorizeEmployeeMoreThan8Salarieso_Returns5()
        {
            Employee employee = new Employee()
            { 
                RegistrationId = "0009968", 
                Name = "Victor Wilson", 
                OccupationArea = "Diretoria",
                Office = "Diretor Financeiro", 
                GrossSalary = 12696.20M, 
                AdmissionDate = new DateTime(2012, 01, 05) 
            };
            int weight = ActWageWeight(employee);
            Assert.Equal(5, weight);
        }
    }
}
