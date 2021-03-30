using ProfitDistribution.Domain.Enums;
using ProfitDistribution.Domain.Model;
using System;

namespace ProfitDistribution.Services.Handlers
{
    public class AreaWeightServises : IWeightServices
    {
        public int Categorize(Employee employee)
        {
            int weight = 0;
            if (employee.Area == Area.Diretoria.GetDescription<Area>())
                weight = 1;
            else if (employee.Area == Area.Contabilidade.GetDescription<Area>()
                || employee.Area == Area.Financeiro.GetDescription<Area>()
                || employee.Area == Area.Tecnologia.GetDescription<Area>())
                weight = 2;
            else if (employee.Area == Area.ServicosGerais.GetDescription<Area>())
                weight = 3;
            else if (employee.Area == Area.RelacionamentoCliente.GetDescription<Area>())
                weight = 5;
            else
                throw new ArgumentException("Area não categorizada");
            return weight;
        }
    }
}
