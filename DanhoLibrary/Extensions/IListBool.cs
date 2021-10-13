using System.Collections.Generic;

namespace DanhoLibrary.Extensions
{
    public static partial class DanhoExtender
    {
        /// <summary> 
        /// If array contains a true element, it returns true else false 
        /// </summary>
        public static bool Some(this IList<bool> collection, IListCallback<bool, bool> callback)
        {
            for (int i = 0; i < collection.Count; i++)
                if (callback(collection[i])) 
                    return true;
            return false;
        }
        public static bool Some(this IList<bool> collection, IListCallback2<bool, bool> callback)
        {
            for (int i = 0; i < collection.Count; i++)
                if (callback(collection[i], i))
                    return true;
            return false;
        }
        public static bool Some(this IList<bool> collection, IListCallback3<bool, bool> callback)
        {
            for (int i = 0; i < collection.Count; i++)
                if (callback(collection[i], i, collection))
                    return true;
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
    }
}
