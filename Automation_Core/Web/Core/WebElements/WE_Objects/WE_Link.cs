using OpenQA.Selenium;
using WebAutomation.Web.Core.Others;
using WebAutomation.Web.Core.WebElements.WE_Interactions;

namespace WebAutomation.Web.Core.WebElements.WE_Objects
{
    public class WE_Link : WE_Base
    {

        public WE_Link(By locator)
        {
            SetElement(locator);
        }

        public WE_Link(IWebElement givenElement)
        {
            SetElement(givenElement);
        }

        public WE_Link(By locator, WE_Iframe homeFrame)
        {
            SetElement(locator, homeFrame);
        }

        public WE_Link(IWebElement givenElement, WE_Iframe homeFrame)
        {
            SetElement(givenElement, homeFrame);
        }

        public string GetText()
        {
            return Text.GetElementText(element);
        }

        public void JsClick()
        {
            JScript.JsClick(element);
        }

        public void Click()
        {
            try
            {
                WE_Interactions.Click.OnElement(element);
            }
            catch (ElementClickInterceptedException)
            {
                JsClick();
            }
        }

        public bool WaitAndClick(int seconds)
        {
            try
            {
                Wait.ForElementToExist(locator, 10);
                element.Click();
            }
            catch (NoSuchElementException e)
            {
                return false;
            }
            return true;
        }

        public void ClickAndWaitForPageToLoad(int miliseconds)
        {
            WE_Interactions.Click.AndWaitForPageToLoad(element, miliseconds);
        }

        public void ClickAndWaitForPageToLoad()
        {
            WE_Interactions.Click.AndWaitForPageToLoad(element);
        }

        public string GetHyperlink()
        {
            return Other.GetElementHyperlink(element);
        }

    }
}
