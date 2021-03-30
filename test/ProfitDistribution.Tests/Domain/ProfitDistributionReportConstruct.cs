﻿using ProfitDistribution.Domain.Model;
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
                    {   
                        "0014319",
                        new Employee()
                        {
                           Matricula = "0014319", 
                           Nome = "Abraham Jones", 
                           Area = "Diretoria", 
                           Cargo = "Diretor Tecnologia", 
                           Salario_bruto = 18053.25M, 
                           Data_de_admissao = new DateTime(2016, 07, 05) 
                        } 
                    },
                    { 
                        "0004468",
                        new Employee()
                        {
                            Matricula ="0004468",
                            Nome ="Flossie Wilson",
                            Area ="Contabilidade",
                            Cargo ="Auxiliar de Contabilidade",
                            Salario_bruto = 1396.52M,
                            Data_de_admissao = new DateTime(2015, 01, 05)
                        }
                    },
                    { 
                        "0002949",
                        new Employee() 
                        {
                            Matricula ="0002949",
                            Nome ="Stephenson Stone",
                            Area ="Financeiro",
                            Cargo ="Analista de Finanças", 
                            Salario_bruto =5694.14M, 
                            Data_de_admissao = new DateTime(2014, 01, 26) 
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
