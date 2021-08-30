using NUnit.Framework;
using AutoTests.Settings;
using AutoTests.TestRunner;

namespace AutoTests.BaseClasses
{
    [TestFixture]
    public abstract class TestBase : WebDriverBase
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {

            this.InitDriver();
            this.SetUrl(ObjectRepository.Config.GetWebsite());
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            this.DriverQuit();
        }
    }

}
