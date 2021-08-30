using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AutoTests.PageObjects;
using AutoTests.BaseClasses;
using AutoTests.Config;
using AutoTests.Settings;
using AutoTests.Libraries.TestRunner;
using AutoTests.Libraries.ExcelReader;

using ExcelDataReader;
using System.IO;
using System.Reflection;
using System.Data;
using System.Collections.Generic;
using System;
using System.Collections;

namespace AutoTests.Tests.GarageDoorPriceCalculation
{
    public class GarageDoorPriceCalculationTests : TestBase
    {
        /// <summary>
        /// Load garage door price calculation test steps
        /// </summary>
        private TestSteps TestSteps => new TestSteps();

        /// <summary>
        /// Valid test cases of garage door price calculation
        /// </summary>
        [TestCaseSource(typeof(Should_Calculate_Garage_Door_Price_Succesfully))]
        public void Should_Calculate_Garage_Door_Price_Succesfully(
            string doorsWidth,
            string doorsHeight,
            bool checkGateAutomation,
            bool checkGateInstallationWork,
            string calculationResultMessageRegex,
            string calculatedPrice
        )
        {
            TestCase testCase = new TestCase();
            testCase.RunTestSteps(TestSteps.EnterGarageDoorProperties, new GarageDoorProperties()
            {
                DoorsWidth = doorsWidth,
                DoorsHeight = doorsHeight,
                GateAutomation = checkGateAutomation,
                GateInstallationWork = checkGateInstallationWork
            });
            testCase.RunTestSteps(TestSteps.CalculateGarageDoorPrice, new GarageDoorPriceProperties()
            {
                CalculationResultMessageRegex = calculationResultMessageRegex,
                CalculatedPrice = calculatedPrice
            });
            testCase.RunTestSteps(TestSteps.ClearCalculatorForm);
        }

        /// <summary>
        /// Test cases of garage door price calculation that does not conform to standard dimensions
        /// </summary>
        [TestCase]
        public void Should_Throw_Message_That_Dimensions_Do_Not_Meet_Standards()
        {
            //var calculationResultMessageRegex = @"Dėmesio! Jūsų pateikti matmenys neatitinka standartinių vartų\. Norėdami sužinoti kainą pagal šiuos matmenis \(((\d+\.?\d*)|(\.\d+))mm X ((\d+\.?\d*)|(\.\d+))mm\) susisiekite telefonu";
        }

        /// <summary>
        /// Invalid test cases of garage door price calculation
        /// </summary>
        [TestCase]
        public void Should_Throw_Error()
        {
            //var calculationResultMessageRegex = @"Dėmesio! Jūsų pateikti matmenys neatitinka standartinių vartų\. Norėdami sužinoti kainą pagal šiuos matmenis \(((\d+\.?\d*)|(\.\d+))mm X ((\d+\.?\d*)|(\.\d+))mm\) susisiekite telefonu";
        }

    }
}