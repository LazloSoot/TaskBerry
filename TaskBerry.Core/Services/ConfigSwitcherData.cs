using System;
using TaskBerry.Core.Helpers;

namespace TaskBerry.Core.Services
{
    [Serializable]
    public class ConfigSwitcherData
    {
        public string PathToRootDir { get; set; }
        public string PathToSettingsDir { get; set; }
        public bool IsRecursive { get; set; }
        public bool IsDebug { get; set; }
        public string[] ProjectNamesToSwitch { get; set; }
        public EnvironmentType CurrentEnvironmentType { get; set; }

        public override string ToString()
        {
            return this.GetAllPropertiesStringValues();
        }
    }
}
