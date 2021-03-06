using ProfitDistribution.Domain.Model;

namespace ProfitDistribution.Services.Handlers
{
    public class AdmissionTimeWeight : IWeight
    {
        public int Categorize(Employee employee)
        {
            int admissionYear = employee.AdmissionYear();
            if (admissionYear <= 1)
                return 1;
            else if (admissionYear > 1 && admissionYear <= 3)
                return 2;
            else if (admissionYear > 3 && admissionYear <= 8)
                return 3;
            else if (admissionYear > 8)
                return 5;
            return 0;
        }
    }
}
