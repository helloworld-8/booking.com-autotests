using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using ATFramework.Config;
using System.ComponentModel;
using OpenQA.Selenium;

namespace ATFramework.Libraries.WebDriver
{
    public class WebDriver
    {
        private IWebDriver driver;

        public WebDriver()
        {
            this.SetDefaultDriver();
        }

        public WebDriver(Browsers browser)
        {
            this.SetDriver(browser);
        }

        private FirefoxDriver GetFirefoxDriver()
        {
            return new FirefoxDriver();
        }

        private ChromeDriver GetChromeDriver()
        {
            return new ChromeDriver();
        }

        public void SetDefaultDriver()
        {
            this.driver = this.GetChromeDriver();
        }

        public void SetDriver(Browsers browser)
        {
            switch (browser)
            {
                case Browsers.Firefox:
                    this.driver = GetFirefoxDriver();
                    break;
                case Browsers.Chrome:
                    this.driver = GetChromeDriver();
                    break;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        public IWebDriver GetCurrentDriver()
        {
            return this.driver;
        }

        public void Init()
        {
            this.GetCurrentDriver().Manage().Window.Maximize();
            this.GetCurrentDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public string Title
        {
            get { return this.GetCurrentDriver().Title; }
        }

        public void SetUrl(string url)
        {
            this.GetCurrentDriver().Url = url;
        }

        public void NavigateToUrl(string url)
        {
            this.GetCurrentDriver().Navigate().GoToUrl(url);
        }

        public void WebDriverQuit()
        {
            if (this.GetCurrentDriver() != null)
            {
                this.GetCurrentDriver().Close();
                this.GetCurrentDriver().Quit();
            }
        }

    }
}
