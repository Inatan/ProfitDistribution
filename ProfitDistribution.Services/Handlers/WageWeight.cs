using ProfitDistribution.Domain.Model;

namespace ProfitDistribution.Services.Handlers
{
    public class WageWeight : IWeight
    {
        public int Categorize(Employee employee)
        {
            decimal salary = 1100.00M;
            int quantityWage = employee.MeasureQuantityMinimalSalaries(salary);
            if (employee.cargo == "Estagiário" || quantityWage <= 3)
                return 1;
            else if(quantityWage > 3 && quantityWage <= 5)
                return 2;
            else if (quantityWage > 5 && quantityWage <= 8)
                return 3;
            else if (quantityWage > 8)
                return 5;
            return 0;
        }
    }
}
