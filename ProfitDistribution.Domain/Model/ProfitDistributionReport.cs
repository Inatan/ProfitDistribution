using System.Collections.Generic;
using System.Linq;

namespace ProfitDistribution.Domain.Model
{
    public class ProfitDistributionReport
    {
        
        public IList<Participation> participacoes { get; set; }
        public  int total_de_funcionarios;
        public  decimal total_distribuido;
        public decimal total_disponibilizado;
        public decimal saldo_total_disponibilizado;

        public ProfitDistributionReport(IList<Participation> participacoes, decimal total_disponibilizado)
        {
            this.participacoes = participacoes;
            this.total_disponibilizado = total_disponibilizado;
            this.total_de_funcionarios = participacoes.Count;
            this.total_distribuido = participacoes.Sum(p => p.valor_da_participação);
            this.saldo_total_disponibilizado = this.total_disponibilizado - this.total_distribuido;
        }
    }
}
