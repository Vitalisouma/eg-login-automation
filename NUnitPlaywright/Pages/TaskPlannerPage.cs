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
        private readonly ILocator _deleteTask1;
        private readonly ILocator _enterTaskInput;
        private readonly ILocator _addTaskButton;
        private readonly ILocator _previousButtton;
        private readonly ILocator _finishButtton;

        public TaskPlannerPage(IPage page)
        {
            _page = page;
            _pageHeadingLabel = page.Locator("#taskPlanner");
            _addTaskButton = page.Locator("#newTask"); ;

            _previousButtton = page.Locator("#prevButton"); ;
            _finishButtton = page.Locator("#nextButton"); ;

        }



        public async Task ThereIsAnAddTaskButtonAsync()
        {
            
        
        await _addTaskButton.IsVisibleAsync();
        }

    }

}