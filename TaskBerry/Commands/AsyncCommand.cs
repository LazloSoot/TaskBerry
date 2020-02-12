using NLog;
using System.Threading.Tasks;
using TaskBerry.Infrastructure.Contracts.Command;

namespace TaskBerry.Commands
{
    public abstract class AsyncCommand<T> : Command, IAsyncCommand<T>
    {
        public T Result { get; private set; }
        public AsyncCommand(Logger logger) 
            :base(logger)
        {

        }

        public abstract Task<T> ExecuteAsync(object parameter);
    }
}
