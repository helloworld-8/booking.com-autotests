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
    public class SearchFormComponents_DatePicker_WebElements : ATFramework_WebElementsBase
    {
        public SearchFormComponents_DatePicker_WebElements(WebDriver webDriver) : base(webDriver) {
            this.js = (IJavaScriptExecutor)webDriver.GetCurrentDriver();
        }

        private IJavaScriptExecutor js;

        // Global
        public IWebElement CheckInDate_Input => this.GetWebDriver().GetCurrentDriver().FindElement(By.CssSelector("div[data-mode=\"checkin\"]"));
        public IWebElement CheckOutDate_Input => this.GetWebDriver().GetCurrentDriver().FindElement(By.CssSelector("div[data-mode=\"checkout\"]"));
        public IWebElement DatePicker => this.GetWebDriver().GetCurrentDriver().FindElement(By.CssSelector("div[class=\"bui-calendar\"]"));
        public IReadOnlyCollection<IWebElement> DatePickerMonths => this.GetWebDriver().GetCurrentDriver().FindElements(By.CssSelector("div[data-bui-ref=\"calendar-month\"]"));
        public IWebElement ControlNext => this.GetWebDriver().GetCurrentDriver().FindElement(By.CssSelector("div[data-bui-ref=\"calendar-next\"]"));
        public IWebElement ControlPrev => this.GetWebDriver().GetCurrentDriver().FindElement(By.CssSelector("div[data-bui-ref=\"calendar-prev\"]"));
        public string CheckInYear => (string)js.ExecuteScript("return document.getElementsByName(\"checkin_year\")[0].getAttribute(\"value\")");
        public string CheckInMonth => (string)js.ExecuteScript("return document.getElementsByName(\"checkin_month\")[0].getAttribute(\"value\")");
        public IWebElement CheckInMonthDay => this.GetWebDriver().GetCurrentDriver().FindElement(By.Name("checkin_monthday"));
        public string CheckOutYear => (string)js.ExecuteScript("return document.getElementsByName(\"checkout_year\")[0].getAttribute(\"value\")");
        public string CheckOutMonth => (string)js.ExecuteScript("return document.getElementsByName(\"checkout_month\")[0].getAttribute(\"value\")");
        public IWebElement CheckOutMonthDay => this.GetWebDriver().GetCurrentDriver().FindElement(By.Name("checkout_monthday"));
        
        public string disabledDateClass = "bui-calendar__date--disabled";
        public IWebElement FindDateBy(string date)
        {
            return this.DatePicker.FindElement(By.CssSelector(String.Format("td[data-date=\"{0}\"]", date)));
        }
        public IWebElement FindFirstDate(IWebElement datePickerMonth)
        {
            return datePickerMonth.FindElement(By.CssSelector("td[data-date]"));
        }



        // Home page


        // Search results page

    }
}
