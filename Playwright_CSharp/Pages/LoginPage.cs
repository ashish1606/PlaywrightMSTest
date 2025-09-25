using FluentAssertions;
using Microsoft.Playwright;
using Playwright_CSharp.Constants;
using Playwright_CSharp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_CSharp.Pages
{
    public class LoginPage
    {
        private WebActions webActions;
        private IPage page;
        private readonly ILocator userNameInputBox;
        private readonly ILocator passwordInputBox;
        private readonly ILocator loginButton;
        private readonly ILocator userNameAndPasswordDoesNotMatchText;
        private readonly ILocator lockedUserWarningText;
        public LoginPage(IPage page)
        {
            this.page = page;
            webActions=new WebActions(page);
            userNameInputBox = page.Locator("//input[contains(@id,'user-name')]");
            passwordInputBox = page.Locator("//input[contains(@id,'password')]");
            loginButton = page.Locator("//input[contains(@id,'login-button')]");
            userNameAndPasswordDoesNotMatchText = page.Locator("//h3[text()='Epic sadface: Username and password do not match any user in this service']");
            lockedUserWarningText = page.Locator("//h3[text()='Epic sadface: Sorry, this user has been locked out.']");
        }

        public async Task LoginToTheApplication(string userName, string password)
        {
            //await webActions.WaitForElement(userNameInputBox);
            await webActions.InputText(userNameInputBox, userName);
            await webActions.InputText(passwordInputBox, password);
            await webActions.Click(loginButton);
        }

        public async Task VerifyUserNameAndPasswordDoNotMatchText()
        {

            string actualtext = await webActions.GetElementText(userNameAndPasswordDoesNotMatchText);
            Assert.AreEqual(actualtext, ApplicationConstants.USERNAME_PASSWORD_DO_NOT_MATCH_TEXT, "Text does not match");

        }

        public async Task VerifyLockedOutUserWarningText()
        {
            string actualtext = await webActions.GetElementText(lockedUserWarningText);
            Assert.AreEqual(actualtext, ApplicationConstants.LOCKED_USER_WARNING_TEXT, "Text does not match");
            

        }
    }
}
