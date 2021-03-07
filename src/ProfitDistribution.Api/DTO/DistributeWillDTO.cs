using System.ComponentModel.DataAnnotations;

namespace ProfitDistribution.Api.DTO
{
    public class DistributeWillDTO
    {
        [Required]
        public decimal DistributeValue { get; set; }
    }
}
