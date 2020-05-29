using System;

namespace DanhoLibrary
{
    public partial class ConsoleItems
    {
        /// <summary> Tell people they had an error, via <param name="ErrorMessage"></param> </summary>
        /// <param name="ErrorMessage">Message to tell User</param>
        public static void Error(string ErrorMessage)
        {
            Console.Clear();
            Console.WriteLine(ErrorMessage);
            Break(5);
            Console.WriteLine("Please try again");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary> Clear(), "Your choice failed to be read", 5 cw's, "Please try again", ReadKey(), Clear() </summary>
        public static void Error() => Error("Your choice failed to be read.");

        /// <summary> Tell people they had an error, and what they inserted </summary>
        /// <param name="Choice"></param>
        public static void Error(object Choice) => Error($"Your choice \"{Choice}\", failed to be read.");
    }
}