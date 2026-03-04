using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tools.General_Tools
{

    /// <summary>
    /// @TODO: Expand this Class as it could have some potential.
    /// </summary>
    public class RunSettings
    {

        public static string GetProperty(TestContext testContext, string name)
        {
            return testContext.Properties[name].ToString();
        }

    }
}