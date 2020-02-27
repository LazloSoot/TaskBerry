using System;
using System.ComponentModel;

namespace TaskBerry.Infrastructure.ViewModels
{
    public interface IViewModel : INotifyPropertyChanged, IDisposable
    {
        string DisplayName { get; }
    }
}
