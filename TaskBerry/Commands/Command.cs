using System;
using TaskBerry.Infrastructure.Contracts.Command;
using TaskBerry.Infrastructure.Contracts.Services;

namespace TaskBerry.Commands
{
    public abstract class Command : ICommand
    {
        protected ILogger Logger { get; private set; }

        public Command(ILogger logger)
        {
            Logger = logger;
        }

        public abstract event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
    }
}
