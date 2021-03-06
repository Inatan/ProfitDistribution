using ProfitDistribution.Domain.Model;
using ProfitDistribution.Services.Handlers;
using System;
using Xunit;

namespace ProfitDistribution.Tests.Services
{
    public class EmployeeToParticipation
    {
        [Fact]
        public void ConvertEmployeeToParticipation_ReturnsExpectedParticipation()
        {
            Employee employee = new Employee("0014319", "Abraham Jones", "Diretoria", "Diretor Tecnologia", 18053.25M, new DateTime(2016, 07, 05));
            ParticipationServices participationServices = new ParticipationServices();
            Participation participationResult = participationServices.EmployeeToParticipation(employee);
            Participation participationExpected = new Participation("0014319", "Abraham Jones", 173311.20M);
            Assert.Equal(participationExpected.valor_da_participação,participationResult.valor_da_participação);
            Assert.Equal(participationExpected.nome,participationResult.nome);
            Assert.Equal(participationExpected.matricula,participationResult.matricula);

        }

    }
}
