using ATFramework.Helpers;
using booking.com.BaseClass;
using booking.com.PageObjects.SearchFormComponents;
using booking.com.PageObjects.SearchResultsPage;
using booking.com.WebElements.SearchResultsPage;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace booking.com.Tests.Search
{
    public class Search_SearchFromHomePage_Tests : TestBase
    {
        private SearchFormComponents_SearchForm_PageObject SearchForm_PageObject => new SearchFormComponents_SearchForm_PageObject(this.GetWebDriver());
        private SearchFormComponents_SearchDestination_PageObject SearchDestination_PageObject => new SearchFormComponents_SearchDestination_PageObject(this.GetWebDriver());
        private SearchFormComponents_DatePicker_PageObject DatePicker_PageObject => new SearchFormComponents_DatePicker_PageObject(this.GetWebDriver(), SearchFormIsIn.SearchResultsPage);
        private SearchFormComponents_GuestsTotal_PageObject GuestsTotal_PageObject => new SearchFormComponents_GuestsTotal_PageObject(this.GetWebDriver(), SearchFormIsIn.SearchResultsPage);
        private SearchResultsPage_WebElements SearchResultsPage_WebElements => new SearchResultsPage_WebElements(this.GetWebDriver());
        private SearchResultsPage_PageObject SearchResultsPage_PageObject => new SearchResultsPage_PageObject(this.GetWebDriver());


        [Test]
        public void Should_Perform_A_Successful_Search_And_Redirect_To_Search_Results_Page()
        {
            SearchForm_PageObject.PerformRandomSearch();
            StringAssert.AreEqualIgnoringCase(new Uri(Routes.SearchResultsPage).LocalPath, new Uri(this.GetWebDriver().GetCurrentUrl()).LocalPath, "The page address does not start with searchresults.html");
        }
        
        [TestCase("Kaunas", "2021-09-22", "2021-09-30", "2", "0", "1")]
        [TestCase("Palanga", "2021-09-20", "2021-09-30", "2", "0", "1")]
        public void Should_Perform_A_Successful_Search_And_Save_The_Same_Search_Criteria_In_Search_Form(
            string searchDestination,
            string checkInDate,
            string checkOutDate,
            string adultsNumber,
            string childrenNumber,
            string roomsNumber,
            params string[] childrenAge
        )
        {
            SearchForm_PageObject.PerformSearch(searchDestination, checkInDate, checkOutDate, adultsNumber, childrenNumber, roomsNumber, childrenAge);
            string currentCheckInDate = this.DatePicker_PageObject.GetCurrentCheckInDate();
            string currentCheckOutDate = this.DatePicker_PageObject.GetCurrentCheckOutDate();
            Assert.AreEqual(checkInDate, currentCheckInDate, "The check in date was not saved");
            Assert.AreEqual(checkOutDate, currentCheckOutDate, "The check out date was not saved");
            Assert.AreEqual(this.GuestsTotal_PageObject.GetCurrentAdultsNumber().ToString(), adultsNumber, "The adults number was not saved");
            Assert.AreEqual(this.GuestsTotal_PageObject.GetCurrentChildrenNumber().ToString(), childrenNumber);
            if (childrenAge.Length > 0)
            {
                Assert.AreEqual(this.GuestsTotal_PageObject.GetCurrentChildrenAge(), childrenAge);
            }
            Assert.AreEqual(this.GuestsTotal_PageObject.GetCurrentRoomsNumber().ToString(), roomsNumber);
            
            // Go Back
            this.GetWebDriver().NavigateToUrl(Routes.HomePage);
            SearchForm_PageObject.ClearSearchForm();
        }

        [TestCase("Vilnius", "2021-09-22", "2021-09-30", "2", "0", "1")]
        [TestCase("Kaunas", "2021-09-22", "2021-09-30", "2", "0", "1")]
        public void Should_Perform_A_Successful_Search_And_Display_Relevant_Search_Results(
            string searchDestination,
            string checkInDate,
            string checkOutDate,
            string adultsNumber,
            string childrenNumber,
            string roomsNumber,
            params string[] childrenAge
        )
        {
            SearchForm_PageObject.PerformSearch(searchDestination, checkInDate, checkOutDate, adultsNumber, childrenNumber, roomsNumber, childrenAge);

            var datesDiff = (DateTime.Parse(checkOutDate) - DateTime.Parse(checkInDate)).Days.ToString();
            this.GetWebDriver().GetCurrentDriver().WaitUntilElementIsVisible(this.SearchResultsPage_WebElements.HeadingThatContains(searchDestination));

            StringAssert.Contains(searchDestination, this.SearchResultsPage_WebElements.HeadingThatContains(searchDestination).Text, "Heading does not contain selected destination name");

            List<SearchResultModel> searchResults = this.SearchResultsPage_PageObject.GetSearchResults();

            if (searchResults.Count > 0)
            {
                foreach (var searchResult in searchResults)
                {
                    StringAssert.Contains(searchDestination, searchResult.Location, "Search destination is not found in a hotel list");
                    StringAssert.Contains(adultsNumber, searchResult.AdultsNumber, "Adults number is not found in a hotel list");
                    if (!string.IsNullOrEmpty(searchResult.ChildrenNumber))
                    {
                        StringAssert.Contains(childrenNumber, searchResult.ChildrenNumber, "Children number is not found in a hotel list");
                    }
                    // It turns out that it sometimes shows nights, sometimes weeks. Needs some work. For now we disabling it.
                    //StringAssert.Contains(datesDiff, searchResult.Nights, "Nights number is not found in a hotel list");
                }
            }
            else
            {
                // should be error. Later will fix it.
            }

            // Go Back
            this.GetWebDriver().NavigateToUrl(Routes.HomePage);
            SearchForm_PageObject.ClearSearchForm();
        }


    }
}
