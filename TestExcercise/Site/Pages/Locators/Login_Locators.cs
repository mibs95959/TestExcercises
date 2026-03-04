using OpenQA.Selenium;

namespace TestExcercise.Site.Pages.Locators
{
    internal class Login_Locators
    {

        protected static By Username_Textfield = By.CssSelector("input[name=\"username\"]");
        protected static By Password_Textfield = By.CssSelector("input[name=\"password\"]");
        protected static By Continue_Button = By.CssSelector("button[type=\"submit\"]");

    }
}
