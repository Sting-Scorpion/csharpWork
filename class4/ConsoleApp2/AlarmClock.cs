using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApp2
{
    class AlarmClock
    {
        public event Action<AlarmClock> Alarm;
        public event Action<AlarmClock> Tick;

        public Clock CurTime { get; set; }
        public Clock TarTime { get; set; }

        public void Run()
        {
            while (true)
            {
                CurTime = new Clock(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                Tick(this);
                if (CurTime.Equals(TarTime))
                {
                    Alarm(this);
                }
                Thread.Sleep(1000);
            }
        }
    }
}
