using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12x2_Agent.Lib.Interval
{
    class IntervalWeekly : Interval
    {
        public IList<DayOfWeek> SchedDays { get; set; } = new List<DayOfWeek>();

        public IntervalWeekly() : base() { }

        public IntervalWeekly(IList<DayOfWeek> _schedDays, TimeSpan _startTime, int _id) : this()
        {
            Id = _id;
            SchedDays = _schedDays;
            Time = _startTime;
        }


        // !!!! new - проблема в том, что интервал наследует АйИтервал - зачем описывать там этот метод?
        public new int MinToStart()
        {
            DateTime now = DateTime.Now;

            int minDays = 7;
            foreach (var schedDay in SchedDays)
            {
                int days = GetDays(now.DayOfWeek, schedDay);
                if (days == 0 && (now.Hour * 60 + now.Minute) - (Time.Hours * 60 + Time.Minutes) > 0) continue;
                if (minDays > days) minDays = days;
            }
            int minutes = minDays * 24 * 60 - (now.Hour * 60 + now.Minute) + (Time.Hours * 60 + Time.Minutes);
            return minutes;
        }

        public new int MinFromStart()
        {
            DateTime now = DateTime.Now;

            int minDays = 0;
            foreach (var schedDay in SchedDays)
            {
                int days = 7 - GetDays(now.DayOfWeek, schedDay);
                if (minDays < days) minDays = days;
            }
            int minutes = minDays * 24 * 60 - (now.Hour * 60 + now.Minute) + (Time.Hours * 60 + Time.Minutes);
            return minutes;
        }

        private int GetDays(DayOfWeek start, DayOfWeek end)
        {
            if (start.CompareTo(end) <= 0)
                return ((int)end - (int)start);

            return 7 - (int)start + (int)end;
        }


    }
}
