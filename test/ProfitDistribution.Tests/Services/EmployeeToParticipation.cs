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
                    Matricula = "0014319",
                    Nome = "Abraham Jones",
                    Area = "Diretoria",
                    Cargo = "Diretor Tecnologia",
                    Salario_bruto = 18053.25M,
                    Data_de_admissao = new DateTime(2016, 07, 05)
                };
            ParticipationServices participationServices = new ParticipationServices();
            Participation participationResult = participationServices.EmployeeToParticipation(employee);
            Participation participationExpected = new Participation("0014319", "Abraham Jones", 173311.20M);
            Assert.Equal(participationExpected.Valor_da_participação,participationResult.Valor_da_participação);
            Assert.Equal(participationExpected.Nome,participationResult.Nome);
            Assert.Equal(participationExpected.Matricula,participationResult.Matricula);

        }

    }
}
