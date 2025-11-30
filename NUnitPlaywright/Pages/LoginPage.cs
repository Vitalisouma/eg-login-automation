using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitPlaywright.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;
        private readonly ILocator _fullNameInput;
        private readonly ILocator _regMailInput;
        private readonly ILocator _startButton;

        private readonly ILocator _emailInput;
        private readonly ILocator _passwordInput;
        private readonly ILocator _showHideInput;
        private readonly ILocator _loginButton;

        private readonly ILocator _validEmailLabel;
        private readonly ILocator _validPasswordLabel;

        private readonly ILocator _nextButton;
        private readonly ILocator _previousButton;
        

        public LoginPage(IPage page)
        {
            _page = page;
            _fullNameInput = page.Locator("#candidateName");
            _regMailInput = page.Locator("#candidateMail");
            _startButton = page.Locator("#startButton");

            _emailInput = page.Locator("#email");
            _passwordInput = page.Locator("#password");
            _showHideInput = page.Locator("#showPassword");
            _loginButton = page.GetByRole(AriaRole.Button, new() { Name = "Login" });

            _validEmailLabel = page.Locator("#errorMsgMail");
            _validPasswordLabel = page.Locator("#errorMsgPwd");

            _nextButton = page.Locator("#nextButton"); // nextButton = page.GetByRole(AriaRole.Button, new() {  Name = "nextButton" });
            _previousButton = page.Locator("#prevButton");

        }

        // Open the html file to access the online app
        public async Task GotoAsync()
        {
            // Resolve absolute path and ensure the file exists in the test output folder
            string curDir = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(curDir, "QA_Task 1_updated_v4.html");
            string fullPath = Path.GetFullPath(filePath);

            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException($"Local test HTML not found. Ensure the file is copied to the test output directory: {fullPath}");
            }

            // Use Uri to produce a correctly encoded file:// URL (encodes spaces, #, etc.)
            string fileUrl = new Uri(fullPath).AbsoluteUri;
            await _page.GotoAsync(fileUrl);
        }


        // Register on the landing page of the html file
        public async Task RegisterAsync(string fullname, string mail)
        {
            await _fullNameInput.FillAsync(fullname);
            await _regMailInput.FillAsync(mail);
            // Ensure the button exists and is visible before clicking to avoid locator timeout
            await _startButton.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await _startButton.ClickAsync();
        }


        // Do login with email and password
        public async Task LoginAsync(string email, string password)
        {
            await _emailInput.FillAsync(email);
            await _passwordInput.FillAsync(password);
            await _loginButton.ClickAsync();
        }


        // check the Show/Hide checkbox
        public async Task ShowHidePasswordAsync(string email, string password)
        {
            await _emailInput.FillAsync(email);
            await _passwordInput.FillAsync(password);
            await _showHideInput.CheckAsync();
        }


        // On succesful log in, show valid email and password messages
        public async Task LoginSuccessAsync()
        {
            await _validEmailLabel.IsVisibleAsync();
            await _validPasswordLabel.IsVisibleAsync();
        }


        // Click Next to go to the  Task Planner page
        public async Task GoToNextPageAsync()
        {
            await _nextButton.ClickAsync();
        }

    }
}