using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using AutoTests.Config;
using AutoTests.Settings;

namespace AutoTests.BaseClasses
{
    public class WebDriverBase
    {
        private static FirefoxDriver GetFirefoxDriver()
        {
            FirefoxDriver driver = new FirefoxDriver();
            return driver;
        }

        private static ChromeDriver GetChromeDriver()
        {
            ChromeDriver driver = new ChromeDriver();
            return driver;
        }

        public void InitDriver()
        {
            ObjectRepository.Config = new AppConfigReader();
            switch (ObjectRepository.Config.GetBrowser())
            {
                case BrowserType.Firefox:
                    ObjectRepository.Driver = GetFirefoxDriver();
                    break;
                case BrowserType.Chrome:
                    ObjectRepository.Driver = GetChromeDriver();
                    break;
                default:
                    ObjectRepository.Driver = GetChromeDriver();
                    break;
            }

            ObjectRepository.Driver.Manage().Window.Maximize();
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public string Title
        {
            get { return ObjectRepository.Driver.Title; }
        }

        public void SetUrl(string url)
        {
            ObjectRepository.Driver.Url = url;
        }

        public void NavigateToUrl(string url)
        {
            ObjectRepository.Driver.Navigate().GoToUrl(url);
        }

        public void DriverQuit()
        {
            if (ObjectRepository.Driver != null)
            {
                ObjectRepository.Driver.Close();
                ObjectRepository.Driver.Quit();
            }
        }

    }
}
