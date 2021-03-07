using ProfitDistribution.Domain.Model;
using System.Collections.Generic;

namespace ProfitDistribution.Services.Handlers
{
    public class ParticipationServices : IParticipationServices
    {
        public Participation EmployeeToParticipation(Employee employee)
        {
            WeightCalculatorServices calculatorHandler = new WeightCalculatorServices();

            AdmissionTimeWeightServices admissionWeight = new AdmissionTimeWeightServices();
            AreaWeightServises areaWeight = new AreaWeightServises();
            WageWeightServices wageWeight = new WageWeightServices();

            int admission = calculatorHandler.Calculate(admissionWeight, employee);
            int area = calculatorHandler.Calculate(areaWeight, employee);
            int wage = calculatorHandler.Calculate(wageWeight, employee);

            Participation participation = new Participation(employee, admission,area,wage);
            return participation;
        }

        public IEnumerable<Participation> GenerateParticipations(IEnumerable<Employee> employees)
        {
            List<Participation> participations = new List<Participation>();
            ParticipationServices services = new ParticipationServices();
            foreach (Employee employee in employees)
            {
                Participation participation = services.EmployeeToParticipation(employee);
                participations.Add(participation);
            }
            return participations;
        }


    }
}
