# # POM Based Login Project
 Project Title and Description: An assignment of a small POM-based project to automate the login flow .
    • Installation Instructions: These steps will be defined in the github/workflow.
    • Usage Instructions: How to use the project's features and functionalities. Examples or code snippets are highly beneficial here.
This is being Updated……

The CI is not running at the moment due to set up issues. This is being resolved.
Meanwhile you can go to the project/solution folder on github  and pull /export a local copy of the project and run locally.  
Run on Visual Studio. You can build from the Menu and also Test from the menu using Test Explorer. Alternatively, you can open the project in Terminal (Right click project in solution explorer > Open in Terminal.
Then use commands: dotnet build and dotnet test

    • Features: This POM has been kept simple.  
      
    • There are 3 Page Objects designed and the UnitTest1.cs which runs the tests.  
<img width="537" height="588" alt="Small POM for Login" src="https://github.com/user-attachments/assets/8efa73a4-ff0e-4045-9f14-da38da5f7874" />







    • The project automates the following scenarios for login based on the asignemnt instructions;
            ▪  Valid Cases
                • Test 1: Valid Test for successful login with valid credentials
                • Test 2: Valid Test for show/hide password functionality
            ▪  Invalid Cases
                • Test 3: Invalid Test for login with an incomplete email
                • Test 4: Invalid Test for email starting with a number
                • Test 5: Invalid Test for emaiil without a dot before the TLD
                • Test 6: Invalid Test for password with less than 8 characters
                • Test 7: Invalid Test for password with no uppercase letter
                • Test 9: Invalid Test for password with no digit
                • Test 10: Invalid Test for empty email and password fields
            ▪  A smoke check that opens Task Planner
                • Test 8: A smoke check that opens the Task Planner

    • Technologies Used: C# with Playwright, (NUNit, Github Actions, Node.js, .NET10.0)
    
    • Issues/Bugs:
      There are intentional mismatches (Issues, 1,3,5) that have been detected hence there are some failing tests. These are mainly with field error messages. The issue being either a wrong error message has been thrown, there is a misspelling of a word or wrong words entirely.  These can be rectified to pass the tests if need be (.I.e. to have the CI passing on last commit). However, the automation also detects 3 actual defects (Issues 2,4,7) which flout email and password rules. Hence the last commit will still be failing on last commit until the issues are fixed.
    • Note only Issue #6 answers the manual task (...to raise a foccused bug report.) in the assignment.  The rest of the issues can be brought up to standards later.
      



