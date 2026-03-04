using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestExcercise.Site.Pages.Locators
{
    internal class AuthenticatorApp_Locators
    {

        protected static By Code_Textfield = By.CssSelector("input[inputmode=\"numeric\"]");
        protected static By Enter_Button = By.XPath("//button//span[text()='Enter']");
    }
}
