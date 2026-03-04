using Reqnroll;
using TestExcercise.Site.Components.Interactions;

namespace TestExcercise.Gherkins.StepDefinitions.Components
{
    [Binding]
    internal class Header_Steps : Header_Interactions
    {

        [StepDefinition(@"I click on the Login button")]
        public void ClickOnLogin()
        {
            LoginButton().Click();
        }



    }
}
