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
        [Test]
        public void Should_Calculate_Garage_Door_Price()
        {
            HomePageObject home = new HomePageObject();

            string calculationResultMessageRegex = @"Vartų kaina dabar - TIK ((\d+\.?\d*)|(\.\d+))€! Tai yra preliminari kaina Jūsų vartų pagal pateiktus išmatavimus\. Dėl tikslios kainos prašome susisiekti telefonu\.";
            home.CalculateGarageDoorPrice("2000", "2000", true, false, calculationResultMessageRegex, "665.98");

            //home.ClearCalculatorForm();

           // home.CalculateGarageDoorPrice("2500", "2500", true, true);
           // home.ClearCalculatorForm();
        }

    }
}