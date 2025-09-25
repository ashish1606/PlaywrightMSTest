using FluentAssertions;
using Microsoft.Playwright;
using Playwright_CSharp.Constants;
using Playwright_CSharp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_CSharp.Pages
{
    public class CheckoutPage
    {


        private IPage page;
        private WebActions webActions;
        private readonly ILocator checkoutButton;
        private readonly ILocator firstNameInputBox;
        private readonly ILocator lastNameInputBox;
        private readonly ILocator postalCodeInputBox;
        private readonly ILocator postalCodeWarningText;
        private readonly ILocator continueButton;
        private readonly ILocator finishButton;
        private readonly ILocator orderSuccessText;
        public CheckoutPage(IPage page)
        {
            this.page = page;
            webActions=new WebActions(page);
            checkoutButton = page.GetByText("Checkout");
            firstNameInputBox = page.GetByPlaceholder("First Name");
            lastNameInputBox = page.GetByPlaceholder("Last Name");
            postalCodeInputBox = page.GetByPlaceholder("Postal Code");
            //postalCodeWarningText = page.Locator("//h3[text()='Error: Postal Code is required']");
            postalCodeWarningText = page.GetByText("Error: Postal Code is required");
            continueButton = page.Locator("//input[contains(@id,'continue')]");
            finishButton = page.GetByText("Finish");
            orderSuccessText = page.Locator("//h2[contains(@class,'complete-header')]");

        }

        public async Task FillCheckOutInformation(string firstName, string lastName, string postCode)
        {
            await webActions.InputText(firstNameInputBox, firstName);
            await webActions.InputText(lastNameInputBox, lastName);
            await webActions.InputText(postalCodeInputBox, postCode);
        }

        public async Task ClickOnCheckoutButton()
        {
            await webActions.Click(checkoutButton);
        }

        public async Task ClickOnContinueButton()
        {
            await webActions.Click(continueButton);
        }

        public async Task ClickOnFinishButton()
        {
            await webActions.Click(finishButton);
        }

        public async Task VerifyOrderSuccessText()
        {
            string actualtext = await webActions.GetElementText(orderSuccessText);
            Assert.AreEqual(actualtext, ApplicationConstants.ORDER_SUCCESS_TEXT, "Text does not match");
        }

        public async Task VerifyPostCodeMandatoryWaningText()
        {

            string actualtext = await webActions.GetElementText(postalCodeWarningText);
            Assert.AreEqual(actualtext, ApplicationConstants.POSTALCODE_MANDATORY_TEXT, "Text does not match");
           
        }
    }
}
