using System.Collections;
using System.Text;

namespace TaskBerry.Core.Helpers
{
    public static class Extentions
    {
        public static string GetAllPropertiesStringValues(this object target)
        {
            var type = target.GetType();
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("{");
            foreach (var prop in type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
            {
                if (prop.PropertyType != typeof(string) && typeof(IEnumerable).IsAssignableFrom(prop.PropertyType))
                {
                    stringBuilder.Append($" \"{prop.Name}\" : [ ");
                    foreach (var value in prop.GetValue(target) as IEnumerable)
                    {
                        if (value == null)
                            stringBuilder.Append("null");
                        else
                            stringBuilder.Append(value);
                    }
                    stringBuilder.AppendLine(" ]");
                }
                else
                {
                    stringBuilder.AppendLine($" \"{prop.Name}\" : \"{prop.GetValue(target).ToString()}\"");
                }
            }
            stringBuilder.AppendLine("}");
            return stringBuilder.ToString();
        }
    }
}
