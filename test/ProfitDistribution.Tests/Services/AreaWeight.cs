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
                    Matricula = "0009968",
                    Nome = "Victor Wilson", 
                    Area = "Diretoria",
                    Cargo = "Diretor Financeiro",
                    Salario_bruto = 12696.20M,
                    Data_de_admissao = new DateTime(2012, 01, 05)
                };
            int weight = ActAreaWeight(employee);
            Assert.Equal(1, weight);
        }

        [Fact]
        public void CategorizeEmployeeOfContabilidade_Returns2()
        {
            Employee employee = 
                new Employee() {
                    Matricula = "0004468",
                    Nome = "Flossie Wilson",
                    Area = "Contabilidade",
                    Cargo = "Auxiliar de Contabilidade",
                    Salario_bruto = 1396.52M,
                    Data_de_admissao = new DateTime(2015, 01, 05) 
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
                    Matricula = "0002105",
                    Nome = "Dorthy Lee",
                    Area = "Financeiro",
                    Cargo = "Estagiário",
                    Salario_bruto = 1491.45M,
                    Data_de_admissao = new DateTime(2015, 03, 16)
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
                    Matricula = "0006335",
                    Nome = "Beulah Long",
                    Area = "Tecnologia",
                    Cargo = "Jovem Aprendiz",
                    Salario_bruto = 1019.88M,
                    Data_de_admissao = new DateTime(2014, 08, 27)
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
                    Matricula = "0001843",
                    Nome = "Daugherty Kramer",
                    Area = "Serviços Gerais",
                    Cargo = "Atendente de Almoxarifado",
                    Salario_bruto = 2120.08M,
                    Data_de_admissao = new DateTime(2016, 04, 21)
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
                    Matricula = "0008601",
                    Nome = "Taylor Mccarthy",
                    Area = "Relacionamento com o Cliente",
                    Cargo = "Auxiliar de Ouvidoria",
                    Salario_bruto = 1800.16M,
                    Data_de_admissao = new DateTime(2017, 03, 31)
                };
            int weight = ActAreaWeight(employee);
            Assert.Equal(5, weight);
        }
    }
}
