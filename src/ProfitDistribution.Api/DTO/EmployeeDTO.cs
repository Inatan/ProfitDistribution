using ProfitDistribution.Api.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProfitDistribution.Api.DTO
{
    public class EmployeeDTO
    {
        [Required(ErrorMessage = "matricula é obrigatória")]
        public string Matricula { get; set; }
        [Required(ErrorMessage = "nome é obrigatório")]
        
        public string Nome { get; set; }
        [Required(ErrorMessage = "area é obrigatória")]
        [Area(ErrorMessage = "area só pode ser (Diretoria, Contabilidade, Financeiro, Tecnologia, Serviços Gerais e Relacionamento com o Cliente)")]
        public string Area { get; set; }
        [Required(ErrorMessage = "cargo é obrigatório")]
        public string Cargo { get; set; }
        [Required(ErrorMessage = "salario_bruto é obrigatório")]
        [Money(ErrorMessage = "salario_bruto deve estar em um formato monetário (R$ XX,XX) e positivo")]
        public string Salario_bruto { get; set; }
        [Required(ErrorMessage = "data_de_admissao é obrigatória")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        [Admission(ErrorMessage = "data_de_admissao não pode ser maior que a data atual")]
        public DateTime Data_de_admissao { get; set; }
    }
}
