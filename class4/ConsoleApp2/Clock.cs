using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Clock
    {
        int hour, minute, second;//当前时间
        //闹钟的设定时间
        public int Hour
        {
            get { return hour; }
            set
            {
                if (value < 0 || value > 24) throw new ArgumentOutOfRangeException("invalid hour!");
                hour = value;
            }
        }
        public int Minute
        {
            get { return minute; }
            set
            {
                if (value < 0 || value > 60) throw new ArgumentOutOfRangeException("invalid minute!");
                minute = value;
            }
        }
        public int Second
        {
            get { return second; }
            set
            {
                if (value < 0 || value > 60) throw new ArgumentOutOfRangeException("invalid second!");
                second = value;
            }
        }

        public Clock(int hour = 0, int minute = 0, int second = 0)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        public override bool Equals(object obj)
        {
            var time = obj as Clock;
            return time != null && Hour == time.Hour && Minute == time.Minute && Second == time.Second;
        }
        public override int GetHashCode()
        {
            return Hour * 3600 + Minute * 60 + Second;
        }
    }
}
