using ATFramework.Libraries.WebDriver;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ATFramework.BaseClass
{
    public class ATFramework_PageControllerBase
    {
        private WebDriver webDriver;

        protected ATFramework_PageControllerBase(WebDriver webDriver)
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
