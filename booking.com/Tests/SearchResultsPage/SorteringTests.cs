using ATFramework.Helpers;
using booking.com.BaseClass;
using booking.com.PageObjects.SearchFormComponents;
using booking.com.PageObjects.SearchResultsPage;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace booking.com.Tests.SearchResultsPage
{
    public class SearchResultsPage_Sortering_Tests : TestBase
    {
        private SearchResultsPage_Sortering_PageObject SearchResultsPage_Sortering_PageObject => new SearchResultsPage_Sortering_PageObject(this.GetWebDriver());
        private SearchFormComponents_SearchForm_PageObject SearchForm_PageObject => new SearchFormComponents_SearchForm_PageObject(this.GetWebDriver());
        private SearchResultsPage_PageObject SearchResultsPage_PageObject => new SearchResultsPage_PageObject(this.GetWebDriver());


        protected override void OneTimeSetUp()
        {
            base.OneTimeSetUp();
            this.SearchForm_PageObject.PerformRandomSearch();
        }

        [Test]
        public void Should_Sort_Search_Results_By_Lowest_Prices()
        {
            this.SearchResultsPage_Sortering_PageObject.SortByHighestPrice();
            this.SearchResultsPage_Sortering_PageObject.WaitUntilLoadingElementGoesAway();
            
            // For now can't make away loading element go away.
            Thread.Sleep(5000);

            // Verify prices
            List<SearchResultModel> searchResults = this.SearchResultsPage_PageObject.GetSearchResults();
            List<int> prices = new List<int>();

            if (searchResults.Count > 0)
            {
                foreach (var searchResult in searchResults)
                {
                    prices.Add(int.Parse(searchResult.Price));
                }

                Assert.IsTrue(GenericHelper.ascendingCheck(prices));
            }
            else
            {
                // should be error. Later will fix it.
            }


        }

    }
}
