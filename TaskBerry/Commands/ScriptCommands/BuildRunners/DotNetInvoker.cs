using NLog;
using System;
using TaskBerry.Infrastructure.Contracts.Command;
using TaskBerry.Infrastructure.Enums;

namespace TaskBerry.Commands.ScriptCommands.BuildRunners
{
    public class DotNetInvoker : Command, IScriptCommand
    {
        public ScriptTypes Type => ScriptTypes.DBKiller;

        public override event EventHandler CanExecuteChanged;

        public DotNetInvoker(Logger logger)
            : base(logger)
        {

        }

        public override bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
