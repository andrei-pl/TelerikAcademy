using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _07.Timer
{
    class Program
    {
        //07. Using delegates write a class Timer that has can execute certain method at each t seconds.

        static void Main(string[] args)
        {
            Timer.SetInterval(new Action(() => Console.WriteLine(DateTime.Now)), 1);
        }
    }

    public class Timer
    {
        public static void SetInterval(Action f, int t)
        {
            while (true)
            {
                Thread.Sleep(t * 1000);

                f();
            }
        }
    }
}
