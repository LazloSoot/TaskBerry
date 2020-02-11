using NLog;
using System;
using TaskBerry.Infrastructure.Contracts.Command;
using TaskBerry.Infrastructure.Enums;

namespace TaskBerry.Commands
{
    public abstract class ScriptCommand : IScriptCommand
    {
        public abstract ScriptTypes Type { get; }

        protected Logger Logger { get; private set; }

        public ScriptCommand(Logger logger)
        {
            Logger = logger;
        }

        public abstract event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
    }
}
