using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ProfitDistribution.Domain.Enums
{
    public static class EnumExtensions
    {
        public static string GetDescription<T>(this T enumValue)
            where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("Type isn't enum");

            var description = enumValue.ToString();
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            if (fieldInfo != null)
            {
                var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    description = ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return description;
        }

        public static List<string> GetEnumDescriptions<T>()
        {
            Type enumType = typeof(T);

            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("Type isn't enum");

            List<string> enumDescritpionList = new List<string>();

            foreach (var tEnum in Enum.GetValues(typeof(T)))
            {
                var field = tEnum.GetType().GetField(tEnum.ToString());
                var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);

                enumDescritpionList.Add(attributes[0].Description);
            }

            return enumDescritpionList;
        }

    }
}
