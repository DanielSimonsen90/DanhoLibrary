using System.Collections.Generic;
using System.Linq;

namespace DanhoLibrary.Extensions
{
    public static partial class DanhoExtender
    {

        /// <summary> If all indexes specified are true, returns true else false </summary>
        /// <param name="indexes">Indexes expected to be true</param>
        public static bool AllTrue(this IList<bool> collection, params int[] indexes) => indexes.All(index => collection[index]);
    }
}
