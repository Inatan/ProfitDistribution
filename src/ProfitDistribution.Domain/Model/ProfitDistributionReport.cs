using System.Collections.Generic;
using System.Linq;

namespace ProfitDistribution.Domain.Model
{
    public class ProfitDistributionReport
    {
        
        public IEnumerable<Participation> Participacoes { get; set; }
        public  int Total_de_funcionarios { get; set; }
        public  decimal Total_distribuido { get; set; }
        public decimal Total_disponibilizado { get; set; }
        public decimal Saldo_total_disponibilizado { get; set; }

        public ProfitDistributionReport(IEnumerable<Participation> participacoes, decimal total_disponibilizado)
        {
            this.Participacoes = participacoes;
            this.Total_disponibilizado = total_disponibilizado;
            this.Total_de_funcionarios = participacoes.Count();
            this.Total_distribuido = participacoes.Sum(p => p.Valor_da_participacao);
            this.Saldo_total_disponibilizado = this.Total_disponibilizado - this.Total_distribuido;
        }
    }
}
