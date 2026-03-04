using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reqnroll;
using System;
using Tools.General_Tools.Windows;

namespace WebAutomation.SpecFlow
{
    [Binding]
    public sealed class Core_Hooks
    {

        public static TestContext TestContext;

        public static bool Headless;

        [BeforeTestRun]
        public static void Setup(TestContext context)
        {
            TestContext = context;
            FileManager_Tool.CleanupReportsFolder();
            ProcessManager_Tool.EndAllProcessesWithGivenName("chromedriver"); // prevents multitasking :( 
            FileManager_Tool.SetupFolders();

            var headlessProp = TestContext.Properties["HeadlessMode"];
            Headless = bool.Parse(headlessProp?.ToString() ?? "false");

        }

        [AfterTestRun]
        public static void TearDown()
        {
            // Open to do whatever we need here :)
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            // Open to do whatever we need here :)
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            // Open to do whatever we need here :)
        }

        [AfterScenario]
        public void AfterScenario()
        {
            try
            {
                // We shouldn't kill chrome between every scenario, that's cray cray.
                //WB_Interactions.End();
                //if (Headless) {
                //    ProcessManager_Tool.EndProcess("chrome");
                //}
                //ProcessManager_Tool.EndProcess("chromedriver");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [BeforeStep]
        public static void BeforeStep(ScenarioContext scenarioContext)
        {
            // Open to do whatever we need here :)
        }

        [AfterStep]
        public static void AfterStep(ScenarioContext scenarioContext)
        {
            // Open to do whatever we need here :)
        }

    }
}
