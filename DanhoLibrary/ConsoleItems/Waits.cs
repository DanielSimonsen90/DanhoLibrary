using System;
using System.Threading;

namespace DanhoLibrary
{
    public partial class ConsoleItems
    {
        /// <summary> Sleep for <paramref name="time"/> in ms </summary>
        /// <param name="time">Time in ms</param>
        public static void Wait(int time) => Thread.Sleep(time); 
        /// <summary> Waiting... animation </summary>
        /// <param name="periods">Amount of periods to spam</param>
        /// <param name="time">Waiting time</param>
        public static void Waiting(int periods, int time)
        {
            for (int x = 1; x <= periods; x++)
            {
                Console.Write(".");
                Wait(time);
            }
        }
    }
}