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
    public class HomePage
    {
     
        private IPage page;
        private WebActions webActions;
        private readonly ILocator continueAsGuestButton;
        private readonly ILocator shoppingCartLink;
        private readonly ILocator addToCardButtonForBackPack;
        private readonly ILocator proudctText;


        public HomePage(IPage page)
        {
            this.page = page;
            webActions=new WebActions(page);
            shoppingCartLink = page.Locator("//a[contains(@class,'shopping_cart_link')]");
            addToCardButtonForBackPack = page.Locator("//button[contains(@id,'add-to-cart-sauce-labs-backpack')]");
            continueAsGuestButton = page.GetByText("Continue as guest");
            proudctText = page.GetByText("Products");

        }

        public async Task ClickOnAddToCardButtonForBackPack()
        {
            await webActions.Click(addToCardButtonForBackPack);
        }
        public async Task ClickOnShoppingCartLink()
        {
           await webActions.Click(shoppingCartLink);
        }

        public async Task VerifyProductText()
        {
            string actualtext = await webActions.GetElementText(proudctText);
            Assert.AreEqual(actualtext, ApplicationConstants.PRODUCT_TEXT, "Text does not match");
            
        }


        public async Task ClickOnContinueAsGuestButton()
        {

            await webActions.Click(continueAsGuestButton);

        }





        public Task<bool> IsContinueAsGuestButtonPresent()
        {
            try
            {
                Thread.Sleep(2000);
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return webActions.IsElementVisible(continueAsGuestButton);
        }
    }
}
