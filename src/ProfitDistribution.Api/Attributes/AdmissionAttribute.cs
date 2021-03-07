using System;
using System.ComponentModel.DataAnnotations;


namespace ProfitDistribution.Api.Attributes
{
    public class AdmissionAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return DateTime.Now > (DateTime)value;
        }
    }
}
