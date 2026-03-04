using TestExcercise.Site.Pages.Locators;
using WebAutomation.Web.Core.WebElements.WE_Objects;

namespace TestExcercise.Site.Pages.Interactions
{
    internal class SecondLayerAuth_Interactions : SecondLayerAuth_Locators
    {

        protected static WE_Button AuthenticatorAppButton()
        {
            return new WE_Button(AuthenticatorApp_Button);
        }


    }
}
