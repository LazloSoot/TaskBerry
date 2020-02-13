using TaskBerry.Infrastructure.Models;

namespace TaskBerry.Infrastructure.Contracts.Command
{
    public interface IScriptCommand : ICommand
    {
        ScriptTypes Type { get; }
    }
}
