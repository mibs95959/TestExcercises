using OpenQA.Selenium;
using System;
using System.Threading;

namespace WebAutomation.Web.Core.WebElements.WE_Objects
{
    public class WE_Text : WE_Base
    {

        public WE_Text(By locator)
        {
            SetElement(locator);
        }

        public WE_Text(IWebElement givenElement)
        {
            SetElement(givenElement);
        }

        public WE_Text(By locator, WE_Iframe homeFrame)
        {
            SetElement(locator, homeFrame);
        }

        public WE_Text(IWebElement givenElement, WE_Iframe homeFrame)
        {
            SetElement(givenElement, homeFrame);
        }

        public string GetText()
        {
            return WE_Interactions.Text.GetElementText(element);
        }

        public bool WaitUntilTextIsPresent(int seconds)
        {
            for (int i = 0; i < seconds * 60; i++)
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(element.Text)) return true;
                }
                catch (Exception)
                {
                    Thread.Sleep(100);
                }
            }

            throw new TimeoutException("No text appeared in the element within the specified time.");
        }



        public bool WaitUntilTextIs(int seconds, string text)
        {
            for (int i = 0; i < seconds * 60; i++)
            {
                try
                {
                    if (element.Text.Equals(text)) return true;
                }
                catch (Exception)
                {
                    Thread.Sleep(100);
                }
            }
            return false;
        }

    }
}
