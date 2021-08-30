
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using AutoTests.BaseClasses;
using AutoTests.Config;
using AutoTests.Helpers;
using AutoTests.Settings;

namespace AutoTests.PageObjects
{
    /// <summary>
    /// Properties of the the garage door
    /// </summary>
    public class GarageDoorProperties
    {
        /// <summary>
        /// Enter the width of the garage door opening (mm)
        /// </summary>
        public string DoorsWidth { get; set; }
        /// <summary>
        /// Enter the height of the garage door opening (mm)
        /// </summary>
        public string DoorsHeight { get; set; }
        /// <summary>
        /// Select gate automation option?
        /// </summary>
        public bool GateAutomation { get; set; }
        /// <summary>
        /// Select gate installation work option?
        /// </summary>
        public bool GateInstallationWork { get; set; }

    }

    public class GarageDoorPriceProperties
    {
        /// <summary>
        /// Enter the regular expression of the result message to verify it
        /// </summary>
        public string CalculationResultMessageRegex { get; set; }
        
        /// <summary>
        /// Enter the properly calculated price to verify it. Leave empty string if no verifying is needed
        /// </summary>
        public string CalculatedPrice { get; set; }
    }

    /// <summary>
    /// Home page HTML elements
    /// </summary>
    public class HomePageObject : PageObjectBase
    {
        [FindsBy(How = How.Id, Using = "doors_width")]
        public IWebElement DoorsWidth_Input { get; set; }

        [FindsBy(How = How.Id, Using = "doors_height")]
        public IWebElement DoorsHeight_Input { get; set; }

        [FindsBy(How = How.Id, Using = "automatika")]
        public IWebElement GateAutomation_Checkbox { get; set; }

        [FindsBy(How = How.Id, Using = "darbai")]
        public IWebElement GateInstallationWork_Checkbox { get; set; }

        [FindsBy(How = How.Id, Using = "calc_submit")]
        public IWebElement Calculation_Button { get; set; }

        [FindsBy(How = How.Id, Using = "calc_result")]
        public IWebElement CalculationResult_Text { get; set; }
    }
}