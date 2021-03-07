using System;
using System.ComponentModel.DataAnnotations;

namespace ProfitDistribution.Api.Attributes
{
    public class AreaAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var validAreas = new string[]{ "Diretoria", "Contabilidade", "Financeiro", "Tecnologia", "Serviços Gerais", "Relacionamento com o Cliente" };
            return Array.IndexOf(validAreas, value.ToString()) >= 0;
        }
    }
}
