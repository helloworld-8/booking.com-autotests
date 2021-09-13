using ATFramework.BaseClass;
using ATFramework.Helpers;
using ATFramework.Libraries.WebDriver;
using booking.com.WebElements.SearchResultsPage;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booking.com.PageObjects.SearchFormComponents
{
    public class SearchFormComponents_SearchForm_PageObject : ATFramework_PageObjectBase
    {
        public SearchFormComponents_SearchForm_PageObject(WebDriver webDriver) : base(webDriver) { }
        private SearchFormComponents_SearchDestination_PageObject SearchDestination_PageObject =>
            new SearchFormComponents_SearchDestination_PageObject(this.GetWebDriver());
        private SearchFormComponents_DatePicker_PageObject DatePicker_PageObject =>
            new SearchFormComponents_DatePicker_PageObject(this.GetWebDriver());
        private SearchFormComponents_GuestsTotal_PageObject GuestsTotal_PageObject =>
            new SearchFormComponents_GuestsTotal_PageObject(this.GetWebDriver());
        private IWebElement Search_Button => this.GetWebDriver().GetCurrentDriver().FindElement(By.CssSelector("button[class=\"sb-searchbox__button \"]"));

        private SearchResultsPage_WebElements SearchResultsPage_WebElements => new SearchResultsPage_WebElements(this.GetWebDriver());

        public void PerformRandomSearch()
        {
            // This could be random. But for now:
            this.PerformSearch("Kaunas", 
                DateTime.Today.AddDays(1).ToString("yyyy-MM-dd"), 
                DateTime.Today.AddDays(8).ToString("yyyy-MM-dd"),
                "2",
                "0",
                "0");
        }


        public void PerformSearch(
            string searchDestination,
            string checkInDate,
            string checkOutDate,
            string adultsNumber,
            string childrenNumber,
            string roomsNumber,
            params string[] childrenAge
            )
        {
            this.SearchDestination_PageObject.EnterSearchDestination(searchDestination);
            this.DatePicker_PageObject.SelectCheckInOutDates(checkInDate, checkOutDate);

            // Set default values to none

            if (String.Equals("0",adultsNumber))
                this.GuestsTotal_PageObject.ClearAdults();
            else
            {
                this.GuestsTotal_PageObject.SetAdultsTo(adultsNumber);
            }

            if (String.Equals("0", roomsNumber))
            {
                this.GuestsTotal_PageObject.ClearRooms();
            }
            else
            {
                this.GuestsTotal_PageObject.SetRoomsTo(roomsNumber);
            }

            if (String.Equals("0", childrenNumber))
            {
                this.GuestsTotal_PageObject.ClearChildren();
            }
            else
            {
                this.GuestsTotal_PageObject.SetChildrenTo(adultsNumber, childrenAge);
            }

            this.Search_Button.Click();

            // This for making sure that correct page is fully loaded
            this.GetWebDriver().GetCurrentDriver().WaitUntilUrlContains(Routes.SearchResultsPage);
            while (!this.SearchResultsPage_WebElements.isSearchResultsLoaded)
            { }
            this.GetWebDriver().GetCurrentDriver().WaitUntilElementIsVisible(this.SearchResultsPage_WebElements.HotelList_Container, 20);
        }

        public void ClearSearchForm()
        {
            this.GuestsTotal_PageObject.ClearAdults();
            this.GuestsTotal_PageObject.ClearRooms();
            this.GuestsTotal_PageObject.ClearChildren();
            this.SearchDestination_PageObject.ClearDestination();
            // For check in-out dates is no need
        }

    }
}
