using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using WebAutomation.Web.Core;

namespace WebAutomation.Web.Core.Others
{
    public class Robot : SeleniumCore
    {
        /// <summary>
        /// Could be used to Hover as well...
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void MoveMouseTo(uint x, uint y)
        {
            var actions = new Actions(driver);
            actions.MoveByOffset((int)x, (int)y).Perform();
        }

        public static void PressEnter()
        {
            var actions = new Actions(driver);
            actions.KeyDown(Keys.Enter).Perform();
            actions.KeyDown(Keys.Enter).Perform();
            actions.KeyUp(Keys.Enter).Perform();
        }

        public static void PressDelete()
        {
            var actions = new Actions(driver);
            actions.SendKeys(Keys.Delete).Perform();
        }

        public static void PressEsc()
        {
            var actions = new Actions(driver);
            actions.SendKeys(Keys.Escape).Perform();
        }

        public static void PressControlA()
        {
            var actions = new Actions(driver);
            actions.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
        }
    }
}
