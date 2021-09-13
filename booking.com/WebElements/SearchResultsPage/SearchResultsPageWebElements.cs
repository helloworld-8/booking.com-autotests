using ATFramework.BaseClass;
using ATFramework.Libraries.WebDriver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booking.com.WebElements.SearchResultsPage
{
    public class SearchResultsPage_WebElements : ATFramework_WebElementsBase
    {
        public SearchResultsPage_WebElements(WebDriver webDriver) : base(webDriver)
        {
            this.js = (IJavaScriptExecutor)webDriver.GetCurrentDriver();
        }

        private IJavaScriptExecutor js;
        public IWebElement HeadingThatContains(string textFragment)
        {
            return this.GetWebDriver().GetCurrentDriver().FindElement(By.XPath(String.Format("//h1[contains(text(), '{0}')]", textFragment)));
        }
        public bool isSearchResultsLoaded => (bool)js.ExecuteScript("return booking.env.scripts_tracking.searchresults.loaded");
        public IWebElement HotelList_Container => this.GetWebDriver().GetCurrentDriver().FindElement(By.Id("hotellist_inner"));
        public IReadOnlyCollection<IWebElement> SearchResults => this.GetWebDriver().GetCurrentDriver().FindElements(By.CssSelector("div[data-hotelid]"));
        public IWebElement GetLocation(IWebElement searchResult)
        {
            return searchResult.FindElement(By.CssSelector("div[class=\"sr_card_address_line\"]"));
        }

        public IWebElement GetPrice(IWebElement searchResult)
        {
            return searchResult.FindElement(By.CssSelector("div.bui-price-display__value"));
        }

        public IWebElement GetRoomDetails(IWebElement searchResult)
        {
            return searchResult.FindElement(By.CssSelector(".room_details .bui-price-display__label.prco-inline-block-maker-helper"));
        }
        public IWebElement SortBar => this.GetWebDriver().GetCurrentDriver().FindElement(By.CssSelector("div[data-sort-bar-container=\"sort-bar\"]"));
        public IWebElement SortByPrice_Button => SortBar.FindElement(By.CssSelector("li[data-id=\"price\"]"));

        public IWebElement LoadingElement => this.GetWebDriver().GetCurrentDriver().FindElement(By.CssSelector(".bui-spinner"));

    }
}
