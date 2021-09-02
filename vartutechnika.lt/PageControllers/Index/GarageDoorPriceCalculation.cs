using ATFramework.BaseClass;
using ATFramework.Helpers;
using ATFramework.Libraries.WebDriver;
using Ganss.Excel;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using vartutechnika.lt.DataModels;

namespace vartutechnika.lt.Tests.PageObjects.HomePage
{
    /// <summary>
    /// Web elements of the garage door price calculation section in the home page
    /// </summary>
    public class GarageDoorPriceCalculation_PageController : ATFramework_PageControllerBase
    {

        public GarageDoorPriceCalculation_PageController(WebDriver webDriver) : base(webDriver)
        {

        }

        #region web elements
        [FindsBy(How = How.Id, Using = "doors_width")]
        [CacheLookup]
        public IWebElement DoorsWidth_Input { get; set; }

        [FindsBy(How = How.Id, Using = "doors_height")]
        [CacheLookup]

        public IWebElement DoorsHeight_Input { get; set; }

        [FindsBy(How = How.Id, Using = "automatika")]
        [CacheLookup]

        public IWebElement GateAutomation_Checkbox { get; set; }

        [FindsBy(How = How.Id, Using = "darbai")]
        [CacheLookup]

        public IWebElement GateInstallationWork_Checkbox { get; set; }

        [FindsBy(How = How.Id, Using = "calc_submit")]
        [CacheLookup]

        public IWebElement Calculation_Button { get; set; }

        [FindsBy(How = How.Id, Using = "calc_result")]
        public IWebElement CalculationResult_Textbox { get; set; }
        #endregion

        #region test steps
        public void CalculateGarageDoorPrice(GarageDoorPriceCalculation_DataModel testCaseData)
        {
                this.DoorsWidth_Input.SendKeys(testCaseData.DoorsWidth);
                this.DoorsHeight_Input.SendKeys(testCaseData.DoorsHeight);
                if (!this.GateAutomation_Checkbox.Selected && testCaseData.GateAutomation)
                {
                    this.GateAutomation_Checkbox.Click();
                }
                if (!this.GateInstallationWork_Checkbox.Selected && testCaseData.GateInstallationWork)
                {
                    this.GateInstallationWork_Checkbox.Click();
                }

                this.Calculation_Button.Click();
                this.GetWebDriver().GetCurrentDriver().WaitUntilElementIsVisible(this.CalculationResult_Textbox, 10);
                StringAssert.IsMatch(testCaseData.CalculationResultMessageRegex, this.CalculationResult_Textbox.Text.Trim());
                if (testCaseData.CalculatedPrice.Length > 0)
                {
                    StringAssert.Contains(testCaseData.CalculatedPrice, this.CalculationResult_Textbox.Text);
                }
        }

        public void ClearCalculatorForm()
        {
            this.DoorsWidth_Input.Clear();
            this.DoorsHeight_Input.Clear();
            if (this.GateAutomation_Checkbox.Selected)
            {
                this.GateAutomation_Checkbox.Click();
            }
            if (this.GateInstallationWork_Checkbox.Selected)
            {
                this.GateInstallationWork_Checkbox.Click();
            }
        }
        #endregion

    }
}