using ATFramework.BaseClass;
using ATFramework.Helpers;
using ATFramework.Libraries.WebDriver;
using booking.com.WebElements.SearchResultsPage;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace booking.com.PageObjects.SearchResultsPage
{
    public class SearchResultModel
    {
        public string Location { get; set; }
        public string AdultsNumber { get; set; }
        public string ChildrenNumber { get; set; }
        public string Nights { get; set; }
        public string Price { get; set; }
        public string Url { get; set; }
    }

    public class SearchResultsPage_PageObject : ATFramework_PageObjectBase
    {
        private SearchResultsPage_WebElements SearchResultsPage_WebElements => new SearchResultsPage_WebElements(this.GetWebDriver());
        public SearchResultsPage_PageObject(WebDriver webDriver) : base(webDriver) { }

        public List<SearchResultModel> GetSearchResults()
        {
            if (this.SearchResultsPage_WebElements.SearchResults.Count == 0)
            {
                // should be error. Will fix it later.
            }
            List<SearchResultModel> SearchResults = new List<SearchResultModel>();

            foreach (var searchResult in this.SearchResultsPage_WebElements.SearchResults)
            {
                SearchResultModel searchResultModel = new SearchResultModel();
                searchResultModel.Location = this.SearchResultsPage_WebElements.GetLocation(searchResult).Text;
                searchResultModel.Price = new string(this.SearchResultsPage_WebElements.GetPrice(searchResult).Text.Where(c => char.IsDigit(c)).ToArray());

                string[] roomsDetails = this.SearchResultsPage_WebElements.GetRoomDetails(searchResult).Text.Split(',');
                if (roomsDetails.Length > 1)
                {
                    // It turns out that it sometimes shows nights, sometimes weeks. Needs some work. For now we disabling it.
                    //searchResultModel.Nights = roomsDetails.Length > 0 ? roomsDetails[0] : "";
                    searchResultModel.Nights = "";
                    searchResultModel.AdultsNumber = roomsDetails.Length > 1 ? roomsDetails[1] : "";
                    searchResultModel.ChildrenNumber = roomsDetails.Length > 2 ? roomsDetails[2] : "";
                }
                searchResultModel.Url = this.SearchResultsPage_WebElements.GetLink(searchResult).GetAttribute("href");
                SearchResults.Add(searchResultModel);
            }
            return SearchResults;
        }
    }
}
