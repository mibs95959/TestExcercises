using System;

namespace Tools.General_Tools
{

    /// <summary>
    /// This class wil help you add some basic content to the console in a more readable way.
    /// </summary>
    public class ConsoleHelper_Tool
    {
        private static void AddTwoEmptyLinesOnConsole()
        {
            Console.WriteLine();
            Console.WriteLine();
        }

        /// <summary>
        /// Just a really silly and basic way to read in console some custom output.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        public static void EasyToReadContent(string title, string content)
        {
            AddTwoEmptyLinesOnConsole();
            Console.WriteLine(title);
            Console.WriteLine();
            Console.WriteLine(content);
            AddTwoEmptyLinesOnConsole();
        }

        public static void EasyToReadContent(string content)
        {
            AddTwoEmptyLinesOnConsole();
            Console.WriteLine(content);
            AddTwoEmptyLinesOnConsole();
        }

    }
}
