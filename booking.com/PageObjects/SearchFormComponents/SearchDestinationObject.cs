using ATFramework.BaseClass;
using ATFramework.Helpers;
using ATFramework.Libraries.WebDriver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace booking.com.PageObjects.SearchFormComponents
{
    public class SearchFormComponents_SearchDestination_PageObject : ATFramework_PageObjectBase
    {
        public SearchFormComponents_SearchDestination_PageObject(WebDriver webDriver) : base(webDriver) { }
        private IWebElement SearchDestination_Input => this.GetWebDriver().GetCurrentDriver().FindElement(By.Id("ss"));
        private IWebElement SearchDestinationAutoComplete_Dropdown => this.GetWebDriver().GetCurrentDriver().FindElement(By.CssSelector("ul.c-autocomplete__list"));
        private IReadOnlyCollection<IWebElement> SearchDestinationAutoComplete_Results => SearchDestinationAutoComplete_Dropdown.FindElements(By.TagName("li"));

        public void EnterSearchDestination(string searchDestination)
        {
            // Hardcoded fix
            Thread.Sleep(1000);

            this.SearchDestination_Input.SendKeys(searchDestination);

            // Sometimes it can happen that the autocomplete list does not appear. This is a hard-coded fix.
            try
            {
                this.GetWebDriver().GetCurrentDriver().WaitUntilElementIsVisible(this.SearchDestinationAutoComplete_Dropdown);
            }
            catch (WebDriverTimeoutException)
            {
                this.SearchDestination_Input.SendKeys(" ");
                this.GetWebDriver().GetCurrentDriver().WaitUntilElementIsVisible(this.SearchDestinationAutoComplete_Dropdown);
            }

            foreach (var searchDestinationInAutoComplete in SearchDestinationAutoComplete_Results)
            {
                if (searchDestinationInAutoComplete.Text.Contains(searchDestination))
                {
                    searchDestinationInAutoComplete.Click();
                }
            }

            /* Uncomment this, if code with foreach does not work */
            // Find first result in the autocomplete drop-down field
            //SearchDestinationAutoComplete_Results.ElementAt(0).Click();

        }

        public void ClearDestination()
        {
            this.SearchDestination_Input.Clear();
        }

    }
}
