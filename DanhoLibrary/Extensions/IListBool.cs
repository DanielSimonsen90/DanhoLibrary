using System.Collections.Generic;

namespace DanhoLibrary.Extensions
{
    public static partial class DanhoExtender
    {
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
    }
}
