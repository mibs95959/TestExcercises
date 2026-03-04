using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using Tools.General_Tools.Windows;

namespace WebAutomation.Web.Core.WebBrowser
{
    public class WB_Interactions : SeleniumCore
    {
        static WB_Interactions()
        {
            //Make sure that the driver is closed gracefully (and chrome windows) when the application is closed.
            AppDomain.CurrentDomain.DomainUnload += (_, _) => End();
        }


        /// <summary>
        /// Dirty C# version of waiting for a HTTP request to finish
        /// </summary>
        /// <param name="partialRequestUrl"></param>
        /// <param name="driver"></param>
        public static void WaitForWebRequest(string partialRequestUrl, int timeoutInSeconds = 10)
        {
            var jsExecutor = (IJavaScriptExecutor)driver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            Debug.WriteLine($"Waiting for {partialRequestUrl} request");
            try
            {
                wait.Until(d =>
                {
                    var requests = (IReadOnlyCollection<object>)jsExecutor.ExecuteScript(
                        $"return performance.getEntries().filter(entry => entry.name.includes('{partialRequestUrl}') && entry.entryType === 'resource');"
                    );
                    return requests.Count > 0;
                });
            }
            catch
            {
                throw new TimeoutException($"Request with URL containing '{partialRequestUrl}' was not found in {timeoutInSeconds} seconds");
            }
            Thread.Sleep(1000); // Ensure post-request rendering
        }

        public static void GoToUrl(string _url)
        {
            driver.Navigate().GoToUrl(_url);
        }

        public static string GetCurrentUrl()
        {
            return driver.Url;
        }

        public static void CloseWindow()
        {
            driver.Close();
        }

        public static void End()
        {
            if (driver != null)
                driver.Quit();
            driver = null;
            Cleanup();
        }

        public static void Refresh()
        {
            driver.Navigate().Refresh();
        }

        public static void Maximize()
        {
            driver.Manage().Window.Maximize();
        }

        public static void GoBack()
        {
            driver.Navigate().Back();
        }

        public static void GoForward()
        {
            driver.Navigate().Forward();
        }

        public static void OpenNewTab()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
        }

        public static void OpenNewTabAndSwitchToIt()
        {
            OpenNewTab();
            SwitchToLastTabOpen();
        }

        public static void SwitchToLastTabOpen()
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }



        // Screenshots:

        public static string Screenshot(string _screenshotName)
        {
            if (driver == null)
            {
                Console.WriteLine("Driver is null, cannot take screenshot.");
                throw new ApplicationException("Could not attach to browser (while taking screenshot)");
            }


            string nameAndPath = FileManager_Tool.GetBasePath() + Path.AltDirectorySeparatorChar + "Reports" + Path.AltDirectorySeparatorChar + _screenshotName.Replace("<", "").Replace(">", "") + ".jpg";
            try
            {
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile(nameAndPath);
                return nameAndPath;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to take screenshot: " + e.Message);
                throw;
            }
        }

        public static SKBitmap GetPageBodyScreenshot(string nameAndPath)
        {
            if (driver == null)
            {
                Console.WriteLine("Driver is null, cannot take screenshot.");
                throw new ApplicationException("Could not attach to browser (while taking body screenshot)");
            }

            Screenshot sc = ((ITakesScreenshot)driver).GetScreenshot();
            var img = SKBitmap.Decode(sc.AsByteArray);

            using var data = img.Encode(SKEncodedImageFormat.Png, 100);

            File.WriteAllBytes(nameAndPath, data.ToArray());
            return img;
        }


        // Logs:

        public static ICollection<LogEntry> GetLogs()
        {
            return driver.Manage().Logs.GetLog(LogType.Browser);
        }


        // Clipboard: 

        /// <summary>
        /// Javascript way of retrieving the clipboard content.
        /// Needed for docker runtime where X doesn't work properly (and therefore not "TextTools").
        /// </summary>
        /// <returns></returns>
        public static string GetClipboardText()
        {
            var js = @"async function getCBContents() {
                  try {
                    window.cb = await navigator.clipboard.readText();
                    console.log(""Pasted content: "", window.cb);
                  } catch (err) {
                    console.error(""Failed to read clipboard contents: "", err);
                    window.cb = ""Error : "" + err;
                  }
                    return window.cb;
                };
                return getCBContents();";

            var cb = ((IJavaScriptExecutor)driver).ExecuteScript(js);
            Console.WriteLine("Clipboard content: " + cb.ToString());
            return cb.ToString();

        }

        public static WebDriverWait WaitForSeconds(int seconds)
        {
            return new(driver, TimeSpan.FromSeconds(seconds));
        }




    }
}
