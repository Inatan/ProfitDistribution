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
                    RegistrationId = "0014319",
                    Name = "Abraham Jones",
                    OccupationArea = "Diretoria",
                    Office = "Diretor Tecnologia",
                    GrossSalary = 18053.25M,
                    AdmissionDate = new DateTime(2016, 07, 05)
                };
            ParticipationServices participationServices = new ParticipationServices(new SalaryServices(1100.00M));
            Participation participationResult = participationServices.EmployeeToParticipation(employee);
            Participation participationExpected = new Participation("0014319", "Abraham Jones", 173311.20M);
            Assert.Equal(participationExpected.ParticipationValue,participationResult.ParticipationValue);
            Assert.Equal(participationExpected.Name,participationResult.Name);
            Assert.Equal(participationExpected.RegistrationID,participationResult.RegistrationID);

        }

    }
}
