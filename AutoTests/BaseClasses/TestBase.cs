using NUnit.Framework;
using AutoTests.Settings;

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
