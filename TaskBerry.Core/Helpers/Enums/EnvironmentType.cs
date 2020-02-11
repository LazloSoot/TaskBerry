using System;
using System.ComponentModel;

namespace TaskBerry.Core.Helpers
{
    [Serializable]
    public enum EnvironmentType
    {
        [StringValue("Default")]
        [Description("Matches the configuration for default environment")]
        origin = 0,
        [StringValue("Local")]
        [Description("Matches the configuration for local environment")]
        local = 1,
        [StringValue("Test")]
        [Description("Matches the configuration for test environment")]
        test = 2
    }
}
