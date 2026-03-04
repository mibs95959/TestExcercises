using System;
using System.Threading;

namespace Tools.General_Tools
{

    public class Time_Tool
    {

        public static string GetDateAndTime()
        {
            // Make sure it lex sortable
            return DateTime.Now.ToString("yyyy-MM-ddTHH.mm.ss");
        }

        public static string GetDate()
        {
            return DateTime.Now.Date.ToString("dd/MM/yyyy");
        }

        public static string GetTime()
        {
            return DateTime.Now.ToString("hh:mm:ss");
        }

        public static DateTime TransformStringToDateTime(string time)
        {
            return DateTime.Parse(time);
        }

        public static bool IsCountdownHappening(DateTime first, DateTime second)
        {
            return first > second;
        }

        public static void WaitForGivenAmountOfSeconds(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

        public static bool IsPerformanceMeet(DateTime? start, DateTime ending, int seconds)
        {

            TimeSpan sp = TimeSpan.FromSeconds(seconds);

            TimeSpan timeDiff = (TimeSpan)(ending - start);

            Console.WriteLine("TimeDiff: " + timeDiff.TotalSeconds);
            Console.WriteLine("Accepted Timespan: " + sp);

            return timeDiff <= sp;
        }

        public static void ConvertToDateTime(string value)
        {
            DateTime convertedDate;
            try
            {
                convertedDate = Convert.ToDateTime(value);
                Console.WriteLine("'{0}' converts to {1} {2} time.",
                                  value, convertedDate,
                                  convertedDate.Kind.ToString());
            }
            catch (FormatException)
            {
                Console.WriteLine("'{0}' is not in the proper format.", value);
            }
        }

    }
}
