using System;
using System.Diagnostics;

namespace Tools.General_Tools
{
    /// <summary>
    /// Got the base from: https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch.start?view=net-5.0
    /// 
    /// Todo's here:
    /// - Have bool's methods that return whether or not if the timelapse meet the expectations.
    /// 
    /// </summary>
    public class Chronometer_Tool
    {

        private static Stopwatch stopWatch = new Stopwatch();
        private static TimeSpan timeSpan;

        public static void ClearTime()
        {
            timeSpan = TimeSpan.Zero;
        }

        public static void StartChronometer()
        {
            stopWatch.Start();
        }

        public static void StopChronometer()
        {
            stopWatch.Stop();
            timeSpan = stopWatch.Elapsed;
        }

        public static string GetElapsedTime()
        {
            return string.Format("{0:00}:{1:00}:{2:00}.{3:00}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);
        }


    }
}
