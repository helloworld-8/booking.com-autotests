using AutoTests.PageObjects;
using NUnit.Framework;
using AutoTests.Settings;
using AutoTests.Helpers;

namespace AutoTests.Tests.GarageDoorPriceCalculation
{
    public class TestSteps
    {
        HomePageObject Home => new HomePageObject();
        public void EnterGarageDoorProperties(GarageDoorProperties properties)
        {
            Home.DoorsWidth_Input.SendKeys(properties.DoorsWidth);
            Home.DoorsHeight_Input.SendKeys(properties.DoorsHeight);
            if (!Home.GateAutomation_Checkbox.Selected && properties.GateAutomation)
            {
                Home.GateAutomation_Checkbox.Click();
            }
            if (!Home.GateInstallationWork_Checkbox.Selected && properties.GateInstallationWork)
            {
                Home.GateInstallationWork_Checkbox.Click();
            }
        }

        public void CalculateGarageDoorPrice(GarageDoorPriceProperties properties)
        {
            Home.Calculation_Button.Click();
            ObjectRepository.Driver.WaitUntilElementIsVisible(Home.CalculationResult_Text, 10);
            StringAssert.IsMatch(properties.CalculationResultMessageRegex, Home.CalculationResult_Text.Text.Trim());
            if (properties.CalculatedPrice.Length > 0)
            {
                StringAssert.Contains(properties.CalculatedPrice, Home.CalculationResult_Text.Text);
            }
        }

        public void ClearCalculatorForm()
        {
            Home.DoorsWidth_Input.Clear();
            Home.DoorsHeight_Input.Clear();
            if (Home.GateAutomation_Checkbox.Selected)
            {
                Home.GateAutomation_Checkbox.Click();
            }
            if (Home.GateInstallationWork_Checkbox.Selected)
            {
                Home.GateInstallationWork_Checkbox.Click();
            }
        }
    }
}
