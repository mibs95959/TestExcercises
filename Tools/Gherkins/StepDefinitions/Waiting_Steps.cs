using Reqnroll;
using System.Threading;

namespace Tools.Gherkins.StepDefinitions
{

    [Binding]
    public class Waiting_Steps
    {

        [StepDefinition(@"I wait for '(.*)' seconds")]
        public static void WaitInSeconds(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }


    }
}
