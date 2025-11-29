using NUnitPlaywright.Pages;

namespace NUnitPlaywright
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests : PageTest
    {
        [Test]
        public async Task SuccessfulLoginTest()
        {
            var loginPage = new LoginPage(Page); // Use the provided 'Page' property

            await loginPage.GotoAsync();
            await loginPage.RegisterAsync("John Smith", "ThisShouldBeEmail@yahoo.co.uk");
            await Expect(Page).ToHaveTitleAsync("Login Page");
            await loginPage.LoginAsync("RegisteredEmail@yahoo.co.uk", "Boxing2012@");
            await loginPage.LoginSuccessAsync();
            await Expect(Page.Locator("#errorMsgMail")).ToHaveTextAsync("Valid Email"); //or>  await Expect(Page.GetByText("Valid Email", new() { Exact = true })).ToBeVisibleAsync();
            await Expect(Page.GetByText("Valid Password")).ToBeVisibleAsync(); //or> await Expect(Page.Locator("#errorMsgPwd")).ToHaveTextAsync("Valid Password");
        }

        [Test]
        public async Task ShowHidePassword()
        {
            var loginPage = new LoginPage(Page); // Use the provided 'Page' property

            await loginPage.GotoAsync();
            await loginPage.RegisterAsync("John Smith", "ThisShouldBeEmail@yahoo.co.uk");
            await Expect(Page).ToHaveTitleAsync("Login Page");
            await loginPage.ShowHidePasswordAsync("RegisteredEmail@yahoo.co.uk", "Boxing2012@");

            await Expect(Page.Locator("#password")).ToHaveValueAsync("Boxing2012@");
            // 
        }
    }
}
