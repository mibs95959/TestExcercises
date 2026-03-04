using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using WebAutomation.Web.Core;

namespace WebAutomation.Web.Core.WebElements.WE_Interactions
{
    public class Bools : SeleniumCore
    {

        public static bool DoesElementExist(By _locator)
        {
            return Find.Element(_locator) != null;
        }

        public bool DoesElementExist(IWebElement element)
        {
            return element != null;
        }

        public static bool IsElementDisplayed(By _locator)
        {
            try
            {
                return Find.Element(_locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static bool IsFirstElementDisplayed(By _locator)
        {
            try
            {
                return Find.Elements(_locator)[0].Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsElementDisplayed(IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsElementSelected(By _locator)
        {
            try
            {
                return Find.Element(_locator).Selected;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static bool IsElementSelected(IWebElement element)
        {
            try
            {
                return element.Selected;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static bool IsElementEnabled(By _locator)
        {
            return Find.Element(_locator).Enabled;
        }

        public static bool IsElementEnabled(IWebElement element)
        {
            return element.Enabled;
        }

        public static bool IsElementWithGivenTextDisplayed(By _locator, string textInput)
        {
            foreach (IWebElement x in Find.Elements(_locator))
            {
                if (Text.GetElementText(x).Equals(textInput)) return true;
            }
            return false;
        }

        public static bool IsElementWithGivenTextDisplayed(IList<IWebElement> elements, string textInput)
        {
            foreach (IWebElement x in elements)
            {
                if (Text.GetElementText(x).Equals(textInput)) return true;
            }
            return false;
        }


    }
}
