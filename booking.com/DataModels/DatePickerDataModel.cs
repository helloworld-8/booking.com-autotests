using Ganss.Excel;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATFramework.Helpers;

namespace booking.com.DataModels
{
    public class DatePicker_DataModel
    {
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
        public string SingleDate { get; set; }

        public static IEnumerable<TestCaseData> Should_Select_CheckInOut_Dates_Succesfully
        {
            get
            {
                var testCasesData = new ExcelMapper(ExcelHelper.GetDataFilePath("SearchForm\\DatePicker\\Should_Select_CheckInOut_Dates_Succesfully.xlsx"))
                    .Fetch<DatePicker_DataModel>();

                foreach (var testCaseData in testCasesData)
                {
                    yield return new TestCaseData(testCaseData)
                        .SetName($"Should_Select_CheckInOut_Dates_Succesfully({testCaseData.CheckInDate}-{testCaseData.CheckOutDate})");
                }
            }
        }

        public static IEnumerable<TestCaseData> This_Date_Should_Not_Be_Visible_In_Date_Picker
        {
            get
            {
                var testCasesData = new ExcelMapper(ExcelHelper.GetDataFilePath("SearchForm\\DatePicker\\This_Date_Should_Not_Be_Visible_In_Date_Picker.xlsx"))
                    .Fetch<DatePicker_DataModel>();

                foreach (var testCaseData in testCasesData)
                {
                    yield return new TestCaseData(testCaseData)
                        .SetName($"This_Date_Should_Not_Be_Visible_In_Date_Picker({testCaseData.SingleDate}");
                }
            }
        }

    }




}
