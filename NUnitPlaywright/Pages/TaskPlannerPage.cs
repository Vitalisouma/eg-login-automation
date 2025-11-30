using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitPlaywright.Pages
{
    public class TaskPlannerPage
    {
        private readonly IPage _page;
        private readonly ILocator _pageHeadingLabel;
        private readonly ILocator _enterTaskInput;
        private readonly ILocator _addTaskButton;
        private readonly ILocator _previousButtton;
        private readonly ILocator _finishButtton;

        public TaskPlannerPage(IPage page)
        {
            _page = page;
            _pageHeadingLabel = page.Locator("#taskPlanner");
            _enterTaskInput = page.Locator("#newTask");
            _addTaskButton = page.Locator("#newTask"); 

            _previousButtton = page.Locator("#prevButton"); ;
            _finishButtton = page.Locator("#nextButton"); ;
        }


        // Verify the page Heading is visible on the page
        public async Task HeadingIsVisibleAsync()
        {         
        await _pageHeadingLabel.IsVisibleAsync();
        }


        // Verify the Enter Task field is present on the page
        public async Task EnterTaskFieldIsPresentAsync()
        {
            await _enterTaskInput.IsVisibleAsync();
        }


        // Verify the Add Task button is present on the page
        public async Task AddTaskButtonIsPresentAsync()
        {
            await _addTaskButton.IsVisibleAsync();
        }


        // Verify the Previous button is present on the page
        public async Task PreviousButtonIsPresentAsync()
        {
            await _finishButtton.IsVisibleAsync();
        }


        // Verify the Finish button is present on the page
        public async Task FinishButtonIsPresentAsync()
        {
            await _finishButtton.IsVisibleAsync();
        }

    }

}