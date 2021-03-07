using System;
using System.ComponentModel.DataAnnotations;

namespace ProfitDistribution.Api.DTO
{
    public class EmployeeDTO
    {
        [Required]
        public string matricula { get; set; }
        [Required]
        public string nome { get; set; }
        [Required]
        public string area { get; set; }
        [Required]
        public string cargo { get; set; }
        [Required]
        public string salario_bruto { get; set; }
        [Required]
        public DateTime data_de_admissao { get; set; }
    }
}
