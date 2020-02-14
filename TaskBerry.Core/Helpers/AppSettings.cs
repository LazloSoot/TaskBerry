using System;
using System.Configuration;

namespace TaskBerry.Core.Helpers
{
    public static class AppSettings
    {
        public static T GetSettingsValue<T>(string key)
        {
            var value = ConfigurationManager.AppSettings.Get(key);

            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ConfigurationErrorsException($"{key} must be configured");
            }

            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch(InvalidCastException ex)
            {
                throw new ConfigurationErrorsException($"{key} has incorrect value", ex);
            }
        }
    }
}
