using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            AlarmClock clock = new AlarmClock();
            clock.TarTime = new Clock(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second + 5);
            clock.Tick += ShowTime;
            clock.Alarm += MakeNoise;
            clock.Alarm += ShowTime;

            clock.Run();
        }
        static void ShowTime(AlarmClock clock)
        {
            Clock time = clock.CurTime;
            Console.WriteLine($"Time Now: " + $"{time.Hour}:{time.Minute}:{time.Second}");
        }
        static void MakeNoise(AlarmClock clock)
        {
            Console.WriteLine("Playing disgusting music to wake up you......");
        }
    }
}
