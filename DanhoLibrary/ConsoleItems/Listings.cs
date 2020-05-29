using System;
using System.Collections.Generic;

namespace DanhoLibrary
{
    public partial class ConsoleItems
    {
        /// <summary> Lists each element of array with an [x] of + 1 | [1]: Option[0] </summary>
        /// <param name="Options">Options to list</param>
        public static void ListOptions(params object[] Options)
        {
            for (int x = 0; x < Options.Length; x++)
                Console.WriteLine($"[{x + 1}]: {Options[x]}");
            Console.WriteLine();
        }
        /// <summary> Lists each element of array with an [x] of + 1 | [1]: Option[0] | outputs Choice in int </summary>
        /// <param name="Options">Options to list</param>
        /// <param name="Conversion">Choice in int</param>
        public static void ListOptions(out int Conversion, params object[] Options)
        {
            ListOptions(Options);
            try { Conversion = int.Parse(Console.ReadLine()); }
            catch { Conversion = -1; Error("Conversion to int failed!"); }
        }

        /// <summary> Lists each element of list with an [x] of + 1 | [1]: Option[0] </summary>
        /// <param name="Options">Options to list</param>
        public static void ListOptions(List<object> Options) => ListOptions(Options.ToArray());
        /// <summary> Lists each element of list with an [x] of + 1 | [1]: Option[0] | outputs Choice in int </summary>
        /// <param name="Options">Options to list</param>
        /// <param name="Conversion">Choice in int</param>
        public static void ListOptions(List<object> Options, out int Conversion) => ListOptions(out Conversion, Options.ToArray());
    }
}
