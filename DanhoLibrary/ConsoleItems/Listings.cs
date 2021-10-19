using System;
using System.Collections.Generic;

namespace DanhoLibrary
{
    public partial class ConsoleItems
    {
        /// <summary> Lists each element of array with an [x] of + 1 | [1]: Option[0] </summary>
        /// <param name="options">Options to list</param>
        public static Dictionary<int, T> ListOptions<T>(params T[] options)
        {
            Dictionary<int, T> dicc = new Dictionary<int, T>();
            for (int i = 0; i < options.Length; i++)
            {
                dicc.Add(i + 1, options[i]);
                Console.WriteLine($"[{i + 1}]: {options[i]}");
            }
            Console.WriteLine();
            return dicc;
        }
        /// <summary> Lists each element of array with an [x] of + 1 | [1]: Option[0] | outputs Choice in int </summary>
        /// <param name="options">Options to list</param>
        /// <param name="conversion">Choice in int</param>
        public static Dictionary<int, T> ListOptions<T>(out int conversion, params T[] options)
        {
            Dictionary<int, T> result = ListOptions(options);
            if (!int.TryParse(Console.ReadLine(), out conversion)) Error("Conversion to int failed!");
            return result;
        }

        /// <summary> Lists each element of list with an [x] of + 1 | [1]: Option[0] </summary>
        /// <param name="options">Options to list</param>
        public static Dictionary<int, T> ListOptions<T>(List<T> options) => ListOptions(options.ToArray());
        /// <summary> Lists each element of list with an [x] of + 1 | [1]: Option[0] | outputs Choice in int </summary>
        /// <param name="options">Options to list</param>
        /// <param name="conversion">Choice in int</param>
        public static Dictionary<int, T> ListOptions<T>(List<T> options, out int conversion) => ListOptions(out conversion, options.ToArray());
    }
}
