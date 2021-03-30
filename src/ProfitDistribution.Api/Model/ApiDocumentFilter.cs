using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ProfitDistribution.Api.Model
{
    public class ApiDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Tags = new[]
            {
                new OpenApiTag { Name = "Employee", Description = "Consulta e mantém os Funcionários." },
                new OpenApiTag { Name = "ProfitDistributionReport", Description = "Consulta as relatório de distribuição de lucro com base no valor a ser distribuído e funcionários cadastrados." }
            };

            swaggerDoc.Info.Title = "Distribuição de Lucros Api";
            swaggerDoc.Info.Description = "Api de Distribuição dos lucros responsável recuperar/cadastrar/deletar/atualizar funcionário(Employee), além realizar um relatório de distribuição de lucros(ProfitDistribuitionReport) com base no total o que a empresa pretende disponibilizar para distribuir de lucros";
        }
    }
}
