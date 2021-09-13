using ATFramework.BaseClass;
using ATFramework.Helpers;
using ATFramework.Libraries.WebDriver;
using booking.com.WebElements.SearchResultsPage;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace booking.com.PageObjects.SearchResultsPage
{
    public class SearchResultsPage_Sortering_PageObject : ATFramework_PageObjectBase
    {
        private SearchResultsPage_WebElements SearchResultsPage_WebElements => new SearchResultsPage_WebElements(this.GetWebDriver());
        public SearchResultsPage_Sortering_PageObject(WebDriver webDriver) : base(webDriver) { }

        public void SortByHighestPrice()
        {
            this.SearchResultsPage_WebElements.SortByPrice_Button.Click();
        }

        public void WaitUntilLoadingElementGoesAway()
        {
            try
            {
                this.GetWebDriver().GetCurrentDriver().WaitUntilElementIsVisible(this.SearchResultsPage_WebElements.LoadingElement);
            }
            catch
            {
                // skip
            }

            // Little hardcoded for now
            while (GenericHelper.IsElementVisible(this.SearchResultsPage_WebElements.LoadingElement))
            {
            }
            Thread.Sleep(500);
        }


    }
}
