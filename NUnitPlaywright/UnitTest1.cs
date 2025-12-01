using Microsoft.Playwright;
using NUnitPlaywright.Pages;
using static System.Net.Mime.MediaTypeNames;

namespace NUnitPlaywright
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests : PageTest
    {
      
        public async Task RegisterAccount()
        {
            var RegistrationFormPage = new RegistrationFormPage(Page); // Use the provided 'Page' property

            await RegistrationFormPage.GotoAsync();
            await RegistrationFormPage.RegisterAsync("John Smith", "Register@yahoo.co.uk");
            await Expect(Page).ToHaveTitleAsync("Login Page");
        }
        

        [Test] // Test 1: Valid Test for successful login with valid credentials
        public async Task SuccessfulLoginTest()
        {
            // Go to the app, register and login with valid credentials
            var loginPage = new LoginPage(Page); 
            await RegisterAccount();
            await loginPage.LoginAsync("RegisteredEmail@yahoo.co.uk", "Boxing2012@");

            // Assertions to verify successful login
            await loginPage.LoginSuccessAsync();
            await Expect(Page.Locator("#errorMsgMail")).ToHaveTextAsync("Valid Email"); 
            await Expect(Page.GetByText("Valid Password")).ToBeVisibleAsync(); 
        }


        [Test] // Test 2: Valid Test for show/hide password functionality
        public async Task ShowHidePassword()
        {
            // Go to the app and register 
            var loginPage = new LoginPage(Page); // Use the provided 'Page' property
            await RegisterAccount();

            // Enter email and password, then click Show/Hide password checkbox 
            await loginPage.ShowHidePasswordAsync("RegisteredEmail@yahoo.co.uk", "Boxing2012@");

            // Assertions to verify password visibility toggling
            await Expect(Page.Locator("#password")).ToHaveValueAsync("Boxing2012@");     
        }


        [Test]  // Test 3: Invalid Test for login with an incomplete email
        public async Task InvalidLoginIncompleteEmail()
        {
            // Go to the app, register and login with an incomplete email in format
            var loginPage = new LoginPage(Page);
            await RegisterAccount();
            await loginPage.LoginAsync("incomplete@", "Boxing2020@"); //Rule 3 for emails: After @, must have one or more alphanumeric segments separated by dots or hyphens

            // Assertions to verify error messages for invalid email format
            await Expect(Page.Locator("#errorMsgMail")).ToHaveTextAsync("Invalid Email"); // This test passes but the error message is wrong ("Valid Password")
            await Expect(Page.Locator("#errorMsgPwd")).ToBeHiddenAsync();
        }


        [Test] // Test 4: Invalid Test for email starting with a number
        public async Task InvalidLoginEmailStartsWithNumber()
        {
            // Go to the app, register and login with an email starting with a number
            var loginPage = new LoginPage(Page); 
            await RegisterAccount();
            await loginPage.LoginAsync("3vitalis@yahoo.co.uk", "Boxing2020@"); //Rule 1 Starts with one or more alphabetic characters (a–z, A–Z). Issued raised on Hithub issues

            // Assertions to verify error messages for invalid email format 
            await Expect(Page.Locator("#errorMsgMail")).ToHaveTextAsync("Invalid Email"); // Defect found. Issue 2 raised on Github issues
            await Expect(Page.Locator("#errorMsgPwd")).ToBeHiddenAsync();
        }


        [Test] // Test 5: Invalid Test for email without a dot before the TLD
        public async Task InvalidLoginEmailHasNoDot()
        {
            var loginPage = new LoginPage(Page); 
            await RegisterAccount();
            await loginPage.LoginAsync("nodotbeforetld@gmailcom", "Boxing2020@"); //Rule 4: Must include a dot before the TLD.
            await Expect(Page.Locator("#errorMsgMail")).ToHaveTextAsync("Invalid Email"); // This test passes but the error message is wrong ("Valid Password") Issue #1 raised on Github issues  
            await Expect(Page.Locator("#errorMsgPwd")).ToBeHiddenAsync();
        }


        [Test] // Test 6: Invalid Test for password with less than 8 characters
        public async Task InvalidLogin7CharacterPassword()
        {
            var loginPage = new LoginPage(Page);
            await RegisterAccount();

            await loginPage.LoginAsync("vitalis.ouma@yahoo.co.uk", "Box202@"); // Password is less than 8 characters
            await Expect(Page.Locator("#errorMsgMail")).ToHaveTextAsync("Valid Email");  // Mismatch raised on Github issues. 
            await Expect(Page.Locator("#errorMsgPwd")).ToHaveTextAsync("Invalid Password"); //Issue 7 raised on Github issues
        }


        [Test] // Test 7: Invalid Test for password with no uppercase letter
        public async Task InvalidLoginPasswordHasNoUppercaseLetter()
        {
            var loginPage = new LoginPage(Page); 
            await RegisterAccount();

            await loginPage.LoginAsync("vitalis.ouma@yahoo.co.uk", "boxing2020@"); // Password has no uppercase letter
            await Expect(Page.Locator("#errorMsgMail")).ToHaveTextAsync("Valid Email");  
            await Expect(Page.Locator("#errorMsgPwd")).ToHaveTextAsync("Invalid Password"); // Defect found! Issue 4 raised on Github issues
        }


        [Test] // Test 8: A smoke check that opens the Task Planner 
        public async Task OpenTaskPlannerSmokeCheck()
        {
            var loginPage = new LoginPage(Page);
            var taskPlannerPage = new TaskPlannerPage(Page);

            await RegisterAccount();
            await loginPage.GoToNextPageAsync();
            await Expect(Page.Locator("#taskPlanner")).ToContainTextAsync("Task Planner");
            await taskPlannerPage.AddTaskButtonIsPresentAsync();
        }

                // Extra tests for invalid cases
        [Test] // Test 9: Invalid Test for password with no digit 
        public async Task InvalidLoginPasswordHasNoDigit()
        {
            var loginPage = new LoginPage(Page);
            await RegisterAccount();

            await loginPage.LoginAsync("vitalis.ouma@yahoo.co.uk", "boxingTennis"); // Password has no digit.  
            await Expect(Page.Locator("#errorMsgMail")).ToHaveTextAsync("Vaild Email");   // vaild instead of valid. Issue 5 raised on Github issues
            await Expect(Page.Locator("#errorMsgPwd")).ToHaveTextAsync("Invalid Password"); 
        }


        [Test] // Test 10: Invalid Test for empty email and password fields
        public async Task InvalidLoginEmptyEmailandPassword()
        {
            var loginPage = new LoginPage(Page); 
            await RegisterAccount();
            await loginPage.LoginAsync("", "");

            await Expect(Page.Locator("#errorMsgMail")).ToHaveTextAsync("Invalid email");
            await Expect(Page.Locator("#errorMsgPwd")).ToHaveTextAsync("Invalid Password");
        }

    }
}
