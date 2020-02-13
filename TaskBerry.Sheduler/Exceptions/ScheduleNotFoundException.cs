using System;

namespace TaskBerry.Scheduler.Exceptions
{
    public class ScheduleNotFoundException : Exception
    {
        public ScheduleNotFoundException()
        {
        }

        public ScheduleNotFoundException(string scheduleName) : base($"Schedule with name: {scheduleName} not found")
        {
        }

        public ScheduleNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
