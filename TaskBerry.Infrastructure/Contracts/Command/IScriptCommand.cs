using TaskBerry.Infrastructure.Enums;

namespace TaskBerry.Infrastructure.Contracts.Command
{
    public interface IScriptCommand : ICommand
    {
        ScriptTypes Type { get; }
    }
}
