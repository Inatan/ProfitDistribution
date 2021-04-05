using System.Collections.Generic;
using System.Linq;

namespace ProfitDistribution.Domain.Model
{
    public class ProfitDistributionReport
    {

        public readonly IEnumerable<Participation> Participations;
        public readonly int EmployeeTotal;
        public readonly decimal DistributedTotal;
        public readonly decimal AvailableTotal;
        public readonly decimal AvailableTotalBalace;

        public ProfitDistributionReport(IEnumerable<Participation> participations, decimal availableTotal)
        {
            this.Participations = participations;
            this.AvailableTotal = availableTotal;
            this.EmployeeTotal = participations.Count();
            this.DistributedTotal = participations.Sum(p => p.ParticipationValue);
            this.AvailableTotalBalace = this.AvailableTotal - this.DistributedTotal;
        }
    }
}
