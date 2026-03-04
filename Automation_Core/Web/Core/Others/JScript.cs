using OpenQA.Selenium;
using System;
using WebAutomation.Web.Core;

namespace WebAutomation.Web.Core.Others
{
    public class JScript : SeleniumCore
    {

        public static IJavaScriptExecutor jse = driver;

        public static IJavaScriptExecutor js()
        {
            return jse;
        }

        public static string ExecuteGivenJs(string script)
        {
            return (string)js().ExecuteScript(script);
        }

        public static string ExecuteGivenJs(string script, IWebElement element)
        {
            return (string)js().ExecuteScript(script, element);
        }

        public static void JsClick(IWebElement element)
        {
            js().ExecuteScript("arguments[0].click();", element);
        }


        // https://stackoverflow.com/questions/16149431/make-function-wait-until-element-exists/47776379 - To implement later on...


        public static void StopPageFromLoading()
        {
            js().ExecuteScript("return window.stop");
        }

        public static void ReloadPage()
        {
            js().ExecuteScript("document.location.reload()");
        }



        public static string GetCurrentIFrame()
        {
            return (string)js().ExecuteScript("return self.name");
        }

        public static void Zoom(string zoomLevel)
        {
            js().ExecuteScript("document.body.style.zoom = '" + zoomLevel + "%'");
        }

        public static string GetNetwork()
        {
            return js().ExecuteScript("var performance = window.performance || window.mozPerformance || window.msPerformance || window.webkitPerformance || {}; var network = performance.getEntries() || {}; return network;").ToString();
        }

        public static void SetLocalStorage(IWebDriver driver, string key, string value)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            try
            {
                // Check if the key is already set to the specified value
                var currentValue = (string)js.ExecuteScript($"return window.localStorage.getItem('{key}');");
                if (currentValue != value)
                {
                    // Set the local storage item if the current value is different
                    js.ExecuteScript($"window.localStorage.setItem('{key}', '{value}');");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error setting local storage item: {ex.Message}");
                throw;
            }
        }

    }
}
