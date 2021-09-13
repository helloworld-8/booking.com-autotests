using NUnit.Framework;
using booking.com.BaseClass;
using OpenQA.Selenium;
using booking.com.PageObjects.SearchFormComponents;

namespace booking.com.Tests.HomePage.SearchForm
{


    public class HomePage_SearchForm_SearchDestination_Tests : TestBase
    {
        public SearchFormComponents_SearchDestination_PageObject SearchDestination_PageObject => new SearchFormComponents_SearchDestination_PageObject(this.GetWebDriver());

        protected override void OneTimeSetUp()
        {
            base.OneTimeSetUp();
        }

        [TestCase("Kaunas")]
        public void Should_Enter_And_Select_Search_Destination_Succesfully(string searchDestination)
        {
            this.SearchDestination_PageObject.EnterSearchDestination(searchDestination);
        }

    }
}