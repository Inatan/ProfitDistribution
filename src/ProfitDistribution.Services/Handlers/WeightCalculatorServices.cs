using ProfitDistribution.Domain.Model;

namespace ProfitDistribution.Services.Handlers
{
    public class WeightCalculatorServices : IWeightCalculatorServices
    {
        public int Calculate(IWeightServices weight, Employee employee,decimal salary =0)
        {
            return weight.Categorize(employee, salary);
        }
    }
}
