using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace WebAutomation.Web.Core.WebElements.WE_Interactions
{
    public class Wait : SeleniumCore
    {

        public static bool ForElementToExist(By _locator, double seconds = 10)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (timer.Elapsed.TotalSeconds < seconds)
            {
                try
                {
                    if (!driver.FindElement(_locator).Equals(null)) return true;
                }
                catch (NoSuchElementException)
                {
                    Thread.Sleep(100);
                }
            }
            timer.Stop();
            return false;
        }

        public static bool ForElementToBeDisplayed(By _locator, int seconds)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (timer.Elapsed.TotalSeconds < seconds)
            {
                try
                {
                    if (driver.FindElement(_locator).Displayed) return true;
                }
                catch (Exception)
                {
                    Thread.Sleep(300);
                }
            }
            timer.Stop();
            return false;
        }

        public static bool ForElementsToExist(By _locator, int seconds)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (timer.Elapsed.TotalSeconds < seconds)
            {
                try
                {
                    if (driver.FindElements(_locator)[0] != null) return true;
                }
                catch (Exception)
                {
                    Thread.Sleep(100);
                }
            }
            timer.Stop();
            return false;
        }

        public static bool ForElementsToBeDisplayed(By _locator, int seconds)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (timer.Elapsed.TotalSeconds < seconds)
            {
                try
                {
                    if (driver.FindElements(_locator)[0].Displayed) return true;
                }
                catch (Exception)
                {
                    Thread.Sleep(300);
                }
            }
            timer.Stop();
            return false;
        }

        /// <summary>
        /// 'X' Stands for Experimental.
        /// </summary>
        /// <param name="_locator"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static bool ForSecondsForElementToExist(By _locator, int seconds)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (timer.Elapsed.TotalSeconds < seconds)
            {
                try
                {
                    if (!driver.FindElement(_locator).Equals(null)) return true;
                }
                catch (NoSuchElementException)
                {
                    Thread.Sleep(100);
                }
            }
            timer.Stop();
            return false;
        }

        public static bool ForElementTextToBe(By _locator, string text, int seconds)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (timer.Elapsed.TotalSeconds < seconds)
            {
                try
                {
                    if (driver.FindElement(_locator).Text.Equals(text)) return true;
                }
                catch (Exception)
                {
                    Thread.Sleep(100);
                }
            }
            timer.Stop();
            return false;
        }

        public static bool ForElementTextToNotBeEmpty(By _locator, int seconds)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (timer.Elapsed.TotalSeconds < seconds)
            {
                try
                {
                    if (!driver.FindElement(_locator).Text.Equals("")) return true;
                }
                catch (Exception)
                {
                    Thread.Sleep(100);
                }
            }
            timer.Stop();
            return false;
        }

        public static bool ForElementTextToBe(By _locator, List<string> text, int seconds)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (timer.Elapsed.TotalSeconds < seconds)
            {
                try
                {
                    foreach (string s in text) if (driver.FindElement(_locator).Text.Equals(s)) return true;
                }
                catch (Exception)
                {
                    Thread.Sleep(100);
                }
            }
            timer.Stop();
            return false;
        }

        public static bool SeleniumWaitForElementToExist(By _locator, int seconds)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (timer.Elapsed.TotalSeconds < seconds)
            {
                try
                {
                    if (driver.FindElement(_locator) != null) return true;
                }
                catch (Exception)
                {
                    Thread.Sleep(100);
                }
            }
            timer.Stop();
            return false;
        }

        public static bool BoolWaitForElementToExist(By _locator, int seconds)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (timer.Elapsed.TotalSeconds < seconds)
            {
                try
                {
                    if (!driver.FindElement(_locator).Equals(null)) return true;
                }
                catch (NoSuchElementException)
                {
                    Thread.Sleep(100);
                }
            }
            timer.Stop();
            return false;
        }

        public static bool BoolWaitForElementsToExist(By _locator, int seconds)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (timer.Elapsed.TotalSeconds < seconds)
            {
                try
                {
                    if (driver.FindElements(_locator).Count() > 0) return true;
                }
                catch (NoSuchElementException)
                {
                    Thread.Sleep(100);
                }
            }
            timer.Stop();
            return false;
        }


        public static bool BoolWaitForElementToDissapear(By _locator, int seconds)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (timer.Elapsed.TotalSeconds < seconds)
            {
                try
                {
                    Find.Element(_locator).Equals(null);
                    Thread.Sleep(100);
                }
                catch (NullReferenceException)
                {
                    return true;
                }
            }
            timer.Stop();
            return false;
        }

    }
}
