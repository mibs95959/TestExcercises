using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Tools.General_Tools;

namespace WebAutomation.Web.Core.WebElements.WE_Interactions
{
    public class Find : SeleniumCore
    {
        private static int defaultWaitInSeconds = 3;

        public static IWebElement Element_NoWait(By _locator)
        {
            try
            {
                return driver.FindElement(_locator);
            }
            catch (NoSuchElementException)
            {
            }
            /// TO TEST!!!!
            catch (StaleElementReferenceException)
            {
                return driver.FindElement(_locator);
            }
            return null;
        }

        public static IWebElement Element(By _locator, double timeout = 10)
        {
            try
            {
                Wait.ForElementToExist(_locator, timeout);
                return driver.FindElement(_locator);
            }
            catch (NoSuchElementException)
            {
            }
            return null;
        }

        public static IWebElement ParentElement(By locator)
        {
            try
            {
                IWebElement child = Element(locator);
                return child.FindElement(By.XPath(".."));
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        public static IWebElement ParentElement(IWebElement element)
        {
            try
            {
                return element.FindElement(By.XPath(".."));
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        public static IWebElement Element_NoWait(IWebElement element, By _locator)
        {
            try
            {
                return element.FindElement(_locator);
            }
            catch (NoSuchElementException)
            {
                ConsoleHelper_Tool.EasyToReadContent("Attention!:", "The element that you were trying to find By: '" + _locator + "' does not seem to be present on the page or the locator itself needs to be fixed");
                return null;
            }
        }

        public static IWebElement Element(IWebElement element, By _locator)
        {
            try
            {
                Wait.ForElementToExist(_locator, defaultWaitInSeconds);
                return element.FindElement(_locator);
            }
            catch (NoSuchElementException)
            {
                ConsoleHelper_Tool.EasyToReadContent("Attention!:", "The element that you were trying to find By: '" + _locator + "' does not seem to be present on the page or the locator itself needs to be fixed");
                return null;
            }
        }

        /// <summary>
        /// NEW!
        /// </summary>
        /// <param name="element"></param>
        /// <param name="_locator"></param>
        /// <param name="miliseconds"></param>
        /// <returns></returns>
        public static IWebElement TryToFindElement(IWebElement element, By _locator, int seconds)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (timer.Elapsed.TotalSeconds < seconds)
            {
                try
                {
                    Wait.ForElementToExist(_locator, defaultWaitInSeconds);
                    return element.FindElement(_locator);
                }
                catch (NoSuchElementException)
                {
                }
            }
            return null;
        }

        /// <summary>
        /// NEW!
        /// </summary>
        /// <param name="element"></param>
        /// <param name="_locator"></param>
        /// <param name="miliseconds"></param>
        /// <returns></returns>
        public static IWebElement TryToFindElement(By _locator, int seconds)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (timer.Elapsed.TotalSeconds < seconds)
            {
                try
                {
                    Wait.ForElementToExist(_locator, defaultWaitInSeconds);
                    return Element(_locator);
                }
                catch (NoSuchElementException)
                {
                }
            }
            return null;
        }

        public static bool TryToFindElementBool(By _locator, int miliseconds)
        {
            if (TryToFindElement(_locator, miliseconds) != null) return true;
            return false;
        }

        /// <summary>
        /// NEW!
        /// </summary>
        /// <param name="element"></param>
        /// <param name="_locator"></param>
        /// <param name="miliseconds"></param>
        /// <returns></returns>
        public static IList<IWebElement> TryToFindElements(By _locator, int seconds)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (timer.Elapsed.TotalSeconds < seconds)
            {
                try
                {
                    Wait.ForElementToExist(_locator, defaultWaitInSeconds);
                    return Elements(_locator);
                }
                catch (NoSuchElementException)
                {
                }
            }
            return null;
        }

        public static IList<IWebElement> Elements(By _locator)
        {
            // SONI: Changed away from busy wait
            try
            {
                Wait.ForElementToExist(_locator, defaultWaitInSeconds);
                return driver.FindElements(_locator);
            }
            catch (Exception)
            {
                ConsoleHelper_Tool.EasyToReadContent("Attention!:", "The elements that you were trying to find By: '" + _locator + "' does not seem to be present on the page or the locator itself needs to be fixed");
                return null;
            }
        }

        public static IList<IWebElement> Elements(By _locator, int seconds)
        {
            try
            {
                Wait.ForElementsToExist(_locator, seconds);
                return driver.FindElements(_locator);
            }
            catch (NoSuchElementException)
            {
                ConsoleHelper_Tool.EasyToReadContent("Attention!:", "The elements that you were trying to find By: '" + _locator + "' does not seem to be present on the page or the locator itself needs to be fixed");
                return null;
            }
        }

        public static IList<IWebElement> Elements(IWebElement anchorElement, By _locator)
        {
            try
            {
                Wait.ForElementToExist(_locator, 10);
                return anchorElement.FindElements(_locator);
            }
            catch (NoSuchElementException)
            {
                ConsoleHelper_Tool.EasyToReadContent("Attention!:", "The elements that you were trying to find By: '" + _locator + "' does not seem to be present on the page or the locator itself needs to be fixed");
                return null;
            }
        }


        public static IWebElement GetLastWebElement(By _locator)
        {
            IList<IWebElement> webElements = Elements(_locator);
            return webElements[webElements.Count - 1];
        }

        public static int GetQtyOfWebElementsFoundByLocator(By _locator)
        {
            return Elements(_locator).Count;
        }

    }
}
