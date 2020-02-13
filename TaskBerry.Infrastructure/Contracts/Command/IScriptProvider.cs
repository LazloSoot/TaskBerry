using System.Collections.Generic;
using TaskBerry.Infrastructure.Models;

namespace TaskBerry.Infrastructure.Contracts.Command
{
    public interface IScriptProvider
    {
        IEnumerable<IScriptCommand> GetScripts(ScriptTypes scriptTypes);
    }
}
