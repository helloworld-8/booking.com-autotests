using NUnit.Framework;
using booking.com.BaseClass;
using OpenQA.Selenium;
using booking.com.PageObjects.SearchFormComponents;

namespace booking.com.Tests.SearchResultsPage.SearchForm
{


    public class SearchResultsPage_SearchForm_SearchDestination_Tests : TestBase
    {
        public SearchFormComponents_SearchDestination_PageObject SearchDestination_PageObject
            => new SearchFormComponents_SearchDestination_PageObject(this.GetWebDriver());
        public SearchFormComponents_SearchForm_PageObject SearchForm_PageObject => new SearchFormComponents_SearchForm_PageObject(this.GetWebDriver());

        protected override void OneTimeSetUp()
        {
            base.OneTimeSetUp();
            this.SearchForm_PageObject.PerformRandomSearch();
        }

        [TestCase("Palanga")]
        public void Should_Enter_And_Select_New_Search_Destination_Succesfully(string newSearchDestination)
        {
            this.SearchDestination_PageObject.ClearDestination();
            this.SearchDestination_PageObject.EnterSearchDestination(newSearchDestination);
        }
    }
}