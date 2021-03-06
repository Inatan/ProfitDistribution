using ProfitDistribution.Domain.Model;

namespace ProfitDistribution.Services.Handlers
{
    public interface IWeight
    {
        int Categorize(Employee employee);
    }
}
