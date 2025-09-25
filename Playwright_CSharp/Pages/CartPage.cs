using Microsoft.Playwright;
using Playwright_CSharp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playwright_CSharp.Pages
{
    public class CartPage
    {

        private WebActions webActions;
        private IPage page;
        private readonly ILocator checkoutButton;
        

        public CartPage(IPage page)
        {
            this.page = page;
            webActions=new WebActions(page);
            checkoutButton = page.GetByText("Checkout");
           
        }

        public async Task ClickOnCheckoutButton()
        {
           await webActions.Click(checkoutButton);
        }
    }
}
