using ATFramework.BaseClass;
using ATFramework.Libraries.WebDriver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booking.com.WebElements.SearchFormComponents
{
    public class SearchFormComponents_GuestsTotal_WebElements : ATFramework_WebElementsBase
    {
        public SearchFormComponents_GuestsTotal_WebElements(WebDriver webDriver) : base(webDriver) { }

        // Global

        // Home page
        public IWebElement HomePage_GuestsTotal_Input => this.GetWebDriver().GetCurrentDriver().FindElement(By.Id("xp__guests__toggle"));
        public IWebElement HomePage_GuestsTotal_Container => this.GetWebDriver().GetCurrentDriver().FindElement(By.Id("xp__guests__inputs-container"));
        public IWebElement HomePage_Adults_Row => HomePage_GuestsTotal_Container.FindElement(By.CssSelector(".sb-group__field.sb-group__field-adults"));
        public IWebElement HomePage_Adults_Number => HomePage_Adults_Row.FindElement(By.CssSelector("span[data-bui-ref=\"input-stepper-value\"]"));
        public IWebElement HomePage_Adults_AddButton => HomePage_Adults_Row.FindElement(By.CssSelector("button[data-bui-ref=\"input-stepper-add-button\"]"));
        public IWebElement HomePage_Adults_SubtractButton => HomePage_Adults_Row.FindElement(By.CssSelector("button[data-bui-ref=\"input-stepper-subtract-button\"]"));

        public IWebElement HomePage_Children_Row => HomePage_GuestsTotal_Container.FindElement(By.CssSelector(".sb-group__field.sb-group-children"));
        public IWebElement HomePage_Children_Number => HomePage_Children_Row.FindElement(By.CssSelector("span[data-bui-ref=\"input-stepper-value\"]"));
        public IWebElement HomePage_Children_AddButton => HomePage_Children_Row.FindElement(By.CssSelector("button[data-bui-ref=\"input-stepper-add-button\"]"));
        public IWebElement HomePage_Children_SubtractButton => HomePage_Children_Row.FindElement(By.CssSelector("button[data-bui-ref=\"input-stepper-subtract-button\"]"));
        public IWebElement HomePage_ChildrenAge_Container => this.GetWebDriver().GetCurrentDriver().FindElement(By.CssSelector(".sb-group__children__field"));
        public IReadOnlyCollection<IWebElement> HomePage_ChildrenAge_Selects => HomePage_ChildrenAge_Container.FindElements(By.TagName("select"));

        public IWebElement HomePage_Rooms_Row => HomePage_GuestsTotal_Container.FindElement(By.CssSelector(".sb-group__field.sb-group__field-rooms"));
        public IWebElement HomePage_Rooms_Number => HomePage_Rooms_Row.FindElement(By.CssSelector("span[data-bui-ref=\"input-stepper-value\"]"));
        public IWebElement HomePage_Rooms_AddButton => HomePage_Rooms_Row.FindElement(By.CssSelector("button[data-bui-ref=\"input-stepper-add-button\"]"));
        public IWebElement HomePage_Rooms_SubtractButton => HomePage_Rooms_Row.FindElement(By.CssSelector("button[data-bui-ref=\"input-stepper-subtract-button\"]"));

        // Search results page
        public IWebElement SearchResultsPage_GuestsTotal_Row => this.GetWebDriver().GetCurrentDriver().FindElement(By.CssSelector("div[data-component=\"search/group/group\"]"));
        public IWebElement SearchResultsPage_Adults_Row => SearchResultsPage_GuestsTotal_Row.FindElement(By.CssSelector(".sb-group__field.sb-group__field-adults"));
        public IWebElement SearchResultsPage_Adults_Select => SearchResultsPage_Adults_Row.FindElement(By.Id("group_adults"));
        public IWebElement SearchResultsPage_Rooms_Row => SearchResultsPage_GuestsTotal_Row.FindElement(By.CssSelector(".sb-group__field.sb-group__field-rooms"));
        public IWebElement SearchResultsPage_Rooms_Select => SearchResultsPage_Rooms_Row.FindElement(By.Id("no_rooms"));
        
        public IWebElement SearchResultsPage_Children_Row => SearchResultsPage_GuestsTotal_Row.FindElement(By.CssSelector(".sb-group__field.sb-group-children"));
        public IWebElement SearchResultsPage_Children_Select => SearchResultsPage_Children_Row.FindElement(By.Id("group_children"));
        public IWebElement SearchResultsPage_ChildrenAge_Container => this.GetWebDriver().GetCurrentDriver().FindElement(By.CssSelector(".sb-group__children__field"));
        public IReadOnlyCollection<IWebElement> SearchResultsPage_ChildrenAge_Selects => SearchResultsPage_ChildrenAge_Container.FindElements(By.TagName("select"));
    }
}
