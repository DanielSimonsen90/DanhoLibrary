using System;

namespace DanhoLibrary
{
    public partial class ConsoleItems
    {
        public static int RandomNumber(int max) => new Random().Next(max);
        public static int RandomNumber(int min, int max) => new Random().Next(min, max);
    }
}
