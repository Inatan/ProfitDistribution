using ProfitDistribution.Api.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProfitDistribution.Api.DTO
{
    public class EmployeeDTO
    {
        [Required(ErrorMessage = "Matrícula é obrigatória")]
        public string Matricula { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        
        public string Nome { get; set; }
        [Required(ErrorMessage = "Area é obrigatória")]
        [Area(ErrorMessage = "Area só pode ser (Diretoria, Contabilidade, Financeiro, Tecnologia, Serviços Gerais e Relacionamento com o Cliente)")]
        public string Area { get; set; }
        [Required(ErrorMessage = "Cargo é obrigatório")]
        public string Cargo { get; set; }
        [Required(ErrorMessage = "Salário é obrigatório")]
        [Money(ErrorMessage = "Salário deve estar num formato válido e ser positivo")]
        public string Salario_Bruto { get; set; }
        [Required(ErrorMessage = "Data de admissão é obrigatória")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        [Admission(ErrorMessage = "Data de admissão não pode ser maior que a data atual")]
        public DateTime Data_de_admissao { get; set; }
    }
}
