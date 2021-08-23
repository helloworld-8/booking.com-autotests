using OpenQA.Selenium;
using AutoTests.Interfaces;

namespace AutoTests.Settings
{
    public class ObjectRepository
    {
        public static IConfig Config { get; set; }
        public static IWebDriver Driver { get; set; }
    }
}
