using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBerry.Infrastructure.Contracts.Services;
using TaskBerry.Infrastructure.Models.TaskBerry;

namespace TaskBerry.Core.Services
{
    public sealed class StateService : IStateManager
    {
        public AppStatus CurrentStatus { get; private set; }

        public string Description { get; private set; }

        public string SubjectName { get; private set; }

        public string ActionName { get; private set; }

        public event EventHandler OnStateChanged;

        public StateService()
        {
            CurrentStatus = AppStatus.Initialised;
            Description = "Application initialized and ready";
            SubjectName = "TaskBerry";
            ActionName = "Ready";
        }
    }
}
