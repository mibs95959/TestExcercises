using OpenQA.Selenium;
using System;
using System.Threading;
using WebAutomation.Web.Core.Others;
using WebAutomation.Web.Core.WebElements.WE_Interactions;

namespace WebAutomation.Web.Core.WebElements.WE_Objects
{
    public class WE_Button : WE_Base
    {
        public WE_Button(By locator)
        {
            SetElement(locator);
        }

        public WE_Button(IWebElement givenElement)
        {
            SetElement(givenElement);
        }

        public WE_Button(By locator, WE_Iframe homeFrame)
        {
            SetElement(locator, homeFrame);
        }

        public WE_Button(IWebElement givenElement, WE_Iframe homeFrame)
        {
            SetElement(givenElement, homeFrame);
        }

        public string GetText()
        {
            return Text.GetElementText(element);
        }

        public void Click()
        {
            try
            {
                WE_Interactions.Click.OnElement(element);
            }
            catch (Exception ex)
            {
                if (ex is ElementClickInterceptedException || ex is ElementNotInteractableException)
                {
                    JsClick();
                }
            }
        }

        public void DoubleClick()
        {
            Click();
            Click();
        }

        /// <summary>
        /// TODO: Review this method before merge.
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="times"></param>
        public void TryToClick(By locator, int times)
        {
            int attempts = 0;
            while (attempts < times)
            {
                try
                {
                    SetElement(locator);
                    Click();
                    break;
                }
                catch (StaleElementReferenceException)
                {
                }
                attempts++;
            }
        }

        public void ClickUntilGivenCondition(bool condition, int maxTimes)
        {
            for (int i = 0; i < maxTimes; i++)
            {
                Click();
                if (condition) break;
            }
        }

        public void ClickUntilGivenCondition(bool condition, int maxTimes, int intervalWaitInCentiseconds)
        {
            for (int i = 0; i < maxTimes; i++)
            {
                Click();
                Thread.Sleep(intervalWaitInCentiseconds);
                if (condition) break;
            }
        }

        public void JsClick()
        {
            JScript.JsClick(element);
        }

        public void HoverAndClick()
        {
            HoverOver();
            WE_Interactions.Click.OnElement(element);
        }

        public void ClickAndWaitForPageToLoad(int miliseconds)
        {
            WE_Interactions.Click.AndWaitForPageToLoad(element, miliseconds);
        }

        public void ClickAndWaitForPageToLoad()
        {
            WE_Interactions.Click.AndWaitForPageToLoad(element);
        }

        public void ClickAndWait(int centiseconds)
        {
            WE_Interactions.Click.AndWait(element, centiseconds);
        }

        public void ClickAsSoonIsEnabled(int centisecondsTimeout)
        {
            for (int i = 0; i < centisecondsTimeout; i++)
            {
                if (IsEnabled())
                {
                    Click();
                    break;
                }
                Thread.Sleep(100);
            }
        }

        public string GetHyperlink()
        {
            return Other.GetElementHyperlink(element);
        }

        public bool IsEnabled()
        {
            return Bools.IsElementEnabled(element);
        }

        public bool IsSelected()
        {
            return Bools.IsElementSelected(element);
        }

        public bool WaitUntilIsEnabled(int seconds)
        {
            for (int i = 0; i < seconds * 60; i++)
            {
                if (IsEnabled())
                {
                    break;
                }
                Thread.Sleep(100);
            }
            return Bools.IsElementEnabled(element);
        }

    }
}
