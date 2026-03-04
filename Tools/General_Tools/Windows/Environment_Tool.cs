using System;

namespace Tools.General_Tools.Windows
{
    public class Environment_Tool
    {

        public static string GetCurrentComputerName()
        {
            return Environment.MachineName;
        }

    }
}
