using OpenQA.Selenium;
using WebAutomation.Web.Core.Others;
using WebAutomation.Web.Core.WebElements.WE_Interactions;

namespace WebAutomation.Web.Core.WebElements.WE_Objects
{
    public class WE_Searchbox : WE_Base
    {

        public WE_Searchbox(By locator)
        {
            SetElement(locator);
        }

        public WE_Searchbox(IWebElement givenElement)
        {
            SetElement(givenElement);
        }

        public WE_Searchbox(By locator, WE_Iframe homeFrame)
        {
            SetElement(locator, homeFrame);
        }

        public WE_Searchbox(IWebElement givenElement, WE_Iframe homeFrame)
        {
            SetElement(givenElement, homeFrame);
        }

        public string GetText()
        {
            return Text.GetElementText(element);
        }

        public void SetText(string input)
        {
            Text.ClearAndSetElementText(element, input);
        }

        public void SearchFor(string input)
        {
            Text.ClearAndSetElementText(element, input);
            Robot.PressEnter();
        }

        public void ClearText()
        {
            WE_Interactions.Click.OnElement(element);
            Text.ClearElementText(element);
        }

        /// <summary>
        /// With Key Simulation.
        /// </summary>
        public void ClearText_KS()
        {
            WE_Interactions.Click.OnElement(element);
            Robot.PressControlA();
            Robot.PressDelete();
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
