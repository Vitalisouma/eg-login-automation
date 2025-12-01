using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitPlaywright.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;

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
          
            _emailInput = page.Locator("#email");
            _passwordInput = page.Locator("#password");
            _showHideInput = page.Locator("#showPassword");
            _loginButton = page.GetByRole(AriaRole.Button, new() { Name = "Login" });

            _validEmailLabel = page.Locator("#errorMsgMail");
            _validPasswordLabel = page.Locator("#errorMsgPwd");

            _nextButton = page.Locator("#nextButton"); // nextButton = page.GetByRole(AriaRole.Button, new() {  Name = "nextButton" });
            _previousButton = page.Locator("#prevButton");

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


        // Click previous button to go back to Previous page
        public async Task GoToPreviousPageAsync()
        {
            await _previousButton.ClickAsync();
        }


        // Click Next to go to the  Task Planner page
        public async Task GoToNextPageAsync()
        {
            await _nextButton.ClickAsync();
        }

        
    }
}