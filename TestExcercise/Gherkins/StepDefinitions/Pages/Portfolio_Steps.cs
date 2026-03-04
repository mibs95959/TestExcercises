using Reqnroll;
using TestExcercise.Site.Pages.Interactions;

namespace TestExcercise.Gherkins.StepDefinitions.Pages
{
    [Binding]
    internal class Portfolio_Steps : Portfolio_Interactions
    {

        [StepDefinition(@"I verify that I can see the portfolio value")]
        public async Task VerifyPortfolioValue()
        {
            Assert.IsTrue(PortfolioValueText().IsDisplayed());
        }

        [StepDefinition(@"I verify that the portfolio value is not 0")]
        public async Task VerifyPortfolioValueIsNotZero()
        {
            Assert.IsTrue(PortfolioValueText().GetText() != "0");
        }

    }
}
