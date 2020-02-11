using System.Collections.Generic;
using TaskBerry.Infrastructure.Enums;

namespace TaskBerry.Infrastructure.Contracts.Command
{
    public interface IScriptProvider
    {
        IEnumerable<IScriptCommand> GetScripts(ScriptTypes scriptTypes);
    }
}
