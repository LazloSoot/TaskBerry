using System;
using TaskBerry.Core.Helpers;

namespace TaskBerry.Core.Settings
{
    [Serializable]
    public class MsBuildData
    {
        public override string ToString()
        {
            return this.GetAllPropertiesStringValues();
        }
    }
}
