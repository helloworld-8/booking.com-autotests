using NUnit.Framework;
using booking.com.BaseClass;
using OpenQA.Selenium;
using booking.com.PageObjects.SearchFormComponents;
using System.Collections.Generic;

namespace booking.com.Tests.HomePage.SearchForm
{


    public class HomePage_SearchForm_GuestsTotal_Tests : TestBase
    {
        public SearchFormComponents_GuestsTotal_PageObject GuestsTotal_PageObject => 
            new SearchFormComponents_GuestsTotal_PageObject(this.GetWebDriver());

        protected override void OneTimeSetUp()
        {
            base.OneTimeSetUp();
        }

        [TestCase("5")]
        [TestCase("10")]
        [TestCase("1")]
        public void Should_Set_Adults_Number_Succesfully(string adultsNumber)
        {
            this.GuestsTotal_PageObject.ClearAdults();
            this.GuestsTotal_PageObject.SetAdultsTo(adultsNumber);
            Assert.AreEqual(this.GuestsTotal_PageObject.GetCurrentAdultsNumber().ToString(), adultsNumber);
        }

        [TestCase("2", new[] { "10", "10" })]
        [TestCase("3", new[] { "10", "10", "12" })]
        [TestCase("2", new[] { "10", "12" })]
        public void Should_Set_Children_Number_And_Age_Succesfully(string childrenNumber, params string[] childrenAge)
        {
            this.GuestsTotal_PageObject.ClearChildren();
            this.GuestsTotal_PageObject.SetChildrenTo(childrenNumber, childrenAge);
            Assert.AreEqual(this.GuestsTotal_PageObject.GetCurrentChildrenNumber().ToString(), childrenNumber);
            Assert.AreEqual(this.GuestsTotal_PageObject.GetCurrentChildrenAge(), childrenAge);
        }

        [TestCase("5")]
        [TestCase("10")]
        [TestCase("1")]
        public void Should_Set_Rooms_Number_Succesfully(string roomsNumber)
        {
            this.GuestsTotal_PageObject.ClearRooms();
            this.GuestsTotal_PageObject.SetRoomsTo(roomsNumber);
            Assert.AreEqual(this.GuestsTotal_PageObject.GetCurrentRoomsNumber().ToString(), roomsNumber);
        }

    }
}