using System;
using System.Collections.Generic;
using System.Text;
using TestExcercise.Site.Components.Locators;
using WebAutomation.Web.Core.WebElements.WE_Objects;

namespace TestExcercise.Site.Components.Interactions
{
    internal class Header_Interactions : Header_Locators
    {

        protected static WE_Button LoginButton()
        {
            return new WE_Button(Login_Button);
        }
    
    
    
    
    }
}
