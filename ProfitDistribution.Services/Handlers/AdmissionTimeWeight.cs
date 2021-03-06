using ProfitDistribution.Domain.Model;

namespace ProfitDistribution.Services.Handlers
{
    public class AdmissionTimeWeight : IWeight
    {
        public int Categorize(Employee employee)
        {
            if (employee.admissionYear <= 1)
                return 1;
            else if (employee.admissionYear > 1 && employee.admissionYear <= 3)
                return 2;
            else if (employee.admissionYear > 3 && employee.admissionYear <= 8)
                return 3;
            else if (employee.admissionYear > 8)
                return 5;
            return 0;
        }
    }
}
