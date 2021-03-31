using System;

namespace ProfitDistribution.Domain.Model
{
    public class Employee
    {
        public string Matricula { get; set; } // RegistrationId
        public string Nome { get; set; } // Name
        public string Area { get; set; } //OccupationArea
        public string Cargo { get; set; } // Office
        public decimal Salario_bruto { get; set; } // GrossSalary
        public DateTime Data_de_admissao { get; set; } // AdmissionDate

        public int AdmissionYear()
        { 
            return ((new DateTime(1, 1, 1)) + (DateTime.Today - Data_de_admissao)).Year;
        }

        public int MeasureQuantityMinimalSalaries(decimal minimalSalary)
        {
            return Convert.ToInt32(Math.Truncate(Salario_bruto / minimalSalary));
        }
    }
}
