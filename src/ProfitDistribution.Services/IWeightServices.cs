using ProfitDistribution.Domain.Model;

namespace ProfitDistribution.Services
{
    public interface IWeightServices
    {
        int Categorize(Employee employee,decimal salary = 0);
    }
}
