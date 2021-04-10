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
        void WhenConstructProfitDistributionReturnsExpectValues(decimal valueToDistribution, decimal expectedBalance)
        {
            Dictionary<string,Employee> employees =
                new Dictionary<string, Employee>
                {
                    {   
                        "0014319",
                        new Employee()
                        {
                           RegistrationId = "0014319", 
                           Name = "Abraham Jones", 
                           OccupationArea = "Diretoria", 
                           Office = "Diretor Tecnologia", 
                           GrossSalary = 18053.25M, 
                           AdmissionDate = new DateTime(2016, 07, 05) 
                        } 
                    },
                    { 
                        "0004468",
                        new Employee()
                        {
                            RegistrationId ="0004468",
                            Name ="Flossie Wilson",
                            OccupationArea ="Contabilidade",
                            Office ="Auxiliar de Contabilidade",
                            GrossSalary = 1396.52M,
                            AdmissionDate = new DateTime(2015, 01, 05)
                        }
                    },
                    { 
                        "0002949",
                        new Employee() 
                        {
                            RegistrationId ="0002949",
                            Name ="Stephenson Stone",
                            OccupationArea ="Financeiro",
                            Office ="Analista de Finanças", 
                            GrossSalary =5694.14M, 
                            AdmissionDate = new DateTime(2014, 01, 26) 
                        }
                    }
                };
            decimal sumExpected = 427926.60M;
            decimal countExpeted = 3;

            ParticipationServices participationServices = new ParticipationServices(new SalaryServices(1100.00M));
            List<Participation> participations = participationServices.GenerateParticipations(employees).ToList();
            ProfitDistributionReport report = new ProfitDistributionReport(participations,valueToDistribution);

            Assert.Equal(sumExpected, report.DistributedTotal);
            Assert.Equal(countExpeted, report.EmployeeTotal);
            Assert.Equal(expectedBalance, report.AvailableTotalBalace);
        }
    }
}
