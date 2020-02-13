using System;
using TaskBerry.Infrastructure.Models.TaskBerry;

namespace TaskBerry.Infrastructure.Contracts.Services
{
    public interface IStateManager
    {
        AppStatus CurrentStatus { get; }
        string Description { get; }
        string SubjectName { get; }
        string ActionName { get; }
        event EventHandler OnStateChanged;
    }
}
