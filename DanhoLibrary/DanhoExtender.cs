using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DanhoLibrary
{
    /// <summary> 
    /// Purely extension methods 
    /// </summary>
    public static class DanhoExtender
    {
        #region bool[]
        /// <summary> 
        /// If array contains a true element, it returns true else false 
        /// </summary>
        public static bool AnyTrue(this bool[] arr)
        {
            foreach (bool item in arr)
                if (item) return true;
            return false;
        }

        /// <summary> If all indexes specified are true, returns true else false </summary>
        /// <param name="Indexes">Indexes expected to be true</param>
        public static bool True(this bool[] arr, params int[] Indexes)
        {
            for (int x = 0; x < Indexes.Length; x++)
                if (!arr[Indexes[x]]) return false;
            return true;
        }
        #endregion

        #region T[]

        #region Returns bool
        /// <summary> Tests if this contains all of collection's values </summary>
        /// <param name="collection">collection of strings to test for</param>
        /// <returns>true if all of <paramref name="collection"/> is in this else false</returns>
        public static bool ContainsAll<T>(this T[] arr, params T[] collection)
        {
            for (int x = 0; x < collection.Length; x++)
                if (!arr.Contains(collection[x]))
                    return false;
            return true;
        }
        public static bool ContainsAll<T>(this List<T> List, params T[] collection) => List.ToArray().ContainsAll(collection);

        /// <summary> Goes through <paramref name="collection"/> and checks if <paramref name="arr"/>.Contains(collectionItem) </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="arr">Original array</param>
        /// <param name="collection">External collection</param>
        /// <returns>True if <paramref name="collection"/> has items in <paramref name="arr"/> else false</returns>
        public static bool ContainsAny<T>(this T[] arr, params T[] collection)
        {
            for (int x = 0; x < collection.Length; x++)
                if (arr.Contains(collection[x]))
                    return true;
            return false;
        }
        public static bool ContainsAny<T>(this List<T> List, params T[] collection) => List.ToArray().ContainsAny(collection);

        /// <summary> 
        /// If all items in array are null, true else false 
        /// </summary>
        public static bool AllNull<T>(this T[] arr)
        {
            foreach (var item in arr)
                if (item != null)
                    return false;
            return true;
        }
        public static bool AllNull<T>(this List<T> List) => List.ToArray().AllNull();
        #endregion

        #region Returns T
        /// <summary>
        /// Returns a random item from <paramref name="arr"/>
        /// </summary>
        public static T GetRandomItem<T>(this T[] arr) => arr[new Random().Next(arr.Length - 1)];
        public static T GetRandomItem<T>(this List<T> List) => List.ToArray().GetRandomItem();

        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified predicate, and returns the first occurence within the entire List<T>.
        /// </summary>
        /// <param name="match">The Predicate<in T> delegate that defines the cinditions of the element to search for.</param>
        /// <returns></returns>
        public static T Find<T>(this T[] arr, Predicate<T> match) => arr.ToList().Find(match);
        #endregion

        #endregion

        public static string Capitalize(this string input) => input.Substring(0, 1).ToUpper() + input.Substring(1, input.Length);
    }
}
