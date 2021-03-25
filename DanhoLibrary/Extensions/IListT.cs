using System;
using System.Collections.Generic;
using System.Linq;

namespace DanhoLibrary.Extensions
{
    public static partial class DanhoExtender
    {
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
        public static IList<T> Filter<T>(this IList<T> collection, FilterCallback<T> callback) =>
        (
            from T item in collection
            where callback(item, collection.IndexOf(item), collection)
            select item
        ).ToList();
        #endregion

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
    }
}
