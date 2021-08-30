using AutoTests.Libraries.ExcelReader;
using System.Collections;
using System.Data;
using System.IO;
using System.Reflection;

namespace AutoTests.Tests.GarageDoorPriceCalculation
{
    class Should_Calculate_Garage_Door_Price_Succesfully : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Tests\GarageDoorPriceCalculation\TestCaseData\Should_Calculate_Garage_Door_Price_Succesfully.xlsx");
            ExcelReader testCaseData = new ExcelReader(filePath);
            DataSet dataset = testCaseData.GetData();
            foreach (DataRow row in dataset.Tables["Sheet1"].Rows)
            {
                yield return row.ItemArray;
            }
        }
    }
}
