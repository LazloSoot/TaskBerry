using System;

namespace TaskBerry.Scheduler.Exceptions
{
    public class ScheduleAlreadyExistsException : Exception
    {
        public ScheduleAlreadyExistsException()
        {
        }

        public ScheduleAlreadyExistsException(string scheduleName) : base($"Task with name: {scheduleName} already exists.")
        {
        }

        public ScheduleAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
