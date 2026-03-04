using OpenQA.Selenium;
using System;
using System.Threading;
using WebAutomation.Web.Core.Others;

namespace WebAutomation.Web.Core.WebElements.WE_Objects
{
    public class WE_Checkbox : WE_Base
    {

        public WE_Checkbox(By locator)
        {
            SetElement(locator);
        }

        public WE_Checkbox(IWebElement givenElement)
        {
            SetElement(givenElement);
        }

        public WE_Checkbox(By locator, WE_Iframe homeFrame)
        {
            SetElement(locator, homeFrame);
        }

        public WE_Checkbox(IWebElement givenElement, WE_Iframe homeFrame)
        {
            SetElement(givenElement, homeFrame);
        }

        public void Click()
        {
            WE_Interactions.Click.OnElement(element);
        }

        public void JsClick()
        {
            JScript.JsClick(element);
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

        public bool IsEnabled()
        {
            return WE_Interactions.Bools.IsElementEnabled(element);
        }

        public bool IsChecked()
        {
            try
            {
                return element.GetAttribute("checked").Equals("true");
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        public bool WaitUntilIsEnabled(int centisecondsTimeout)
        {
            for (int i = 0; i < centisecondsTimeout; i++)
            {
                if (IsEnabled())
                {
                    break;
                }
                Thread.Sleep(100);
            }
            return WE_Interactions.Bools.IsElementEnabled(element);
        }

    }
}
