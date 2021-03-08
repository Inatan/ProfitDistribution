using ProfitDistribution.Domain.Model;
using System.Collections.Generic;

namespace ProfitDistribution.Services
{
    public interface IParticipationServices
    {
        Participation EmployeeToParticipation(Employee employee);

        IEnumerable<Participation> GenerateParticipations(IDictionary<string, Employee> employees);

    }
}
