using System;

namespace TaskBerry.Infrastructure.Models.Scheduler
{
    public interface IInterval
    {
        int Hour { get; set; }
        int Minute { get; set; }
        double SheduleInterval { get; set; }
        TimeSpan GetDuration();
    }
}
