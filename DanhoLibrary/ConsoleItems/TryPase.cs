using System;

namespace DanhoLibrary
{
    public static class TryParsing
    {
        /// <summary> Convert item to another type </summary>
        /// <typeparam name="T">Final conversion</typeparam>
        /// <param name="item">Item to convert</param>
        /// <returns>Conversion, else throws invalid operation(?)</returns>
        public static object TryParse<T>(this object item)
        {
            try { return Conversion<T>(item); }
            catch { throw new Exception("Parsing failed"); }
        }
        private static object Conversion<T>(this object item)
        {
            string ItemStr = item.ToString();

            if (typeof(T) == typeof(string)) return ItemStr;
            else if (typeof(T) == typeof(char)) return char.Parse(ItemStr);
            else if (typeof(T) == typeof(int)) return int.Parse(ItemStr);
            else if (typeof(T) == typeof(double)) return double.Parse(ItemStr);
            else if (typeof(T) == typeof(float)) return float.Parse(ItemStr);
            else try { return (T)item; } catch { return item; }
        }

        /// <summary> Convert item to another type </summary>
        /// <typeparam name="T">Final conversion</typeparam>
        /// <param name="item">Item to convert</param>
        /// <returns>Conversion, else throws invalid operation(?)</returns>
        public static T[] TryParse<T>(this T[] item)
        {
            try { return Conversion(item); }
            catch { throw new Exception("Parsing failed"); }
        }
        private static T[] Conversion<T>(this T[] array)
        {
            T[] Conversion = new T[array.Length];

            for (int x = 0; x < array.Length; x++)
                Conversion[x] = array[x];
            return Conversion;
        }
    }
}