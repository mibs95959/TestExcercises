using OpenQA.Selenium;

namespace WebAutomation.Web.Core.WebElements.WE_Objects
{
    public class WE_Iframe : WE_Base
    {

        public WE_Iframe(By locator)
        {
            SetElement(locator);
        }

        public WE_Iframe(IWebElement givenElement)
        {
            SetElement(givenElement);
        }


        public void SwitchTo()
        {
            WE_Interactions.IFrames.SwitchToGivenIFrame(element);
        }

        public void SwitchBack()
        {
            WE_Interactions.IFrames.SwitchBackToMainIFrame();
        }

        public string GetIFrameTitle()
        {
            return GetAttributeValue("title");
        }

    }
}
