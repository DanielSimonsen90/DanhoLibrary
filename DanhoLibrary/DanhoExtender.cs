using System;
using System.Collections.Generic;
using System.Linq;

namespace DanhoLibrary
{
    /// <summary> 
    /// Purely extension methods 
    /// </summary>
    public static class DanhoExtender
    {
        #region IList<bool>
        /// <summary> 
        /// If array contains a true element, it returns true else false 
        /// </summary>
        public static bool AnyTrue(this IList<bool> collection)
        {
            foreach (bool item in collection)
                if (item) return true;
            return false;
        }

        /// <summary> If all indexes specified are true, returns true else false </summary>
        /// <param name="indexes">Indexes expected to be true</param>
        public static bool AllTrue(this IList<bool> collection, params int[] indexes)
        {
            for (int x = 0; x < indexes.Length; x++)
                if (!collection[indexes[x]]) 
                    return false;
            return true;
        }
        #endregion

        #region IList<T>

        #region Returns bool
        /// <summary> Tests if this contains all of collection's values </summary>
        /// <param name="collection">collection of strings to test for</param>
        /// <returns>true if all of <paramref name="collection"/> is in this else false</returns>
        public static bool ContainsAll<T>(this IList<T> arr, params T[] collection)
        {
            for (int x = 0; x < collection.Length; x++)
                if (!arr.Contains(collection[x]))
                    return false;
            return true;
        }

        /// <summary> Goes through <paramref name="collection"/> and checks if <paramref name="arr"/>.Contains(collectionItem) </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="arr">Original array</param>
        /// <param name="collection">External collection</param>
        /// <returns>True if <paramref name="collection"/> has items in <paramref name="arr"/> else false</returns>
        public static bool ContainsAny<T>(this IList<T> arr, params T[] collection)
        {
            for (int x = 0; x < collection.Length; x++)
                if (arr.Contains(collection[x]))
                    return true;
            return false;
        }

        /// <summary> 
        /// If all items in array are null, true else false 
        /// </summary>
        public static bool AllNull<T>(this IList<T> arr)
        {
            foreach (var item in arr)
                if (item != null)
                    return false;
            return true;
        }
        #endregion

        #region Returns T
        /// <summary>
        /// Returns a random item from <paramref name="collection"/>
        /// </summary>
        public static T GetRandomItem<T>(this IList<T> collection) => collection[ConsoleItems.RandomNumber(collection.Count)];

        /// <summary>
        /// Returns first element of <paramref name="collection"/> and removes it from the collection
        /// </summary>
        public static T Shift<T>(this IList<T> collection)
        {
            T ReturnElement = collection[0];
            collection.RemoveAt(0);
            return ReturnElement;
        }

        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified predicate, and returns the first occurence within the entire List<T>.
        /// </summary>
        /// <param name="match">The Predicate<in T> delegate that defines the cinditions of the element to search for.</param>
        /// <returns></returns>
        public static T Find<T>(this IList<T> collection, Predicate<T> match) => collection.ToList().Find(match);
        #endregion

        #region Returns string
        /// <summary>
        /// Converets all elements from <paramref name="collection"/> to one long string
        /// </summary>
        public static string Join<T>(this IList<T> collection) => ConsoleItems.ToString(collection.ToArray());
        /// <summary>
        /// Returns each element in <paramref name="collection"/> to a string value
        /// </summary>
        /// <param name="collection">Caller</param>
        /// <param name="seperator">The seperator string between each element in <paramref name="collection"/></param>
        /// <returns></returns>
        public static string Join<T>(this IList<T> collection, string seperator) => ConsoleItems.ToString(seperator, collection);
        #endregion

        #region Returns IList<T>
        /// <summary>
        /// Goes through <paramref name="collection"/> and runs <paramref name="callback"/> for each element and returns the final result as <typeparamref name="EndType"/> array
        /// </summary>
        /// <typeparam name="StartType">Start type</typeparam>
        /// <typeparam name="EndType">End type</typeparam>
        /// <param name="collection">Start array</param>
        /// <param name="callback">Function that should return <typeparamref name="EndType"/> array</param>
        /// <returns><paramref name="collection"/> as <typeparamref name="EndType"/> array</returns>
        public static IList<EndType> Map<StartType, EndType>(this IList<StartType> collection, Func<StartType, EndType> callback)
        {
            EndType[] newArr = new EndType[collection.Count];

            for (int i = 0; i < collection.Count; i++)
                newArr[i] = callback(collection[i]);
            return newArr;
        }

        public delegate bool FilterCallback<T>(T value, int index = 0, IList<T> collection = null);
        public static IList<T> Filter<T>(this IList<T> collection, FilterCallback<T> callback)
        {
            IList<T> result = new List<T>();

            foreach (T item in collection)
                if (callback(item, collection.IndexOf(item), collection))
                    result.Add(item);

            return result;
        }
        #endregion

        public static int IndexOf<T>(this IList<T> collection, T item) => collection.IndexOf(item);
        
        /// <summary>
        /// For each loop as method
        /// </summary>
        /// <param name="collection">Array to loop through</param>
        /// <param name="callback">Method that each element goes through</param>
        public static void ForEach<T>(this IList<T> collection, Action<T> callback)
        {
            foreach (T item in collection)
                callback(item);
        }

        #endregion

        #region Dictionary<TKey, TValue>
        public static List<V> GetValues<K, V>(this Dictionary<K,V> dictionary)
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
        #endregion

        #region KeyValuePair
        public static string Write<K, V>(this KeyValuePair<K,V> kvp) => $"{kvp.Key}: {kvp.Value}";
        public static IList<object> ToCollection<K, V>(this KeyValuePair<K, V> kvp) => new object[] { kvp.Key, kvp.Value };
        #endregion

        #region string
        /// <summary>
        /// Capitalizes the first letter of <paramref name="input"/>
        /// </summary>
        public static string Capitalize(this string input) => input.Substring(0, 1).ToUpper() + input.Substring(1, input.Length);
        /// <summary>
        /// Inserts <paramref name="toInsert"/> every <paramref name="every"/> index of <paramref name="input"/>.Length
        /// </summary>
        /// <param name="input">Input string</param>
        /// <param name="toInsert">string to input</param>
        /// <param name="every">Every 1st/2nd/3rd etc character</param>
        /// <returns></returns>
        public static string InsertEvery(this string input, string toInsert, int every)
        {
            string returnedString = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                if (i % every == 0 && i != 0)
                    returnedString += toInsert;
                returnedString += input[i];
            }
            return returnedString;
        }
        #endregion
    }
}