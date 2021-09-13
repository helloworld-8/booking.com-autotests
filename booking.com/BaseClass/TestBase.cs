using ATFramework.BaseClass;
using System;
using OpenQA.Selenium;
using ATFramework.Helpers;

namespace booking.com.BaseClass
{
    public class TestBase : ATFramework_TestBase
    {
        protected override void OneTimeSetUp()
        {
            base.OneTimeSetUp();
            this.GetWebDriver().SetUrl(Routes.HomePage);

            // Accept cookies
            IWebElement cookieAcceptButton = this.GetWebDriver().GetCurrentDriver().FindElement(By.Id("onetrust-accept-btn-handler"));
            this.GetWebDriver().GetCurrentDriver().WaitUntilElementIsVisible(cookieAcceptButton);
            cookieAcceptButton.Click();
        }
    }
}
