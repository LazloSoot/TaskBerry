using System;
using TaskBerry.Core.Helpers;

namespace TaskBerry.Core.Services
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
