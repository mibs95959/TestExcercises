using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;
using WebAutomation.Web.Core;

namespace WebAutomation.Web.Core.WebElements.WE_Interactions
{
    public class Click : SeleniumCore
    {
        public static void OnElement(By _locator)
        {
            Find.Element(_locator).Click();
        }

        public static void OnElement(IWebElement element)
        {
            element.Click();
        }

        public static void AndWait(By _locator, int seconds)
        {
            Find.Element(_locator).Click();
            Thread.Sleep(seconds);
        }

        public static void AndWait(IWebElement element, int seconds)
        {
            element.Click();
            Thread.Sleep(seconds);
        }

        public static void AndWaitForPageToLoad(By locator)
        {
            OnElement(locator);
        }

        public static void AndWaitForPageToLoad(IWebElement element)
        {
            OnElement(element);
        }

        public static void AndWaitForPageToLoad(By locator, float centisecond)
        {
            OnElement(locator);
        }

        public static void AndWaitForPageToLoad(IWebElement element, float centisecond)
        {
            OnElement(element);
        }

        /// <summary>
        /// Warning: Whenever you are using this method please bear in mind that will 
        /// click only the first one with the given 'Text'.
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="text"></param>
        public static void AndWaitGivenTimeOnElementWithGivenText(By locator, string textInput)
        {
            IList<IWebElement> webElements = Find.Elements(locator);
            foreach (IWebElement x in webElements)
            {
                if (Text.GetElementText(x).Contains(textInput))
                {
                    OnElement(x);
                    break;
                }
            }
        }

        public static void AndWaitGivenTimeOnElementWithGivenText(By locator, string textInput, float centisecond)
        {
            IList<IWebElement> webElements = Find.Elements(locator);
            foreach (IWebElement x in webElements)
            {
                if (Text.GetElementText(x).Equals(textInput))
                {
                    AndWaitForPageToLoad(x, centisecond);
                    break;
                }
            }
        }

        public static void AndWaitOnElementWithGivenText(By locator, string text)
        {
            AndWaitGivenTimeOnElementWithGivenText(locator, text);
        }

        public static void ClickAndWaitOnElementWithGivenText(By locator, string text, float centiseconds)
        {
            AndWaitGivenTimeOnElementWithGivenText(locator, text, centiseconds);
        }

        public static void AndWaitGivenTimeOnElementWithGivenText(IList<IWebElement> elements, string textInput, float centisecond)
        {
            foreach (IWebElement x in elements)
            {
                if (Text.GetElementText(x).Equals(textInput))
                {
                    AndWaitForPageToLoad(x, centisecond);
                    break;
                }
            }
        }

        public static void AndWaitOnElementWithGivenText(IList<IWebElement> elements, string text)
        {
            AndWaitGivenTimeOnElementWithGivenText(elements, text, 5);
        }

        public static void OnElementWithGivenText(By locator, string textInput)
        {
            IList<IWebElement> webElements = Find.Elements(locator);
            foreach (IWebElement x in webElements)
            {
                if (Text.GetElementText(x).Equals(textInput))
                {
                    OnElement(x);
                    break;
                }
            }
        }

        public static void OnElementWithGivenText(IList<IWebElement> elements, string textInput)
        {
            foreach (IWebElement x in elements)
            {
                if (Text.GetElementText(x).Equals(textInput))
                {
                    OnElement(x);
                    break;
                }
            }
        }

        public static void DoubleClickOnElementWithGivenText(IList<IWebElement> elements, string textInput)
        {
            foreach (IWebElement x in elements)
            {
                if (Text.GetElementText(x).Equals(textInput))
                {
                    OnElement(x);
                    OnElement(x);
                    break;
                }
            }
        }

    }
}
