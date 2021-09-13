using NUnit.Framework;
using booking.com.BaseClass;
using OpenQA.Selenium;
using booking.com.PageObjects.SearchFormComponents;

namespace booking.com.Tests.SearchResultsPage.SearchForm
{
    public class SearchResultsPage_SearchForm_DatePicker_Tests : TestBase
    {
        public SearchFormComponents_DatePicker_PageObject DatePicker_PageObject => 
            new SearchFormComponents_DatePicker_PageObject(this.GetWebDriver(), SearchFormIsIn.SearchResultsPage);

        public SearchFormComponents_SearchForm_PageObject SearchForm_PageObject => new SearchFormComponents_SearchForm_PageObject(this.GetWebDriver());

        protected override void OneTimeSetUp()
        {
            base.OneTimeSetUp();
            this.SearchForm_PageObject.PerformRandomSearch();
        }

        [TestCase("2022-12-12", "2022-12-15")]
        public void Should_Select_New_CheckInOut_Dates_Succesfully(string checkInDate, string checkOutDate)
        {
            this.DatePicker_PageObject.SelectCheckInOutDates(checkInDate, checkOutDate);
            string currentCheckInDate = this.DatePicker_PageObject.GetCurrentCheckInDate();
            string currentCheckOutDate = this.DatePicker_PageObject.GetCurrentCheckOutDate();
            Assert.AreEqual(checkInDate, currentCheckInDate, "The desired check in date was not selected");
            Assert.AreEqual(checkOutDate, currentCheckOutDate, "The desired check out date was not selected");
        }

    }
}