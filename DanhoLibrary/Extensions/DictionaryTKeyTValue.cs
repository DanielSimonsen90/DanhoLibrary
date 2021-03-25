using System.Collections.Generic;

namespace DanhoLibrary.Extensions
{
    public static partial class DanhoExtender
    {
        public static List<V> GetValues<K, V>(this Dictionary<K, V> dictionary)
        {
            List<V> values = new List<V>();
            foreach (V value in dictionary.Values)
                values.Add(value);
            return values;
        }
        public static List<K> GetKeys<K, V>(this Dictionary<K, V> dictionary)
        {
            List<K> keys = new List<K>();
            foreach (K key in dictionary.Keys)
                keys.Add(key);
            return keys;
        }
    }
}
