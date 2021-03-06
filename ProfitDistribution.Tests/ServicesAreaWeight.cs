using ProfitDistribution.Domain.Model;
using ProfitDistribution.Services.Handlers;
using System;
using Xunit;

namespace ProfitDistribution.Tests
{
    public class ServicesAreaWeight
    {
        [Fact]
        public void CategorizeEmployeeOfDiretoriaReturns1()
        {
            Employee employee = new Employee("0009968", "Victor Wilson", "Diretoria", "Diretor Financeiro", "R$ 12.696,20", new DateTime(2012, 01, 05));
            AreaWeight areaWeight = new AreaWeight();
            WeightCalculatorHandler calculatorHandler = new WeightCalculatorHandler();
            int weight = calculatorHandler.Calculate(areaWeight, employee);
            Assert.Equal(1, weight);
        }

        [Fact]
        public void CategorizeEmployeeOfContabilidadeReturns2()
        {
            Employee employee = new Employee("0004468", "Flossie Wilson", "Contabilidade", "Auxiliar de Contabilidade", "R$ 1.396,52",new DateTime(2015,01,05));
            AreaWeight areaWeight = new AreaWeight();
            WeightCalculatorHandler calculatorHandler = new WeightCalculatorHandler();
            int weight = calculatorHandler.Calculate(areaWeight, employee);
            Assert.Equal(2, weight);
        }

        [Fact]
        public void CategorizeEmployeeOfFinanceiroReturns2()
        {
            Employee employee = new Employee("0002105", "Dorthy Lee", "Financeiro", "Estagiário", "R$ 1.491,45", new DateTime(2015, 03, 16));
            AreaWeight areaWeight = new AreaWeight();
            WeightCalculatorHandler calculatorHandler = new WeightCalculatorHandler();
            int weight = calculatorHandler.Calculate(areaWeight, employee);
            Assert.Equal(2, weight);
        }

        [Fact]
        public void CategorizeEmployeeOfTecnologiaReturns2()
        {
            Employee employee = new Employee("0006335", "Beulah Long", "Tecnologia", "Jovem Aprendiz", "R$ 1.019,88", new DateTime(2014, 08, 27));
            AreaWeight areaWeight = new AreaWeight();
            WeightCalculatorHandler calculatorHandler = new WeightCalculatorHandler();
            int weight = calculatorHandler.Calculate(areaWeight, employee);
            Assert.Equal(2, weight);
        }

        [Fact]
        public void CategorizeEmployeeOfServicosGeraisReturns3()
        {
            Employee employee = new Employee("0001843", "Daugherty Kramer", "Serviços Gerais", "Atendente de Almoxarifado", "R$ 2.120,08", new DateTime(2016, 04, 21));
            AreaWeight areaWeight = new AreaWeight();
            WeightCalculatorHandler calculatorHandler = new WeightCalculatorHandler();
            int weight = calculatorHandler.Calculate(areaWeight, employee);
            Assert.Equal(3, weight);
        }

        [Fact]
        public void CategorizeEmployeeOfRelacionamentoComOClienteReturns5()
        {
            Employee employee = new Employee("0008601", "Taylor Mccarthy", "Relacionamento com o Cliente", "Auxiliar de Ouvidoria", "R$ 1.800,16", new DateTime(2017, 03, 31));
            AreaWeight areaWeight = new AreaWeight();
            WeightCalculatorHandler calculatorHandler = new WeightCalculatorHandler();
            int weight = calculatorHandler.Calculate(areaWeight, employee);
            Assert.Equal(5, weight);
        }
    }
}
