using System;
using System.Diagnostics;

namespace Tools.General_Tools.Windows
{
    public class ProcessManager_Tool
    {

        /// <summary>
        /// This method will start any given process / application.
        /// 
        /// Note: In order to this method to work properly the Application input MUST contain 
        /// the full path + the Application itself. 
        /// </summary>
        /// <param name="Application"></param>
        public static void StartProcess(string process)
        {
            Process.Start(process);
        }

        public static void StartProcess(string process, string arg)
        {
            ProcessStartInfo newProcess = new ProcessStartInfo(process);
            newProcess.Arguments = arg;
            Process.Start(newProcess);
        }

        /// <param name="process">The .exe application</param>
        /// <param name="arg">Argument/s for it</param>
        /// <param name="workspace">The given folder/path where the ".exe" is</param>
        public static void StartProcess(string process, string arg, string workspace)
        {
            ProcessStartInfo newProcess = new ProcessStartInfo();
            newProcess.FileName = process;
            newProcess.Arguments = arg;
            newProcess.WorkingDirectory = workspace;
            Process.Start(newProcess);
        }

        /// <summary>
        /// Note on this method, you dont need to add the ".exe" at the end
        /// just the name of the process.
        /// </summary>
        /// <param name="process"></param>
        public static void EndProcess(string process)
        {
            try
            {
                Process[] proc = Process.GetProcessesByName(process);
                proc[0].Kill(true);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("No process to end was found open with the name of: " + process);
            }
        }

        public static void EndAllProcessesWithGivenName(string process)
        {
            Process[] proc = Process.GetProcessesByName(process);
            foreach (Process _currentProcess in proc)
            {
                _currentProcess.Kill(true);
            }
        }

        public static bool IsGivenProcessRunning(string process)
        {
            return Process.GetProcessesByName(process).Length != 0;
        }

    }
}
