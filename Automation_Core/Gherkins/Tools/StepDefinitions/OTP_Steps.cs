using System;
using Reqnroll;
using Tools.General_Tools;
using System.Text.RegularExpressions;

namespace WebAutomation.SpecFlow.Tools.StepDefinitions
{
    [Binding]
    public sealed class OTP_Steps : OTP_Tool
    {
        [Given("I get the six digits Authorization code from '(.*)'")]
        public static void GetAuthCodeFrom(string input)
        {
            ScenarioContext_Tool.StoreObject("SixDigAuthCode", GetAuthSixDigCode(input));
        }

        /// <summary>
        /// TODO: Refactor this step.
        /// 
        /// Read/write at the Scenario context what kind of user we are using, so it then becomes a Dynamic step.
        /// </summary>
        [Given("I get a valid Authorization token for the account being used")]
        public static void GetValidAuthToken()
        {
            string secretForWhichAcc = ScenarioContext_Tool.GetStringObject("Login_Token");

            try
            {
                // Apparently login_token is sometimes the 2fa token, sometimes an account, depending on run context :( 
                // Check which is which instead of relying on env to be the trigger (which would be faulty)
                // Is base32 ? 
                if (Regex.Match(secretForWhichAcc, "[A-Z2-7=]{16}").Success)
                {
                    ScenarioContext_Tool.StoreObject("SixDigAuthCode", GetAuthSixDigCode(secretForWhichAcc));
                }
                else
                {
                    ScenarioContext_Tool.StoreObject("SixDigAuthCode", GetAuthSixDigCode((string)Core_Hooks.TestContext.Properties[secretForWhichAcc + "_token"]));
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Warning!: No Token found at the Runsetting file for the account " + secretForWhichAcc);
            }
        }


    }
}
