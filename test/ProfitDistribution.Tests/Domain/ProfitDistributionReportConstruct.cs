using ProfitDistribution.Domain.Model;
using ProfitDistribution.Services.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ProfitDistribution.Tests.Domain
{
    public class ProfitDistributionReportConstruct
    {
        [Theory]
        [InlineData(500000, 72073.40)]
        [InlineData(300000, -127926.60)]
        void WhenConstructProfitDistribution_ReturnsExpectValues(decimal valueToDistribution, decimal expectedBalance)
        {
            Dictionary<string,Employee> employees =
                new Dictionary<string, Employee>
                {
                    { "0014319",new Employee("0014319", "Abraham Jones", "Diretoria", "Diretor Tecnologia", 18053.25M, new DateTime(2016, 07, 05)) },
                    { "0004468",new Employee("0004468", "Flossie Wilson", "Contabilidade", "Auxiliar de Contabilidade", 1396.52M, new DateTime(2015, 01, 05)) },
                    { "0002949",new Employee("0002949", "Stephenson Stone", "Financeiro", "Analista de Finanças", 5694.14M, new DateTime(2014, 01, 26))}
                };
            decimal sumExpected = 427926.60M;
            decimal countExpeted = 3;

            ParticipationServices participationServices = new ParticipationServices();
            List<Participation> participations = participationServices.GenerateParticipations(employees).ToList();
            ProfitDistributionReport report = new ProfitDistributionReport(participations,valueToDistribution);

            Assert.Equal(sumExpected, report.total_distribuido);
            Assert.Equal(countExpeted, report.total_de_funcionarios);
            Assert.Equal(expectedBalance, report.saldo_total_disponibilizado);
        }
    }
}
