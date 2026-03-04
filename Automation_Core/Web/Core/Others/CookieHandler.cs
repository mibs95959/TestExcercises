using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace WebAutomation.Web.Core.Others
{
    public class CookieHandler : SeleniumCore
    {

        public static Cookie GetCookieByName(string name)
        {
            return driver.Manage().Cookies.GetCookieNamed(name);
        }

        public static void InsertCookie(Cookie input)
        {
            driver.Manage().Cookies.AddCookie(input);
        }

        public static List<Cookie> GetCookies()
        {
            return driver.Manage().Cookies.AllCookies.ToList();
        }

        public static void PrintInConsoleAllCookies()
        {
            foreach (var cookie in GetCookies())
            {
                Console.WriteLine();
                Console.WriteLine(cookie.Name);
                Console.WriteLine(cookie.Value);
                Console.WriteLine();
            }
        }

        public static bool WaitForCookie(string name, int seconds)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (timer.Elapsed.TotalSeconds < seconds)
            {
                try
                {
                    foreach (var cookie in GetCookies())
                    {
                        if (cookie.Name.Equals(name)) return true;
                    }

                }
                catch (Exception)
                {
                    Thread.Sleep(100);
                }
            }
            timer.Stop();
            return false;
        }

        /// <summary>
        /// Note: Havent tried the method yet, but there might be a chance 
        /// that it takes certain time to clear all the cookies.
        /// 
        ///             .---. .---. 
        ///            :     : o   :    me want cookie!
        ///        _..-:   o :     :-.._    /
        ///     .-''  '  `---' `---' "   ``-.    
        ///   .'   "   '  "  .    "  . '  "  `.  
        ///  :   '.---.,,.,...,.,.,.,..---.  ' ;
        ///  `. " `.                     .' " .'
        ///   `.  '`.                   .' ' .'
        ///    `.    `-._ _.-' "  .'  .----.
        ///      `. "    '"--...--"'  . ' .'  .'  o   `.
        ///      .'`-._'    " .     " _.-'`. :       o  :
        ///      '      ```--.....--'''    ' `:_ o       :
        ///  .'    "     '         "     "   ; `.;";";";'
        /// ;         '       "       '     . ; .' ; ; ;
        ///;     '         '       '   "    .'      .-'
        ///'  "     "   '      "           "    _.-
        /// 
        /// </summary>
        public static void EatCookies()
        {
            try
            {
                driver.Manage().Cookies.DeleteAllCookies();
                Console.WriteLine("Cookies successfully deleted");
            }
            catch (ObjectDisposedException) { }
        }

        /// <summary>
        /// Took from:
        /// https://stackoverflow.com/questions/13956572/specific-cookie-is-present-or-not-using-selenium-webdriver-c-sharp
        /// </summary>
        /// <param name="cookieName"></param>
        /// <returns></returns>
        public static bool IsGivenCookiePresent(string cookieName)
        {
            return driver.Manage().Cookies.AllCookies.Any(c => c.Name.Equals(cookieName, StringComparison.OrdinalIgnoreCase));
        }

        public static Cookie GetGivenCookieValue(string cookieName)
        {
            return driver.Manage().Cookies.GetCookieNamed(cookieName);
        }

    }
}
