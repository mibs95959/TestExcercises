using Reqnroll;
using System;
using System.Collections.Generic;
using System.Text;
using TestExcercise.Site.Pages.Interactions;
using Tools.General_Tools;

namespace TestExcercise.Gherkins.StepDefinitions.Pages
{
    [Binding]
    internal class AuthenticatorApp_Steps : AuthenticatorApp_Interactions
    {

        private static string _2FAtoken = Hooks.testContext.Properties["2FAtoken"]?.ToString() ?? string.Empty;



        [StepDefinition(@"I set the default 2FA token")]
        public async Task SetDefault2FAToken()
        {
            CodeTextfield().Click();
            CodeTextfield().SetText(OTP_Tool.GetAuthSixDigCode(_2FAtoken));
        }


        [StepDefinition(@"I click on the Enter button")]
        public async Task ClickOnEnterButton()
        {
            EnterButton().Click();
        }

    }
}
