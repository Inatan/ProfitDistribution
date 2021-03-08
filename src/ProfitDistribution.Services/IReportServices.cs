using System.Threading.Tasks;

namespace ProfitDistribution.Services
{
    public interface IReportServices
    {
        Task<object> PresentReport(string value);
    }
}
