using ATFramework.BaseClass;

namespace booking.com.BaseClass
{
    public class TestBase : ATFramework_TestBase
    {
        protected override void OneTimeSetUp()
        {
            base.OneTimeSetUp();
            this.GetWebDriver().SetUrl(Routes.HomePage);
        }
    }
}
