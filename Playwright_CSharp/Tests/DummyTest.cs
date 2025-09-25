using Microsoft.Playwright;

namespace Playwright_CSharp.Tests
{
    [TestClass]
    public class DummyTest
    {
        [TestMethod]
        public async Task Test1()
        {

            var playwrightDriver = await Playwright.CreateAsync();
            var browser = await playwrightDriver.Chromium.LaunchAsync();
            var browserContext = await browser.NewContextAsync();
            var page = await browserContext.NewPageAsync();

            await page.GotoAsync("https://www.google.co.uk/");
        }
    }
}