
1. Project Title and Description: 
An assignment of a small POM-based project to automate the login flow.
Technologies Used: C# with Playwright, (NUNit, Github Actions, Node.js, .NET10.0)
      The POM Structure
    • This POM has been kept simple.  
      There are 3 Page Objects designed and the UnitTest1.cs which runs the tests.
      
    • 
    • 
    • 
    • 
    • 
    • 
2. Local Installation and Usage Instructions:
2.1 Get Visual Studio, Set Up Nunit and Playwright
    • Download and Install Visual Studio (VS) from Microsoft 
    • Open VS. On the top, Click Tools > Select ‘Nuget Package Manager’ >  Select ‘Manage Nuget Package for Solution’; to Open the Nuget Solution Manager
    • On the Nuget Solution Manager, on the top left, Click Browse. 
    • Go to the Search and install the following 6 packages
        ◦ Microsoft.Playwright, Microsoft.Playwright.Nunit, Microsoft.Playwright.TestAdapter
        ◦ Nunit, Nunit.Analyzers, NUnit3TestAdapter
2.2 Clone / Download the repository
    • Clone the repository for the project from the link provided  
    • Visit the link https://github.com/Vitalisouma/eg-login-automation
    • Click Code (In green) button and select ‘Open with Visual Studio, This opens the project directly in VS.
      Note: There is also an option to ‘Download ZIP’ your local which is handy if you haven’t already installed Visual Studio and the packages. 
    • Unzip the folder in a chosen directory. 
    • You can Open the file by either clicking the file from file explorer or open from within VS
    • From File Explorer, navigate to *\NunitPlaywright\NUnitPlaywright\NUnitPlaywright.csproj
    • Right Click the file. Select ‘Open With’ > ‘Microsoft Visual Studio’
    • From within VS, Click ‘File’ > ‘Open’ > Select ‘Project/Solution’
    • Navigate to where you unzipped the download from Github and click  NUnitPlaywright.csproj 
      The project is opened in VS and you will see project with the Solution Explorer on the right showing all the project folders and files.
















You can now see the whole projects structure.  Expand or click on the folders/files to see more about their contents.
3 Build and Run Tests
In the Solution explorer, Right Click on the project NunitPlaywright and select ‘Open in Terminal’
A power shell window will open at the bottom from where you can run commands.

It is important to install and update some pacgaes and  dependencies before Build and Run Tests.
Run these commands in sequence;
      run: npm init –yes    *>// To Initialize Node.js dependencies
      run: npm install  *>// To Install Node.js dependencies for LOCAL
      run: npm ci  *>// To Install Node.js dependencies for CI 
      run: npm install @playwright/test  *>// To Install Playwright Test library and functionalities
      run: npx playwright install –with-deps  *>// To Install Playwright browsers
    
To build the Auto – Tests, Type dotnet build in the powershell prompt and press enter.  You will see the build is successful

To Run the Auto Test,  Type dotnet test.  This will run the tests and dsplay output right here in the powershell window.  You will Test Summary at the bottom. 5 failed, 5 Passed etc.

You can also run the test to generate a Test report by dotnet test –logger “html”. This will generate a basic HTML test result report which will be saved in the TestResults folder in the Solution explorer.

You can also run and view Test results including Debugging (with Copilot) using the Test Explorer.
Go to the top Menu and click Test > Select ‘Test Explorer’

You can then scrutinize each test individually.  You can rerun test, debug, Ask Copilot, You can go to the code for the test etc.  Click here for more about Test Explorer here. 
Note:  You can Build solution and Run tests from the top Menu of VS from the respective options

3. CI Installation and Usage Instructions
      There is no need for any installations on the CI.
      Visit the public Github repository link provided  https://github.com/Vitalisouma/eg-login-automation 

The CI is setup accordingly, the project has been successfully pushed to this github repo.  A GitHub Actions  workflow (github/workflows/loginworkflow.yml) has been set up; running headless tests on every push/PR.
Workflow steps have been defined including one for generating Test report.  The steps are running fine except for the main one which is To run the Tests.  This is failing and trying to resolve it has gone in circles.  Therefore, I can not proceed beyond here at the moment. Amm working to resolve the issue.  The issues have been seemingly due to environmental differences, dependency mismatches, version and Powershell issues.

Nevertheless,  the CI still provides some meaningful insights on solving the assignment problem.
        ◦ You can view the workflow itself, and see the steps defined and actions prompted.
        ◦ You can see the POM structure as organized.  View the code for the 3 object pages and the UnittTest1.cs file which hosts and orchestrates the tests inlcuding assertions.
        ◦ You can view Issues raised from the manual task. These issues includes defects found by the auto tests running in Local.  There are 3 defects and at least 2 mismatches.
        ◦ There is also a folder for Test Results.
        ◦ You can view the README file.

4 Features and Issues
    • The project automates the following scenarios for login based on the assignment instructions;
    •  Valid Cases
        ◦ Test 1: Valid Test for successful login with valid credentials
        ◦ Test 2: Valid Test for show/hide password functionalit
    •  Invalid Cases
        ◦ Test 3: Invalid Test for login with an incomplete email
        ◦ Test 4: Invalid Test for email starting with a number
        ◦ Test 5: Invalid Test for email without a dot before the TLD
        ◦ Test 6: Invalid Test for password with less than 8 characters
        ◦ Test 7: Invalid Test for password with no uppercase letter
        ◦ Test 9: Invalid Test for password with no digit
        ◦ Test 10: Invalid Test for empty email and password fields
    •  A smoke check that opens Task Planner
        ◦ Test 8: A smoke check that opens the Task Planner
Issues/Bugs Summary
 Defects have been raised on Github issues.
 https://github.com/Vitalisouma/eg-login-automation/issues 
      There are intentional mismatches (Issues, 1,3,5) that have been detected hence there are some failing tests. These are mainly with field error messages. The issue being either a wrong error message has been thrown, there is a misspelling of a word or wrong words entirely.  These can be rectified to pass the tests if need be (.I.e. to have the CI passing on last commit). However, the automation also detects 3 actual defects (Issues 2,4,7) which flout email and password rules. Hence the last commit will still be failing on last commit until the issues are fixed.
      Note: Only Issue #6 answers the manual task (...to raise a focused bug report.) in the assignment.  The rest of the issues can be brought up to standards later.

