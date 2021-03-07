using ProfitDistribution.Domain.Model;
using System.Collections.Generic;

namespace ProfitDistribution.Api.DTO
{
    public class ProfitDistributionReportDTO
    {
        public IEnumerable<ParticipationDTO> participacoes { get; set; }
        public string total_de_funcionarios { get; set; }
        public string total_distribuido { get; set; }
        public string total_disponibilizado { get; set; }
        public string saldo_total_disponibilizado { get; set; }

    }

    public class ParticipationDTO
    {
        public string matricula { get; set; }
        public string nome { get; set; }
        public string valor_da_participação { get; set; }
    }
}
