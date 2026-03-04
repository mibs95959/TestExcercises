using OpenQA.Selenium;
using WebAutomation.Web.Core.WebElements.WE_Interactions;

namespace WebAutomation.Web.Core.WebElements.WE_Objects
{
    public class WE_Textfield : WE_Base
    {

        public WE_Textfield(By locator)
        {
            SetElement(locator);
        }

        public WE_Textfield(IWebElement givenElement)
        {
            SetElement(givenElement);
        }

        public WE_Textfield(By locator, WE_Iframe homeFrame)
        {
            SetElement(locator, homeFrame);
        }

        public WE_Textfield(IWebElement givenElement, WE_Iframe homeFrame)
        {
            SetElement(givenElement, homeFrame);
        }

        public string GetText()
        {
            return Text.GetElementText(element);
        }

        public void SetText(string input)
        {
            Text.SetElementText(element, input);
        }

        public void ClearText()
        {
            Text.ClearElementText(element);
        }

        public void ClearAndSetText(string input)
        {
            Text.ClearAndSetElementText(element, input);
        }

        /// <summary>
        /// With Key Simulation.
        /// </summary>
        public void ClearText_KS()
        {
            WE_Interactions.Click.OnElement(element);
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(Keys.Delete);
        }

        public bool IsEnabled()
        {
            return Bools.IsElementEnabled(element);
        }

        public void Click()
        {
            WE_Interactions.Click.OnElement(element);
        }

    }
}
