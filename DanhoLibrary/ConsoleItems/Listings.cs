using System;
using System.Collections.Generic;

namespace DanhoLibrary
{
    public partial class ConsoleItems
    {
        /// <summary> Lists each element of array with an [x] of + 1 | [1]: Option[0] </summary>
        /// <param name="Options">Options to list</param>
        public static Dictionary<int, T> ListOptions<T>(params T[] Options)
        {
            Dictionary<int, T> dicc = new Dictionary<int, T>();
            for (int i = 0; i < Options.Length; i++)
            {
                dicc.Add(i + 1, Options[i]);
                Console.WriteLine($"[{i + 1}]: {Options[i]}");
            }
            Console.WriteLine();
            return dicc;
        }
        /// <summary> Lists each element of array with an [x] of + 1 | [1]: Option[0] | outputs Choice in int </summary>
        /// <param name="Options">Options to list</param>
        /// <param name="Conversion">Choice in int</param>
        public static Dictionary<int, T> ListOptions<T>(out int Conversion, params T[] Options)
        {
            Dictionary<int, T> result = ListOptions(Options);
            if (int.TryParse(Console.ReadLine(), out Conversion)) return result;
            Error("Conversion to int failed!");
            return result;
        }

        /// <summary> Lists each element of list with an [x] of + 1 | [1]: Option[0] </summary>
        /// <param name="Options">Options to list</param>
        public static Dictionary<int, T> ListOptions<T>(List<T> Options) => ListOptions(Options.ToArray());
        /// <summary> Lists each element of list with an [x] of + 1 | [1]: Option[0] | outputs Choice in int </summary>
        /// <param name="Options">Options to list</param>
        /// <param name="Conversion">Choice in int</param>
        public static Dictionary<int, T> ListOptions<T>(List<T> Options, out int Conversion) => ListOptions(out Conversion, Options.ToArray());
    }
}
