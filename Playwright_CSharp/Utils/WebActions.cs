using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_CSharp.Utils
{
    public class WebActions
    {
        private readonly IPage page ;
        private readonly int defaultTimeout;
        public WebActions(IPage page, int defaultTime=30000)
        {
            this.page = page ;
            this.defaultTimeout = defaultTime ;

        }

        // Click Element
        public async Task Click(ILocator locator)
        {
      
            await locator.ClickAsync(new LocatorClickOptions { Timeout = defaultTimeout });


        }
        

        //Fill Input Box
        public async Task InputText(ILocator locator, string inputValue)
        {
     
            await locator.FillAsync(inputValue,new LocatorFillOptions { Timeout=defaultTimeout});

        }

        // Get Element Text
        public async Task<string> GetElementText(ILocator locator)
        {
         
            var text = await locator.InnerTextAsync(new LocatorInnerTextOptions { Timeout = defaultTimeout });
            return text;

        }

        // Wait For Element
        public async Task WaitForElement(ILocator locator)
        {
            await locator.WaitForAsync(new LocatorWaitForOptions {  Timeout = defaultTimeout });
        }


        // Check If Element is Visible
        public async Task<bool> IsElementVisible(ILocator locator)
        {
      
            return await locator.IsVisibleAsync();

        }

        public void Wait()
        {
            Thread.Sleep(2000);
        }


        //Select Dropdown by Index
        public static async Task<string> SelectDropDownByIndex(ILocator dropdownLocator, int index)
        {

            // Ensure dropdown exists

            if (dropdownLocator == null)
            {
                throw new ArgumentNullException(nameof(dropdownLocator), "Dropdown locator cannot be null");

            }
            var options = await dropdownLocator.Locator("option").ElementHandlesAsync();

            // Validate the index

            if (index < 0 || index >= options.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Index{index} is out of range. Dropdown has {options.Count} options");
            }


            var value = await options[index].GetAttributeAsync("value");

            if (string.IsNullOrEmpty(value))
            {
                throw new Exception($"option at this {index} does not have a valid value attributes.");
            }

            await dropdownLocator.SelectOptionAsync(new SelectOptionValue { Value = value });

            return value;


        }

        // Select Dropdown By Text

        public static async Task SelectDropdownByValue(ILocator locator, string value)
        {
            await locator.SelectOptionAsync(new SelectOptionValue { Value= value });
        }

       

        // Hover on Element

        public async Task Hover(ILocator locator)
        {
            await locator.HoverAsync(new LocatorHoverOptions { Timeout = defaultTimeout });
        }


    }

}

