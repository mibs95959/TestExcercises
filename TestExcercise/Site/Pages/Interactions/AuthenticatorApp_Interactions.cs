using System;
using System.Collections.Generic;
using System.Text;
using TestExcercise.Site.Pages.Locators;
using WebAutomation.Web.Core.WebElements.WE_Objects;

namespace TestExcercise.Site.Pages.Interactions
{
    internal class AuthenticatorApp_Interactions : AuthenticatorApp_Locators
    {

        protected static WE_Textfield CodeTextfield()
        {
            return new WE_Textfield(Code_Textfield);
        }

        protected static WE_Button EnterButton()
        {
            return new WE_Button(Enter_Button);
        }

    }
}
