using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using AutoTests.BaseClasses;
using AutoTests.Config;
using AutoTests.Helpers;
using AutoTests.Settings;

namespace AutoTests.PageObjects
{
    public class HomePageObject : PageObjectBase
    {

        [FindsBy(How = How.Id, Using = "doors_width")]
        private readonly IWebElement doorsWidth;

        [FindsBy(How = How.Id, Using = "doors_height")]
        private readonly IWebElement doorsHeight;

        [FindsBy(How = How.Id, Using = "automatika")]
        private readonly IWebElement gateAutomation;

        [FindsBy(How = How.Id, Using = "darbai")]
        private readonly IWebElement gateInstallationWork;

        [FindsBy(How = How.Id, Using = "calc_submit")]
        private readonly IWebElement calculationButton;

        [FindsBy(How = How.Id, Using = "calc_result")]
        private readonly IWebElement calculationResultMessage;

        /// <summary>
        /// Calculate the price of a garage door
        /// </summary>
        /// <param name="doorsWidthValue">Enter the width of the garage door opening (mm)</param>
        /// <param name="doorsHeightValue">Enter the height of the garage door opening (mm)</param>
        /// <param name="clickOnGateAutomation">Select gate automation option?</param>
        /// <param name="clickOnGateInstallationWork">Select gate installation work option?</param>
        /// <param name="calculationResultMessageRegex">Enter the regular expression calculation result message to verify it</param>
        /// <param name="calculatedPrice">Enter the properly calculated price to verify it</param>
        /// 
        public void CalculateGarageDoorPrice(
            string doorsWidthValue,
            string doorsHeightValue,
            bool clickOnGateAutomation,
            bool clickOnGateInstallationWork,
            string calculationResultMessageRegex,
            string calculatedPrice
        )
        {
            doorsWidth.SendKeys(doorsWidthValue);
            doorsHeight.SendKeys(doorsHeightValue);
            if(!gateAutomation.Selected && clickOnGateAutomation)
            {
                gateAutomation.Click();
            }
            if (!gateInstallationWork.Selected && clickOnGateInstallationWork)
            {
                gateInstallationWork.Click();
            }
            calculationButton.Click();
            ObjectRepository.Driver.WaitUntilElementIsVisible(calculationResultMessage, 20);
            StringAssert.IsMatch(calculationResultMessageRegex,calculationResultMessage.Text.Trim());
            StringAssert.Contains(calculatedPrice, calculationResultMessage.Text);
        }

        public void ClearCalculatorForm()
        {
            doorsWidth.Clear();
            doorsHeight.Clear();
            if (gateAutomation.Selected)
            {
                gateAutomation.Click();
            }
            if (gateInstallationWork.Selected)
            {
                gateInstallationWork.Click();
            }
        }

    }
}