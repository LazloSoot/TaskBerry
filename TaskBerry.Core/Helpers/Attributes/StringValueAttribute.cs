using System;

namespace TaskBerry.Core.Helpers
{
    public class StringValueAttribute : Attribute
    {
        public string StringValue { get; private set; }
        public StringValueAttribute(string value)
        {
            StringValue = value;
        }
    }
}
