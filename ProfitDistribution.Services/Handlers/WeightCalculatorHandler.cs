using ProfitDistribution.Domain.Model;

namespace ProfitDistribution.Services.Handlers
{
    public class WeightCalculatorHandler
    {
        public WeightCalculatorHandler() { }

        public int Calculate(IWeight weight, Employee employee)
        {
            return weight.Categorize(employee);
        }
    }
}
