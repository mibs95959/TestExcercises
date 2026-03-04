using OpenQA.Selenium;

namespace WebAutomation.Web.Core.WebElements.WE_Interactions
{
    public class IFrames : SeleniumCore
    {

        public static void SwitchToGivenIFrame(IWebElement element)
        {
            driver.SwitchTo().Frame(element);
        }

        public static void SwitchToGivenIFrameByIndex(int index)
        {
            driver.SwitchTo().Frame(index);
        }

        public static void SwitchBackToMainIFrame()
        {
            driver.SwitchTo().DefaultContent();
        }

    }
}
