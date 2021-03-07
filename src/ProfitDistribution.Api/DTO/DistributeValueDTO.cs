using System.ComponentModel.DataAnnotations;

namespace ProfitDistribution.Api.DTO
{
    public class DistributeValueDTO
    {
        [Required]
        public string DistributeValue { get; set; }
    }
}
