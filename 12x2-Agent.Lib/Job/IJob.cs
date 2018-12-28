using _12x2_Agent.Lib.Interval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12x2_Agent.Lib.Job
{
    interface IJob
    {
        Object Run();
        IInterval Interval { get; set; }

    }
}
