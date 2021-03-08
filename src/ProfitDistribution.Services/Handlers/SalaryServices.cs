using ProfitDistribution.Services;

namespace ProfitDistribution.Services.Handlers
{
    public class SalaryServices
    {
        private decimal _salary;
        public SalaryServices(decimal salary)
        {
            _salary = salary;
        }

        public decimal GetSalary()
        {
            return _salary;
        }
    }
}
