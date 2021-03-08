using Microsoft.Extensions.Configuration;
using ProfitDistribution.Domain.Model;
using System.Collections.Generic;

namespace ProfitDistribution.Services.Handlers
{
    public class ParticipationServices : IParticipationServices
    {
        private readonly SalaryServices _salaryServices;
        public ParticipationServices(SalaryServices salaryServices)
        {
            _salaryServices = salaryServices;
        }

        public Participation EmployeeToParticipation(Employee employee)
        {
            WeightCalculatorServices calculatorHandler = new WeightCalculatorServices();

            AdmissionTimeWeightServices admissionWeight = new AdmissionTimeWeightServices();
            AreaWeightServises areaWeight = new AreaWeightServises();
            WageWeightServices wageWeight = new WageWeightServices();

            int admission = calculatorHandler.Calculate(admissionWeight, employee);
            int area = calculatorHandler.Calculate(areaWeight, employee);
            int wage = calculatorHandler.Calculate(wageWeight, employee, _salaryServices.GetSalary());

            Participation participation = new Participation(employee, admission,area,wage);
            return participation;
        }

        public IEnumerable<Participation> GenerateParticipations(IDictionary<string, Employee> employees)
        {
            List<Participation> participations = new List<Participation>();
            foreach (Employee employee in employees.Values)
            {
                Participation participation = this.EmployeeToParticipation(employee);
                participations.Add(participation);
            }
            return participations;
        }


    }
}
