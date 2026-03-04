using Reqnroll;
using System;
using System.Collections.Generic;
using System.Text;
using WebAutomation.SpecFlow.Web.StepDefinitions.Generic;

namespace TestExcercise.Gherkins.StepDefinitions.Common
{
    [Binding]
    internal class Navigation_Steps
    {

        [StepDefinition(@"I navigate to home page")]
        public void GoHome()
        {
            BrowserInteractions_Steps.NavigateToGivenUrl(Hooks.targetUrl);
        }

    }
}
