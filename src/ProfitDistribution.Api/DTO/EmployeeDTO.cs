using ProfitDistribution.Api.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProfitDistribution.Api.DTO
{
    public class EmployeeDTO
    {
        [Required(ErrorMessage = "matricula é obrigatória")]
        [JsonPropertyName("matricula")]
        public string RegistrationId { get; set; }
        [Required(ErrorMessage = "nome é obrigatório")]
        [JsonPropertyName("nome")]
        public string Name { get; set; }
        [Required(ErrorMessage = "area é obrigatória")]
        [Area]
        [JsonPropertyName("area")]
        public string OccupationArea { get; set; }
        [Required(ErrorMessage = "cargo é obrigatório")]
        [JsonPropertyName("cargo")]
        public string Office { get; set; }
        [Required(ErrorMessage = "salario_bruto é obrigatório")]
        [Money(ErrorMessage = "salario_bruto deve estar em um formato monetário (R$ XX,XX) e positivo")]
        [JsonPropertyName("salario_bruto")]
        public string GrossSalary { get; set; }
        [Required(ErrorMessage = "data_de_admissao é obrigatória")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        [Admission]
        [JsonPropertyName("data_de_admissao")]
        public DateTime AdmissionDate { get; set; }
    }
}
