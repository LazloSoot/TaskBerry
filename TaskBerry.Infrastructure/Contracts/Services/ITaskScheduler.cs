using System;
using System.Collections.Generic;
using TaskBerry.Infrastructure.Contracts.Command;
using TaskBerry.Infrastructure.Models.Scheduler;

namespace TaskBerry.Infrastructure.Contracts.Services
{
    public interface ITaskScheduler
    {
        void Schedule(IEnumerable<ICommand> commands, string taskName, IInterval interval);
        void ScheduleAsync<T>(IEnumerable<IAsyncCommand<T>> commands, string taskName, IInterval interval);
        void RemoveSchedule(string taskName);
        void RemoveSchedule(string[] taskNames);
        void AddToStartup();
        void RemoveFromStartup();

    }
}
