using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace TasksInDotnet48
{
    public class CustomStopwatch
    {
        private DateTime StartTime;
        private DateTime EndTime;
        public void Start()
        {            
            StartTime = DateTime.Now;            
        }
        public void Stop()
        {            
            EndTime= DateTime.Now;
        }

        public long TotalElapsedTimeInSeconds()
        {
            TimeSpan timePassed = EndTime - StartTime;

           return (long)timePassed.TotalMilliseconds;
        }

        public long TotalElapsedTimeInMiliSeconds()
        {
            TimeSpan timePassed =  EndTime - StartTime; 
            return (long)timePassed.TotalMilliseconds;           
        }
    }
}
