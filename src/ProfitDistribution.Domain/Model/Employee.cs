using System;

namespace ProfitDistribution.Domain.Model
{
    public class Employee
    {
        public string RegistrationId { get; set; } 
        public string Name { get; set; }
        public string OccupationArea { get; set; }
        public string Office { get; set; } 
        public decimal GrossSalary { get; set; }
        public DateTime AdmissionDate { get; set; }

        public int AdmissionYear()
        { 
            return ((new DateTime(1, 1, 1)) + (DateTime.Today - AdmissionDate)).Year;
        }

        public int MeasureQuantityMinimalSalaries(decimal minimalSalary)
        {
            return Convert.ToInt32(Math.Truncate(GrossSalary / minimalSalary));
        }
    }
}
