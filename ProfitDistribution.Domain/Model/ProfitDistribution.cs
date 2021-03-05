using System.Collections.Generic;

namespace ProfitDistribution.Domain.Model
{
    public class ProfitDistribution
    {
        public IList<Participation> participacoes { get; set; }
        public readonly int total_de_funcionarios;
        public readonly int total_distribuido;
        public readonly int total_disponibilizado;
        public readonly int saldo_total_disponibilizado;

    }
}
