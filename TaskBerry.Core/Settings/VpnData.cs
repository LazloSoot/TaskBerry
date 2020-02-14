using System;
using TaskBerry.Core.Helpers;

namespace TaskBerry.Core.Settings
{
    [Serializable]
    public class VpnData
    {
        public override string ToString()
        {
            return this.GetAllPropertiesStringValues();
        }
    }
}
