using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _7.Timer
{
    class Timer
    {
        public delegate void Caller();

        public static void CallbackFunc()
        {
            Console.WriteLine("Tick!");
        }

        public static void ExecAtInterval(Caller caller, int time)
        {
            while (true)
            {
                caller();
                Thread.Sleep(time * 1000);
            }
        }

        static void Main()
        {
            ExecAtInterval(CallbackFunc, 1);
        }
    }
}
