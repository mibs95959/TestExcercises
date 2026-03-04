using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Tools.General_Tools.Windows;
using WebAutomation.Web.Core.WebBrowser;
using WebAutomation.Web.Core.WebElements.WE_Interactions;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace WebAutomation.Web.Core
{
    public class SeleniumCore
    {
        /// <summary>
        /// This is the Selenium WebDriver.
        /// </summary>
        //protected static IWebDriver driver;

        public static ChromeDriver driver;

        protected static ChromeOptions options = new ChromeOptions();
        private static string ProjectPath = FileManager_Tool.GetCurrentPath();
        private static string profilePath;


        public static IWebDriver InitializeChrome(bool headless, bool incognito)
        {
            try
            {
                driver = new ChromeDriver(ProjectPath, optionsForChrome(headless, incognito));
                return driver;
            }
            catch (Win32Exception)
            {
                // look in the path instead
                driver = new ChromeDriver(optionsForChrome(headless, incognito));
                return driver;
            }
        }

        public static void EndChrome()
        {
            ProcessManager_Tool.EndProcess("chrome");
        }
        public static void EndChromedriver()
        {
            ProcessManager_Tool.EndProcess("chromedriver");
        }

        // Screen management

        private static void ScreenAndResProps()
        {
            // Note: Cannot have computer name differences(!)
            Console.WriteLine("Resizing Window to 1920x1080");
            options.AddArgument("--window-size=1920,1080");
        }

        /// <summary>
        /// Allows JS to read clipboard
        /// </summary>
        private static void ChromeClipboardProps()
        {
            // Note: Setting only works properly in non-private mode.
            var clipboardException = new Dictionary<string, object> {
              {"[*.]*,*",
                new Dictionary<string, object> {
                    {"last_modified", DateTimeOffset.Now.ToUnixTimeMilliseconds()},
                    {"setting", 1}
                }
              }
            };
            options.AddUserProfilePreference("profile.content_settings.exceptions.clipboard", clipboardException);
        }

        private static void ChromeDownloadProps()
        {
            options.AddUserProfilePreference("download.default_directory", FileManager_Tool.GetDownloadsFolderPath());
            options.AddUserProfilePreference("download.directory_upgrade", true);
            options.AddUserProfilePreference("browser.set_download_behavior", "allow");
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads", 1);
        }

        private static void ChromeHeadlessProps()
        {
            options.AddArgument("--window-size=1920,1080");
            options.AddArguments("--start-maximized");
            options.AddArguments("--headless");
            options.AddArguments("--disable-gpu");
            options.AddArguments("--no-sandbox");

            options.AddArguments("--disable-dev-shm-usage");
            options.AddArguments("--verbose");

            // Do not pollute the AI tracking with browser tracking (for headless at least)
            options.AddUserProfilePreference("enable_do_not_track", true);
        }

        private static void NoProxy()
        {
            Proxy proxy = new Proxy();
            proxy.Kind = ProxyKind.Manual;
            proxy.IsAutoDetect = false;
            proxy.HttpProxy =
            proxy.SslProxy = "";
            options.Proxy = proxy;
        }


        private static ChromeOptions optionsForChrome(bool headless, bool incognito)
        {
            ScreenAndResProps();
            options.AddArguments("--no-default-browser-check"); // Disable the default browser check prompt
            options.AddArguments("--disable-default-apps"); // Disable default apps on the first run
            options.AddArguments("--ignore-certificate-errors");
            options.AddArguments("--disable-search-engine-choice-screen"); // Chromedriver v127 requires default search engine to be chosen in incognito, this disables that prompt

            // To overcome limited resource problems 
            // Source: https://stackoverflow.com/questions/50642308/webdriverexception-unknown-error-devtoolsactiveport-file-doesnt-exist-while-t
            // Note: I know some of these arguments are above, but i want to be 100% sure we hit them.
            // Note 2: We NEED to have this line (or the arguments be there no matter what) while running it from the Pipelines
            //options.AddArguments("--disable-dev-shm-usage", "--no-sandbox");

            profilePath = Path.GetTempPath() + Path.DirectorySeparatorChar + "Chrome" + DateTime.Now.ToString("_yyyy-MM-dd\\tHH-mm-ss");
            Directory.CreateDirectory(profilePath);



            options.AddArgument("--user-data-dir=" + profilePath);
            if (incognito) options.AddArgument("--incognito"); //will break clipboard permissions
            //options.AddArgument("--disable-notifications"); //easier to do debug, if enabled
            NoProxy();
            ChromeDownloadProps();
            if (headless) ChromeHeadlessProps();

            ChromeClipboardProps();
            return options;
        }


        /// <summary>
        /// Unfortunately this is the only way to actually clear Chrome cache.
        /// 
        /// As soon as we find a better way this will get obsolete and replaced.
        /// 
        /// This path was taken due to while using the Incognito mode was bringing in some scenarios issues that I was not able to resolve.
        /// Such as having to deal with the Save As window which in the normal mode never happens. 
        /// Another case was accessing to the clipboard data was also triggering a Chrome native alert that we had to deal with that we couldnt interact with it no matter how much we tried.
        /// </summary>
        private static void ClearChromeCache()
        {
            WB_Interactions.GoToUrl("chrome://settings/clearBrowserData");
            Find.Element(By.XPath("//settings-ui")).GetShadowRoot()
                .FindElement(By.CssSelector("#main")).GetShadowRoot()
                .FindElement(By.CssSelector(".cr-centered-card-container")).GetShadowRoot()
                .FindElement(By.CssSelector("settings-section[page-title='Privacy and security']"))
                .FindElement(By.CssSelector("settings-privacy-page")).GetShadowRoot()
                .FindElement(By.CssSelector("settings-clear-browsing-data-dialog")).GetShadowRoot()
                .FindElement(By.CssSelector("#clearBrowsingDataDialog"))
                .FindElement(By.CssSelector("#clearBrowsingDataConfirm")).Click();
        }

        public static IWebDriver StartWebDriver(bool headless, bool incognito, int timeoutSeconds = 5)
        {
            return InitializeChrome(headless, incognito);
        }


        public static IWebDriver StartTempChromeWebDriver(bool headless, bool incognito = false)
        {
            try
            {
                return new ChromeDriver(ProjectPath, optionsForChrome(headless, incognito));
            }
            catch (Win32Exception)
            {
                // look in the path instead                
                return new ChromeDriver(optionsForChrome(headless, incognito));
            }
        }

        public static void Cleanup()
        {
            if (profilePath != null && Directory.Exists(profilePath))
            {
                try
                {
                    Directory.Delete(profilePath, true);
                    profilePath = null;
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

    }
}
