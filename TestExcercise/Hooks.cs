using Reqnroll;
using System;
using System.Collections.Generic;
using System.Text;
using Tools.General_Tools;
using Tools.General_Tools.Windows;

namespace TestExcercise
{
    [Binding]
    public sealed class Hooks
    {

        
        internal static ScenarioContext_Tool scenarioContext = new ScenarioContext_Tool();
        internal static string targetUrl = string.Empty;
        internal static TestContext testContext;


        private static void GatheringValues(TestContext context)
        {
            targetUrl = context.Properties["URL"]?.ToString() ?? string.Empty;
            testContext = context;
        }

        [BeforeTestRun]
        public static void BeforeTestRun(TestContext context)
        {
            GatheringValues(context);
        }

        [BeforeScenario]
        public void FirstBeforeScenario()
        {
        }

        [AfterScenario]
        public void AfterScenario()
        {
            ProcessManager_Tool.EndAllProcessesWithGivenName("chromedriver");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ProcessManager_Tool.EndAllProcessesWithGivenName("chromedriver");
        }


    }
}
