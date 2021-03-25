using System.Collections.Generic;

namespace DanhoLibrary.Extensions
{
    public static partial class DanhoExtender
    {
        public static string Write<K, V>(this KeyValuePair<K, V> kvp) => $"{kvp.Key}: {kvp.Value}";
        public static IList<object> ToCollection<K, V>(this KeyValuePair<K, V> kvp) => new object[] { kvp.Key, kvp.Value };
    }
}
