using OpenQA.Selenium;
using WebAutomation.Web.Core.WebElements.WE_Interactions;

namespace WebAutomation.Web.Core.WebElements.WE_Objects
{
    public class WE_Toggle : WE_Base
    {

        public WE_Toggle(By locator)
        {
            SetElement(locator);
        }

        public WE_Toggle(IWebElement givenElement)
        {
            SetElement(givenElement);
        }

        public WE_Toggle(By locator, WE_Iframe homeFrame)
        {
            SetElement(locator, homeFrame);
        }

        public WE_Toggle(IWebElement givenElement, WE_Iframe homeFrame)
        {
            SetElement(givenElement, homeFrame);
        }

        public void Click()
        {
            WE_Interactions.Click.OnElement(element);
        }

        public bool IsEnabled()
        {
            return Bools.IsElementEnabled(element);
        }

        public bool IsSelected()
        {
            return Bools.IsElementSelected(element);
        }
    }
}
