using ProfitDistribution.Domain.Model;
using ProfitDistribution.Services.Handlers;
using System;
using Xunit;

namespace ProfitDistribution.Tests
{
    public class AreaWeight
    {
        private int ActAreaWeight(Employee employee)
        {
            Services.Handlers.AreaWeight areaWeight = new Services.Handlers.AreaWeight();
            WeightCalculatorHandler calculatorHandler = new WeightCalculatorHandler();
            int weight = calculatorHandler.Calculate(areaWeight, employee);
            return weight;
        }

        [Fact]
        public void CategorizeEmployeeOfDiretoria_Returns1()
        {
            Employee employee = new Employee("0009968", "Victor Wilson", "Diretoria", "Diretor Financeiro", 12696.20M, new DateTime(2012, 01, 05));
            int weight = ActAreaWeight(employee);
            Assert.Equal(1, weight);
        }

        [Fact]
        public void CategorizeEmployeeOfContabilidade_Returns2()
        {
            Employee employee = new Employee("0004468", "Flossie Wilson", "Contabilidade", "Auxiliar de Contabilidade", 1396.52M,new DateTime(2015,01,05));
            int weight = ActAreaWeight(employee);
            Assert.Equal(2, weight);
        }

        [Fact]
        public void CategorizeEmployeeOfFinanceiro_Returns2()
        {
            Employee employee = new Employee("0002105", "Dorthy Lee", "Financeiro", "Estagiário", 1491.45M, new DateTime(2015, 03, 16));
            int weight = ActAreaWeight(employee);
            Assert.Equal(2, weight);
        }

        [Fact]
        public void CategorizeEmployeeOfTecnologia_Returns2()
        {
            Employee employee = new Employee("0006335", "Beulah Long", "Tecnologia", "Jovem Aprendiz", 1019.88M, new DateTime(2014, 08, 27));
            int weight = ActAreaWeight(employee);
            Assert.Equal(2, weight);
        }

        [Fact]
        public void CategorizeEmployeeOfServicosGerais_Returns3()
        {
            Employee employee = new Employee("0001843", "Daugherty Kramer", "Serviços Gerais", "Atendente de Almoxarifado", 2120.08M, new DateTime(2016, 04, 21));
            int weight = ActAreaWeight(employee);
            Assert.Equal(3, weight);
        }

        [Fact]
        public void CategorizeEmployeeOfRelacionamentoComOCliente_Returns5()
        {
            Employee employee = new Employee("0008601", "Taylor Mccarthy", "Relacionamento com o Cliente", "Auxiliar de Ouvidoria", 1800.16M, new DateTime(2017, 03, 31));
            int weight = ActAreaWeight(employee);
            Assert.Equal(5, weight);
        }
    }
}
