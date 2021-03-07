using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ProfitDistribution.Api.Model
{
    public class TagDescriptionsDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Tags = new[]
            {
                new OpenApiTag { Name = "Employee", Description = "Consulta e mantém os Funcionários." },
                new OpenApiTag { Name = "ProfitDistributionReport", Description = "Consulta as relatório de distribuição de lucro com base no valor a ser distribuído e funcionários cadastrados." }
            };
        }
    }
}
