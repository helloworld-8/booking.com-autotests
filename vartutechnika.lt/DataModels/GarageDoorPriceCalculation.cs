using Ganss.Excel;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vartutechnika.lt.DataModels
{
    public class GarageDoorPriceCalculation_DataModel
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
        /// <summary>
        /// Enter the regular expression of the result message to verify it
        /// </summary>
        public string CalculationResultMessageRegex { get; set; }
        /// <summary>
        /// Enter the properly calculated price to verify it
        /// </summary>
        public string CalculatedPrice { get; set; }


        public static IEnumerable<TestCaseData> Should_Calculate_Garage_Door_Price_Succesfully
        {
            get
            {
                var testCasesData = new ExcelMapper("C:/Users/Martynas/source/repos/ATFramework/vartutechnika.lt/Data/GarageDoorPriceCalculation/Should_Calculate_Garage_Door_Price_Succesfully.xlsx")
                    .Fetch<GarageDoorPriceCalculation_DataModel>();

                foreach (var testCaseData in testCasesData)
                {
                    yield return new TestCaseData(testCaseData)
                        .SetName($"{testCaseData.DoorsWidth}x{testCaseData.DoorsHeight}");
                }
            }
        }

    }




}
