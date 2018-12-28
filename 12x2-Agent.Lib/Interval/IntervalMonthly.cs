using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12x2_Agent.Lib.Interval
{
    class IntervalMonthly : Interval
    {
        private int _day = 1;

        public int Day
        {
            get { return _day; }
            set
            {
                if (value < 1 || value > 31) throw new Exception("Day must be between 1 and 31");
                _day = value;
            }
        }

        public new int MinToStart()
        {
            int tmpDay = _day;
            DateTime now = DateTime.Now;

            if (tmpDay > DateTime.DaysInMonth(now.Year, now.Month))
                tmpDay = DateTime.DaysInMonth(now.Year, now.Month);

            DateTime n = new DateTime(now.Year, now.Month, tmpDay, Time.Hours, Time.Minutes, 0);
            if (now.Day > tmpDay) n = n.AddMonths(1);
            return (n - now).Minutes;

        }

        public new int MinFromStart()
        {
            int tmpDay = _day;
            DateTime now = DateTime.Now;

            if (tmpDay > DateTime.DaysInMonth(now.Year, now.Month))
                tmpDay = DateTime.DaysInMonth(now.Year, now.Month);

            DateTime n = new DateTime(now.Year, now.Month, tmpDay, Time.Hours, Time.Minutes, 0);
            if (now.Day < tmpDay) n = n.AddMonths(-1);
            return (now - n).Minutes;
        }

    }
}
