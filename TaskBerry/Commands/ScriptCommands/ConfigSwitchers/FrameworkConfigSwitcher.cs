using System;
using TaskBerry.Infrastructure.Contracts.Command;
using TaskBerry.Infrastructure.Contracts.Services;
using TaskBerry.Infrastructure.Models;

namespace TaskBerry.Commands.ScriptCommands.ConfigSwitchers
{
    public class FrameworkConfigSwitcher : Command, IScriptCommand
    {
        public ScriptTypes Type => ScriptTypes.DBKiller;

        public override event EventHandler CanExecuteChanged;

        public FrameworkConfigSwitcher(ILogger logger)
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
