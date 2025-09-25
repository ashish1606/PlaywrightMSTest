using Playwright_CSharp.Constants;
using Playwright_CSharp.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Allure.Net.Commons;
using Allure.Commons;

namespace Playwright_CSharp.Tests
{
    [TestClass]
   
    public class LoginPageTest : BaseTest
    {
       // private static AllureLifecycle allure=AllureLifecycle.Instance;

        [TestMethod]
        [Description("Verify user with valid login credentials can login to the application successfully")]
        
        public async Task LoginSuccessfulValidation()
        {
            LoginPage loginPage = new LoginPage(page);
            await loginPage.LoginToTheApplication(ApplicationConstants.VALID_USER, ApplicationConstants.VALID_PASSWORD);
            await new HomePage(page).VerifyProductText();
        }

        [TestMethod]
        [Description("Verify user with invaild credentials cannot login to the application")]
        public async Task LoginUnSuccessfulValidation()
        {
            LoginPage loginPage = new LoginPage(page);
            await loginPage.LoginToTheApplication(ApplicationConstants.VALID_USER, ApplicationConstants.INVALID_PASSWORD);
            await loginPage.VerifyUserNameAndPasswordDoNotMatchText();

        }
        [TestMethod]
        [Description("Verify locked out user cannot login to the application")]
        public async Task LokedUserSuccessfulValidation()
        {
            LoginPage loginPage = new LoginPage(page);
            await loginPage.LoginToTheApplication(ApplicationConstants.LOCKED_OUT_USER, ApplicationConstants.VALID_PASSWORD);
            await loginPage.VerifyLockedOutUserWarningText();
        }
    }
}
