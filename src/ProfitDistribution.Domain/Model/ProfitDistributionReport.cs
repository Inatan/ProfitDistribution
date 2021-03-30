using System.Collections.Generic;
using System.Linq;

namespace ProfitDistribution.Domain.Model
{
    public class ProfitDistributionReport
    {
        
        public IEnumerable<Participation> Participations { get; set; }
        public  int EmployeeTotal { get; set; }
        public  decimal DistributedTotal { get; set; }
        public decimal AvailableTotal { get; set; }
        public decimal AvailableTotalBalace { get; set; }

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
