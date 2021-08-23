using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AutoTests.PageObjects;
using AutoTests.BaseClasses;
using AutoTests.Config;
using AutoTests.Settings;

namespace AutoTests.TestScripts
{

    public class GarageDoorPriceCalculation : TestBase
    {

        HomePageObject home;

        [Test]
        public void Should_Calculate_Garage_Door_Price()
        {
            this.home = new HomePageObject();

            string calculationSuccessMessageRegex = @"Vartų kaina dabar - TIK ((\d+\.?\d*)|(\.\d+))€! Tai yra preliminari kaina Jūsų vartų pagal pateiktus išmatavimus\. Dėl tikslios kainos prašome susisiekti telefonu\.";
            
            home.CalculateGarageDoorPrice("2000", "2000", true, false, calculationSuccessMessageRegex, "665.98");
            home.ClearCalculatorForm();

            home.CalculateGarageDoorPrice("2000", "2500", true, false, calculationSuccessMessageRegex, "781.52");
            home.ClearCalculatorForm();
        }

        [Test]
        public void Should_Throw_An_Error()
        {
            string calculationSuccessMessageRegex = @"Vartų kaina dabar - TIK ((\d+\.?\d*)|(\.\d+))€! Tai yra preliminari kaina Jūsų vartų pagal pateiktus išmatavimus\. Dėl tikslios kainos prašome susisiekti telefonu\.";

            home.CalculateGarageDoorPrice("20000", "2000", true, false, calculationSuccessMessageRegex, "665.98");
            home.ClearCalculatorForm();
        }

    }
}