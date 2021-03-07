using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ProfitDistribution.Api.Attributes
{
    public class MoneyAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string money = value as string;
            try
            {
                var currency = Decimal.Parse(money, NumberStyles.Currency, new CultureInfo("pt-BR"));
                return currency > 0;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
