using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebAutomation.Web.Core.WebBrowser
{
    public class WB_Listeners : SeleniumCore
    {

        public static void PerformanceLogsProps()
        {
            options.SetLoggingPreference(LogType.Performance, LogLevel.Warning);
        }

        public static void BrowserLogsProps()
        {
            options.SetLoggingPreference(LogType.Browser, LogLevel.Warning);
        }


        // Get Logs

        public static ReadOnlyCollection<LogEntry> GetPerformanceLogs()
        {
            return driver.Manage().Logs.GetLog(LogType.Performance);
        }

        public static ReadOnlyCollection<LogEntry> GetBrowserLogs()
        {
            return driver.Manage().Logs.GetLog(LogType.Browser);
        }

    }
}
