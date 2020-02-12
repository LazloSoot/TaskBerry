using System.Threading.Tasks;
using TaskBerry.Infrastructure.Contracts.Command;
using TaskBerry.Infrastructure.Contracts.Services;

namespace TaskBerry.Commands
{
    public abstract class AsyncCommand<T> : Command, IAsyncCommand<T>
    {
        public T Result { get; private set; }
        public AsyncCommand(ILogger logger) 
            :base(logger)
        {

        }

        public abstract Task<T> ExecuteAsync(object parameter);
    }
}
