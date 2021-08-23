using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using AutoTests.Settings;

namespace AutoTests.Helpers
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
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                return wait.Until(ElementIsVisible(element)); //Wait finishes when return is a non-null value or 'true'
            }
            catch (NoSuchElementException ex)
            {
                //MethodLogger.OutputLog($"Element: {element} was not found on current page.");
                //MethodLogger.OutputLog(ex);
                return null;
            }
            catch (WebDriverTimeoutException)
            {
                //MethodLogger.OutputLog($"Timed out Looking for Clickable Element; {element}: Waited for {timeOutInSeconds} seconds.");
                return null;
            }
        }




    }
}
