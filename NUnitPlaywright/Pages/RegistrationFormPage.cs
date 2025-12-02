using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitPlaywright.Pages
{
    public class RegistrationFormPage
    {
        private readonly IPage _page;
        private readonly ILocator _pageHeadingLabel;
        private readonly ILocator _fullNameInput;
        private readonly ILocator _regMailInput;
        private readonly ILocator _startButton;


        public RegistrationFormPage(IPage page)
        {
            _page = page;
            _pageHeadingLabel = page.Locator("#registrationFrorm");
            _fullNameInput = page.Locator("#candidateName");
            _regMailInput = page.Locator("#candidateMail");
            _startButton = page.Locator("#startButton");

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
        

        // Register on the landing page of the html file.
        public async Task RegisterAsync(string fullname, string mail) 
        {
            await _fullNameInput.FillAsync(fullname);
            await _regMailInput.FillAsync(mail);
            // Ensure the button exists and is visible before clicking to avoid locator timeout
            await _startButton.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await _startButton.ClickAsync();
        }


        // Verify the page Heading is visible on the page
        public async Task HeadingIsVisibleAsync()
        {
            await _pageHeadingLabel.IsVisibleAsync();
        }
    }
}