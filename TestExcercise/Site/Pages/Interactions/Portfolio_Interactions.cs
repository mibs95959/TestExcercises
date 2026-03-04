using TestExcercise.Site.Pages.Locators;
using WebAutomation.Web.Core.WebElements.WE_Objects;

namespace TestExcercise.Site.Pages.Interactions
{
    internal class Portfolio_Interactions : Portfolio_Locators
    {

        protected static WE_Text PortfolioValueText()
        {
            return new WE_Text(PortfolioValue_Text);
        }

    }
}
