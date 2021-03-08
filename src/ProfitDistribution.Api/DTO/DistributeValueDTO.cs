using ProfitDistribution.Api.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ProfitDistribution.Api.DTO
{
    public class DistributeValueDTO
    {
        [Required(ErrorMessage = "Valor a distribuir é obrigatório")]
        [Money(ErrorMessage = "Salário deve estar num formato válido e ser positivo")]
        public string total_disponibilizado { get; set; }
    }
}
