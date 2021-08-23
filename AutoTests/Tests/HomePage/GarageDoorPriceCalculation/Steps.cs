using AutoTests.Libraries;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace AutoTests.Tests.GarageDoorPriceCalculation
{
    public class GarageDoorPriceCalculationTestSteps
    {
        private BaseTest _test = new BaseTest();
        public void Should_Open_Website()
        {
            _test.StartBrowser();
            _test.SetUrl("http://vartutechnika.lt");
        }

        public void Should_Allow_Enter_Doors_Width(string doorsWidthValue)
        {
            IWebElement doorsWidthElement = _test.Driver.FindElement(By.Id("doors_width"));
            doorsWidthElement.Clear();
            doorsWidthElement.SendKeys(doorsWidthValue);
        }

        public void Should_Allow_Enter_Doors_Height(string doorsHeightValue)
        {
            IWebElement doorsHeightElement = _test.Driver.FindElement(By.Id("doors_height"));
            doorsHeightElement.Clear();
            doorsHeightElement.SendKeys(doorsHeightValue);

        }
        public void Should_Allow_Check_Gate_Automation()
        {
            IWebElement gateAutomationElement = _test.Driver.FindElement(By.Id("automatika"));
            gateAutomationElement.Click();
        }

        public void Should_Allow_Click_Calculation_Button()
        {
            IWebElement calculationButtonElement = _test.Driver.FindElement(By.Id("calc_submit"));
            calculationButtonElement.Click();
        }

        public void Should_Appear_Success_Message_After_Clicking_Calculation_Button()
        {
            var calculationResultElement = _test.Driver.FindElement(By.Id("calc_result"), 10, displayed: true);
            StringAssert.IsMatch(@"Vartų kaina dabar - TIK ((\d+\.?\d*)|(\.\d+))€! Tai yra preliminari kaina Jūsų vartų pagal pateiktus išmatavimus\. Dėl tikslios kainos prašome susisiekti telefonu\.", calculationResultElement.Text.Trim());
        }

        public void Should_Appear_Properly_Calculated_Price_In_Success_Message(string properlyPrice)
        {
            var calculationResultElement = _test.Driver.FindElement(By.Id("calc_result"));
            StringAssert.Contains(properlyPrice, calculationResultElement.Text);
        }
    }
}



