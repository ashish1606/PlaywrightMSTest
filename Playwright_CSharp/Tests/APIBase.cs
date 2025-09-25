using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Playwright_CSharp.Tests
{
    [TestClass]
    public class APIBase
    {

        protected IAPIRequestContext ApiContext;
        protected string BaseUrl;

        [TestInitialize]
        public async Task Initialize()
        {
            
            var playwright=await Playwright.CreateAsync();
            ApiContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
            {
                ExtraHTTPHeaders = new Dictionary<string, string>
                {
                    {"Accept","application/json" }
                }
            });

        }

        [TestCleanup]
        public async Task Cleanup()
        {
            await ApiContext.DisposeAsync();
        }
        public class Config
        {
            public string BaseURL { get; set; }
        }
    }
}
