using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using AutoTests.Settings;

namespace AutoTests.BaseClasses
{
    public class PageObjectBase
    {
        public PageObjectBase()
        {
            PageFactory.InitElements(ObjectRepository.Driver, this);
        }

    }
}
