using ATFramework.Libraries.WebDriver;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ATFramework.BaseClass
{
    public class ATFramework_PageObjectBase
    {
        private WebDriver webDriver;

        protected ATFramework_PageObjectBase(WebDriver webDriver)
        {
            this.webDriver = webDriver;
            PageFactory.InitElements(webDriver.GetCurrentDriver(), this);

        }
        protected WebDriver GetWebDriver()
        {
            return this.webDriver;
        }
    }
}
