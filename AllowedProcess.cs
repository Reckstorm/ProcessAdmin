﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessAdmin_19._08
{
    internal class AllowedProcess
    {
        public string ProcessName { get; set; }
        public int AllowedTime { get; set; }
        public object locker { get; set; } = new object();

        private int workTime;

        public int WorkTime
        {
            get 
            {
                lock(locker)
                {
                    return workTime;
                }
            }
            set 
            { 
                lock(locker)
                {
                    workTime = value;
                }
            }
        }

        public AllowedProcess()
        {
            AllowedTime = 0;
            WorkTime = 0;
            ProcessName = string.Empty;
        }

        public AllowedProcess(string proc, int allowedTime)
        {
            ProcessName = proc;
            AllowedTime = allowedTime;
        }
    }
}
