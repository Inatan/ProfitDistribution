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
                    matricula = "0009968",
                    nome = "Victor Wilson", 
                    area = "Diretoria",
                    cargo = "Diretor Financeiro",
                    salario_bruto = 12696.20M,
                    data_de_admissao = new DateTime(2012, 01, 05)
                };
            int weight = ActAreaWeight(employee);
            Assert.Equal(1, weight);
        }

        [Fact]
        public void CategorizeEmployeeOfContabilidade_Returns2()
        {
            Employee employee = 
                new Employee() {
                    matricula = "0004468",
                    nome = "Flossie Wilson",
                    area = "Contabilidade",
                    cargo = "Auxiliar de Contabilidade",
                    salario_bruto = 1396.52M,
                    data_de_admissao = new DateTime(2015, 01, 05) 
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
                    matricula = "0002105",
                    nome = "Dorthy Lee",
                    area = "Financeiro",
                    cargo = "Estagiário",
                    salario_bruto = 1491.45M,
                    data_de_admissao = new DateTime(2015, 03, 16)
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
                    matricula = "0006335",
                    nome = "Beulah Long",
                    area = "Tecnologia",
                    cargo = "Jovem Aprendiz",
                    salario_bruto = 1019.88M,
                    data_de_admissao = new DateTime(2014, 08, 27)
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
                    matricula = "0001843",
                    nome = "Daugherty Kramer",
                    area = "Serviços Gerais",
                    cargo = "Atendente de Almoxarifado",
                    salario_bruto = 2120.08M,
                    data_de_admissao = new DateTime(2016, 04, 21)
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
                    matricula = "0008601",
                    nome = "Taylor Mccarthy",
                    area = "Relacionamento com o Cliente",
                    cargo = "Auxiliar de Ouvidoria",
                    salario_bruto = 1800.16M,
                    data_de_admissao = new DateTime(2017, 03, 31)
                };
            int weight = ActAreaWeight(employee);
            Assert.Equal(5, weight);
        }
    }
}
