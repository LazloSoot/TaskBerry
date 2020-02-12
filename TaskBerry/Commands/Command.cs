using NLog;
using System;
using TaskBerry.Infrastructure.Contracts.Command;

namespace TaskBerry.Commands
{
    public abstract class Command : ICommand
    {
        protected Logger Logger { get; private set; }

        public Command(Logger logger)
        {
            Logger = logger;
        }

        public abstract event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
    }
}
