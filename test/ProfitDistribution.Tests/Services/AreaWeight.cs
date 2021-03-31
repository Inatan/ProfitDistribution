using ProfitDistribution.Domain.Model;
using ProfitDistribution.Services.Handlers;
using System;
using Xunit;

namespace ProfitDistribution.Tests.Services
{
    public class AreaWeight
    {
        private int ActAreaWeight(Employee employee)
        {
            ProfitDistribution.Services.Handlers.AreaWeightServises areaWeight = new ProfitDistribution.Services.Handlers.AreaWeightServises();
            WeightCalculatorServices calculatorHandler = new WeightCalculatorServices();
            int weight = calculatorHandler.Calculate(areaWeight, employee);
            return weight;
        }

        [Fact]
        public void CategorizeEmployeeOfDiretoria_Returns1()
        {
            Employee employee = 
                new Employee()
                {
                    RegistrationId = "0009968",
                    Name = "Victor Wilson", 
                    OccupationArea = "Diretoria",
                    Office = "Diretor Financeiro",
                    GrossSalary = 12696.20M,
                    AdmissionDate = new DateTime(2012, 01, 05)
                };
            int weight = ActAreaWeight(employee);
            Assert.Equal(1, weight);
        }

        [Fact]
        public void CategorizeEmployeeOfContabilidade_Returns2()
        {
            Employee employee = 
                new Employee() {
                    RegistrationId = "0004468",
                    Name = "Flossie Wilson",
                    OccupationArea = "Contabilidade",
                    Office = "Auxiliar de Contabilidade",
                    GrossSalary = 1396.52M,
                    AdmissionDate = new DateTime(2015, 01, 05) 
                };
            int weight = ActAreaWeight(employee);
            Assert.Equal(2, weight);
        }

        [Fact]
        public void CategorizeEmployeeOfFinanceiro_Returns2()
        {
            Employee employee =
                new Employee()
                {
                    RegistrationId = "0002105",
                    Name = "Dorthy Lee",
                    OccupationArea = "Financeiro",
                    Office = "Estagiário",
                    GrossSalary = 1491.45M,
                    AdmissionDate = new DateTime(2015, 03, 16)
                };
            int weight = ActAreaWeight(employee);
            Assert.Equal(2, weight);
        }

        [Fact]
        public void CategorizeEmployeeOfTecnologia_Returns2()
        {
            Employee employee = 
                new Employee()
                {
                    RegistrationId = "0006335",
                    Name = "Beulah Long",
                    OccupationArea = "Tecnologia",
                    Office = "Jovem Aprendiz",
                    GrossSalary = 1019.88M,
                    AdmissionDate = new DateTime(2014, 08, 27)
                };
            int weight = ActAreaWeight(employee);
            Assert.Equal(2, weight);
        }

        [Fact]
        public void CategorizeEmployeeOfServicosGerais_Returns3()
        {
            Employee employee =
                new Employee()
                {
                    RegistrationId = "0001843",
                    Name = "Daugherty Kramer",
                    OccupationArea = "Serviços Gerais",
                    Office = "Atendente de Almoxarifado",
                    GrossSalary = 2120.08M,
                    AdmissionDate = new DateTime(2016, 04, 21)
                };
            int weight = ActAreaWeight(employee);
            Assert.Equal(3, weight);
        }

        [Fact]
        public void CategorizeEmployeeOfRelacionamentoComOCliente_Returns5()
        {
            Employee employee =
                new Employee()
                {
                    RegistrationId = "0008601",
                    Name = "Taylor Mccarthy",
                    OccupationArea = "Relacionamento com o Cliente",
                    Office = "Auxiliar de Ouvidoria",
                    GrossSalary = 1800.16M,
                    AdmissionDate = new DateTime(2017, 03, 31)
                };
            int weight = ActAreaWeight(employee);
            Assert.Equal(5, weight);
        }
    }
}
