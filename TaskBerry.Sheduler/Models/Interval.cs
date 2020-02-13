using System;
using TaskBerry.Infrastructure.Models.Scheduler;

namespace TaskBerry.Scheduler.Models
{
    public sealed class Interval : IInterval
    {
        private int _hour;
        private int _minute;

        public int Hour
        {
            get => _hour;
            set
            {
                if (value > 24) _hour = 24;
                else if (value < 0) _hour = 0;
                else _hour = value;
            }
        }

        public int Minute
        {
            get => _minute;
            set
            {
                if (value > 60) _minute = 60;
                else if (value < 0) _minute = 0;
                else _minute = value;
            }
        }

        public double SheduleInterval { get; set; }

        public Periodicity Periodicity { get; set; }

        public Interval(int hour, int minute, double sheduleInterval, Periodicity periodicity)
        {
            Hour = hour;
            Minute = minute;
            SheduleInterval = sheduleInterval;
            Periodicity = periodicity;
        }

        public Interval(DateTime date, int minDelay, double sheduleInterval, Periodicity periodicity)
        {
            Hour = date.Hour;
            Minute = date.Minute + minDelay;
            SheduleInterval = sheduleInterval;
            Periodicity = periodicity;
        }

        public Interval(int hour, int minute, double sheduleInterval)
        {
            Hour = hour;
            Minute = minute;
            SheduleInterval = sheduleInterval;
            Periodicity = Periodicity.Hour;
        }

        public TimeSpan GetDuration()
        {
            switch (Periodicity)
            {
                case Periodicity.Hour:
                    return TimeSpan.FromHours(SheduleInterval);
                case Periodicity.Minute:
                    return TimeSpan.FromMinutes(SheduleInterval);
                case Periodicity.Day:
                case Periodicity.Week:
                    return TimeSpan.FromDays(SheduleInterval);
                default:
                    return TimeSpan.FromHours(SheduleInterval);
            }
        }

        public override string ToString()
        {
            return $"{Hour:#00}:{Minute:#00}";
        }
    }
}
