using NUnit.Framework;
using booking.com.BaseClass;
using OpenQA.Selenium;
using booking.com.PageObjects.SearchFormComponents;
using booking.com.DataModels;

namespace booking.com.Tests.HomePage.SearchForm
{


    public class HomePage_SearchForm_DatePicker_Tests : TestBase
    {
        public SearchFormComponents_DatePicker_PageObject DatePicker_PageObject => 
            new SearchFormComponents_DatePicker_PageObject(this.GetWebDriver());

        protected override void OneTimeSetUp()
        {
            base.OneTimeSetUp();
        }

        [TestCaseSource(typeof(DatePicker_DataModel), "Should_Select_CheckInOut_Dates_Succesfully")]
        public void Should_Select_CheckInOut_Dates_Succesfully(DatePicker_DataModel testCaseData)
        {
            this.DatePicker_PageObject.SelectCheckInOutDates(testCaseData.CheckInDate, testCaseData.CheckOutDate);
            string currentCheckInDate = this.DatePicker_PageObject.GetCurrentCheckInDate();
            string currentCheckOutDate = this.DatePicker_PageObject.GetCurrentCheckOutDate();
            Assert.AreEqual(testCaseData.CheckInDate, currentCheckInDate, "The desired check in date was not selected");
            Assert.AreEqual(testCaseData.CheckOutDate, currentCheckOutDate, "The desired check out date was not selected");
        }

        [TestCaseSource(typeof(DatePicker_DataModel), "This_Date_Should_Not_Be_Visible_In_Date_Picker")]
        public void This_Date_Should_Not_Be_Visible_In_Date_Picker(DatePicker_DataModel testCaseData)
        {
            bool isDateVisible = this.DatePicker_PageObject.IsDateVisibleInDatePicker(testCaseData.SingleDate);
            Assert.IsFalse(isDateVisible, string.Format("Date {0} is visible in date picker ", testCaseData.SingleDate));
        }

        [TestCase("2021-09-09")]
        [TestCase("2021-09-08")]
        [TestCase("2021-09-07")]
        [TestCase("2021-09-06")]
        public void This_Date_Should_Not_Be_Active_In_Date_Picker(string date)
        {
            bool isDateActive = this.DatePicker_PageObject.IsDateActiveInDatePicker(date);
            Assert.IsFalse(isDateActive, string.Format("Date {0} is active in date picker ", date));
        }

        [TestCase("2021-09-20")]
        public void This_Date_Should_Be_Active_In_Date_Picker(string date)
        {
            bool isDateActive = this.DatePicker_PageObject.IsDateActiveInDatePicker(date);
            Assert.IsTrue(isDateActive, string.Format("Date {0} is not active in date picker ", date));
        }



    }
}