using System.Collections.Generic;

namespace DanhoLibrary.Extensions
{
    public static partial class DanhoExtender
    {
        public static IList<KeyValuePair<K, V>> ToArray<K, V>(this Dictionary<K, V> dictionary)
        {
            IList<KeyValuePair<K, V>> result = new List<KeyValuePair<K, V>>();
            foreach (var item in dictionary)
                result.Add(item);
            return result;
        }

        public static IList<V> GetValues<K, V>(this Dictionary<K, V> dictionary) => dictionary.ToArray().Map(kvp => kvp.Value);
        public static IList<K> GetKeys<K, V>(this Dictionary<K, V> dictionary) => dictionary.ToArray().Map(kvp => kvp.Key);
    }
}
