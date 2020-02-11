using System;
using System.ComponentModel;

namespace TaskBerry.Core.Helpers
{
    public static class EnumExtentions
    {
        public static string GetStringValue(this Enum target)
        {
            var type = target.GetType();
            var fieldInfo = type.GetField(target.ToString());
            var attrs = fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];

            if (attrs.Length < 1)
            {
                throw new ArgumentException("Input object does not have string value!");
            }

            return attrs[0].StringValue;
        }

        public static string GetDescription(this Enum target)
        {
            var type = target.GetType();
            var fieldInfo = type.GetField(target.ToString());
            var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attrs.Length < 1)
            {
                throw new ArgumentException("Input object does not have description!");
            }

            return attrs[0].Description;
        }

        public static bool IsSingleFlag<T>(this T target) where T : Enum
        {
            var n = Convert.ToInt64(target);
            if ((n & (n - 1)) == 0)
            {
                return true;
            }

            return false;
        }
    }
}
