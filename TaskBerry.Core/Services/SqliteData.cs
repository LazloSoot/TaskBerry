using System;
using TaskBerry.Core.Helpers;

namespace TaskBerry.Core.Services
{
    [Serializable]
    public class SqliteData
    {
        public string ConnectionString { get; set; }
        public override string ToString()
        {
            return this.GetAllPropertiesStringValues();
        }
    }
}
