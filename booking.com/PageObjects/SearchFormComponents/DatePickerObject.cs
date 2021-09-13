using ATFramework.BaseClass;
using ATFramework.Helpers;
using ATFramework.Libraries.WebDriver;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using ATFramework.Libraries.Cache;
using booking.com.WebElements.SearchFormComponents;

namespace booking.com.PageObjects.SearchFormComponents
{
    public class SearchFormComponents_DatePicker_PageObject : ATFramework_PageObjectBase
    {
        public SearchFormComponents_DatePicker_PageObject(WebDriver webDriver, SearchFormIsIn searchFormIsIn = SearchFormIsIn.HomePage) : base(webDriver)
        {
            this.searchFormIsIn = searchFormIsIn;
        }
        private SearchFormComponents_DatePicker_WebElements DatePicker_WebElements => new SearchFormComponents_DatePicker_WebElements(this.GetWebDriver());

        private SearchFormIsIn searchFormIsIn;

        /// <summary>
        /// This is required to have one method that automatically processes dates. 
        /// Changing the date format on the site would make it easy to change here as well. 
        /// </summary>
        /// <param name="date">Any real date</param>
        /// <param name="dateFormat">Date format</param>
        /// <returns></returns>
        private string FormattedDate(string date, DateFormat dateFormat = DateFormat.yyyyMMdd)
        {
            DateTime convertedDate = Convert.ToDateTime(date);
            string _dateFormat = dateFormat == DateFormat.yyyyMMdd ? "yyyy-MM-dd" : "yyyy-MM";
            return convertedDate.ToString(_dateFormat);
        }

        /// <summary>
        /// This represents the currently visible dates. 
        /// Only two-month dates can be seen on the site at a time, so we need to know which ones are visible now.
        /// Usually shows the dates from the month that is now.
        /// </summary>
        /// <returns></returns>
        private List<string> GetCurrentVisibleDates()
        {
            List<string> currentVisibleDates = new List<string>();
            foreach (var datePickerMonth in this.DatePicker_WebElements.DatePickerMonths)
            {
                string date = this.DatePicker_WebElements.FindFirstDate(datePickerMonth).GetAttribute("data-date");
                currentVisibleDates.Add(this.FormattedDate(date, DateFormat.yyyyMM));
            }
            return currentVisibleDates;
        }


        /// <summary>
        /// Here we aim to make the desired date visible
        /// Also check this.GetCurrentVisibleDates();
        /// </summary>
        /// <param name="date">Any real date</param>
        private void MakeDateVisible(string date)
        {
            DatePickerPage datePickerPage = DatePickerPage.Unknown;
            string formatedDate = this.FormattedDate(date, DateFormat.yyyyMM);

            if (!GenericHelper.IsElementVisible(this.DatePicker_WebElements.ControlPrev) && GenericHelper.IsElementVisible(this.DatePicker_WebElements.ControlNext))
            {
                datePickerPage = DatePickerPage.First;
            }
            else if (GenericHelper.IsElementVisible(this.DatePicker_WebElements.ControlPrev) && GenericHelper.IsElementVisible(this.DatePicker_WebElements.ControlNext))
            {
                datePickerPage = DatePickerPage.Middle;
            }
            else if (GenericHelper.IsElementVisible(this.DatePicker_WebElements.ControlPrev) && !GenericHelper.IsElementVisible(this.DatePicker_WebElements.ControlNext))
            {
                datePickerPage = DatePickerPage.Last;
            }

            switch (datePickerPage)
            {
                case DatePickerPage.Last:
                case DatePickerPage.Middle:
                    // Go back to the first page of date picker. It is not most efficiency, but so far effective
                    while (GenericHelper.IsElementVisible(this.DatePicker_WebElements.ControlPrev))
                    {
                        this.DatePicker_WebElements.ControlPrev.Click();
                    }
                    datePickerPage = DatePickerPage.First;
                    goto case DatePickerPage.First;
                case DatePickerPage.First:
                    bool dateFound = false;

                    // Not the most neat code, but it still works
                    if (!GetCurrentVisibleDates().Contains(formatedDate))
                    {
                        while (GenericHelper.IsElementVisible(this.DatePicker_WebElements.ControlNext))
                        {
                            this.DatePicker_WebElements.ControlNext.Click();

                            if (GetCurrentVisibleDates().Contains(formatedDate))
                            {
                                dateFound = true;
                                break;
                            }
                        }
                    } else
                    {
                        dateFound = true;
                    }

                    if (!dateFound)
                    {
                        throw new DateNotFoundInDatePickerException(date);
                    }
                    break;
            }

        }

        /// <summary>
        /// If the date is visible, this method helps to choose (select) it.
        /// </summary>
        /// <param name="date"></param>
        private void SelectDate(string date)
        {
            string formattedDate = this.FormattedDate(date);
            this.DatePicker_WebElements.FindDateBy(formattedDate).Click();
        }
        public string GetCurrentCheckInDate()
        {
            var checkInYear = this.DatePicker_WebElements.CheckInYear;
            var checkInMonth = this.DatePicker_WebElements.CheckInMonth;
            var checkInDay = new SelectElement(this.DatePicker_WebElements.CheckInMonthDay).SelectedOption.GetAttribute("value");

            if(!String.IsNullOrEmpty(checkInYear) && !String.IsNullOrEmpty(checkInMonth) && !String.IsNullOrEmpty(checkInDay))
            {
                return this.FormattedDate(String.Format("{0}-{1}-{2}", checkInYear, checkInMonth, checkInDay));
            }
            return "";
        }

        public string GetCurrentCheckOutDate()
        {
            var checkOutYear = this.DatePicker_WebElements.CheckOutYear;
            var checkOutMonth = this.DatePicker_WebElements.CheckOutMonth;
            var checkOutDay = new SelectElement(this.DatePicker_WebElements.CheckOutMonthDay).SelectedOption.GetAttribute("value");

            if (!String.IsNullOrEmpty(checkOutYear) && !String.IsNullOrEmpty(checkOutMonth) && !String.IsNullOrEmpty(checkOutDay))
            {
                return this.FormattedDate(String.Format("{0}-{1}-{2}", checkOutYear, checkOutMonth, checkOutDay));
            }
            return "";
        }

        /// <summary>
        /// We aim to determine whether such a date is generally visible in the date picker.
        /// </summary>
        /// <param name="date">Any real date</param>
        /// <returns></returns>
        public bool IsDateVisibleInDatePicker(string date)
        {
            if(!GenericHelper.IsElementVisible(this.DatePicker_WebElements.DatePicker))
            {
                this.DatePicker_WebElements.CheckInDate_Input.Click();
                this.GetWebDriver().GetCurrentDriver().WaitUntilElementIsVisible(this.DatePicker_WebElements.DatePicker);
            }

            try
            {
                this.MakeDateVisible(date);
                return true;
            }
            catch (DateNotFoundInDatePickerException ex)
            {
                return false;
            }
        }

        public bool IsDateActiveInDatePicker(string date)
        {
            if (!GenericHelper.IsElementVisible(this.DatePicker_WebElements.DatePicker))
            {
                this.DatePicker_WebElements.CheckInDate_Input.Click();
                this.GetWebDriver().GetCurrentDriver().WaitUntilElementIsVisible(this.DatePicker_WebElements.DatePicker);
            }

            try
            {
                this.MakeDateVisible(date);
            }
            catch (DateNotFoundInDatePickerException ex)
            {
                return false;
            }

            string formattedDate = this.FormattedDate(date);
            if(GenericHelper.HasClass(this.DatePicker_WebElements.FindDateBy(formattedDate), this.DatePicker_WebElements.disabledDateClass)) {
                return false;
            } else
            {
                return true;
            }
        }

        public void SelectCheckInOutDates(string checkInDate, string checkOutDate)
        {

            switch (this.searchFormIsIn)
            {
                case SearchFormIsIn.HomePage:

                    if (!GenericHelper.IsElementVisible(this.DatePicker_WebElements.DatePicker))
                    {
                        this.DatePicker_WebElements.CheckInDate_Input.Click();
                        this.GetWebDriver().GetCurrentDriver().WaitUntilElementIsVisible(this.DatePicker_WebElements.DatePicker);
                    }
                    if (checkInDate != this.GetCurrentCheckInDate())
                    {
                        this.MakeDateVisible(checkInDate);
                        this.SelectDate(checkInDate);
                    }
                    if (checkOutDate != this.GetCurrentCheckOutDate())
                    {
                        this.MakeDateVisible(checkOutDate);
                        this.SelectDate(checkOutDate);
                    }

                    break;

                case SearchFormIsIn.SearchResultsPage:

                    if (!GenericHelper.IsElementVisible(this.DatePicker_WebElements.DatePicker))
                    {
                        this.DatePicker_WebElements.CheckInDate_Input.Click();
                        this.GetWebDriver().GetCurrentDriver().WaitUntilElementIsVisible(this.DatePicker_WebElements.DatePicker);
                    }

                    if (checkInDate != this.GetCurrentCheckInDate())
                    {
                        this.MakeDateVisible(checkInDate);
                        this.SelectDate(checkInDate);
                    }

                    if (GenericHelper.IsElementVisible(this.DatePicker_WebElements.DatePicker))
                    {
                        this.DatePicker_WebElements.CheckInDate_Input.Click();
                    }

                    if (!GenericHelper.IsElementVisible(this.DatePicker_WebElements.DatePicker))
                    {
                        this.DatePicker_WebElements.CheckOutDate_Input.Click();
                        this.GetWebDriver().GetCurrentDriver().WaitUntilElementIsVisible(this.DatePicker_WebElements.DatePicker);
                    }

                    if (checkOutDate != this.GetCurrentCheckOutDate())
                    {
                        this.MakeDateVisible(checkOutDate);
                        this.SelectDate(checkOutDate);
                    }

                    if (GenericHelper.IsElementVisible(this.DatePicker_WebElements.DatePicker))
                    {
                        this.DatePicker_WebElements.CheckOutDate_Input.Click();
                    }

                    break;
            }
        }

    }
}