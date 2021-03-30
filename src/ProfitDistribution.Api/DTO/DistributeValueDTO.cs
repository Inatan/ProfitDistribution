using Newtonsoft.Json;
using ProfitDistribution.Api.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProfitDistribution.Api.DTO
{
    public class DistributeValueDTO
    {
        [Required(ErrorMessage = "total_disponibilizado é obrigatório")]
        [Money(ErrorMessage = "total_disponibilizado deve formato monetário (R$ XX,XX) e positivo")]
        [JsonPropertyName("total_disponibilizado")]
        public string AvailableTotal { get; set; }
    }
}
