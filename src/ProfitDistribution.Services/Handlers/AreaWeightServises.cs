using ProfitDistribution.Domain.Model;
using System;

namespace ProfitDistribution.Services.Handlers
{
    public class AreaWeightServises : IWeightServices
    {
        public int Categorize(Employee employee,decimal salary = 0)
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
                    throw new Exception("Area não categorizada");
            }
            return weight;
        }
    }
}
