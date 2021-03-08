using System;

namespace ProfitDistribution.Domain.Model
{
    public class Employee
    {
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string Area { get; set; }
        public string Cargo { get; set; }
        public decimal Salario_bruto { get; set; }
        public DateTime Data_de_admissao { get; set; }

        public int AdmissionYear()
        { 
            return DateTime.Today.Year - Data_de_admissao.Year;
        }

        public int MeasureQuantityMinimalSalaries(decimal minimalSalary)
        {
            return Convert.ToInt32(Math.Truncate(Salario_bruto / minimalSalary));
        }
    }
}
