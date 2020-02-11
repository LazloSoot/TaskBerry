using System;
using System.ComponentModel;

namespace TaskBerry.Infrastructure.Enums
{
    [Flags]
    public enum ScriptTypes
    {
        [Description("No action")]
        None = 0,
        [Description("Switches configs for .Net Core projects")]
        NetCoreConfigsSwitcher = 1,
        [Description("Switches configs for .Net Framework projects")]
        NetFrameworkConfigSwitcher = 2,
        [Description("Builds C# projects")]
        ProjectBuilder = 4,
        [Description("Runs C# projects")]
        ProjectRunner = 8,
        [Description("Cleans C# projects")]
        ProjectCleaner = 16,
        [Description("Deletes databases")]
        DBKiller = 32,

        [Description("Switches configs for all types of projects")]
        AllConfigsSwitcher = NetCoreConfigsSwitcher | NetFrameworkConfigSwitcher,
        [Description("Builds and runs projects")]
        BuildRunner = ProjectBuilder | ProjectRunner,
        [Description("Cleans, builds and runs projects")]
        CleanBuildRunner = ProjectCleaner | ProjectBuilder | ProjectRunner,
        [Description("Builds, switches configs and runs all types of C# projects")]
        AllInclusive = AllConfigsSwitcher | BuildRunner | DBKiller
    }
}
