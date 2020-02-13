using System;
using System.ComponentModel;

namespace TaskBerry.Infrastructure.Models
{
    [Flags]
    public enum ScriptTypes
    {
        [Description("No action")]
        None = 0,

        [Description("Switches configs for .Net Core projects")]
        NetCoreConfigsSwitcher = 1,
        [Description("Switches configs for .Net Framework projects")]
        NetFrameworkConfigsSwitcher = 2,
        [Description("Replaces configs for .Net Core projects")]
        NetCoreConfigsReplacer = 4,
        [Description("Replaces configs for .Net Framework projects")]
        NetFrameworkConfigsReplacer = 8,

        [Description("Invokes MsBuild to clean, build or run c# projects")]
        MsBuildInvoker = 16,
        [Description("Invokes Dotnet to clean, build or run c# projects")]
        DotnetInvoker = 32,
        [Description("Deletes databases")]
        DBKiller = 64,

        [Description("Switches configs for all types of projects")]
        AllConfigsSwitcher = NetCoreConfigsSwitcher | NetFrameworkConfigsSwitcher,
        [Description("Replaces configs for all types of projects")]
        AllConfigsReplacer = NetCoreConfigsReplacer | NetFrameworkConfigsReplacer,
        //[Description("Builds and runs projects")]
        //BuildRunner = ProjectBuilder | ProjectRunner,
        //[Description("Cleans, builds and runs projects")]
        //CleanBuildRunner = ProjectCleaner | ProjectBuilder | ProjectRunner,
        [Description("Builds, switches configs and runs all types of C# projects")]
        AllInclusive = AllConfigsSwitcher | DBKiller
    }
}
