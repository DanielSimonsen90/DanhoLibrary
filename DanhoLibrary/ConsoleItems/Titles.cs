﻿using System;
using System.Text;

namespace DanhoLibrary
{
    /// <summary>
    /// Titles that make Console UIs just a little better
    /// </summary>
    public partial class ConsoleItems
    {
        /// <summary> Centers title according to length (must be in default window size) </summary>
        /// <param name="title"></param>
        public static void Title(string title)
        {
            int space = Console.WindowWidth - title.Length - 1;
            StringBuilder dash = new StringBuilder();
            for (int x = 0; x < space; x++) dash.Append("-");
            Console.WriteLine($"{dash}\n{title.PadLeft(space / 2)}\n{dash}");

            Break(2);
        }
        /// <summary> Centers <paramref name="title"/> according to length (must be default window size) </summary>
        /// <param name="title">Title of UI</param>
        /// <param name="welcomeMessage">Cute welcome message to welcome user</param>
        public static void Title(string title, string welcomeMessage)
        {
            Title(title);
            Console.WriteLine(welcomeMessage);
            Break();
        }
    }
}