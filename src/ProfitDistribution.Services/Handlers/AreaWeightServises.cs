using ProfitDistribution.Domain.Model;

namespace ProfitDistribution.Services.Handlers
{
    public class AreaWeightServises : IWeightServices
    {
        public int Categorize(Employee employee)
        {
            int weight = 0;
            switch (employee.Area)
            {
                case "Diretoria":
                    weight = 1;
                    break;
                case "Contabilidade":
                case "Financeiro":
                case "Tecnologia":
                    weight = 2;
                    break;
                case "Serviços Gerais":
                    weight = 3;
                    break;
                case "Relacionamento com o Cliente":
                    weight = 5;
                    break;

                default:
                    weight = 0;
                    break;
            }
            return weight;
        }
    }
}
