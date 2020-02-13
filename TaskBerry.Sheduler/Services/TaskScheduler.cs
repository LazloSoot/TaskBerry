using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBerry.Infrastructure.Contracts.Command;
using TaskBerry.Infrastructure.Contracts.Services;
using TaskBerry.Infrastructure.Models.Scheduler;

namespace TaskBerry.Scheduler.Services
{
    public sealed class TaskScheduler : ITaskScheduler
    {
        public void AddToStartup()
        {
            throw new NotImplementedException();
        }

        public void RemoveFromStartup()
        {
            throw new NotImplementedException();
        }

        public void RemoveSchedule(string taskName)
        {
            throw new NotImplementedException();
        }

        public void RemoveSchedule(string[] taskNames)
        {
            throw new NotImplementedException();
        }

        public void Schedule(IEnumerable<ICommand> commands, string taskName, IInterval interval)
        {
            throw new NotImplementedException();
        }

        public void ScheduleAsync<T>(IEnumerable<IAsyncCommand<T>> commands, string taskName, IInterval interval)
        {
            throw new NotImplementedException();
        }
    }
}
