using OpenQA.Selenium;
using System.Threading;
using System.Threading.Tasks;
using WebAutomation.Web.Core.Others;
using WebAutomation.Web.Core.WebElements;
using WebAutomation.Web.Core.WebElements.WE_Interactions;

namespace WebAutomation.Web.Core.WebElements.WE_Objects
{
    /// <summary>
    /// Dont use this type, as its meant to be an Abstract class.
    /// 
    /// This class will contain everything that is common to all the other types of WebElements.
    /// </summary>
    public abstract class WE_Base
    {

        public IWebElement element;
        public By locator;

        protected async Task SetElement(By locator)
        {
            this.locator = locator;
            element = Find.Element(locator);
        }

        protected async Task SetElement(IWebElement givenElement)
        {
            element = givenElement;
        }

        protected async Task SetElement(By locator, WE_Iframe homeFrame)
        {
            if (!JScript.GetCurrentIFrame().Equals(homeFrame.GetIFrameTitle())) homeFrame.SwitchTo();
            element = Find.Element(locator);
        }

        protected async Task SetElement(IWebElement givenElement, WE_Iframe homeFrame)
        {
            if (!JScript.GetCurrentIFrame().Equals(homeFrame.GetIFrameTitle())) homeFrame.SwitchTo();
            element = givenElement;
        }

        public bool IsDisplayed()
        {
            return Bools.IsElementDisplayed(element);
        }

        public bool IsDisplayedWithReFind()
        {
            element = Find.Element(locator);
            return Bools.IsElementDisplayed(element);
        }

        public void HoverOver()
        {
            WE_Actions.HoverGivenElement(element);
        }

        public void HoverOverAndWait(int centiseconds)
        {
            WE_Actions.HoverGivenElement(element);
            Thread.Sleep(centiseconds * 10);
        }

        public void TakeScreenshot(string nameAndPath)
        {
            Other.GetElementScreenShot(element, nameAndPath);
        }

        public string GetAttributeValue(string attribute)
        {
            return element.GetAttribute(attribute);
        }

        public bool WaitXCentiSecondsToBeDisplayed(float seconds)
        {
            for (int i = 0; i < seconds * 10; i++)
            {
                if (element != null)
                {
                    if (IsDisplayed()) return true;
                }
                Thread.Sleep(100);
            }
            return false;
        }

        public bool WaitUntilIsNoLongerDisplayed(float seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                if (!IsDisplayed())
                {
                    break;
                }
                Thread.Sleep(100);
            }
            return Bools.IsElementDisplayed(element);
        }

    }
}
