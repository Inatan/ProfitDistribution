using ProfitDistribution.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProfitDistribution.Api.Attributes
{
    public class AreaAttribute : ValidationAttribute
    {
        public AreaAttribute()
        {
            ErrorMessage = "area só pode ser(Diretoria, Contabilidade, Financeiro, Tecnologia, Serviços Gerais e Relacionamento com o Cliente)";
        }
        public override bool IsValid(object value)
        {
            var validAreas = EnumExtensions.GetEnumDescriptions<Area>().ToArray();
            return Array.IndexOf(validAreas, value.ToString()) >= 0;
        }
    }
}
