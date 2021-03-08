using ProfitDistribution.Domain.Model;

namespace ProfitDistribution.Services
{
    public interface IWeightCalculatorServices
    {
        int Calculate(IWeightServices weight, Employee employee,decimal salary=0);
    }
}
