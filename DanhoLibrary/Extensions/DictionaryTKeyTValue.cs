using System.Collections.Generic;

namespace DanhoLibrary.Extensions
{
    public static partial class DanhoExtender
    {
        public static Dictionary<TKey, TValue> Set<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (dictionary.ContainsKey(key))
                dictionary.Remove(key);
            dictionary.Add(key, value);

            return dictionary;
        }

        public static IList<KeyValuePair<K, V>> ToIList<K, V>(this Dictionary<K, V> dictionary)
        {
            IList<KeyValuePair<K, V>> result = new List<KeyValuePair<K, V>>();
            foreach (var item in dictionary)
                result.Add(item);
            return result;
        }

        public static IList<V> GetValues<K, V>(this Dictionary<K, V> dictionary) => dictionary.ToIList().Map(kvp => kvp.Value);
        public static IList<K> GetKeys<K, V>(this Dictionary<K, V> dictionary) => dictionary.ToIList().Map(kvp => kvp.Key);
    }
}
