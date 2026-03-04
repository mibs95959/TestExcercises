using Reqnroll;
using TestExcercise.Site.Pages.Interactions;

namespace TestExcercise.Gherkins.StepDefinitions.Pages
{
    [Binding]
    internal class Login_Steps : Login_Interactions
    {

        private static string _defaultUsername = Hooks.testContext.Properties["username"]?.ToString() ?? string.Empty;
        private static string _defaultPassword = Hooks.testContext.Properties["password"]?.ToString() ?? string.Empty;


        [StepDefinition(@"I set the username to '(.*)'")]
        public async Task SetUsername(string username)
        {
            UsernameTextBox().SetText(username);
        }

        [StepDefinition(@"I set the default username")]
        public async Task SetDefaultUsername()
        {
            UsernameTextBox().SetText(_defaultUsername);
        }

        [StepDefinition(@"I set the password to '(.*)'")]
        public async Task SetPassword(string password)
        {
            PasswordTextBox().SetText(password);
        }

        [StepDefinition(@"I set the default password")]
        public async Task SetDefaultPassword()
        {
            PasswordTextBox().SetText(_defaultPassword);
        }


        [StepDefinition(@"I click the continue button")]
        public async Task ClickContinueButton()
        {
            ContinueButton().Click();
        }



    }
}
