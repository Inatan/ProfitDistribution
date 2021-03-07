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
            Employee employee = 
                new Employee()
                {
                    matricula = "0014319",
                    nome = "Abraham Jones",
                    area = "Diretoria",
                    cargo = "Diretor Tecnologia",
                    salario_bruto = 18053.25M,
                    data_de_admissao = new DateTime(2016, 07, 05)
                };
            ParticipationServices participationServices = new ParticipationServices();
            Participation participationResult = participationServices.EmployeeToParticipation(employee);
            Participation participationExpected = new Participation("0014319", "Abraham Jones", 173311.20M);
            Assert.Equal(participationExpected.valor_da_participação,participationResult.valor_da_participação);
            Assert.Equal(participationExpected.nome,participationResult.nome);
            Assert.Equal(participationExpected.matricula,participationResult.matricula);

        }

    }
}
