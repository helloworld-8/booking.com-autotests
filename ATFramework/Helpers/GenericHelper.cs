using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ATFramework.Helpers
{
    public static class GenericHelper
    {
        /// <summary>
        /// An expectation for checking that an element is present on the DOM of a page
        /// and visible. Visibility means that the element is not only displayed but
        /// also has a height and width that is greater than 0.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns>The <see cref="T:OpenQA.Selenium.IWebElement" /> once it is located and visible.</returns>
        public static Func<IWebDriver, IWebElement> ElementIsVisible(IWebElement element) => driver =>
        {
            try
            {
                return ElementIfVisible(element);
            }
            catch (StaleElementReferenceException)
            {
                return null;
            }
        };

        private static IWebElement ElementIfVisible(IWebElement element)
        {
            if (!element.Displayed)
                return null;
            return element;
        }

        public static IWebElement WaitUntilElementIsVisible(this IWebDriver driver, IWebElement element, int timeOutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            return wait.Until(ElementIsVisible(element)); //Wait finishes when return is a non-null value or 'true'
        }

        public static bool IsElementVisible(IWebElement element)
        {
            return element.Displayed && element.Enabled;
        }

        public static bool HasClass(this IWebElement element, string className)
        {
            return element.GetAttribute("class").Split(' ').Contains(className);
        }

        public static bool WaitUntilUrlContains(this IWebDriver driver, string urlFragment, int timeOutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            return wait.Until(ExpectedConditions.UrlContains(urlFragment));
        }

        public static Boolean ascendingCheck(List<int> data)
        {
            for (int i = 0; i < data.Count - 1; i++)
            {
                if (data[i] > data[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

    }
}
