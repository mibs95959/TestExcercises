using Reqnroll;
using TestExcercise.Site.Pages.Interactions;

namespace TestExcercise.Gherkins.StepDefinitions.Pages
{
    [Binding]
    internal class SecondLayerAuth_Steps : SecondLayerAuth_Interactions
    {

        [StepDefinition(@"I click on the authenticator app button")]
        public async Task ClickOnAuthenticatorAppButton()
        {
            AuthenticatorAppButton().Click();
        }


    }
}
