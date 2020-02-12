using System;
using System.Threading.Tasks;

namespace TaskBerry.Infrastructure.Contracts.Command
{
    public interface IAsyncCommand<T>
    {
        T Result { get; }
        event EventHandler CanExecuteChanged;
        bool CanExecute(object parameter);
        Task<T> ExecuteAsync(object parameter);
    }
}
