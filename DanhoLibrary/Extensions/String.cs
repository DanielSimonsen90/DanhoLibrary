namespace DanhoLibrary.Extensions
{
    public static partial class DanhoExtender
    {
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
        public static string InsertEvery(this string input, string toInsert, int every) => input.ToCharArray().Reduce((result, c, i) =>
        {
            string add = i % every == 0 && i != 0 ? toInsert : input[i].ToString();
            return result += add;
        }, string.Empty);
    }
}
