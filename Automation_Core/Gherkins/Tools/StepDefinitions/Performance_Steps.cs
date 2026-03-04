using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Reqnroll;
using Tools.General_Tools;

namespace WebAutomation.SpecFlow.Tools.StepDefinitions
{
    [Binding]
    public class Performance_Steps
    {

        [StepDefinition("I store the current time for later compare it")]
        public static void StoreCurrentTime()
        {
            ScenarioContext_Tool.StoreObject("genericTimeStored", DateTime.Now);
        }

        [StepDefinition("I store the current time for later compare it with the keyword '(.*)'")]
        public static void StoreCurrentTimeWithKeyword(string keyword)
        {
            ScenarioContext_Tool.StoreObject(keyword, DateTime.Now);
        }

        [StepDefinition("I compare and make sure that the stored time does not exceeds '(.*)' seconds")]
        public static void VerifyStoredCurrentTime(int seconds)
        {
            VerifyStoredCurrentTimeWithKeyword("genericTimeStored", seconds);
        }

        [StepDefinition("I compare and make sure that the stored time with the keyword '(.*)' does not exceeds '(.*)' seconds")]
        public static void VerifyStoredCurrentTimeWithKeyword(string keyword, int seconds)
        {
            DateTime stored = DateTime.Parse(ScenarioContext_Tool.GetObject(keyword).ToString());
            Assert.IsTrue(Time_Tool.IsPerformanceMeet(stored, DateTime.Now, seconds));
        }

    }
}
