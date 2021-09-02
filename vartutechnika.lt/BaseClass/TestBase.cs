using ATFramework.BaseClass;

namespace vartutechnika.lt.BaseClass
{
    public class TestBase : ATFramework_TestBase
    {
        /*public TestBase() : base(BrowserType.Firefox) {
        }*/

        protected override void OneTimeSetUp()
        {
            base.OneTimeSetUp();
            this.GetWebDriver().SetUrl("http://vartutechnika.lt/");
        }
    }
}
