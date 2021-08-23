using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoTests.Config;

namespace AutoTests.Interfaces
{
    public interface IConfig
    {
        BrowserType? GetBrowser();
        string GetWebsite();
    }
}