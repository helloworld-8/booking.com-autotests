using NUnit.Framework;
using ATFramework.Config;
using ATFramework.Libraries.WebDriver;
using System;

namespace ATFramework.BaseClass
{
    [TestFixture]
    public class ATFramework_TestBase
    {
        private WebDriver webDriver;

        protected ATFramework_TestBase()
        {
            this.webDriver = new WebDriver();
        }

        protected ATFramework_TestBase(Browsers browser)
        {
            this.webDriver = new WebDriver(browser);
        }

        protected WebDriver GetWebDriver()
        {
            return this.webDriver;
        }

        [OneTimeSetUp]
        protected virtual void OneTimeSetUp()
        {
            this.GetWebDriver().Init();
        }

        [SetUp]
        protected void SetUp()
        {
        }

        [OneTimeTearDown]
        protected void OneTimeTearDown()
        {
            this.GetWebDriver().WebDriverQuit();
        }
    }

}
