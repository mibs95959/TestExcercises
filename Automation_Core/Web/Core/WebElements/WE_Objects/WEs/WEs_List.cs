using OpenQA.Selenium;
using System.Collections.Generic;

namespace WebAutomation.Web.Core.WebElements.WE_Objects.WEs
{

    public class WEs_List
    {

        private IList<IWebElement> wesList;

        public WEs_List(By locator)
        {
            wesList = WE_Interactions.Find.Elements(locator);
        }

        public WEs_List(By locator, int seconds)
        {
            wesList = WE_Interactions.Find.Elements(locator, seconds);
        }

        public int GetQtyOfWEs()
        {
            return wesList.Count;
        }


        // Gets:

        public string GetTextFromElementByIndex(int index)
        {
            return wesList[index].Text;
        }


        // Clicks:

        public void ClickOnWeWithGivenText(string text)
        {
            WE_Interactions.Click.OnElementWithGivenText(wesList, text);
        }

        public void ClickOnWeWithGivenIndex(int index)
        {
            wesList[index].Click();
        }

        // Booleans:

        public bool IsWeWithGivenTextDisplayed(string text)
        {
            return WE_Interactions.Bools.IsElementWithGivenTextDisplayed(wesList, text);
        }

        public bool IsWeWithGivenTextEnabled(string text)
        {
            return WE_Interactions.Text.GetElementWithGivenText(wesList, text).Enabled;
        }

        public bool DoesAnyElementContains(string text)
        {
            foreach (IWebElement x in wesList)
            {
                if (x.Text.Contains(text)) return true;
            }
            return false;
        }

    }
}
