using System;
using System.Threading.Tasks;

namespace TaskBerry.Infrastructure.Contracts.Command
{
    public interface IAsyncCommand<T> : ICommand
    {
        T Result { get; }
        Task<T> ExecuteAsync(object parameter);
    }
}
