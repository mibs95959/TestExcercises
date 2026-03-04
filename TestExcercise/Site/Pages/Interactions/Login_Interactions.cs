using TestExcercise.Site.Pages.Locators;
using WebAutomation.Web.Core.WebElements.WE_Objects;

namespace TestExcercise.Site.Pages.Interactions
{
    internal class Login_Interactions : Login_Locators
    {

        protected static WE_Textfield UsernameTextBox()
        {
            return new WE_Textfield(Username_Textfield);
        }

        protected static WE_Textfield PasswordTextBox()
        {
            return new WE_Textfield(Password_Textfield);
        }   

        protected static WE_Button ContinueButton()
        {
            return new WE_Button(Continue_Button);
        }

    }
}
