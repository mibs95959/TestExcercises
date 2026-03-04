using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAutomation.Web.Core.Others;
using WebAutomation.Web.Core.WebBrowser;

namespace WebAutomation.SpecFlow.Web.StepDefinitions.Generic
{

    [Binding]
    public class BrowserInteractions_Steps : WB_Interactions
    {
        [StepDefinition("I open a new Chrome browser")]
        public static void OpenNewBrowser()
        {
            StartWebDriver(Core_Hooks.Headless, false);
        }

        [StepDefinition("I open a new Chrome browser in Incognito mode")]
        public static void OpenNewChromeInIncognito()
        {
            StartWebDriver(Core_Hooks.Headless, true);
        }

        [StepDefinition("I open an extra 'Chrome' browser")]
        public static void OpenExtraBrowser(string _browser)
        {
            StartWebDriver(Core_Hooks.Headless, false);
        }

        [StepDefinition("I open a new browser window or tab")]
        public static void OpenNewBrowserTab()
        {
            OpenNewTab();
        }

        [StepDefinition("I navigate to the url '(.*)'")]
        public static void NavigateToGivenUrl(string _url)
        {
            GoToUrl(_url);
        }

        [StepDefinition("I verify that the url contains '(.*)'")]
        public static void VerifyUrlContains(string input)
        {
            Assert.IsTrue(GetCurrentUrl().Contains(input));
        }

        [StepDefinition("I verify that the url does not contain '(.*)'")]
        public static void VerifyUrlDoesNotContains(string input)
        {
            Assert.IsFalse(GetCurrentUrl().Contains(input));
        }

        [StepDefinition("I refresh the page")]
        public static void RefreshPage()
        {
            Refresh();
        }

        [StepDefinition("I Maximize the current Chrome window")]
        public static void MaximizePage()
        {
            Maximize();
        }

        [StepDefinition("I Switch to last open tab")]
        public static void SwitchToLastOpenTab()
        {
            SwitchToLastTabOpen();
        }

        // Logs related steps - Option to move it to another class in the future


        [StepDefinition("I start fetching the Performance Logs from the Browser")]
        public static void StartFetchingPerfLogs()
        {
            WB_Listeners.PerformanceLogsProps();
        }

        [StepDefinition("I start fetching the Browser Logs")]
        public static void StartFetchingBrowserLogs()
        {
            WB_Listeners.BrowserLogsProps();
        }


        [StepDefinition("I verify that there are no Browser Console Error Logs")]
        public static void VerifyBrowserConsoleErrors()
        {
            var consoleLogs = WB_Listeners.GetBrowserLogs();
            if (consoleLogs.Count != 0)
            {
                foreach (LogEntry log in consoleLogs)
                {
                    Console.WriteLine();
                    Console.WriteLine("Severity Level: " + log.Level);
                    Console.WriteLine("Log Message: " + log.Message);
                    Console.WriteLine("TimeStamp: " + log.Timestamp);
                    Console.WriteLine();
                }
                Assert.IsTrue(consoleLogs.Count == 0, "consoleLogs.Count == 0");
            }
        }

        [Given("I print in console all the Browser Logs")]
        public static void PrintInConsoleBrowserLogs()
        {
            Console.WriteLine();
            Console.WriteLine("Browser logs:");
            Console.WriteLine();
            foreach (var entry in WB_Listeners.GetBrowserLogs())
            {
                Console.WriteLine(entry.ToString());
            }
        }


        [Given("I print in console all the Performance Logs")]
        public static void PrintInConsolePerformanceLogs()
        {
            Console.WriteLine();
            Console.WriteLine("Performance logs:");
            Console.WriteLine();
            foreach (var entry in WB_Listeners.GetPerformanceLogs())
            {
                Console.WriteLine(entry.ToString());
            }
        }



        [Given("I print in console all the Network calls")]
        public static void PrintInConsoleNetworkCalls()
        {
            Console.WriteLine();
            Console.WriteLine("JS Network logs:");
            Console.WriteLine();
            var nets = JScript.GetNetwork();
            foreach (var collection in nets.Cast<Dictionary<string, object>>())
            {
                foreach (var entry in collection.Where(e => e.Key != "serverTiming" && e.Key != "toJSON"))
                {
                    Console.WriteLine(entry.Key.ToString() + ": " + entry.Value ?? "(null)");
                }
                Console.WriteLine("---");
            }
        }

        [Given("I get the current session IP")]
        public static string GetCurrentIP()
        {
            try
            {
                IWebDriver tempDriver = StartTempChromeWebDriver(false);

                tempDriver.Navigate().GoToUrl("https://api.ipify.org/?format=json");
                string IP = tempDriver.FindElement(By.CssSelector("pre")).Text;

                tempDriver.Close();
                tempDriver.Quit();

                Console.WriteLine();
                Console.WriteLine("Current IP is: " + IP);
                Console.WriteLine();

                return IP;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("There seems to be a problem with the site where we grab the current local's IP");
                return "error fetching IP";
            }
        }


    }

}
