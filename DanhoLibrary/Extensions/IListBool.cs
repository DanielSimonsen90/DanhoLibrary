using System.Collections.Generic;

namespace DanhoLibrary.Extensions
{
    public static partial class DanhoExtender
    {

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
