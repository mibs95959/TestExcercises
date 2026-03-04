using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutomation.Web.Core.WebElements.WE_Objects
{
    /// <summary>
    /// @TODO: Define and Extend better the WE_Generic class.
    /// 
    /// The idea of this class is to be a generic WebElement that can be used when no specific type is needed.
    /// Ideal for those WEs that do not fit into any of the other specific WebElement types.
    /// 
    /// </summary>
    public class WE_Generic : WE_Base
    {

        public WE_Generic(By locator)
        {
            SetElement(locator);
        }

        public WE_Generic(IWebElement givenElement)
        {
            SetElement(givenElement);
        }


    }
}
