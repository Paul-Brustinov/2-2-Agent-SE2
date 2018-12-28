using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12x2_Agent.Lib.Interval
{
    abstract class Interval : IInterval
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public TimeSpan Time { get; set; }

        public string ClassName => GetType().FullName;

        public string Memo { get; set; }

        // !!!! вот почему я не хотел в этом классе наследовать IInterval
        public int MinToStart() => throw new NotImplementedException();

        // !!!! вот почему я не хотел в этом классе наследовать IInterval
        public int MinFromStart() => throw new NotImplementedException();

        public Interval()
        {
            StartDate = DateTime.Now;
            Time = DateTime.Now.TimeOfDay;
        }
    }
}
