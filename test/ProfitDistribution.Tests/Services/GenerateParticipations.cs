using ProfitDistribution.Domain.Model;
using ProfitDistribution.Services.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ProfitDistribution.Tests.Services
{
    public class GenerateParticipations
    {
        [Fact]
        public void ConvertEmployeesGroupToParticipations_ReturnsExpectedParticipationsValues()
        {
            Dictionary<string,Employee> employees =
                new Dictionary<string, Employee>
                {
                    {"0014319", new Employee("0014319", "Abraham Jones", "Diretoria", "Diretor Tecnologia", 18053.25M, new DateTime(2016, 07, 05)) },
                    {"0004468", new Employee("0004468", "Flossie Wilson", "Contabilidade", "Auxiliar de Contabilidade", 1396.52M, new DateTime(2015, 01, 05))},
                    {"0002949", new Employee("0002949", "Stephenson Stone", "Financeiro", "Analista de Finanças", 5694.14M, new DateTime(2014, 01, 26)) }
                };
            int countExpected = 3;
            decimal sumExpected = 427926.60M;

            ParticipationServices participationServices = new ParticipationServices();
            List<Participation> participations = participationServices.GenerateParticipations(employees).ToList();
            int countResult = participations.Count;
            decimal sumResult = participations.Sum(p => p.valor_da_participação);

            Assert.Equal(countExpected, countResult);
            Assert.Equal(sumExpected, sumExpected);
        }

    }
}
