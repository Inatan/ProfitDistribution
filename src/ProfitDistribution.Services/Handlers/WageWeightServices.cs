using ProfitDistribution.Domain.Model;

namespace ProfitDistribution.Services.Handlers
{
    public class WageWeightServices : IWeightServices
    {
        public int Categorize(Employee employee, decimal salary)
        {
            int quantityWage = employee.MeasureQuantityMinimalSalaries(salary);
            if (employee.Cargo == "Estagiário" || quantityWage <= 3)
                return 1;
            else if(quantityWage > 3 && quantityWage <= 5)
                return 2;
            else if (quantityWage > 5 && quantityWage <= 8)
                return 3;
            return 5;
        }
    }
}
