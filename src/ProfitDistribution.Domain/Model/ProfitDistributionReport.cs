using System.Collections.Generic;
using System.Linq;

namespace ProfitDistribution.Domain.Model
{
    public class ProfitDistributionReport
    {
        
        public IEnumerable<Participation> participacoes { get; set; }
        public  int total_de_funcionarios { get; set; }
        public  decimal total_distribuido { get; set; }
        public decimal total_disponibilizado { get; set; }
        public decimal saldo_total_disponibilizado { get; set; }

        public ProfitDistributionReport(IEnumerable<Participation> participacoes, decimal total_disponibilizado)
        {
            this.participacoes = participacoes;
            this.total_disponibilizado = total_disponibilizado;
            this.total_de_funcionarios = participacoes.Count();
            this.total_distribuido = participacoes.Sum(p => p.valor_da_participação);
            this.saldo_total_disponibilizado = this.total_disponibilizado - this.total_distribuido;
        }
    }
}
