using ProfitDistribution.Domain.Model;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProfitDistribution.Api.DTO
{
    public class ProfitDistributionReportDTO
    {
        [JsonPropertyName("participacoes")]
        public IEnumerable<ParticipationDTO> Participations { get; set; }
        [JsonPropertyName("total_de_funcionarios")]
        public string EmployeeTotal { get; set; }
        [JsonPropertyName("total_distribuido")]
        public string DistributedTotal { get; set; }
        [JsonPropertyName("total_disponibilizado")]
        public string AvailableTotal { get; set; }
        [JsonPropertyName("saldo_total_disponibilizado")]
        public string AvailableTotalBalace { get; set; }

    }

    public class ParticipationDTO
    {
        [JsonPropertyName("matricula")]
        public string RegistrationId { get; set; }
        [JsonPropertyName("nome")]
        public string Name { get; set; }
        [JsonPropertyName("valor_da_participação")]
        public string ParticiapationValue { get; set; }
    }
}
