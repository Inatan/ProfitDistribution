using ProfitDistribution.Domain.Model;

namespace ProfitDistribution.Services.Handlers
{
    public class ParticipationServices
    {
        public Participation EmployeeToParticipation(Employee employee)
        {
            WeightCalculatorHandler calculatorHandler = new WeightCalculatorHandler();

            AdmissionTimeWeight admissionWeight = new AdmissionTimeWeight();
            AreaWeight areaWeight = new AreaWeight();
            WageWeight wageWeight = new WageWeight();

            int admission = calculatorHandler.Calculate(admissionWeight, employee);
            int area = calculatorHandler.Calculate(areaWeight, employee);
            int wage = calculatorHandler.Calculate(wageWeight, employee);

            Participation participation = new Participation(employee, admission,area,wage);
            return participation;
        }

        
    }
}
