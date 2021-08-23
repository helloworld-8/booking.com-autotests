using System;
using System.Configuration;
using AutoTests.Interfaces;

namespace AutoTests.Config
{
    public class AppConfigReader : IConfig
    {
        public BrowserType? GetBrowser()
        {
            string browser = ConfigurationManager.AppSettings.Get("Browser");
            try
            {
                return (BrowserType)Enum.Parse(typeof(BrowserType), browser);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string GetWebsite()
        {
            return ConfigurationManager.AppSettings.Get("Url");
        }
    }
}
