namespace DanhoLibrary
{
    public partial class ConsoleItems
    {
        /// <summary> 
        /// Converts all string elements to one long string 
        /// </summary>
        public static string ToString<T>(params T[] arr) => ToString("list", arr);
        /// <summary>
        /// Converts all string elements to one long string 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="IncludeComma">If true, returns: $"{arr[0]}, {arr[1]}, {arr[2]}"...</param>
        public static string ToString<T>(string seperator, params T[] arr)
        {
            string result = string.Empty;

            foreach (object item in arr)
                result += item.ToString() + (seperator != "list" ? seperator : ", ");

            if (seperator != "list") return result;

            result = result[0..^2]; //removes last comma from string 

            for (int x = result.Length - 1; x >= 0; x--)
                if (result[x] == ',')
                    return result.Substring(0, x) + " &" + result.Substring(x + 1, result.Length - x - 1);
            return result;
        }
    }
}
