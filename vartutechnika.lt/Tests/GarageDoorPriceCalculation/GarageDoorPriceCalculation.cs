using NUnit.Framework;
using vartutechnika.lt.Tests.PageObjects.HomePage;
using vartutechnika.lt.BaseClass;
using vartutechnika.lt.DataModels;

namespace vartutechnika.lt.Tests.GarageDoorPriceCalculation
{

  
    public class GarageDoorPriceCalculation_Tests : TestBase
    {
        public GarageDoorPriceCalculation_Tests() : base()
        {
        }

        private GarageDoorPriceCalculation_PageObject GetPageController()
        {
            return new GarageDoorPriceCalculation_PageObject(this.GetWebDriver());
        }

        [TestCaseSource(typeof(GarageDoorPriceCalculation_DataModel), "Should_Calculate_Garage_Door_Price_Succesfully")]
        public void Should_Calculate_Garage_Door_Price_Succesfully(GarageDoorPriceCalculation_DataModel testCaseData)
        {
            GetPageController().CalculateGarageDoorPrice(testCaseData);
            GetPageController().ClearCalculatorForm();
        }

        //[TestCase]
        public void Should_Throw_Message_That_Dimensions_Do_Not_Meet_Standards()
        {
            //var calculationResultMessageRegex = @"Dėmesio! Jūsų pateikti matmenys neatitinka standartinių vartų\. Norėdami sužinoti kainą pagal šiuos matmenis \(((\d+\.?\d*)|(\.\d+))mm X ((\d+\.?\d*)|(\.\d+))mm\) susisiekite telefonu";
        }

        //[TestCase]
        public void Should_Throw_Error()
        {
            //var calculationResultMessageRegex = @"Dėmesio! Jūsų pateikti matmenys neatitinka standartinių vartų\. Norėdami sužinoti kainą pagal šiuos matmenis \(((\d+\.?\d*)|(\.\d+))mm X ((\d+\.?\d*)|(\.\d+))mm\) susisiekite telefonu";
        }

    }
}