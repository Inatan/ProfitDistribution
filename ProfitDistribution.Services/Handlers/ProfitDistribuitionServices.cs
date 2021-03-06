using ProfitDistribution.Domain.Model;
using System.Collections.Generic;

namespace ProfitDistribution.Services.Handlers
{
    public class ProfitDistribuitionServices
    {
        public List<Participation> GetParticipations(List<Employee> employees)
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
