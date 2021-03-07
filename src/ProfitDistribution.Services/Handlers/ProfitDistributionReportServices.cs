using ProfitDistribution.Domain.Model;
using ProfitDistribution.Infrastructure;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace ProfitDistribution.Services.Handlers
{
    public class ProfitDistributionReportServices : IReportServices
    {
        private readonly IRepository<Employee> _repo;
        private readonly IParticipationServices _services;
        public ProfitDistributionReportServices(IRepository<Employee> repo, IParticipationServices services)
        {
            _repo = repo;
            _services = services;
        }

        public async Task<object> PresentReport(string value)
        {
            decimal toDistribution = Decimal.Parse(value, NumberStyles.Currency, new CultureInfo("pt-BR"));
            var dict = await _repo.GetAllAsync();
            var participations = _services.GenerateParticipations(dict);
            var report = new ProfitDistributionReport(participations, toDistribution);
            return report;
        }
    }
}
