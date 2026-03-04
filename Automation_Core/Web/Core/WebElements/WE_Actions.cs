using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using WebAutomation.Web.Core.WebElements.WE_Interactions;

namespace WebAutomation.Web.Core.WebElements
{
    class WE_Actions : SeleniumCore
    {

        private static Actions actions = new Actions(driver);

        public static void HoverGivenElement(By locator)
        {
            actions.MoveToElement(Find.Element(locator)).Perform();
        }

        public static void HoverGivenElement(IWebElement element)
        {
            actions.MoveToElement(element).Perform();
        }

        public static void DragAndDrop(By elementToDrag, By dropPoint)
        {
            actions.DragAndDrop(Find.Element(elementToDrag), Find.Element(dropPoint));
        }

        public static void DragAndDrop(IWebElement elementToDrag, IWebElement dropPoint)
        {
            actions.DragAndDrop(elementToDrag, dropPoint);
        }

    }
}
