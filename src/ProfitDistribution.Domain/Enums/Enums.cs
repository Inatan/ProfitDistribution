using System;
using System.ComponentModel;

namespace ProfitDistribution.Domain.Enums
{
    public enum Area
    {
        [Description("Diretoria")]
        Diretoria,
        [Description("Contabilidade")]
        Contabilidade,
        [Description("Financeiro")]
        Financeiro,
        [Description("Tecnologia")]
        Tecnologia,
        [Description("Serviços Gerais")]
        ServicosGerais,
        [Description("Relacionamento com o Cliente")]
        RelacionamentoCliente
    }

}
