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
                    {
                        "0014319",
                        new Employee()
                        {
                           matricula = "0014319",
                           nome = "Abraham Jones",
                           area = "Diretoria",
                           cargo = "Diretor Tecnologia",
                           salario_bruto = 18053.25M,
                           data_de_admissao = new DateTime(2016, 07, 05)
                        }
                    },
                    {
                        "0004468",
                        new Employee()
                        {
                            matricula ="0004468",
                            nome ="Flossie Wilson",
                            area ="Contabilidade",
                            cargo ="Auxiliar de Contabilidade",
                            salario_bruto = 1396.52M,
                            data_de_admissao = new DateTime(2015, 01, 05)
                        }
                    },
                    {
                        "0002949",
                        new Employee()
                        {
                            matricula ="0002949",
                            nome ="Stephenson Stone",
                            area ="Financeiro",
                            cargo ="Analista de Finanças",
                            salario_bruto =5694.14M,
                            data_de_admissao = new DateTime(2014, 01, 26)
                        }
                    }
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
