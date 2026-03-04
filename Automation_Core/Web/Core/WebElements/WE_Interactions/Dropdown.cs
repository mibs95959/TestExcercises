using OpenQA.Selenium;
using System.Collections.Generic;

namespace WebAutomation.Web.Core.WebElements.WE_Interactions
{
    public class Dropdown : SeleniumCore
    {

        private static IList<IWebElement> GetDropDownOptions(IWebElement dropDown)
        {
            return dropDown.FindElements(By.CssSelector("option"));
        }

        public static void SelectFromDropdownByName(IWebElement dropdown, string name)
        {
            Click.OnElementWithGivenText(GetDropDownOptions(dropdown), name);
        }

        public static void SelectFromDropdownByIndex(IWebElement element, int index)
        {
            Click.OnElement(GetDropDownOptions(element)[index]);
        }

        public static List<string> GetDisplayedOptionsAtDropdown(IWebElement dropDown)
        {
            List<string> result = new List<string>();
            foreach (IWebElement x in GetDropDownOptions(dropDown))
            {
                result.Add(Text.GetElementText(x));
            }
            return result;
        }


    }
}
