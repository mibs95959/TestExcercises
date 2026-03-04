using OpenQA.Selenium;
using System;
using WebAutomation.Web.Core.Others;
using WebAutomation.Web.Core.WebElements.WE_Interactions;

namespace WebAutomation.Web.Core.WebElements.WE_Objects
{
    public class WE_Tab : WE_Base
    {

        public WE_Tab(By locator)
        {
            SetElement(locator);
        }

        public WE_Tab(IWebElement givenElement)
        {
            SetElement(givenElement);
        }


        public bool IsSelected()
        {
            return Bools.IsElementSelected(element);
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

        public void JsClick()
        {
            JScript.JsClick(element);
        }

    }
}
