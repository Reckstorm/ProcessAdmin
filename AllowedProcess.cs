using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessAdmin_19._08
{
    internal class AllowedProcess
    {
        public Process proc { get; set; }
        public int AllowedTime { get; set; }
        public List<DateTime> StartTimeValues { get; set; }
        public List<DateTime> CloseTimeValues { get; set; }

        public AllowedProcess()
        {
            StartTimeValues = new List<DateTime>();
            CloseTimeValues = new List<DateTime>();
            AllowedTime = 0;
            proc = null;
        }

        public AllowedProcess(Process proc, int allowedTime)
        {
            this.proc = proc;
            AllowedTime = allowedTime;
            StartTimeValues = new List<DateTime>();
            CloseTimeValues = new List<DateTime>();
        }
    }
}
