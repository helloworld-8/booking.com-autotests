using NUnit.Framework;
using ATFramework.Config;
using ATFramework.Libraries.WebDriver;
using System;

namespace ATFramework.BaseClass
{
    public class ATFramework_WebElementsBase
    {
        private WebDriver webDriver;

        protected ATFramework_WebElementsBase(WebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        protected WebDriver GetWebDriver()
        {
            return this.webDriver;
        }
    }

}
