using OpenQA.Selenium;
using System.Collections.Generic;
using WebAutomation.Web.Core.Others;


namespace WebAutomation.Web.Core.WebElements.WE_Interactions
{
    public class Text
    {

        public static string GetElementText(By _locator)
        {
            return Find.Element(_locator).Text;
        }

        public static string GetElementText(IWebElement element)
        {
            return element.Text;
        }

        public static List<string> GetTextsFromGivenWebElements(By _locator)
        {
            List<string> result = new List<string>();
            IList<IWebElement> webElements = Find.Elements(_locator);
            for (int i = 0; i < webElements.Count; i++)
            {
                result.Add(GetElementText(webElements[i]));
            }
            return result;
        }

        public static List<string> GetTextsFromGivenWebElements(IList<IWebElement> elements)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < elements.Count; i++)
            {
                result.Add(GetElementText(elements[i]));
            }
            return result;
        }

        // Set Element Text

        public static void SetElementText(By _locator, string _input)
        {
            Find.Element(_locator).SendKeys(_input);
        }

        public static void SetElementText(IWebElement element, string _input)
        {
            element.SendKeys(_input);
        }

        public static void ClearAndSetElementText(By _locator, string _input)
        {
            IWebElement current = Find.Element(_locator);
            current.Clear();
            current.SendKeys(_input);
        }

        public static void ClearElementText(IWebElement element)
        {
            element.Clear();
        }

        public static void ClearElementText(By _locator)
        {
            Find.Element(_locator).Clear();
        }

        public static void ClearWithKeyPressingSim(By locator)
        {
            ClearWithKeyPressingSim(Find.Element(locator));
        }

        public static void ClearWithKeyPressingSim(IWebElement element)
        {
            element.Click();
            Robot.PressControlA();
            Robot.PressDelete();
        }

        public static void ClearAndSetElementText(IWebElement element, string _input)
        {
            element.Clear();
            element.SendKeys(_input);
        }

        public static IWebElement GetElementWithGivenText(IList<IWebElement> weList, string text)
        {
            foreach (IWebElement x in weList)
            {
                if (GetElementText(x).Equals(text)) return x;
            }
            return null;
        }

    }
}
