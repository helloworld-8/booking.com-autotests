using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Ganss.Excel;
using System.IO;

namespace ATFramework.Helpers
{
    public static class ExcelHelper
    {
        public static string GetDataFilePath(string path)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, String.Format(@"Data\{0}", path));
        }

    }
}
