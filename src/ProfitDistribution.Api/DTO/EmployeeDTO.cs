using System;
using System.ComponentModel.DataAnnotations;

namespace ProfitDistribution.Api.DTO
{
    public class EmployeeDTO
    {
        //public EmployeeDTO(string matricula, string nome, string area, string cargo, string salario_bruto, DateTime data_de_admissao)
        //{
        //    this.matricula = matricula;
        //    this.nome = nome;
        //    this.area = area;
        //    this.cargo = cargo;
        //    this.salario_bruto = salario_bruto;
        //    this.data_de_admissao = data_de_admissao;
        //}

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
