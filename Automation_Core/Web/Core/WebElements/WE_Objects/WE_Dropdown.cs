using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAutomation.Web.Core.WebElements.WE_Interactions;

namespace WebAutomation.Web.Core.WebElements.WE_Objects
{
    public class WE_Dropdown : WE_Base
    {

        // Dropdown elements:

        public WE_Button expandButton;
        public IList<WE_Button> dropDownOptions;
        public WE_Textfield textfield;


        // Constructors:

        public WE_Dropdown(By dropdown)
        {
            SetElement(dropdown);
        }

        public WE_Dropdown(IWebElement dropdown)
        {
            SetElement(dropdown);
        }

        public WE_Dropdown(By locator, WE_Iframe homeFrame)
        {
            SetElement(locator, homeFrame);
        }

        public WE_Dropdown(IWebElement givenElement, WE_Iframe homeFrame)
        {
            SetElement(givenElement, homeFrame);
        }

        public WE_Dropdown(By dropdown, By dropdownOptions)
        {
            SetElement(dropdown);
            dropDownOptions = Converter(Find.Elements(dropdownOptions));
        }

        public WE_Dropdown(By dropdown, By expandButton, By dropdownOptions)
        {
            SetElement(dropdown);
            this.expandButton = new WE_Button(expandButton);
            IList<IWebElement> optionsWEs = Find.Elements(dropdownOptions);
            dropDownOptions = new List<WE_Button>();
            foreach (IWebElement dropdownOption in optionsWEs) dropDownOptions.Add(new WE_Button(dropdownOption));
        }

        public WE_Dropdown(By dropdown, By expandButton, By dropdownOptions, By textField)
        {
            SetElement(dropdown);
            textfield = new WE_Textfield(textField);
            this.expandButton = new WE_Button(expandButton);
            IList<IWebElement> optionsWEs = Find.Elements(dropdownOptions);
            dropDownOptions = new List<WE_Button>();
            foreach (IWebElement dropdownOption in optionsWEs) dropDownOptions.Add(new WE_Button(dropdownOption));
        }

        private IList<WE_Button> Converter(IList<IWebElement> input)
        {
            List<WE_Button> result = new List<WE_Button>();
            foreach (IWebElement x in input) result.Add(new WE_Button(x));
            return result;
        }

        private void DoubleClickOnExpand(By locator)
        {
            new WE_Button(locator).Click();
            new WE_Button(locator).Click();
        }

        private void ExpandDropdown(By dropdownOptions)
        {
            expandButton.Click();
            try
            {
                Find.Elements(dropdownOptions);
            }
            catch (NoSuchElementException)
            {
                expandButton.Click();
            }
        }

        // Capabilities:

        public void Click()
        {
            WE_Interactions.Click.OnElement(element);
        }

        public void ClickOnExpandButton()
        {
            expandButton.Click();
        }

        public bool IsEnabled()
        {
            return Bools.IsElementEnabled(element);
        }

        public bool IsGivenOptionDisplayed(string option)
        {
            return GetDisplayedOptions().Contains(option);
        }

        /// <summary>
        /// TODO: Verify the functionality of this method, as it doesnt seem to be a conventional
        /// Dropdown element.
        /// </summary>
        /// <param name="optionName"></param>
        public void SelectOptionByName(string optionName)
        {
            Dropdown.SelectFromDropdownByName(element, optionName);
        }

        public void SelectOptionByIndex(int index)
        {
            Dropdown.SelectFromDropdownByIndex(element, index);
        }

        // NEW Implementation:

        /// <summary>
        /// Warning: Experimental.
        /// </summary>
        /// <param name="optionName"></param>
        public void New_SelectOptionByName(string optionName)
        {

            try
            {
                dropDownOptions[0].GetText();
            }
            catch (StaleElementReferenceException)
            {
                /// Getting this here: StaleElementReferenceException: stale element reference: stale element not found
                element.Click();
            }

            foreach (WE_Button x in dropDownOptions)
            {
                if (x.GetText().Equals(optionName))
                {
                    x.Click();
                    break;
                }
            }
        }

        /// <summary>
        /// Warning: Experimental.
        /// </summary>
        public void New_SelectOptionByIndex(int index)
        {
            dropDownOptions[index].Click();
        }

        public void SelectFromDropdownByName(string optionName)
        {
            if (dropDownOptions.Count() == 0) expandButton.Click();

            foreach (WE_Button x in dropDownOptions)
            {
                if (x.GetText().Equals(optionName))
                {
                    x.Click();
                    break;
                }
            }
        }



        public List<string> GetDisplayedOptions()
        {
            return Dropdown.GetDisplayedOptionsAtDropdown(element);
        }


    }
}
