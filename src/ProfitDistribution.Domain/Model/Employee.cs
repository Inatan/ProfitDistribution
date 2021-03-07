using System;

namespace ProfitDistribution.Domain.Model
{
    public class Employee
    {
        //public Employee() { }
        //public Employee(string matricula, string nome, string area, string cargo, decimal salario_bruto, DateTime data_de_admissao)
        //{
        //    this.matricula = matricula;
        //    this.nome = nome;
        //    this.area = area;
        //    this.cargo = cargo;
        //    this.salario_bruto = salario_bruto;
        //    this.data_de_admissao = data_de_admissao;
        //}

        //private const decimal SALARIO_MINIMO = 1100.00;
        public string matricula { get; set; }
        public string nome { get; set; }
        public string area { get; set; }
        public string cargo { get; set; }
        public decimal salario_bruto { get; set; }
        public DateTime data_de_admissao { get; set; }

        public int AdmissionYear()
        { 
            return DateTime.Today.Year - data_de_admissao.Year;
        }

        public int MeasureQuantityMinimalSalaries(decimal minimalSalary)
        {
            return Convert.ToInt32(Math.Truncate(salario_bruto / minimalSalary));
        }
    }
}
