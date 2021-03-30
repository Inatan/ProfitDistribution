using ProfitDistribution.Domain.Model;

namespace ProfitDistribution.Services.Handlers
{
    public class WageWeightServices : IWeightServices
    {
        private readonly SalaryServices _salaryServices;

        public WageWeightServices(SalaryServices salaryServices)
        {
            _salaryServices = salaryServices;
        }

        public int Categorize(Employee employee)
        {
            decimal salary = _salaryServices.GetSalary();
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
