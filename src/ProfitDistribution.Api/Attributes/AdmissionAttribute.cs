using System;
using System.ComponentModel.DataAnnotations;


namespace ProfitDistribution.Api.Attributes
{
    public class AdmissionAttribute : ValidationAttribute
    {
        public AdmissionAttribute()
        {
            ErrorMessage = "data_de_admissao não pode ser maior que a data atual";
        }

        public override bool IsValid(object value)
        {
            return DateTime.Now > (DateTime)value;
        }
    }
}
