using System;

namespace DanhoLibrary
{
    public partial class ConsoleItems
    {
        public static int RandomNumber(int Max) => new Random().Next(Max);
        public static int RandomNumber(int Min, int Max) => new Random().Next(Min, Max);
    }
}
