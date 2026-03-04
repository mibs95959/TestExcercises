using OpenQA.Selenium;

namespace WebAutomation.Web.Core.Others
{
    /// <summary>
    /// Extends the 'By' class with a function for locating elements by their innerText.
    /// Usage: IWebElement myElement = FindElement(new ContainsText("I'm looking for this text"));
    /// </summary>
    /// <param name="text">The text to search for in the entire DOM</param>
    public class ContainsText : By
    {
        public ContainsText(string text)
        {
            FindElementMethod = (context) =>
            {
                return context.FindElement(XPath($"//*[contains(text(), '{text}')]"));
            };
        }
    }

    /// <summary>
    /// Extends the 'By' class with a function for locating specific elements by their innerText.
    /// Usage: IWebElement myElement = FindElement(new ElementContainsText("span", "I'm looking for this text"));
    /// </summary>
    /// <param name="tagName">E.g "span" to search for the text in all span elements</param>
    /// <param name="text">The text to search for in all {tagName} elements in the DOM</param>
    public class ElementContainsText : By
    {
        public ElementContainsText(string tagName, string text)
        {
            FindElementMethod = (context) =>
            {
                return context.FindElement(XPath($"//{tagName}[contains(text(), '{text}')]"));
            };
        }
    }

    public static class WebElementExtensions
    {
        /// <summary>
        /// Extension method for executing a JS click. This gets around the overlaying elements issue.
        /// </summary>
        public static void ForceClick(this IWebElement element, IWebDriver driver)
        {
            var jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].click();", element);
        }
    }
}
