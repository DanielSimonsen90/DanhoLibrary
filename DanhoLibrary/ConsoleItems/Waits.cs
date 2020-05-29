using System;
using System.Threading;

namespace DanhoLibrary
{
    public partial class ConsoleItems
    {
        /// <summary> Sleep for <paramref name="Time"/> in ms </summary>
        /// <param name="Time">Time in ms</param>
        public static void Wait(int Time) => Thread.Sleep(Time); 
        /// <summary> Waiting... animation </summary>
        /// <param name="Periods">Amount of periods to spam</param>
        /// <param name="Time">Waiting time</param>
        public static void Waiting(int Periods, int Time)
        {
            for (int x = 1; x <= Periods; x++)
            {
                Console.Write(".");
                Wait(Time);
            }
        }
    }
}