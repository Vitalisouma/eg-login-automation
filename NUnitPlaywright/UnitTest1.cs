using Microsoft.Playwright;
using NUnitPlaywright.Pages;

namespace NUnitPlaywright
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests : PageTest
    {
        
        public async Task RegisterAccount()
        {
            var loginPage = new LoginPage(Page); // Use the provided 'Page' property

            await loginPage.GotoAsync();
            await loginPage.RegisterAsync("John Smith", "Register@yahoo.co.uk");
            await Expect(Page).ToHaveTitleAsync("Login Page");
        }


        [Test]
        public async Task SuccessfulLoginTest()
        {
            var loginPage = new LoginPage(Page); // Use the provided 'Page' property

            //await loginPage.GotoAsync();
            //await loginPage.RegisterAsync("John Smith", "ThisShouldBeEmail@yahoo.co.uk");
            //await Expect(Page).ToHaveTitleAsync("Login Page");

            await RegisterAccount();

            await loginPage.LoginAsync("RegisteredEmail@yahoo.co.uk", "Boxing2012@");
            await loginPage.LoginSuccessAsync();
            await Expect(Page.Locator("#errorMsgMail")).ToHaveTextAsync("Valid Email"); //or>  await Expect(Page.GetByText("Valid Email", new() { Exact = true })).ToBeVisibleAsync();
            await Expect(Page.GetByText("Valid Password")).ToBeVisibleAsync(); //or> await Expect(Page.Locator("#errorMsgPwd")).ToHaveTextAsync("Valid Password");
        }

        [Test]
        public async Task ShowHidePassword()
        {
            var loginPage = new LoginPage(Page); // Use the provided 'Page' property

            //await loginPage.GotoAsync();
            //await loginPage.RegisterAsync("John Smith", "ThisShouldBeEmail@yahoo.co.uk");
            //await Expect(Page).ToHaveTitleAsync("Login Page");

            await RegisterAccount();
            await loginPage.ShowHidePasswordAsync("RegisteredEmail@yahoo.co.uk", "Boxing2012@");
            await Expect(Page.Locator("#password")).ToHaveValueAsync("Boxing2012@");
            
        }

        [Test]
        public async Task InvalidLoginIncompleteEmail()
        {
            var loginPage = new LoginPage(Page); // Use the provided 'Page' property

            await RegisterAccount();
            await loginPage.LoginAsync("incomplete@", "Boxing2020@"); //Rule 3 for emails: After @, must have one or more alphanumeric segments separated by dots or hyphens
            await Expect(Page.Locator("#errorMsgMail")).ToHaveTextAsync("Invalid Email"); // Error message present but spelt as "Valid Password"
            await Expect(Page.Locator("#errorMsgPwd")).ToBeHiddenAsync();
            // Defect: email beginning with number is allowed.  3vitalis@yahoo.co.uk  -- add test

        }

        [Test]
        public async Task InvalidLoginEmailShouldNotAllowNumber()
        {
            var loginPage = new LoginPage(Page); // Use the provided 'Page' property

            await RegisterAccount();
            await loginPage.LoginAsync("3vitalis@yahoo.co.uk", "Boxing2020@"); //Rule 1 Starts with one or more alphabetic characters (a–z, A–Z).
            await Expect(Page.Locator("#errorMsgMail")).ToHaveTextAsync("Invalid Email"); // Error message present but spelt as "Valid Password"
            await Expect(Page.Locator("#errorMsgPwd")).ToBeHiddenAsync();

        }

        [Test]
        public async Task InvalidLoginEmailHasNoDot()
        {
            var loginPage = new LoginPage(Page); // Use the provided 'Page' property

            await RegisterAccount();
            await loginPage.LoginAsync("nodotbeforetld@gmailcom", "Boxing2020@"); //Rule 4 Must include a dot before the TLD.
            await Expect(Page.Locator("#errorMsgMail")).ToHaveTextAsync("Invalid Email"); // Error message present but spelt as "Valid Password"
            await Expect(Page.Locator("#errorMsgPwd")).ToBeHiddenAsync();

        }

        [Test]
        public async Task InvalidLogin7CharacterPassword()
        {
            var loginPage = new LoginPage(Page); // Use the provided 'Page' property

            await RegisterAccount();
            await loginPage.LoginAsync("vitalis.ouma@yahoo.co.uk", "Box2020"); // Password is less than 8 characters
            await Expect(Page.Locator("#errorMsgMail")).ToHaveTextAsync("Valid Email");  // failing because of spelling error. Vaild instead of valid
            await Expect(Page.Locator("#errorMsgPwd")).ToHaveTextAsync("Invalid Password");

        }

        [Test]
        public async Task InvalidLoginPasswordHasNoUppercaseLetter()
        {
            var loginPage = new LoginPage(Page); // Use the provided 'Page' property

            await RegisterAccount();
            await loginPage.LoginAsync("vitalis.ouma@yahoo.co.uk", "boxing2020@"); // Password has no uppercase letter
            //await Expect(Page.Locator("#errorMsgMail")).ToBeHiddenAsync();  // Error message shows up as "Valid Password"
            await Expect(Page.Locator("#errorMsgPwd")).ToHaveTextAsync("Invalid Password"); // No error message for password

        }

        [Test]
        public async Task InvalidLoginPasswordHasNoDigit()
        {
            var loginPage = new LoginPage(Page); // Use the provided 'Page' property

            await RegisterAccount();
            await loginPage.LoginAsync("vitalis.ouma@gmail.com", "boxingTennis"); // Password has no uppercase letter
            await Expect(Page.Locator("#errorMsgMail")).ToBeHiddenAsync();  // Error message shows up as "Valid Password"
            await Expect(Page.Locator("#errorMsgPwd")).ToHaveValueAsync("Invalid Password"); // No error message for password

        }

        [Test]
        public async Task InvalidLoginEmptyEmailandPassword()
        {
            var loginPage = new LoginPage(Page); // Use the provided 'Page' property

            await RegisterAccount();
            await loginPage.LoginAsync("", "");
            await Expect(Page.Locator("#errorMsgMail")).ToHaveTextAsync("Invalid email");
            await Expect(Page.Locator("#errorMsgPwd")).ToHaveTextAsync("Invalid Password");

        }

        [Test]
        public async Task OpenTaskPlannerSmokeCheck()
        {
            var loginPage = new LoginPage(Page);
            var taskPlannerPage = new TaskPlannerPage(Page);

            await RegisterAccount();
            await loginPage.GoToNextPageAsync();
            await Expect(Page.Locator("#taskPlanner")).ToHaveTextAsync("Task Planner");
            await taskPlannerPage.ThereIsAnAddTaskButtonAsync();

        }

    }
}
