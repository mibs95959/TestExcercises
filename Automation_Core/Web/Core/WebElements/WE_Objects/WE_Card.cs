using OpenQA.Selenium;
using System;
using WebAutomation.Web.Core.Others;

namespace WebAutomation.Web.Core.WebElements.WE_Objects
{

    /// <summary>
    /// @TODO: Later add more methods relevant to this Class IF we see that are any relevant ones.
    /// </summary>
    public class WE_Card : WE_Base
    {

        public WE_Card(By locator)
        {
            SetElement(locator);
        }

        public WE_Card(IWebElement givenElement)
        {
            SetElement(givenElement);
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

        public void JsClick()
        {
            JScript.JsClick(element);
        }

    }
}
