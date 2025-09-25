using Playwright_CSharp.Constants;
using Playwright_CSharp.Pages;
using Playwright_CSharp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_CSharp.Tests
{
    [TestClass]
    
    public class CheckoutPageTest : BaseTest
    {
        [TestMethod]
        [Description("Verify valid user can place the order successfully")]
        public async Task OrderSuccessfulValidation()
        {
            await new LoginPage(page).LoginToTheApplication(ApplicationConstants.VALID_USER, ApplicationConstants.VALID_PASSWORD);
            await new HomePage(page).ClickOnAddToCardButtonForBackPack();
            await new HomePage(page).ClickOnShoppingCartLink();
            CheckoutPage checkoutPage = new CheckoutPage(page);
            await checkoutPage.ClickOnCheckoutButton();
            await checkoutPage.FillCheckOutInformation("Ross", "Taylor", "BN16YL");
            await checkoutPage.ClickOnContinueButton();
            await checkoutPage.ClickOnFinishButton();
            await checkoutPage.VerifyOrderSuccessText();

        }

        [TestMethod]
        [Description("Verify postal code is a mandatory field while placing an order")]
        public async Task PostalCodeMadatoryFieldValidation()
        {
            await new LoginPage(page).LoginToTheApplication(ApplicationConstants.VALID_USER, ApplicationConstants.VALID_PASSWORD);
            await new HomePage(page).ClickOnAddToCardButtonForBackPack();
            await new HomePage(page).ClickOnShoppingCartLink();
            CheckoutPage checkoutPage = new CheckoutPage(page);
            await checkoutPage.ClickOnCheckoutButton();
            await checkoutPage.FillCheckOutInformation("Ross", "Taylor", "");
            await checkoutPage.ClickOnContinueButton();
            await checkoutPage.VerifyPostCodeMandatoryWaningText();
        }
    }

}

