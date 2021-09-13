using ATFramework.BaseClass;
using ATFramework.Helpers;
using ATFramework.Libraries.WebDriver;
using booking.com.WebElements.SearchFormComponents;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace booking.com.PageObjects.SearchFormComponents
{
    public class SearchFormComponents_GuestsTotal_PageObject : ATFramework_PageObjectBase
    {
        public SearchFormComponents_GuestsTotal_PageObject(WebDriver webDriver, SearchFormIsIn searchFormIsIn = SearchFormIsIn.HomePage) : base(webDriver)
        {
            this.searchFormIsIn = searchFormIsIn;
        }
        private SearchFormComponents_GuestsTotal_WebElements GuestsTotal_WebElements => new SearchFormComponents_GuestsTotal_WebElements(this.GetWebDriver());

        private SearchFormIsIn searchFormIsIn;

        public void SetAdultsTo(string adultsNumber)
        {
            this.SetNumberTo(adultsNumber, SetWhat.Adults);
        }

        public void SetChildrenTo(string childrenNumber, params string[] childrenAge)
        {
            this.SetNumberTo(childrenNumber, SetWhat.Children, childrenAge);
        }

        public void SetRoomsTo(string roomsNumber)
        {
            this.SetNumberTo(roomsNumber, SetWhat.Rooms);
        }

        private void SetNumberTo(string setToNumber, SetWhat setWhat, params string[] parameters)
        {
            switch (this.searchFormIsIn)
            {
                case SearchFormIsIn.HomePage:
                    this.SetNumberToInHomePage(setToNumber, setWhat, parameters);
                    break;

                case SearchFormIsIn.SearchResultsPage:
                    this.SetNumberToInSearchResultsPage(setToNumber, setWhat, parameters);
                    break;
            }
        }
        private void SetNumberToInSearchResultsPage(string setToNumber, SetWhat setWhat, params string[] parameters)
        {
            switch (setWhat)
            {
                case SetWhat.Adults:
                    new SelectElement(this.GuestsTotal_WebElements.SearchResultsPage_Adults_Select).SelectByValue(setToNumber);
                    break;
                case SetWhat.Children:
                    new SelectElement(this.GuestsTotal_WebElements.SearchResultsPage_Children_Select).SelectByValue(setToNumber);
                    for (int i = 0; i < parameters.Count(); i++)
                    {
                        var childrenAge = parameters[i];
                        var selectElement = new SelectElement(this.GuestsTotal_WebElements.SearchResultsPage_ChildrenAge_Selects.ElementAt(i));
                        selectElement.SelectByValue(childrenAge);
                    }
                    break;
                case SetWhat.Rooms:
                    new SelectElement(this.GuestsTotal_WebElements.SearchResultsPage_Rooms_Select).SelectByValue(setToNumber);
                    break;
            }
        }

        private void SetNumberToInHomePage(string setToNumber, SetWhat setWhat, params string[] parameters)
        {
            int setToNumberInt = int.Parse(setToNumber);
            int getCurrentNumber = 0;
            IWebElement getAddButton = null;
            IWebElement getSubtractButton = null;

            if (!GenericHelper.IsElementVisible(this.GuestsTotal_WebElements.HomePage_GuestsTotal_Container))
            {
                this.GuestsTotal_WebElements.HomePage_GuestsTotal_Input.Click();
                this.GetWebDriver().GetCurrentDriver().WaitUntilElementIsVisible(this.GuestsTotal_WebElements.HomePage_GuestsTotal_Container, 1);
            }

            switch (setWhat)
            {
                case SetWhat.Adults:
                    getCurrentNumber = (int)GetCurrentAdultsNumber();
                    getAddButton = this.GuestsTotal_WebElements.HomePage_Adults_AddButton;
                    getSubtractButton = this.GuestsTotal_WebElements.HomePage_Adults_SubtractButton;
                    break;
                case SetWhat.Children:
                    getCurrentNumber = (int)GetCurrentChildrenNumber();
                    getAddButton = this.GuestsTotal_WebElements.HomePage_Children_AddButton;
                    getSubtractButton = this.GuestsTotal_WebElements.HomePage_Children_SubtractButton;
                    break;
                case SetWhat.Rooms:
                    getCurrentNumber = (int)this.GetCurrentRoomsNumber();
                    getAddButton = this.GuestsTotal_WebElements.HomePage_Rooms_AddButton;
                    getSubtractButton = this.GuestsTotal_WebElements.HomePage_Rooms_SubtractButton;
                    break;
            }

            if (setToNumberInt > getCurrentNumber)
            {
                for (int i = getCurrentNumber; i < setToNumberInt; i++)
                {
                    getAddButton.Click();
                }
            }

            if (setToNumberInt < getCurrentNumber)
            {
                for (int i = getCurrentNumber; i > setToNumberInt; i--)
                {
                    getSubtractButton.Click();
                }
            }

            if (setWhat == SetWhat.Children && setToNumberInt != 0)
            {
                this.GetWebDriver().GetCurrentDriver().WaitUntilElementIsVisible(this.GuestsTotal_WebElements.HomePage_ChildrenAge_Container, 1);

                for (int i = 0; i < parameters.Count(); i++)
                {
                    var childrenAge = parameters[i];
                    var selectElement = new SelectElement(this.GuestsTotal_WebElements.HomePage_ChildrenAge_Selects.ElementAt(i));
                    selectElement.SelectByValue(childrenAge);
                }
            }

        }
        public int? GetCurrentAdultsNumber()
        {
            switch (this.searchFormIsIn)
            {
                case SearchFormIsIn.HomePage:
                    return int.Parse(this.GuestsTotal_WebElements.HomePage_Adults_Number.Text);
                case SearchFormIsIn.SearchResultsPage:
                    var selectElement = new SelectElement(this.GuestsTotal_WebElements.SearchResultsPage_Adults_Select);
                    return int.Parse(selectElement.SelectedOption.GetAttribute("value"));
            }
            return null;
        }
        public int? GetCurrentChildrenNumber()
        {
            switch (this.searchFormIsIn)
            {
                case SearchFormIsIn.HomePage:
                    return int.Parse(this.GuestsTotal_WebElements.HomePage_Children_Number.Text);
                case SearchFormIsIn.SearchResultsPage:
                    var selectElement = new SelectElement(this.GuestsTotal_WebElements.SearchResultsPage_Children_Select);
                    return int.Parse(selectElement.SelectedOption.GetAttribute("value"));
            }
            return null;
        }
        public int? GetCurrentRoomsNumber()
        {
            switch (this.searchFormIsIn)
            {
                case SearchFormIsIn.HomePage:
                    return int.Parse(this.GuestsTotal_WebElements.HomePage_Rooms_Number.Text);
                case SearchFormIsIn.SearchResultsPage:
                    var selectElement = new SelectElement(this.GuestsTotal_WebElements.SearchResultsPage_Rooms_Select);
                    return int.Parse(selectElement.SelectedOption.GetAttribute("value"));
            }
            return null;
        }
        public string[] GetCurrentChildrenAge()
        {
            IReadOnlyCollection<IWebElement> ChildrenAge_Selects = null;
            switch (this.searchFormIsIn)
            {
                case SearchFormIsIn.HomePage:
                    ChildrenAge_Selects = this.GuestsTotal_WebElements.HomePage_ChildrenAge_Selects;
                    break;
                case SearchFormIsIn.SearchResultsPage:
                    ChildrenAge_Selects = this.GuestsTotal_WebElements.SearchResultsPage_ChildrenAge_Selects;
                    break;
            }

            List<string> childrenAge = new List<string>();

            for (int i = 0; i < ChildrenAge_Selects.Count; i++)
            {
                var childrenAgeSelect = new SelectElement(ChildrenAge_Selects.ElementAt(i));
                childrenAge.Add(childrenAgeSelect.SelectedOption.GetAttribute("value"));
            }
            return childrenAge.ToArray();
        }
        public void ClearAdults()
        {
            this.SetAdultsTo("0");
        }
        public void ClearChildren()
        {
            this.SetChildrenTo("0");
        }
        public void ClearRooms()
        {
            this.SetRoomsTo("0");
        }

    }
}