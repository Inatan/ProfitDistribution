using ProfitDistribution.Domain.Model;

namespace ProfitDistribution.Services
{
    public interface IWeight
    {
        int Categorize(Employee employee);
    }
}
