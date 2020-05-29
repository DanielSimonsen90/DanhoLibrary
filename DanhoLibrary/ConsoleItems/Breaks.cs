using System;

namespace DanhoLibrary
{
    public partial class ConsoleItems
    {
        /// <summary> 
        /// Gives a space of 2 lines 
        /// </summary>
        public static void Break() => Break(2);
        /// <summary> Gives specified amount of space </summary>
        /// <param name="amount">cw's of space</param>
        public static void Break(int amount)
        {
            for (int x = 0; x < amount; x++)
                Console.WriteLine();
        }
    }
}
